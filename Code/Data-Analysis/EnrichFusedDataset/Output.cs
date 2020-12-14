using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    public class Output
    {



        public static void createXml(List<Gene> gene_list, FileInfo file)
        {

            file.Directory.Create();

            XmlSerializer serializer = new XmlSerializer(typeof(Genes));

            TextWriter writer = new StreamWriter(file.FullName);

            Genes genes = new Genes();

            genes.gene = gene_list;

            serializer.Serialize(writer, genes);

            writer.Close();

            Console.WriteLine("Xml: ..." + file.FullName);

        }

        public static void createTsv(List<Gene> gene_list, FileInfo file)
        {
            
            var delimiter = "\t";

            using (StreamWriter sw = new StreamWriter(file.FullName)) 
            {
           
                List<string> firstLineContent = new List<string>()
                {

                    "recordId",

                    "ensemblId",

                    "ncbiId",

                    "geneNames"

                };

                var firstLine = string.Join(delimiter, firstLineContent);

                sw.WriteLine(firstLine);

                foreach (Gene item in gene_list)
                {


                    string recordId = "NV";

                    if (!item.recordId.Equals(string.Empty))
                    {

                        recordId = item.recordId.Trim();

                    }


                    string ensemblId = "NV";

                    if (!item.ensemblId.Equals(string.Empty))
                    {

                        ensemblId = item.ensemblId.Trim();

                    }


                    string ncbiId = "NV";

                    if (!item.ncbiId.Equals(string.Empty))
                    {

                        ncbiId = item.ncbiId.Trim();

                    }


                    string geneNames = "NV";

                    if (!item.geneNames.Equals(string.Empty))
                    {

                        geneNames = item.geneNames;

                    }


                    List<string> lineContent = new List<string>()
                    {

                        recordId,

                        ensemblId,

                        ncbiId,

                        geneNames

                    };


                    var line = string.Join(delimiter, lineContent);

                    sw.WriteLine(line);

                }

            }

            Console.WriteLine("Tsv: ..." + file.FullName);
        
        }

    }

}