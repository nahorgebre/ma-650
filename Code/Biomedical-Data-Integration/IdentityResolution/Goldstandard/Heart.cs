using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks.Sources;

namespace Goldstandard
{
    class Heart
    {
        public static void heartGoldStandard()
        {
            Heart_Ensembl_NCBI_Crosswalk_2_all_gene_disease_pmid_associations();
            Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral();
            //Heart_2_Heart_Ensembl_NCBI_Crosswalk();
            //mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk();
            //gene2pubtatorcentral_2_Ensemble_NCBI_Crosswalk();
        }

        public static void gene2pubtatorcentral_2_Ensemble_NCBI_Crosswalk()
        {
            List<Gene> gene2pubtatorcentral_dt = Methods.readXmlFile(Datasets.gene2pubtatorcentral_Path);
            List<Gene> Heart_Ensembl_NCBI_Crosswalk_dt = Methods.readXmlFile(Datasets.Heart_Ensembl_NCBI_Crosswalk_Path);

            (List<Goldstandard> gene2pubtatorcentral_2_Ensemble_NCBI_Crosswalk_TRUE, List<Goldstandard> gene2pubtatorcentral_2_Ensemble_NCBI_Crosswalk_FALSE) = Methods.compareUsingGeneName(gene2pubtatorcentral_dt, Heart_Ensembl_NCBI_Crosswalk_dt, 200);
            Methods.createGoldStandard(gene2pubtatorcentral_2_Ensemble_NCBI_Crosswalk_TRUE, gene2pubtatorcentral_2_Ensemble_NCBI_Crosswalk_FALSE, "gene_disease_pmid_associations_2_Ensemble_NCBI_Crosswalk");
        }

        public static void Heart_2_Heart_Ensembl_NCBI_Crosswalk()
        {
            List<Gene> Heart_dt = Methods.readXmlFile(Datasets.Heart_Path);
            List<Gene> Heart_Ensembl_NCBI_Crosswalk_dt = Methods.readXmlFile(Datasets.Heart_Ensembl_NCBI_Crosswalk_Path);

            (List<Goldstandard> Heart_2_Heart_Ensembl_NCBI_Crosswalk_TRUE, List<Goldstandard> Heart_2_Heart_Ensembl_NCBI_Crosswalk_FALSE) = Methods.compareUsingGeneId(Heart_dt, Heart_Ensembl_NCBI_Crosswalk_dt, 200);
            Methods.createGoldStandard(Heart_2_Heart_Ensembl_NCBI_Crosswalk_TRUE, Heart_2_Heart_Ensembl_NCBI_Crosswalk_FALSE, "Heart_2_Heart_Ensembl_NCBI_Crosswalk");
        }

        public static void mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk()
        {
            List<Gene> mart_export_heart_dt = Methods.readXmlFile(Datasets.mart_export_heart_Path);
            List<Gene> Heart_Ensembl_NCBI_Crosswalk_dt = Methods.readXmlFile(Datasets.Heart_Ensembl_NCBI_Crosswalk_Path);

            (List<Goldstandard> mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk_TRUE, List<Goldstandard> mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk_FALSE) = Methods.compareUsingGeneId(mart_export_heart_dt, Heart_Ensembl_NCBI_Crosswalk_dt, 200);
            Methods.createGoldStandard(mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk_TRUE, mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk_FALSE, "mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk");
        }

        public static void Heart_Ensembl_NCBI_Crosswalk_2_all_gene_disease_pmid_associations()
        {
            string outputDirectory = Environment.CurrentDirectory + "/data/output/";
            Directory.CreateDirectory(outputDirectory);

            string outputFileName = outputDirectory + "/Heart_Ensembl_NCBI_Crosswalk_2_all_gene_disease_pmid_associations.csv";
            using (StreamWriter sw = new StreamWriter(outputFileName)) 
            {
                int trueCount = 0;
                int falseCount = 0;

                foreach (Gene ds1 in Methods.readXmlFile(Datasets.Heart_Ensembl_NCBI_Crosswalk_Path))
                {
                    foreach (Gene ds2 in Methods.readXmlFile(Datasets.all_gene_disease_pmid_associations_Path))
                    {
                        //string nameDs1 = ds1.geneNameList[0].ToString().ToLower();
                        //string nameDs2 = ds2.geneNameList[0].ToString().ToLower();

                        if (ds1.ncbiId.Equals(ds2.ncbiId))
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

        public static void Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral()
        {
            string outputDirectory = Environment.CurrentDirectory + "/data/output/";
            Directory.CreateDirectory(outputDirectory);

            string outputFileName = outputDirectory + "/Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral.csv";
            using (StreamWriter sw = new StreamWriter(outputFileName)) 
            {
                int trueCount = 0;
                int falseCount = 0;

                foreach (Gene ds1 in Methods.readXmlFile(Datasets.Heart_Ensembl_NCBI_Crosswalk_Path))
                {

                    foreach (Gene ds2 in Methods.readXmlFile(Datasets.gene2pubtatorcentral_Path))
                    {
                        if (ds1.ncbiId.Equals(ds2.ncbiId))
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