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

            FileInfo file = new FileInfo(DI3.inputDirectory + "/analysis1.xml");

            List<Gene> gene_list = Parser.getGeneList(file);

            gene_list = Output.adjustRecordId(gene_list, "KaessmannDiseaseAssociations_{0}_rid");

            Output.createXml(gene_list: gene_list, file: new FileInfo(DI3.outputDirectory + "/KaessmannDiseaseAssociations_dt.xml"));

            Output.createTsv(gene_list: gene_list, file: new FileInfo(DI3.outputDirectory + "/KaessmannDiseaseAssociations_dt.tsv"));

        }

    }

}