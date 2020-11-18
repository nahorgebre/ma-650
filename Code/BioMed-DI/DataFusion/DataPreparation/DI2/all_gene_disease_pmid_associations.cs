using System;
using System.IO;
using System.Collections.Generic;

namespace DataPreparation
{
    
    class all_gene_disease_pmid_associations
    {

        public static void runDataPreparation()
        {

            for (int i = 7; i < 7; i++)
            {

                FileInfo kaessmann_2_all_gene_disease_pmid_associations_recordIdListFile = new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI2/kaessmann_2_all_gene_disease_pmid_associations_" + i + ".tsv");

                FileInfo kaessmann_2_all_gene_disease_pmid_associations_Correspondences = new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI2/kaessmann_2_all_gene_disease_pmid_associations_" + i + "/correspondences.csv");

                Methods.createRecordIdListFile(kaessmann_2_all_gene_disease_pmid_associations_Correspondences, kaessmann_2_all_gene_disease_pmid_associations_recordIdListFile, 2);



                FileInfo all_gene_disease_pmid_associations_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI2/all_gene_disease_pmid_associations_" + i + "_dt.xml");

                List<Gene> geneList_kaessmann_2_all_gene_disease_pmid_associations = Parser.parseGene(all_gene_disease_pmid_associations_dt, kaessmann_2_all_gene_disease_pmid_associations_recordIdListFile);


                FileInfo kaessmann_2_all_gene_disease_pmid_associations_dp = new FileInfo(Environment.CurrentDirectory + "/data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_" + i + "_dp.xml");

                Methods.createXmlGene(geneList_kaessmann_2_all_gene_disease_pmid_associations, kaessmann_2_all_gene_disease_pmid_associations_dp);

                AWSupload.uploadDataFusionInput(kaessmann_2_all_gene_disease_pmid_associations_dp, "DI2");
                
            }

        }

    }

}