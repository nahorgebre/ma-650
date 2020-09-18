using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks.Sources;

namespace Goldstandard
{
    class Cerebellum
    {
        public static void cerebellumGoldStandard()
        {
            Cerebellum_2_mart_export_cerebellum();
            mart_export_cerebellum_2_gene2pubtatorcentral();
        }

        public static void mart_export_cerebellum_2_gene2pubtatorcentral()
        {
            List<Gene> mart_export_cerebellum_dt = Methods.readXmlFile(Datasets.mart_export_cerebellum_Path);
            List<Gene> gene2pubtatorcentral_dt = Methods.readXmlFile(Datasets.gene2pubtatorcentral_Path);

            (List<Goldstandard> mart_export_cerebellum_2_gene2pubtatorcentral_TRUE, List<Goldstandard> mart_export_cerebellum_2_gene2pubtatorcentral_FALSE) = Methods.compareUsingGeneName(mart_export_cerebellum_dt, gene2pubtatorcentral_dt, 200);
            Methods.createGoldStandard(mart_export_cerebellum_2_gene2pubtatorcentral_TRUE, mart_export_cerebellum_2_gene2pubtatorcentral_FALSE, "mart_export_cerebellum_2_gene2pubtatorcentral");
        }

        public static void Cerebellum_2_mart_export_cerebellum()
        {
            List<Gene> Cerebellum_dt = Methods.readXmlFile(Datasets.Cerebellum_Path);
            List<Gene> mart_export_cerebellum_dt = Methods.readXmlFile(Datasets.mart_export_cerebellum_Path);

            (List<Goldstandard> Cerebellum_2_mart_export_cerebellum_TRUE, List<Goldstandard> Cerebellum_2_mart_export_cerebellum_FALSE) = Methods.compareUsingGeneId(Cerebellum_dt, mart_export_cerebellum_dt, 200);
            Methods.createGoldStandard(Cerebellum_2_mart_export_cerebellum_TRUE, Cerebellum_2_mart_export_cerebellum_FALSE, "Cerebellum_2_mart_export_cerebellum");
        }

        public static void mart_export_cerebellum_2_all_gene_disease_pmid_associations()
        {
            string outputDirectory = Environment.CurrentDirectory + "/data/output/";
            Directory.CreateDirectory(outputDirectory);

            string outputFileName = outputDirectory + "/mart_export_cerebellum_2_all_gene_disease_pmid_associations.csv";
            using (StreamWriter sw = new StreamWriter(outputFileName)) 
            {
                int trueCount = 0;
                int falseCount = 0;

                foreach (Gene ds1 in Methods.readXmlFile(Datasets.mart_export_cerebellum_Path))
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