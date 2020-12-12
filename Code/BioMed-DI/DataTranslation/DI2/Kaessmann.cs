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

            FileInfo file = new FileInfo(DI2.inputDirectory + "/DI1-fused.xml");

            List<Gene> gene_list = Parser.getGeneList(file);

            gene_list = Output.adjustRecordId(gene_list, "DI1_{0}_rid");

            Output.createXml(gene_list: gene_list, file: new FileInfo(DI2.outputDirectory + "/DI1_dt.xml"));

            Output.createTsv(gene_list: gene_list, file: new FileInfo(DI2.outputDirectory + "/DI1_dt.tsv"));

        }

    }

}