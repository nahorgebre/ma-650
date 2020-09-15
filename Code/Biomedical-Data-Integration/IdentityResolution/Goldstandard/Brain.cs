using System.Collections.Generic;
using System;
using System.IO;

namespace Goldstandard
{
    class Brain
    {
        public static void brainGoldStandard()
        {  
            //Brain_2_mart_export_brain();
            mart_export_brain_2_all_gene_disease_pmid_associations();
            //mart_export_brain_2_gene2pubtatorcentral();
        }

        public static void mart_export_brain_2_gene2pubtatorcentral()
        {
            List<Gene> mart_export_brain_dt = Methods.readXmlFile(Datasets.mart_export_brain_Path);
            List<Gene> gene2pubtatorcentral_dt = Methods.readXmlFile(Datasets.gene2pubtatorcentral_Path);

            (List<Goldstandard> mart_export_brain_2_gene2pubtatorcentral_TRUE, List<Goldstandard> mart_export_brain_2_gene2pubtatorcentral_FALSE) = Methods.compareUsingGeneName(mart_export_brain_dt, gene2pubtatorcentral_dt, 200);
            Methods.createGoldStandard(mart_export_brain_2_gene2pubtatorcentral_TRUE, mart_export_brain_2_gene2pubtatorcentral_FALSE, "mart_export_brain_2_gene2pubtatorcentral");
        }

        public static void Brain_2_mart_export_brain()
        {
            List<Gene> Brain_dt = Methods.readXmlFile(Datasets.Brain_Path);
            List<Gene> mart_export_brain_dt = Methods.readXmlFile(Datasets.mart_export_brain_Path);

            (List<Goldstandard> Brain_2_mart_export_brain_TRUE, List<Goldstandard> Brain_2_mart_export_brain_FALSE) = Methods.compareUsingGeneId(Brain_dt, mart_export_brain_dt, 200);
            Methods.createGoldStandard(Brain_2_mart_export_brain_TRUE, Brain_2_mart_export_brain_FALSE, "Brain_2_mart_export_brain");
        }

        public static void mart_export_brain_2_all_gene_disease_pmid_associations()
        {
            string outputDirectory = Environment.CurrentDirectory + "/data/output/";
            Directory.CreateDirectory(outputDirectory);

            string outputFileName = outputDirectory + "/mart_export_brain_2_all_gene_disease_pmid_associations.csv";
            using (StreamWriter sw = new StreamWriter(outputFileName)) 
            {
                int trueCount = 0;
                int falseCount = 0;

                foreach (Gene ds1 in Methods.readXmlFile(Datasets.mart_export_brain_Path))
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