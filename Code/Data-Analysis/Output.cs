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

    }

}