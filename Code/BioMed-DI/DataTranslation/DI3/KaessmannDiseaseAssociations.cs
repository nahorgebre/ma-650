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

            FileInfo file = new FileInfo(DI3.inputDirectory + "/DI2-fused.xml");

            List<Gene> gene_list = Parser.getGeneList(file);

            gene_list = Output.adjustRecordId(gene_list, "DI2_{0}_rid");

            Output.createXml(gene_list: gene_list, file: new FileInfo(DI3.outputDirectory + "/DI2_dt.xml"));

            Output.createTsv(gene_list: gene_list, file: new FileInfo(DI3.outputDirectory + "/DI2_dt.tsv"));

        }

    }

}