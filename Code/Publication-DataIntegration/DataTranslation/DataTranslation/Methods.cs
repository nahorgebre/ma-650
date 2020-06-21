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
            for (int year = 1985; year <= 2016; year++)
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
                        publication.id = "RePORTER_PUBLNK_C_" + year + "_" + counter;
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

                            //publication.id = "gene2pubtatorcentral_" + counter;
                            publication.id = getRecordId(counter);
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
            createFiles(pulications_list);
            generalMethods.createXml(pulications_list, @"Publication-Mentions\gene2pubtatorcentral_dt");
        }

        public static string getRecordId(int counter, string )
        {
            // ---X---X---
            string countAd = counter.ToString();
            if (countAd.Length == 1)
            {
                countAd += "--------";
            } 
            else if (countAd.Length == 2)
            {
                countAd += "-------";
            }
            else if (countAd.Length == 3)
            {
                countAd += "------";
            }
            else if (countAd.Length == 4)
            {
                countAd += "-----";
            }
            else if (countAd.Length == 5)
            {
                countAd += "----";
            }
            else if (countAd.Length == 6)
            {
                countAd += "---";
            }
            else if (countAd.Length == 7)
            {
                countAd += "--";
            }
            else if (countAd.Length == 8)
            {
                countAd += "-";
            }
            string recordId = "gene2pubtatorcentral_" + countAd;
            return recordId;
        }

        public static void createFiles(List<Publication> pulications_list)
        {
            int length = pulications_list.Count;
            int partition = length / 25;

            List<Publication> partition_list_1 = new List<Publication>();
            partition_list_1 = generalMethods.createList(0, partition, pulications_list);
            generalMethods.createXml(partition_list_1, @"Publication-Mentions\gene2pubtatorcentral_1_dt");

            List<Publication> partition_list_2 = new List<Publication>();
            partition_list_2 = generalMethods.createList(partition, partition * 2, pulications_list);
            generalMethods.createXml(partition_list_2, @"Publication-Mentions\gene2pubtatorcentral_2_dt");

            List<Publication> partition_list_3 = new List<Publication>();
            partition_list_3 = generalMethods.createList(partition * 2, partition * 3, pulications_list);
            generalMethods.createXml(partition_list_3, @"Publication-Mentions\gene2pubtatorcentral_3_dt");

            List<Publication> partition_list_4 = new List<Publication>();
            partition_list_4 = generalMethods.createList(partition * 3, partition * 4, pulications_list);
            generalMethods.createXml(partition_list_4, @"Publication-Mentions\gene2pubtatorcentral_4_dt");

            List<Publication> partition_list_5 = new List<Publication>();
            partition_list_5 = generalMethods.createList(partition * 4, partition * 5, pulications_list);
            generalMethods.createXml(partition_list_5, @"Publication-Mentions\gene2pubtatorcentral_5_dt");

            List<Publication> partition_list_6 = new List<Publication>();
            partition_list_6 = generalMethods.createList(partition * 5, partition * 6, pulications_list);
            generalMethods.createXml(partition_list_6, @"Publication-Mentions\gene2pubtatorcentral_6_dt");

            List<Publication> partition_list_7 = new List<Publication>();
            partition_list_7 = generalMethods.createList(partition * 6, partition * 7, pulications_list);
            generalMethods.createXml(partition_list_7, @"Publication-Mentions\gene2pubtatorcentral_7_dt");

            List<Publication> partition_list_8 = new List<Publication>();
            partition_list_8 = generalMethods.createList(partition * 7, partition * 8, pulications_list);
            generalMethods.createXml(partition_list_8, @"Publication-Mentions\gene2pubtatorcentral_8_dt");

            List<Publication> partition_list_9 = new List<Publication>();
            partition_list_9 = generalMethods.createList(partition * 8, partition * 9, pulications_list);
            generalMethods.createXml(partition_list_9, @"Publication-Mentions\gene2pubtatorcentral_9_dt");

            List<Publication> partition_list_10 = new List<Publication>();
            partition_list_10 = generalMethods.createList(partition * 9, partition * 10, pulications_list);
            generalMethods.createXml(partition_list_10, @"Publication-Mentions\gene2pubtatorcentral_10_dt");

            List<Publication> partition_list_11 = new List<Publication>();
            partition_list_11 = generalMethods.createList(partition * 10, partition * 11, pulications_list);
            generalMethods.createXml(partition_list_11, @"Publication-Mentions\gene2pubtatorcentral_11_dt");

            List<Publication> partition_list_12 = new List<Publication>();
            partition_list_12 = generalMethods.createList(partition * 11, partition * 12, pulications_list);
            generalMethods.createXml(partition_list_12, @"Publication-Mentions\gene2pubtatorcentral_12_dt");

            List<Publication> partition_list_13 = new List<Publication>();
            partition_list_13 = generalMethods.createList(partition * 12, partition * 13, pulications_list);
            generalMethods.createXml(partition_list_13, @"Publication-Mentions\gene2pubtatorcentral_13_dt");

            List<Publication> partition_list_14 = new List<Publication>();
            partition_list_14 = generalMethods.createList(partition * 13, partition * 14, pulications_list);
            generalMethods.createXml(partition_list_14, @"Publication-Mentions\gene2pubtatorcentral_14_dt");

            List<Publication> partition_list_15 = new List<Publication>();
            partition_list_15 = generalMethods.createList(partition * 14, partition * 15, pulications_list);
            generalMethods.createXml(partition_list_15, @"Publication-Mentions\gene2pubtatorcentral_15_dt");

            List<Publication> partition_list_16 = new List<Publication>();
            partition_list_16 = generalMethods.createList(partition * 15, partition * 16, pulications_list);
            generalMethods.createXml(partition_list_16, @"Publication-Mentions\gene2pubtatorcentral_16_dt");

            List<Publication> partition_list_17 = new List<Publication>();
            partition_list_17 = generalMethods.createList(partition * 16, partition * 17, pulications_list);
            generalMethods.createXml(partition_list_17, @"Publication-Mentions\gene2pubtatorcentral_17_dt");

            List<Publication> partition_list_18 = new List<Publication>();
            partition_list_18 = generalMethods.createList(partition * 17, partition * 18, pulications_list);
            generalMethods.createXml(partition_list_18, @"Publication-Mentions\gene2pubtatorcentral_18_dt");

            List<Publication> partition_list_19 = new List<Publication>();
            partition_list_19 = generalMethods.createList(partition * 18, partition * 19, pulications_list);
            generalMethods.createXml(partition_list_19, @"Publication-Mentions\gene2pubtatorcentral_19_dt");

            List<Publication> partition_list_20 = new List<Publication>();
            partition_list_20 = generalMethods.createList(partition * 19, partition * 20, pulications_list);
            generalMethods.createXml(partition_list_20, @"Publication-Mentions\gene2pubtatorcentral_20_dt");

            List<Publication> partition_list_21 = new List<Publication>();
            partition_list_21 = generalMethods.createList(partition * 20, partition * 21, pulications_list);
            generalMethods.createXml(partition_list_21, @"Publication-Mentions\gene2pubtatorcentral_21_dt");

            List<Publication> partition_list_22 = new List<Publication>();
            partition_list_22 = generalMethods.createList(partition * 21, partition * 22, pulications_list);
            generalMethods.createXml(partition_list_22, @"Publication-Mentions\gene2pubtatorcentral_22_dt");

            List<Publication> partition_list_23 = new List<Publication>();
            partition_list_23 = generalMethods.createList(partition * 22, partition * 23, pulications_list);
            generalMethods.createXml(partition_list_23, @"Publication-Mentions\gene2pubtatorcentral_23_dt");

            List<Publication> partition_list_24 = new List<Publication>();
            partition_list_24 = generalMethods.createList(partition * 23, partition * 24, pulications_list);
            generalMethods.createXml(partition_list_24, @"Publication-Mentions\gene2pubtatorcentral_24_dt");

            List<Publication> partition_list_25 = new List<Publication>();
            partition_list_25 = generalMethods.createList(partition * 24, partition * 25, pulications_list);
            generalMethods.createXml(partition_list_25, @"Publication-Mentions\gene2pubtatorcentral_25_dt");

        }

        public static Publication getPublication(int counter, String[] values, string value)
        {
            Publication publication = new Publication();
            //publication.id = "gene2pubtatorcentral_" + counter;
            publication.id = getRecordId(counter);
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
            for (int year = 1985; year <= 2016; year++)
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