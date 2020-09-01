using System;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;

namespace Goldstandard
{
    class Kidney
    {
        public static void kidneyGoldStandard()
        {
            Kidney_2_mart_export_kidney(Datasets.Kidney_dt, Datasets.mart_export_kidney_dt);
            mart_export_kidney_2_all_gene_disease_pmid_associations(Datasets.mart_export_kidney_dt, Datasets.all_gene_disease_pmid_associations_dt);
            mart_export_kidney_2_gene2pubtatorcentral(Datasets.mart_export_kidney_dt, Datasets.gene2pubtatorcentral_dt);
        }

        public static void mart_export_kidney_2_gene2pubtatorcentral(List<Gene> mart_export_kidney_dt, List<Gene> gene2pubtatorcentral_dt)
        {
            (List<Goldstandard> mart_export_kidney_2_gene2pubtatorcentral_TRUE, List<Goldstandard> mart_export_kidney_2_gene2pubtatorcentral_FALSE) = Methods.compareUsingGeneName(mart_export_kidney_dt, gene2pubtatorcentral_dt, 200);
            Methods.createGoldStandard(mart_export_kidney_2_gene2pubtatorcentral_TRUE, mart_export_kidney_2_gene2pubtatorcentral_FALSE, "mart_export_kidney_2_gene2pubtatorcentral");
        }

        public static void Kidney_2_mart_export_kidney(List<Gene> Kidney_dt, List<Gene> mart_export_kidney_dt)
        {
            (List<Goldstandard> Kidney_2_mart_export_kidney_TRUE, List<Goldstandard> Kidney_2_mart_export_kidney_FALSE) = Methods.compareUsingGeneId(Kidney_dt, mart_export_kidney_dt, 200);
            Methods.createGoldStandard(Kidney_2_mart_export_kidney_TRUE, Kidney_2_mart_export_kidney_FALSE, "Kidney_2_mart_export_kidney");
        }

        public static void mart_export_kidney_2_all_gene_disease_pmid_associations(List<Gene> mart_export_kidney_dt, List<Gene> all_gene_disease_pmid_associations_dt)
        {
            (List<Goldstandard> mart_export_kidney_2_all_gene_disease_pmid_associations_TRUE, List<Goldstandard> mart_export_kidney_2_all_gene_disease_pmid_associations_FALSE) = Methods.compareUsingGeneName(mart_export_kidney_dt, all_gene_disease_pmid_associations_dt, 200);
            Methods.createGoldStandard(mart_export_kidney_2_all_gene_disease_pmid_associations_TRUE, mart_export_kidney_2_all_gene_disease_pmid_associations_FALSE, "mart_export_kidney_2_all_gene_disease_pmid_associations");
        }
    }
}