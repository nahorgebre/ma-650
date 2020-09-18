using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks.Sources;

namespace Goldstandard
{
    class Liver
    {
        public static void liverGoldStandard()
        {
            Liver_2_mart_export_liver();
            mart_export_liver_2_gene2pubtatorcentral();
        }

        public static void mart_export_liver_2_gene2pubtatorcentral()
        {
            List<Gene> mart_export_liver_dt = Methods.readXmlFile(Datasets.mart_export_liver_Path);
            List<Gene> gene2pubtatorcentral_dt = Methods.readXmlFile(Datasets.gene2pubtatorcentral_Path);

            (List<Goldstandard> mart_export_liver_2_gene2pubtatorcentral_TRUE, List<Goldstandard> mart_export_liver_2_gene2pubtatorcentral_FALSE) = Methods.compareUsingGeneName(mart_export_liver_dt, gene2pubtatorcentral_dt, 200);
            Methods.createGoldStandard(mart_export_liver_2_gene2pubtatorcentral_TRUE, mart_export_liver_2_gene2pubtatorcentral_FALSE, "mart_export_liver_2_gene2pubtatorcentral");
        }

        public static void Liver_2_mart_export_liver()
        {
            List<Gene> Liver_dt = Methods.readXmlFile(Datasets.Liver_Path);
            List<Gene> mart_export_liver_dt = Methods.readXmlFile(Datasets.mart_export_liver_Path);

            (List<Goldstandard> Liver_2_mart_export_liver_TRUE, List<Goldstandard> Liver_2_mart_export_liver_FALSE) = Methods.compareUsingGeneId(Liver_dt, mart_export_liver_dt, 200);
            Methods.createGoldStandard(Liver_2_mart_export_liver_TRUE, Liver_2_mart_export_liver_FALSE, "Liver_2_mart_export_liver");
        }

        public static void mart_export_liver_2_all_gene_disease_pmid_associations()
        {
            string outputDirectory = Environment.CurrentDirectory + "/data/output/";
            Directory.CreateDirectory(outputDirectory);

            string outputFileName = outputDirectory + "/mart_export_liver_2_all_gene_disease_pmid_associations.csv";
            using (StreamWriter sw = new StreamWriter(outputFileName)) 
            {
                int trueCount = 0;
                int falseCount = 0;

                foreach (Gene ds1 in Methods.readXmlFile(Datasets.mart_export_liver_Path))
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