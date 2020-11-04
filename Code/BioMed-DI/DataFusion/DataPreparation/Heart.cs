using System;
using System.Collections.Generic;

namespace DataPreparation
{

    class Heart
    {

        public static void run() 
        {
            Methods.getDistinctRecordIds(Heart_Ensembl_NCBI_Crosswalk_dt_recordIds, "Heart_Ensembl_NCBI_Crosswalk_dt");
            Methods.getDistinctRecordIds(Heart_dt_recordIds, "Heart_dt");
            Methods.getDistinctRecordIds(mart_export_heart_dt_recordIds, "mart_export_heart_dt");
        }

        public static List<(int, String)> Heart_Ensembl_NCBI_Crosswalk_dt_recordIds = new List<(int, String)>
        {
            (2, Correspondences.Heart_2_Heart_Ensembl_NCBI_Crosswalk),
            (2, Correspondences.mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk),
            (1, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_all_gene_disease_pmid_associations),
            (1, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_1),
            (1, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_2),
            (1, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_3),
            (1, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_4),
            (1, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_5),
            (1, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_6),
            (1, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_7),
            (1, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_8),
            (1, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_9),
            (1, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_10),
            (1, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_11),
            (1, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_12),
            (1, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_13),
            (1, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_14),
            (1, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral_15)
        };

        public static List<(int, String)> Heart_dt_recordIds = new List<(int, String)>
        {
            (1, Correspondences.Heart_2_Heart_Ensembl_NCBI_Crosswalk),
            (1, Correspondences.Heart_2_Brain),
            (1, Correspondences.Heart_2_Cerebellum),
            (1, Correspondences.Heart_2_Kidney),
            (1, Correspondences.Heart_2_Liver),
            (1, Correspondences.Heart_2_Testis )
        };

        public static List<(int, String)> mart_export_heart_dt_recordIds = new List<(int, String)>
        {
            (1, Correspondences.mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk)
        };

    }

}