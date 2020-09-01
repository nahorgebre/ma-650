using System;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;

namespace Goldstandard
{
    class Heart
    {
        public static void heartGoldStandard()
        {
            gene_disease_pmid_associations_2_Ensemble_NCBI_Crosswalk(Datasets.all_gene_disease_pmid_associations_dt, Datasets.Heart_Ensembl_NCBI_Crosswalk_dt);
            Heart_2_Heart_Ensembl_NCBI_Crosswalk(Datasets.Heart_dt, Datasets.Heart_Ensembl_NCBI_Crosswalk_dt);
            mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk(Datasets.mart_export_heart_dt, Datasets.Heart_Ensembl_NCBI_Crosswalk_dt);
            gene2pubtatorcentral_2_Ensemble_NCBI_Crosswalk(Datasets.gene2pubtatorcentral_dt, Datasets.Heart_Ensembl_NCBI_Crosswalk_dt);
        }

        public static void gene2pubtatorcentral_2_Ensemble_NCBI_Crosswalk(List<Gene> gene2pubtatorcentral_dt, List<Gene> Heart_Ensembl_NCBI_Crosswalk_dt)
        {
            (List<Goldstandard> gene2pubtatorcentral_2_Ensemble_NCBI_Crosswalk_TRUE, List<Goldstandard> gene2pubtatorcentral_2_Ensemble_NCBI_Crosswalk_FALSE) = Methods.compareUsingGeneName(gene2pubtatorcentral_dt, Heart_Ensembl_NCBI_Crosswalk_dt, 200);
            Methods.createGoldStandard(gene2pubtatorcentral_2_Ensemble_NCBI_Crosswalk_TRUE, gene2pubtatorcentral_2_Ensemble_NCBI_Crosswalk_FALSE, "gene_disease_pmid_associations_2_Ensemble_NCBI_Crosswalk");
        }

        public static void gene_disease_pmid_associations_2_Ensemble_NCBI_Crosswalk(List<Gene> all_gene_disease_pmid_associations_dt, List<Gene> Heart_Ensembl_NCBI_Crosswalk_dt)
        {
            (List<Goldstandard> gene_disease_pmid_associations_2_Ensemble_NCBI_Crosswalk_TRUE, List<Goldstandard> gene_disease_pmid_associations_2_Ensemble_NCBI_Crosswalk_FALSE) = Methods.compareUsingGeneName(all_gene_disease_pmid_associations_dt, Heart_Ensembl_NCBI_Crosswalk_dt, 200);
            Methods.createGoldStandard(gene_disease_pmid_associations_2_Ensemble_NCBI_Crosswalk_TRUE, gene_disease_pmid_associations_2_Ensemble_NCBI_Crosswalk_FALSE, "gene_disease_pmid_associations_2_Ensemble_NCBI_Crosswalk");
        }

        public static void Heart_2_Heart_Ensembl_NCBI_Crosswalk(List<Gene> Heart_dt, List<Gene> Heart_Ensembl_NCBI_Crosswalk_dt)
        {
            (List<Goldstandard> Heart_2_Heart_Ensembl_NCBI_Crosswalk_TRUE, List<Goldstandard> Heart_2_Heart_Ensembl_NCBI_Crosswalk_FALSE) = Methods.compareUsingGeneId(Heart_dt, Heart_Ensembl_NCBI_Crosswalk_dt, 200);
            Methods.createGoldStandard(Heart_2_Heart_Ensembl_NCBI_Crosswalk_TRUE, Heart_2_Heart_Ensembl_NCBI_Crosswalk_FALSE, "Heart_2_Heart_Ensembl_NCBI_Crosswalk");
        }

        public static void mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk(List<Gene> mart_export_heart_dt, List<Gene> Heart_Ensembl_NCBI_Crosswalk_dt)
        {
            (List<Goldstandard> mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk_TRUE, List<Goldstandard> mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk_FALSE) = Methods.compareUsingGeneId(mart_export_heart_dt, Heart_Ensembl_NCBI_Crosswalk_dt, 200);
            Methods.createGoldStandard(mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk_TRUE, mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk_FALSE, "mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk");
        }
    }
}