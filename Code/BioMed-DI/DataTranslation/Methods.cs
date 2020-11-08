using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace DataTranslation
{

    public class Methods
    {

        public static void createXmlGene(List<Gene> gene_list, string fileName, string directory)
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

        public static void createXmlPublication(List<Publication> publication_list, string fileName, string directory)
        {

            Console.WriteLine("Create Xml: " + fileName);

            Console.WriteLine("Count: " + publication_list.Count);

            Directory.CreateDirectory(string.Format("{0}/{1}", Environment.CurrentDirectory, directory));

            XmlSerializer serializer = new XmlSerializer(typeof(Publications));

            TextWriter writer = new StreamWriter(string.Format("{0}/{1}/{2}", Environment.CurrentDirectory, directory, fileName));

            Publications publications = new Publications();

            publications.publication = publication_list;

            serializer.Serialize(writer, publications);
            
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
                    if (checkIfNullOrEmpty(item.recordId))
                    {

                        recordId = item.recordId.Trim();

                    }

                    string ensemblId = "NaN";
                    if (checkIfNullOrEmpty(item.ensemblId))
                    {

                        ensemblId = item.ensemblId.Trim();

                    }

                    string ncbiId = "NaN";
                    if (checkIfNullOrEmpty(item.ncbiId))
                    {

                        ncbiId = item.ncbiId.Trim();

                    }

                    string geneName = "NaN";
                    if (checkIfNullOrEmpty(item.geneNames))
                    {

                        geneName = item.geneNames;

                    }

                    string pmid = "NaN";
                    if (checkIfNullOrEmpty(item.publicationMentions[0].pmId))
                    {

                        pmid = item.publicationMentions[0].pmId.Trim();

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

        public static void createTsvPublication(List<Publication> publication_list, string fileName, string directory)
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

                foreach (Publication item in publication_list)
                {

                    string recordId = "NaN";
                    if (checkIfNullOrEmpty(item.recordId))
                    {

                        recordId = item.recordId.Trim();

                    }

                    string ensemblId = "NaN";

                    string ncbiId = "NaN";
                    if (checkIfNullOrEmpty(item.ncbiId))
                    {

                        ncbiId = item.ncbiId.Trim();

                    }

                    string geneName = "NaN";
                    if (checkIfNullOrEmpty(item.geneNames))
                    {

                        geneName = item.geneNames;

                    }

                    string pmid = "NaN";
                    if (checkIfNullOrEmpty(item.pmId))
                    {

                        pmid = item.pmId.Trim();

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

    
    
        public static bool checkIfNullOrEmpty(string value)
        {

            bool returnValue = true;

            if (value == null)
            {

                returnValue = false;

            }

            if (value.Equals(string.Empty))
            {

                returnValue = false;

            }

            return returnValue;

        }

    }

}