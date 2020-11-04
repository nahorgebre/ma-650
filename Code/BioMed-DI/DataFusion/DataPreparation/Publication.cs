using System;
using System.Collections.Generic;

namespace DataPreparation
{

    class Publication
    {

        public static void run() 
        {
            Methods.getDistinctRecordIds(PubMedDate_dt_recordIds, "PubMedDate_dt");
            Methods.getDistinctRecordIds(gene2pubtatorcentral_1_dt_recordIds, "gene2pubtatorcentral_1_dt");
            Methods.getDistinctRecordIds(gene2pubtatorcentral_2_dt_recordIds, "gene2pubtatorcentral_2_dt");
            Methods.getDistinctRecordIds(gene2pubtatorcentral_3_dt_recordIds, "gene2pubtatorcentral_3_dt");
            Methods.getDistinctRecordIds(gene2pubtatorcentral_4_dt_recordIds, "gene2pubtatorcentral_4_dt");
            Methods.getDistinctRecordIds(gene2pubtatorcentral_5_dt_recordIds, "gene2pubtatorcentral_5_dt");
            Methods.getDistinctRecordIds(gene2pubtatorcentral_6_dt_recordIds, "gene2pubtatorcentral_6_dt");
            Methods.getDistinctRecordIds(gene2pubtatorcentral_7_dt_recordIds, "gene2pubtatorcentral_7_dt");
            Methods.getDistinctRecordIds(gene2pubtatorcentral_8_dt_recordIds, "gene2pubtatorcentral_8_dt");
            Methods.getDistinctRecordIds(gene2pubtatorcentral_9_dt_recordIds, "gene2pubtatorcentral_9_dt");
            Methods.getDistinctRecordIds(gene2pubtatorcentral_10_dt_recordIds, "gene2pubtatorcentral_10_dt");
            Methods.getDistinctRecordIds(gene2pubtatorcentral_11_dt_recordIds, "gene2pubtatorcentral_11_dt");
            Methods.getDistinctRecordIds(gene2pubtatorcentral_12_dt_recordIds, "gene2pubtatorcentral_12_dt");
            Methods.getDistinctRecordIds(gene2pubtatorcentral_13_dt_recordIds, "gene2pubtatorcentral_13_dt");
            Methods.getDistinctRecordIds(gene2pubtatorcentral_14_dt_recordIds, "gene2pubtatorcentral_14_dt");
            Methods.getDistinctRecordIds(gene2pubtatorcentral_15_dt_recordIds, "gene2pubtatorcentral_15_dt");
        }

        public static List<(int, String)> PubMedDate_dt_recordIds = new List<(int, String)>
        {
            (2, Correspondences.gene2pubtatorcentral_1_2_PubMedDate),
            (2, Correspondences.gene2pubtatorcentral_2_2_PubMedDate),
            (2, Correspondences.gene2pubtatorcentral_3_2_PubMedDate),
            (2, Correspondences.gene2pubtatorcentral_4_2_PubMedDate),
            (2, Correspondences.gene2pubtatorcentral_5_2_PubMedDate),
            (2, Correspondences.gene2pubtatorcentral_6_2_PubMedDate),
            (2, Correspondences.gene2pubtatorcentral_7_2_PubMedDate),
            (2, Correspondences.gene2pubtatorcentral_8_2_PubMedDate),
            (2, Correspondences.gene2pubtatorcentral_9_2_PubMedDate),
            (2, Correspondences.gene2pubtatorcentral_10_2_PubMedDate),
            (2, Correspondences.gene2pubtatorcentral_11_2_PubMedDate),
            (2, Correspondences.gene2pubtatorcentral_12_2_PubMedDate),
            (2, Correspondences.gene2pubtatorcentral_13_2_PubMedDate),
            (2, Correspondences.gene2pubtatorcentral_14_2_PubMedDate),
            (2, Correspondences.gene2pubtatorcentral_15_2_PubMedDate)
        };

        public static List<(int, String)> gene2pubtatorcentral_1_dt_recordIds = new List<(int, String)>
        {
            (1, Correspondences.gene2pubtatorcentral_1_2_PubMedDate),
            (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_1),
            (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_1),
            (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_1),
            (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_1),
            (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_1),
            (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_1)
        };

