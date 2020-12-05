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

            FileInfo file = new FileInfo(DI2.inputDirectory + "/kaessmann-fused.xml");

            List<Gene> gene_list = Parser.getGeneList(file);

            gene_list = Output.adjustRecordId(gene_list, "Kaessmann_{0}_rid");

            Output.createXml(gene_list: gene_list, file: new FileInfo(DI2.outputDirectory + "/Kaessmann_dt.xml"));

            Output.createTsv(gene_list: gene_list, file: new FileInfo(DI2.outputDirectory + "/Kaessmann_dt.tsv"));

        }

    }

}