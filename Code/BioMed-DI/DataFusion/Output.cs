using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace DataFusion
{

    public class Output
    {

        public static void createXmlGene(List<Gene> gene_list, FileInfo file)
        {

            Console.WriteLine("Create Xml: " + file.Name);

            file.Directory.Create();

            XmlSerializer serializer = new XmlSerializer(typeof(Genes));

            TextWriter writer = new StreamWriter(file.FullName);

            Genes genes = new Genes();

            genes.gene = gene_list;

            serializer.Serialize(writer, genes);

            writer.Close();

        }

    }

}