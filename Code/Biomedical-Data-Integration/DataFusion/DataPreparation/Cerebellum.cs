using System;
using System.Collections.Generic;

namespace DataPreparation
{

    class Cerebellum
    {

        public static void run() 
        {
            Methods.getDistinctRecordIds(Cerebellum_dt_recordIds, "Cerebellum_dt");
            Methods.getDistinctRecordIds(mart_export_cerebellum_dt_recordIds, "mart_export_cerebellum_dt");
        }

        public static List<(int, String)> Cerebellum_dt_recordIds = new List<(int, String)>
        {
            (1, Correspondences.Cerebellum_2_mart_export_cerebellum),
            (2, Correspondences.Heart_2_Cerebellum)
        };

        public static List<(int, String)> mart_export_cerebellum_dt_recordIds = new List<(int, String)>
        {
            (2, Correspondences.Cerebellum_2_mart_export_cerebellum),
            (1, Correspondences.mart_export_cerebellum_2_all_gene_disease_pmid_associations),
            (1, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_1),
            (1, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_2),
            (1, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_3),
            (1, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_4),
            (1, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_5),
            (1, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_6),
            (1, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_7),
            (1, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_8),
            (1, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_9),
            (1, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_10),
            (1, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_11),
            (1, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_12),
            (1, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_13),
            (1, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_14),
            (1, Correspondences.mart_export_cerebellum_2_gene2pubtatorcentral_15)
        };

    }

}