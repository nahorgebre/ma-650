using System;
using System.Collections.Generic;

namespace DataPreparation
{
    class Testis
    {

        public static void run()
        {
            Methods.getDistinctRecordIds(mart_export_testis_dt_recordIds, "mart_export_testis_dt");
            Methods.getDistinctRecordIds(Testis_dt_recordIds, "Testis_dt");
        }

        public static List<(int, String)> mart_export_testis_dt_recordIds = new List<(int, String)>
        {
            (2, Correspondences.Testis_2_mart_export_testis),
            (1, Correspondences.mart_export_testis_2_all_gene_disease_pmid_associations),
            (1, Correspondences.mart_export_testis_2_gene2pubtatorcentral_1),
            (1, Correspondences.mart_export_testis_2_gene2pubtatorcentral_2),
            (1, Correspondences.mart_export_testis_2_gene2pubtatorcentral_3),
            (1, Correspondences.mart_export_testis_2_gene2pubtatorcentral_4),
            (1, Correspondences.mart_export_testis_2_gene2pubtatorcentral_5),
            (1, Correspondences.mart_export_testis_2_gene2pubtatorcentral_6),
            (1, Correspondences.mart_export_testis_2_gene2pubtatorcentral_7),
            (1, Correspondences.mart_export_testis_2_gene2pubtatorcentral_8),
            (1, Correspondences.mart_export_testis_2_gene2pubtatorcentral_9),
            (1, Correspondences.mart_export_testis_2_gene2pubtatorcentral_10),
            (1, Correspondences.mart_export_testis_2_gene2pubtatorcentral_11),
            (1, Correspondences.mart_export_testis_2_gene2pubtatorcentral_12),
            (1, Correspondences.mart_export_testis_2_gene2pubtatorcentral_13),
            (1, Correspondences.mart_export_testis_2_gene2pubtatorcentral_14),
            (1, Correspondences.mart_export_testis_2_gene2pubtatorcentral_15)
        };

        public static List<(int, String)> Testis_dt_recordIds = new List<(int, String)>
        {
            (1, Correspondences.Testis_2_mart_export_testis),
            (2, Correspondences.Heart_2_Testis)
        };

    }

}