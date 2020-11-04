using System;
using System.Collections.Generic;

namespace DataPreparation
{
    class Kidney
    {

        public static void run() {
            Methods.getDistinctRecordIds(Kidney_dt_recordIds, "Kidney_dt");
            Methods.getDistinctRecordIds(mart_export_kidney_dt_recordIds, "mart_export_kidney_dt");
        }

        public static List<(int, String)> Kidney_dt_recordIds = new List<(int, String)>
        {
            (1, Correspondences.Kidney_2_mart_export_kidney),
            (2, Correspondences.Heart_2_Kidney)
        };

        public static List<(int, String)> mart_export_kidney_dt_recordIds = new List<(int, String)>
        {
            (2, Correspondences.Kidney_2_mart_export_kidney),
            (1, Correspondences.mart_export_kidney_2_all_gene_disease_pmid_associations),
            (1, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_1),
            (1, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_2),
            (1, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_3),
            (1, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_4),
            (1, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_5),
            (1, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_6),
            (1, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_7),
            (1, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_8),
            (1, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_9),
            (1, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_10),
            (1, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_11),
            (1, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_12),
            (1, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_13),
            (1, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_14),
            (1, Correspondences.mart_export_kidney_2_gene2pubtatorcentral_15)
        };

    }

}