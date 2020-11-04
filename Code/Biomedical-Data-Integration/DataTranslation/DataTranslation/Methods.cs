using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace DataTranslation
{

    public class Methods
    {

        public static void createXml(List<Gene> gene_list, string fileName, string directory)
        {

            Console.WriteLine("Create Xml: " + fileName);

            Console.WriteLine("Count: " + gene_list.Count);

            Directory.CreateDirectory(string.Format("{0}/{1}", Environment.CurrentDirectory, directory));

            XmlSerializer serializer = new XmlSerializer(typeof(Genes));
            TextWriter writer = new StreamWriter(string.Format("{0}/{1}/{2}", Environment.CurrentDirectory, directory, fileName));

            Genes genes = new Genes();
            genes.gene = gene_list;
            serializer.Serialize(writer, genes);
            writer.Close();

            Console.WriteLine(string.Format("{0}/{1}/{2}", Environment.CurrentDirectory, directory, fileName));

        }

        public static void createTsv(List<Gene> gene_list, string fileName, string directory)
        {

            Console.WriteLine("TSV: " + fileName);

            string gsFileName = string.Format("{0}/{1}/{2}", Environment.CurrentDirectory, directory, fileName);
            var delimiter = "\t";

            using (StreamWriter sw = new StreamWriter(gsFileName)) 
            {
           
                List<string> firstLineContent = new List<string>()
                {
                    "recordId",
                    "ensemblId",
                    "ncbiId",
                    "geneName",
                    "pmId"
                };
                var firstLine = string.Join(delimiter, firstLineContent);
                sw.WriteLine(firstLine);

                foreach (Gene item in gene_list)
                {

                    string recordId = "NaN";
                    if (item.recordId != null)
                    {

                        recordId = item.recordId.Trim();

                    }

                    string ensemblId = "NaN";
                    if (item.ensemblId != null)
                    {

                        ensemblId = item.ensemblId.Trim();

                    }

                    string ncbiId = "NaN";
                    if (item.ncbiId != null)
                    {

                        ncbiId = item.ncbiId.Trim();

                    }

                    string geneName = "NaN";
                    if (item.geneNames != null)
                    {

                        if (item.geneNames[0].name != null)
                        {

                            geneName = item.geneNames[0].name.Trim();
                            Console.WriteLine(geneName);

                        }

                    }

                    string pmid = "NaN";
                    if (item.publicationMentions != null)
                    {

                        if (item.publicationMentions[0].pmId != null)
                        {

                            pmid = item.publicationMentions[0].pmId.Trim();

                        }

                    }

                    List<string> lineContent = new List<string>()
                    {
                        recordId,
                        ensemblId,
                        ncbiId,
                        geneName,
                        pmid
                    };
                    var line = string.Join(delimiter, lineContent);
                    sw.WriteLine(line);

                }

            }

        }

        public void validateXmlFile(string filepath)
        {

            Console.WriteLine("Start validating XML file: " + filepath);

            try
            {

                XmlReaderSettings settings = new XmlReaderSettings();
                string path = System.Environment.CurrentDirectory.Substring(0, System.Environment.CurrentDirectory.LastIndexOf("\\"));
                path = path.Substring(0, path.LastIndexOf("\\"));
                settings.Schemas.Add("http://www.w3.org/2001/XMLSchema", path + "/targetSchema/heart.xsd");
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

    }

}