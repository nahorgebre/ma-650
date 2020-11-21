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

        public static void createTsv(List<Gene> gene_list, string fileName, string directory)
        {

            Console.WriteLine("Create TSV: " + fileName);

            string gsFileName = string.Format("{0}/{1}/{2}", Environment.CurrentDirectory, directory, fileName);
            
            var delimiter = "\t";

            using (StreamWriter sw = new StreamWriter(gsFileName)) 
            {
           
                List<string> firstLineContent = new List<string>()
                {
                    "recordId",
                    "ensemblId",
                    "ncbiId",
                    "geneName"
                };

                var firstLine = string.Join(delimiter, firstLineContent);

                sw.WriteLine(firstLine);

                foreach (Gene item in gene_list)
                {

                    string recordId = "NaN";
                    if (checkIfNull(item.recordId))
                    {

                        recordId = item.recordId.Trim();

                    }

                    string ensemblId = "NaN";
                    if (checkIfNull(item.ensemblId))
                    {

                        ensemblId = item.ensemblId.Trim();

                    }

                    string ncbiId = "NaN";
                    if (checkIfNull(item.ncbiId))
                    {

                        ncbiId = item.ncbiId.Trim();

                    }

                    string geneName = "NaN";
                    if (checkIfNull(item.geneNames))
                    {

                        geneName = item.geneNames;

                    }

                    List<string> lineContent = new List<string>()
                    {
                        recordId,
                        ensemblId,
                        ncbiId,
                        geneName
                    };

                    var line = string.Join(delimiter, lineContent);

                    sw.WriteLine(line);

                }

            }

        }
    
        public static bool checkIfNull(string value)
        {

            bool returnValue = false;

            if (value != null)
            {

                returnValue = true;

            }

            return returnValue;

        }

    }

}