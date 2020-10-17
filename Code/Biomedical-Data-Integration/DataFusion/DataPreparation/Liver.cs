using System;
using System.Collections.Generic;

namespace DataPreparation
{
    class Liver
    {

            HashSet<String> Liver_dt = new HashSet<String>();
            List<(int, String)> Liver_dt_recordIds = new List<(int, String)>
            {
                (1, Correspondences.Liver_2_mart_export_liver),
                (2, Correspondences.Heart_2_Liver)
            };

            HashSet<String> mart_export_liver_dt = new HashSet<String>();
            List<(int, String)> mart_export_liver_dt_recordIds = new List<(int, String)>
            {
                (2, Correspondences.Liver_2_mart_export_liver),
                (1, Correspondences.mart_export_liver_2_all_gene_disease_pmid_associations),
                (1, Correspondences.mart_export_liver_2_gene2pubtatorcentral_1),
                (1, Correspondences.mart_export_liver_2_gene2pubtatorcentral_2),
                (1, Correspondences.mart_export_liver_2_gene2pubtatorcentral_3),
                (1, Correspondences.mart_export_liver_2_gene2pubtatorcentral_4),
                (1, Correspondences.mart_export_liver_2_gene2pubtatorcentral_5),
                (1, Correspondences.mart_export_liver_2_gene2pubtatorcentral_6),
                (1, Correspondences.mart_export_liver_2_gene2pubtatorcentral_7),
                (1, Correspondences.mart_export_liver_2_gene2pubtatorcentral_8),
                (1, Correspondences.mart_export_liver_2_gene2pubtatorcentral_9),
                (1, Correspondences.mart_export_liver_2_gene2pubtatorcentral_10),
                (1, Correspondences.mart_export_liver_2_gene2pubtatorcentral_11),
                (1, Correspondences.mart_export_liver_2_gene2pubtatorcentral_12),
                (1, Correspondences.mart_export_liver_2_gene2pubtatorcentral_13),
                (1, Correspondences.mart_export_liver_2_gene2pubtatorcentral_14),
                (1, Correspondences.mart_export_liver_2_gene2pubtatorcentral_15)
            };

    }
}