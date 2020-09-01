using System;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;

namespace Goldstandard
{
    class Cerebellum
    {
        public static void cerebellumGoldStandard()
        {
            Cerebellum_2_mart_export_cerebellum(Datasets.Cerebellum_dt, Datasets.mart_export_cerebellum_dt);
            mart_export_cerebellum_2_all_gene_disease_pmid_associations(Datasets.mart_export_cerebellum_dt, Datasets.all_gene_disease_pmid_associations_dt);
            mart_export_cerebellum_2_gene2pubtatorcentral(Datasets.mart_export_cerebellum_dt, Datasets.gene2pubtatorcentral_dt);
        }

        public static void mart_export_cerebellum_2_gene2pubtatorcentral(List<Gene> mart_export_cerebellum_dt, List<Gene> gene2pubtatorcentral_dt)
        {
            (List<Goldstandard> mart_export_cerebellum_2_gene2pubtatorcentral_TRUE, List<Goldstandard> mart_export_cerebellum_2_gene2pubtatorcentral_FALSE) = Methods.compareUsingGeneName(mart_export_cerebellum_dt, gene2pubtatorcentral_dt, 200);
            Methods.createGoldStandard(mart_export_cerebellum_2_gene2pubtatorcentral_TRUE, mart_export_cerebellum_2_gene2pubtatorcentral_FALSE, "mart_export_cerebellum_2_gene2pubtatorcentral");
        }

        public static void Cerebellum_2_mart_export_cerebellum(List<Gene> Cerebellum_dt, List<Gene> mart_export_cerebellum_dt)
        {
            (List<Goldstandard> Cerebellum_2_mart_export_cerebellum_TRUE, List<Goldstandard> Cerebellum_2_mart_export_cerebellum_FALSE) = Methods.compareUsingGeneId(Cerebellum_dt, mart_export_cerebellum_dt, 200);
            Methods.createGoldStandard(Cerebellum_2_mart_export_cerebellum_TRUE, Cerebellum_2_mart_export_cerebellum_FALSE, "Cerebellum_2_mart_export_cerebellum");
        }

        public static void mart_export_cerebellum_2_all_gene_disease_pmid_associations(List<Gene> mart_export_cerebellum_dt, List<Gene> all_gene_disease_pmid_associations_dt)
        {
            (List<Goldstandard> mart_export_cerebellum_2_all_gene_disease_pmid_associations_TRUE, List<Goldstandard> mart_export_cerebellum_2_all_gene_disease_pmid_associations_FALSE) = Methods.compareUsingGeneName(mart_export_cerebellum_dt, all_gene_disease_pmid_associations_dt, 200);
            Methods.createGoldStandard(mart_export_cerebellum_2_all_gene_disease_pmid_associations_TRUE, mart_export_cerebellum_2_all_gene_disease_pmid_associations_FALSE, "mart_export_cerebellum_2_all_gene_disease_pmid_associations");
        }
    }
}