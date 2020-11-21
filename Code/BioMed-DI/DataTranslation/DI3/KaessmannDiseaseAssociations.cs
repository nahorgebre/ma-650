using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;

namespace DataTranslation
{

    public class KaessmannDiseaseAssociations
    {

        public static void runDataTranslation()
        {

            FileInfo file = new FileInfo(string.Format("{0}/data/input/DI3/analysis1.xml", Environment.CurrentDirectory));

            List<Gene> gene_list = Parser.getGeneList(file, "KaessmannDiseaseAssociations_{0}_rid");

            Methods.createXmlGene(gene_list: gene_list, fileName: "KaessmannDiseaseAssociations_dt.xml", directory: "data/output/DI3");

            Methods.createTsv(gene_list: gene_list, fileName: "KaessmannDiseaseAssociations_dt.tsv", directory: "data/output/DI3");

        }

    }

}