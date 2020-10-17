using System;
using System.Collections.Generic;

namespace DataPreparation
{
    class Publication
    {

            HashSet<String> PubMedDate_dt = new HashSet<String>();
            List<(int, String)> PubMedDate_dt_recordIds = new List<(int, String)>
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

            HashSet<String> gene2pubtatorcentral_1_dt = new HashSet<String>();
            List<(int, String)> gene2pubtatorcentral_1_dt_recordIds = new List<(int, String)>
            {
                (1, Correspondences.gene2pubtatorcentral_1_2_PubMedDate),
                (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_1),
                (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_1),
                (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_1),
                (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_1),
                (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_1),
                (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_1)
            };

            HashSet<String> gene2pubtatorcentral_2_dt = new HashSet<String>();
            List<(int, String)> gene2pubtatorcentral_2_dt_recordIds = new List<(int, String)>
            {
                (1, Correspondences.gene2pubtatorcentral_2_2_PubMedDate),
                (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_2),
                (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_2),
                (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_2),
                (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_2),
                (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_2),
                (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_2)
            };

            HashSet<String> gene2pubtatorcentral_3_dt = new HashSet<String>();
            List<(int, String)> gene2pubtatorcentral_3_dt_recordIds = new List<(int, String)>
            {
                (1, Correspondences.gene2pubtatorcentral_3_2_PubMedDate),
                (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_3),
                (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_3),
                (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_3),
                (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_3),
                (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_3),
                (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_3)
            };

            HashSet<String> gene2pubtatorcentral_4_dt = new HashSet<String>();
            List<(int, String)> gene2pubtatorcentral_4_dt_recordIds = new List<(int, String)>
            {
                (1, Correspondences.gene2pubtatorcentral_4_2_PubMedDate),
                (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_4),
                (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_4),
                (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_4),
                (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_4),
                (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_4),
                (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_4)
            };

            HashSet<String> gene2pubtatorcentral_5_dt = new HashSet<String>();
            List<(int, String)> gene2pubtatorcentral_5_dt_recordIds = new List<(int, String)>
            {
                (1, Correspondences.gene2pubtatorcentral_5_2_PubMedDate),
                (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_5),
                (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_5),
                (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_5),
                (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_5),
                (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_5),
                (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_5)
            };

            HashSet<String> gene2pubtatorcentral_6_dt = new HashSet<String>();
            List<(int, String)> gene2pubtatorcentral_6_dt_recordIds = new List<(int, String)>
            {
                (1, Correspondences.gene2pubtatorcentral_6_2_PubMedDate),
                (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_6),
                (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_6),
                (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_6),
                (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_6),
                (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_6),
                (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_6)
            };

            HashSet<String> gene2pubtatorcentral_7_dt = new HashSet<String>();
            List<(int, String)> gene2pubtatorcentral_7_dt_recordIds = new List<(int, String)>
            {
                (1, Correspondences.gene2pubtatorcentral_7_2_PubMedDate),
                (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_7),
                (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_7),
                (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_7),
                (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_7),
                (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_7),
                (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_7)
            };

            HashSet<String> gene2pubtatorcentral_8_dt = new HashSet<String>();
            List<(int, String)> gene2pubtatorcentral_8_dt_recordIds = new List<(int, String)>
            {
                (1, Correspondences.gene2pubtatorcentral_8_2_PubMedDate),
                (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_8),
                (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_8),
                (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_8),
                (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_8),
                (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_8),
                (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_8)
            };

            HashSet<String> gene2pubtatorcentral_9_dt = new HashSet<String>();
            List<(int, String)> gene2pubtatorcentral_9_dt_recordIds = new List<(int, String)>
            {
                (1, Correspondences.gene2pubtatorcentral_9_2_PubMedDate),
                (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_9),
                (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_9),
                (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_9),
                (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_9),
                (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_9),
                (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_9)
            };

            HashSet<String> gene2pubtatorcentral_10_dt = new HashSet<String>();
            List<(int, String)> gene2pubtatorcentral_10_dt_recordIds = new List<(int, String)>
            {
                (1, Correspondences.gene2pubtatorcentral_10_2_PubMedDate),
                (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_10),
                (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_10),
                (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_10),
                (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_10),
                (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_10),
                (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_10)
            };

            HashSet<String> gene2pubtatorcentral_11_dt = new HashSet<String>();
            List<(int, String)> gene2pubtatorcentral_11_dt_recordIds = new List<(int, String)>
            {
                (1, Correspondences.gene2pubtatorcentral_11_2_PubMedDate),
                (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_11),
                (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_11),
                (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_11),
                (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_11),
                (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_11),
                (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_11)
            };

            HashSet<String> gene2pubtatorcentral_12_dt = new HashSet<String>();
            List<(int, String)> gene2pubtatorcentral_12_dt_recordIds = new List<(int, String)>
            {
                (1, Correspondences.gene2pubtatorcentral_12_2_PubMedDate),
                (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_12),
                (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_12),
                (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_12),
                (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_12),
                (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_12),
                (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_12)
            };

            HashSet<String> gene2pubtatorcentral_13_dt = new HashSet<String>();
            List<(int, String)> gene2pubtatorcentral_13_dt_recordIds = new List<(int, String)>
            {
                (1, Correspondences.gene2pubtatorcentral_13_2_PubMedDate),
                (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_13),
                (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_13),
                (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_13),
                (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_13),
                (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_13),
                (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_13)
            };

            HashSet<String> gene2pubtatorcentral_14_dt = new HashSet<String>();
            List<(int, String)> gene2pubtatorcentral_14_dt_recordIds = new List<(int, String)>
            {
                (1, Correspondences.gene2pubtatorcentral_14_2_PubMedDate),
                (2, Correspondences.mart_export_brain_2_gene2pubtatorcentral_14),
                (2, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_14),
                (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_14),
                (2, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_14),
                (2, Correspondences.mart_export_liver_2_gene2pubtatorcentral_14),
                (2, Correspondences.mart_export_testis_2_gene2pubtatorcentral_14)
            };

            HashSet<String> gene2pubtatorcentral_15_dt = new HashSet<String>();
            List<(int, String)> gene2pubtatorcentral_15_dt_recordIds = new List<(int, String)>
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