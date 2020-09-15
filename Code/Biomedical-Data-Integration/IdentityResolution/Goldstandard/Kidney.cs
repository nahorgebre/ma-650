using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks.Sources;

namespace Goldstandard
{
    class Kidney
    {
        public static void kidneyGoldStandard()
        {
            //Kidney_2_mart_export_kidney();
            mart_export_kidney_2_all_gene_disease_pmid_associations();
            //mart_export_kidney_2_gene2pubtatorcentral();
        }

        public static void mart_export_kidney_2_gene2pubtatorcentral()
        {
            List<Gene> mart_export_kidney_dt = Methods.readXmlFile(Datasets.mart_export_kidney_Path);
            List<Gene> gene2pubtatorcentral_dt = Methods.readXmlFile(Datasets.gene2pubtatorcentral_Path);

            (List<Goldstandard> mart_export_kidney_2_gene2pubtatorcentral_TRUE, List<Goldstandard> mart_export_kidney_2_gene2pubtatorcentral_FALSE) = Methods.compareUsingGeneName(mart_export_kidney_dt, gene2pubtatorcentral_dt, 200);
            Methods.createGoldStandard(mart_export_kidney_2_gene2pubtatorcentral_TRUE, mart_export_kidney_2_gene2pubtatorcentral_FALSE, "mart_export_kidney_2_gene2pubtatorcentral");
        }

        public static void Kidney_2_mart_export_kidney()
        {
            List<Gene> Kidney_dt = Methods.readXmlFile(Datasets.Kidney_Path);
            List<Gene> mart_export_kidney_dt = Methods.readXmlFile(Datasets.mart_export_kidney_Path);

            (List<Goldstandard> Kidney_2_mart_export_kidney_TRUE, List<Goldstandard> Kidney_2_mart_export_kidney_FALSE) = Methods.compareUsingGeneId(Kidney_dt, mart_export_kidney_dt, 200);
            Methods.createGoldStandard(Kidney_2_mart_export_kidney_TRUE, Kidney_2_mart_export_kidney_FALSE, "Kidney_2_mart_export_kidney");
        }

        public static void mart_export_kidney_2_all_gene_disease_pmid_associations()
        {
            string outputDirectory = Environment.CurrentDirectory + "/data/output/";
            Directory.CreateDirectory(outputDirectory);

            string outputFileName = outputDirectory + "/mart_export_kidney_2_all_gene_disease_pmid_associations.csv";
            using (StreamWriter sw = new StreamWriter(outputFileName)) 
            {
                int trueCount = 0;
                int falseCount = 0;

                foreach (Gene ds1 in Methods.readXmlFile(Datasets.mart_export_kidney_Path))
                {

                    foreach (Gene ds2 in Methods.readXmlFile(Datasets.all_gene_disease_pmid_associations_Path))
                    {
                        if (ds1.geneNameList[0].Equals(ds2.geneNameList[0]))
                        {
                            if (trueCount < 200)
                            {
                                sw.WriteLine(ds1.recordId + "," + ds2.recordId + ",TRUE");
                            } 
                        }
                        else 
                        {
                            if (falseCount < 200)
                            {
                                sw.WriteLine(ds1.recordId + "," + ds2.recordId + ",FALSE");
                            }
                        }        
                    }
                }
            }
        }
    }
}