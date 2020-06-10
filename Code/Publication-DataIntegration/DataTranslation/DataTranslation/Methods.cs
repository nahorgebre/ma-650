using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace DataTranslation
{
    public class generalMethods
    {
        public static List<Publication> createList(int begin, int end, List<Publication> source)
        {
            List<Publication> genes_list = new List<Publication>();
            for (int i = begin; i < end; i++)
            {
                genes_list.Add(source[i]);
            }
            return genes_list;
        }

        public static void createXml(List<Publication> publications_list, string targetFileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Publications));
            TextWriter writer = new StreamWriter(targetFileName + ".xml");

            Publications publications = new Publications();
            publications.publication = publications_list;
            serializer.Serialize(writer, publications);
            writer.Close();
        }

        public void validateXmlFile(string filepath)
        {
            Console.WriteLine("Start validating XML file: " + filepath);
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                string path = System.Environment.CurrentDirectory.Substring(0, System.Environment.CurrentDirectory.LastIndexOf("\\"));
                path = path.Substring(0, path.LastIndexOf("\\"));
                settings.Schemas.Add("http://www.w3.org/2001/XMLSchema", path + @"\targetSchema\heart.xsd");
                settings.ValidationType = ValidationType.Schema;

                XmlReader reader = XmlReader.Create(filepath, settings);
                XmlDocument document = new XmlDocument();
                document.Load(reader);

                ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);

                document.Validate(eventHandler);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine("Error: {0}", e.Message);
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("Warning: {0}", e.Message);
                    break;
                default:
                    Console.WriteLine("XML file does fulfill the requirements of the Schema.");
                    break;
            }
        }

        public static string getProjectDirectory()
        {
            string path = Environment.CurrentDirectory.Substring(0, System.Environment.CurrentDirectory.LastIndexOf("\\"));
            path = path.Substring(0, path.LastIndexOf("\\"));
            return path;
        }
    }

    public class pubLinksMethods
    {
        public static void pubLinks_dt()
        {
            for (int year = 1980; year < 2019; year++)
            {
                List<Publication> pulications_list = new List<Publication>();

                string sourceFileName = "RePORTER_PUBLNK_C_" + year + ".csv";

                using (var reader = new StreamReader(generalMethods.getProjectDirectory() + @"\data\Input\Publication-Links\" + sourceFileName))
                {
                    reader.ReadLine();
                    int counter = 1;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        String[] values = line.Split(',');

                        Publication publication = new Publication();
                        publication.recordId = "RePORTER_PUBLNK_C_" + year + "_" + counter;
                        publication.pmid = values[0];

                        List<Project> projects_list = new List<Project>();
                        Project project = new Project();
                        project.projectId = values[1];
                        projects_list.Add(project);

                        publication.projects = projects_list;

                        pulications_list.Add(publication);

                        counter++;
                    }
                }

                string outputFileName = "RePORTER_PUBLNK_C_" + year + "_dt";

                generalMethods.createXml(pulications_list, @"Publication-Links\" + outputFileName);
            }
        }
    }

    public class pubMentionsMethods
    {
        public static void pubMentions_dt() 
        {
            var pmidHashSet = getPmids();
            Console.WriteLine("Number of PMIDs: " + pmidHashSet.Count());
            List<Publication> pulications_list = new List<Publication>();
            Console.WriteLine("Beginning - Number of publications: " + pulications_list.Count);

            using (var reader = new StreamReader(generalMethods.getProjectDirectory() + @"\data\Input\Publication-Mentions\gene2pubtatorcentral.tsv"))
            {
                Console.WriteLine(File.ReadLines(generalMethods.getProjectDirectory() + @"\data\Input\Publication-Mentions\gene2pubtatorcentral.tsv").Count());

                reader.ReadLine();
                int counter = 1;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split('\t');
                 
                    if(pmidHashSet.Contains(values[0]))
                    {
                        if (values[3].Contains('|'))
                        {
                            String[] values3 = values[3].Split('|');
                            foreach (string value in values3)
                            {
                                pulications_list.Add(getPublication(counter, values, value));
                                counter++;
                            }
                        }
                        else
                        {
                            Publication publication = new Publication();
                            publication.recordId = "gene2pubtatorcentral_" + counter;
                            publication.pmid = values[0];

                            List<Gene> genes_list = new List<Gene>();
                            Gene gene = new Gene();
                            gene.ncbiId = values[2];

                            List<GeneName> geneNames_list = new List<GeneName>();
                            GeneName geneName = new GeneName();
                            geneName.geneName = values[3];
                            geneNames_list.Add(geneName);

                            gene.geneNames = geneNames_list;

                            genes_list.Add(gene);
                            publication.genes = genes_list;

                            counter++;
                        }
                    }
                }
            }
            Console.WriteLine("Ending - Number of publications: " + pulications_list.Count);
            generalMethods.createXml(pulications_list, @"Publication-Mentions\gene2pubtatorcentral_dt");
        }

        public static Publication getPublication(int counter, String[] values, string value)
        {
            Publication publication = new Publication();
            publication.recordId = "gene2pubtatorcentral_" + counter;
            publication.pmid = values[0];

            List<Gene> genes_list = new List<Gene>();
            Gene gene = new Gene();
            gene.ncbiId = values[2];

            List<GeneName> geneNames_list = new List<GeneName>();
            GeneName geneName = new GeneName();
            geneName.geneName = value;
            geneNames_list.Add(geneName);

            gene.geneNames = geneNames_list;

            genes_list.Add(gene);
            publication.genes = genes_list;

            return publication;
        }

        public static HashSet<string> getPmids()
        {
            var pmidHashSet = new HashSet<string>();
            for (int year = 1980; year < 2019; year++)
            {
                string sourceFileName = "RePORTER_PUBLNK_C_" + year + ".csv";
                year++;
                using (var reader = new StreamReader(generalMethods.getProjectDirectory() + @"\data\Input\Publication-Links\" + sourceFileName))
                {
                    reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        String[] values = line.Split(',');
                        pmidHashSet.Add(values[0]);
                    }
                }
            }
            return pmidHashSet;
        }
    }
}