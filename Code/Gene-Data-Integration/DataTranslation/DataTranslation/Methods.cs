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
        public static List<Gene> createList(int begin, int end, List<Gene> source)
        {
            List<Gene> genes_list = new List<Gene>();
            for (int i = begin; i < end; i++)
            {
                genes_list.Add(source[i]);
            }
            return genes_list;
        }

        public static void createXml(List<Gene> gene_list, string fileName, string directory)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Genes));
            TextWriter writer = new StreamWriter(string.Format(@"{0}\{1}\{2}", Environment.CurrentDirectory, directory, fileName));

            Genes genes = new Genes();
            genes.gene = gene_list;
            serializer.Serialize(writer, genes);
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
}
