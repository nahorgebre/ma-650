using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;

namespace DataTranslation
{

    public class Kaessmann
    {

        public static void runDataTranslation()
        {

            FileInfo file = new FileInfo(string.Format("{0}/data/input/DI2/kaessmann-fused.xml", Environment.CurrentDirectory));

            List<Gene> gene_list = Parser.getGeneList(file);

            gene_list = Methods.adjustRecordId(gene_list, "Kaessmann_{0}_rid");

            Output.createXml(gene_list: gene_list, fileName: "Kaessmann_dt.xml", directory: "data/output/DI2");

            Output.createTsv(gene_list: gene_list, fileName: "Kaessmann_dt.tsv", directory: "data/output/DI2");

        }

    }

}