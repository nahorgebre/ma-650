using System;
using System.IO;
using System.Collections.Generic;

namespace DataPreparation
{
    
    class all_gene_disease_pmid_associations
    {

        public static void runDataPreparation()
        {

            FileInfo kaessmann_2_all_gene_disease_pmid_associations_1_recordId = new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI2/kaessmann_2_all_gene_disease_pmid_associations_1.tsv");

            Methods.createRecordIdListFile(DI2Correspondences.kaessmann_2_all_gene_disease_pmid_associations_1, kaessmann_2_all_gene_disease_pmid_associations_1_recordId, 2);

            List<Gene> geneList_kaessmann_2_all_gene_disease_pmid_associations_1 = Parser.parseGene(DI2Correspondences.kaessmann_2_all_gene_disease_pmid_associations_1, kaessmann_2_all_gene_disease_pmid_associations_1_recordId);

            FileInfo kaessmann_2_all_gene_disease_pmid_associations_1_dp = new FileInfo(Environment.CurrentDirectory + "/data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_1_dp.xml");

            Methods.createXmlGene(geneList_kaessmann_2_all_gene_disease_pmid_associations_1, kaessmann_2_all_gene_disease_pmid_associations_1_dp);

            AWSupload.uploadDataFusionInput(kaessmann_2_all_gene_disease_pmid_associations_1_dp, "DI2");



            FileInfo kaessmann_2_all_gene_disease_pmid_associations_2_recordId = new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI2/kaessmann_2_all_gene_disease_pmid_associations_2.tsv");
            
            Methods.createRecordIdListFile(DI2Correspondences.kaessmann_2_all_gene_disease_pmid_associations_2, kaessmann_2_all_gene_disease_pmid_associations_2_recordId, 2);
            
            List<Gene> geneList_kaessmann_2_all_gene_disease_pmid_associations_2 = Parser.parseGene(DI2Correspondences.kaessmann_2_all_gene_disease_pmid_associations_2, kaessmann_2_all_gene_disease_pmid_associations_2_recordId);
            
            FileInfo kaessmann_2_all_gene_disease_pmid_associations_2_dp = new FileInfo(Environment.CurrentDirectory + "/data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_2_dp.xml");
            
            Methods.createXmlGene(geneList_kaessmann_2_all_gene_disease_pmid_associations_2, kaessmann_2_all_gene_disease_pmid_associations_2_dp);

            AWSupload.uploadDataFusionInput(kaessmann_2_all_gene_disease_pmid_associations_2_dp, "DI2");



            FileInfo kaessmann_2_all_gene_disease_pmid_associations_3_recordId = new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI2/kaessmann_2_all_gene_disease_pmid_associations_3.tsv");

            Methods.createRecordIdListFile(DI2Correspondences.kaessmann_2_all_gene_disease_pmid_associations_3, kaessmann_2_all_gene_disease_pmid_associations_3_recordId, 2);

            List<Gene> geneList_kaessmann_2_all_gene_disease_pmid_associations_3 = Parser.parseGene(DI2Correspondences.kaessmann_2_all_gene_disease_pmid_associations_3, kaessmann_2_all_gene_disease_pmid_associations_3_recordId);

            FileInfo kaessmann_2_all_gene_disease_pmid_associations_3_dp = new FileInfo(Environment.CurrentDirectory + "/data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_3_dp.xml");

            Methods.createXmlGene(geneList_kaessmann_2_all_gene_disease_pmid_associations_3, kaessmann_2_all_gene_disease_pmid_associations_3_dp);

            AWSupload.uploadDataFusionInput(kaessmann_2_all_gene_disease_pmid_associations_3_dp, "DI2");



            FileInfo kaessmann_2_all_gene_disease_pmid_associations_4_recordId = new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI2/kaessmann_2_all_gene_disease_pmid_associations_4.tsv");

            Methods.createRecordIdListFile(DI2Correspondences.kaessmann_2_all_gene_disease_pmid_associations_4, kaessmann_2_all_gene_disease_pmid_associations_4_recordId, 2);

            List<Gene> geneList_kaessmann_2_all_gene_disease_pmid_associations_4 = Parser.parseGene(DI2Correspondences.kaessmann_2_all_gene_disease_pmid_associations_4, kaessmann_2_all_gene_disease_pmid_associations_4_recordId);
            
            FileInfo kaessmann_2_all_gene_disease_pmid_associations_4_dp = new FileInfo(Environment.CurrentDirectory + "/data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_4_dp.xml");
            
            Methods.createXmlGene(geneList_kaessmann_2_all_gene_disease_pmid_associations_4, kaessmann_2_all_gene_disease_pmid_associations_4_dp);

            AWSupload.uploadDataFusionInput(kaessmann_2_all_gene_disease_pmid_associations_4_dp, "DI2");



            FileInfo kaessmann_2_all_gene_disease_pmid_associations_5_recordId = new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI2/kaessmann_2_all_gene_disease_pmid_associations_5.tsv");
            
            Methods.createRecordIdListFile(DI2Correspondences.kaessmann_2_all_gene_disease_pmid_associations_5, kaessmann_2_all_gene_disease_pmid_associations_5_recordId, 2);
            
            List<Gene> geneList_kaessmann_2_all_gene_disease_pmid_associations_5 = Parser.parseGene(DI2Correspondences.kaessmann_2_all_gene_disease_pmid_associations_5, kaessmann_2_all_gene_disease_pmid_associations_5_recordId);
            
            FileInfo kaessmann_2_all_gene_disease_pmid_associations_5_dp = new FileInfo(Environment.CurrentDirectory + "/data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_5_dp.xml");
            
            Methods.createXmlGene(geneList_kaessmann_2_all_gene_disease_pmid_associations_5, kaessmann_2_all_gene_disease_pmid_associations_5_dp);

            AWSupload.uploadDataFusionInput(kaessmann_2_all_gene_disease_pmid_associations_5_dp, "DI2");



            FileInfo kaessmann_2_all_gene_disease_pmid_associations_6_recordId = new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI2/kaessmann_2_all_gene_disease_pmid_associations_6.tsv");
            Methods.createRecordIdListFile(DI2Correspondences.kaessmann_2_all_gene_disease_pmid_associations_6, kaessmann_2_all_gene_disease_pmid_associations_6_recordId, 2);

            List<Gene> geneList_kaessmann_2_all_gene_disease_pmid_associations_6 = Parser.parseGene(DI2Correspondences.kaessmann_2_all_gene_disease_pmid_associations_6, kaessmann_2_all_gene_disease_pmid_associations_6_recordId);
            
            FileInfo kaessmann_2_all_gene_disease_pmid_associations_6_dp = new FileInfo(Environment.CurrentDirectory + "/data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_6_dp.xml");
            
            Methods.createXmlGene(geneList_kaessmann_2_all_gene_disease_pmid_associations_6, kaessmann_2_all_gene_disease_pmid_associations_6_dp);

            AWSupload.uploadDataFusionInput(kaessmann_2_all_gene_disease_pmid_associations_6_dp, "DI2");



            FileInfo kaessmann_2_all_gene_disease_pmid_associations_7_recordId = new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI2/kaessmann_2_all_gene_disease_pmid_associations_7.tsv");
            
            Methods.createRecordIdListFile(DI2Correspondences.kaessmann_2_all_gene_disease_pmid_associations_7, kaessmann_2_all_gene_disease_pmid_associations_7_recordId, 2);
            
            List<Gene> geneList_kaessmann_2_all_gene_disease_pmid_associations_7 = Parser.parseGene(DI2Correspondences.kaessmann_2_all_gene_disease_pmid_associations_7, kaessmann_2_all_gene_disease_pmid_associations_7_recordId);
            
            FileInfo kaessmann_2_all_gene_disease_pmid_associations_7_dp = new FileInfo(Environment.CurrentDirectory + "/data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_7_dp.xml");

            Methods.createXmlGene(geneList_kaessmann_2_all_gene_disease_pmid_associations_7, kaessmann_2_all_gene_disease_pmid_associations_7_dp);

            AWSupload.uploadDataFusionInput(kaessmann_2_all_gene_disease_pmid_associations_7_dp, "DI2");


        }
   
    }

}