        public static List<(int, String)> gene2pubtatorcentral_2_dt_recordIds = new List<(int, String)>
        {
            (1, Correspondences.gene2pubtatorcentral_2_2_PubMedDate),
            (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_2),
            (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_2),
            (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_2),
            (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_2),
            (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_2),
            (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_2)
        };

        public static List<(int, String)> gene2pubtatorcentral_3_dt_recordIds = new List<(int, String)>
        {
            (1, Correspondences.gene2pubtatorcentral_3_2_PubMedDate),
            (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_3),
            (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_3),
            (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_3),
            (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_3),
            (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_3),
            (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_3)
        };

        public static List<(int, String)> gene2pubtatorcentral_4_dt_recordIds = new List<(int, String)>
        {
            (1, Correspondences.gene2pubtatorcentral_4_2_PubMedDate),
            (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_4),
            (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_4),
            (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_4),
            (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_4),
            (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_4),
            (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_4)
        };

        public static List<(int, String)> gene2pubtatorcentral_5_dt_recordIds = new List<(int, String)>
        {
            (1, Correspondences.gene2pubtatorcentral_5_2_PubMedDate),
            (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_5),
            (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_5),
            (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_5),
            (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_5),
            (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_5),
            (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_5)
        };

        public static List<(int, String)> gene2pubtatorcentral_6_dt_recordIds = new List<(int, String)>
        {
            (1, Correspondences.gene2pubtatorcentral_6_2_PubMedDate),
            (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_6),
            (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_6),
            (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_6),
            (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_6),
            (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_6),
            (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_6)
        };

        public static List<(int, String)> gene2pubtatorcentral_7_dt_recordIds = new List<(int, String)>
        {
            (1, Correspondences.gene2pubtatorcentral_7_2_PubMedDate),
            (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_7),
            (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_7),
            (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_7),
            (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_7),
            (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_7),
            (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_7)
        };

        public static List<(int, String)> gene2pubtatorcentral_8_dt_recordIds = new List<(int, String)>
        {
            (1, Correspondences.gene2pubtatorcentral_8_2_PubMedDate),
            (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_8),
            (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_8),
            (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_8),
            (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_8),
            (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_8),
            (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_8)
        };

        public static List<(int, String)> gene2pubtatorcentral_9_dt_recordIds = new List<(int, String)>
        {
            (1, Correspondences.gene2pubtatorcentral_9_2_PubMedDate),
            (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_9),
            (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_9),
            (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_9),
            (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_9),
            (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_9),
            (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_9)
        };

        public static List<(int, String)> gene2pubtatorcentral_10_dt_recordIds = new List<(int, String)>
        {
            (1, Correspondences.gene2pubtatorcentral_10_2_PubMedDate),
            (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_10),
            (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_10),
            (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_10),
            (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_10),
            (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_10),
            (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_10)
        };

        public static List<(int, String)> gene2pubtatorcentral_11_dt_recordIds = new List<(int, String)>
        {
            (1, Correspondences.gene2pubtatorcentral_11_2_PubMedDate),
            (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_11),
            (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_11),
            (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_11),
            (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_11),
            (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_11),
            (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_11)
        };

        public static List<(int, String)> gene2pubtatorcentral_12_dt_recordIds = new List<(int, String)>
        {
            (1, Correspondences.gene2pubtatorcentral_12_2_PubMedDate),
            (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_12),
            (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_12),
            (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_12),
            (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_12),
            (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_12),
            (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_12)
        };

        public static List<(int, String)> gene2pubtatorcentral_13_dt_recordIds = new List<(int, String)>
        {
            (1, Correspondences.gene2pubtatorcentral_13_2_PubMedDate),
            (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_13),
            (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_13),
            (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_13),
            (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_13),
            (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_13),
            (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_13)
        };

        public static List<(int, String)> gene2pubtatorcentral_14_dt_recordIds = new List<(int, String)>
        {
            (1, Correspondences.gene2pubtatorcentral_14_2_PubMedDate),
            (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_14),
            (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_14),
            (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_14),
            (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_14),
            (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_14),
            (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_14)
        };

        public static List<(int, String)> gene2pubtatorcentral_15_dt_recordIds = new List<(int, String)>
        {
            (1, Correspondences.gene2pubtatorcentral_15_2_PubMedDate),
            (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_15),
            (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_15),
            (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_15),
            (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_15),
            (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_15),
            (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_15)

        };

    }

}