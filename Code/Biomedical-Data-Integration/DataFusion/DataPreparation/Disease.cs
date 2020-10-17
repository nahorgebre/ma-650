using System;
using System.Collections.Generic;

namespace DataPreparation
{
    class Disease
    {

            HashSet<String> all_gene_disease_pmid_associations_dt = new HashSet<String>();
            public static List<(int, String)> all_gene_disease_pmid_associations_dt_recordIds = new List<(int, String)>
            {
                (2, Correspondences.mart_export_brain_2_all_gene_disease_pmid_associations),
                (2, Correspondences.mart_export_cerebellum_2_all_gene_disease_pmid_associations),
                (2, Correspondences.Heart_Ensembl_NCBI_Crosswalk_2_all_gene_disease_pmid_associations),
                (2, Correspondences.mart_export_kidney_2_all_gene_disease_pmid_associations),
                (2, Correspondences.mart_export_liver_2_all_gene_disease_pmid_associations),
                (2, Correspondences.mart_export_testis_2_all_gene_disease_pmid_associations)
            };

    }
}