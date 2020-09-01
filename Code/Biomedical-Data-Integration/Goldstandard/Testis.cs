using System;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;

namespace Goldstandard
{
    class Testis
    {
        public static void testisGoldStandard()
        {
            Testis_2_mart_export_testis(Datasets.Testis_dt, Datasets.mart_export_testis_dt);
            mart_export_testis_2_all_gene_disease_pmid_associations(Datasets.mart_export_testis_dt, Datasets.all_gene_disease_pmid_associations_dt);
            mart_export_testis_2_gene2pubtatorcentral(Datasets.mart_export_testis_dt, Datasets.gene2pubtatorcentral_dt);
        }

        public static void mart_export_testis_2_gene2pubtatorcentral(List<Gene> mart_export_testis_dt, List<Gene> gene2pubtatorcentral_dt)
        {
            (List<Goldstandard> mart_export_testis_2_gene2pubtatorcentral_TRUE, List<Goldstandard> mart_export_testis_2_gene2pubtatorcentral_FALSE) = Methods.compareUsingGeneName(mart_export_testis_dt, gene2pubtatorcentral_dt, 200);
            Methods.createGoldStandard(mart_export_testis_2_gene2pubtatorcentral_TRUE, mart_export_testis_2_gene2pubtatorcentral_FALSE, "mart_export_testis_2_gene2pubtatorcentral");
        }

        public static void Testis_2_mart_export_testis(List<Gene> Testis_dt, List<Gene> mart_export_testis_dt)
        {
            (List<Goldstandard> Testis_2_mart_export_testis_TRUE, List<Goldstandard> Testis_2_mart_export_testis_FALSE) = Methods.compareUsingGeneId(Testis_dt, mart_export_testis_dt, 200);
            Methods.createGoldStandard(Testis_2_mart_export_testis_TRUE, Testis_2_mart_export_testis_FALSE, "Testis_2_mart_export_testis");
        }

        public static void mart_export_testis_2_all_gene_disease_pmid_associations(List<Gene> mart_export_testis_dt, List<Gene> all_gene_disease_pmid_associations_dt)
        {
            (List<Goldstandard> mart_export_testis_2_all_gene_disease_pmid_associations_TRUE, List<Goldstandard> mart_export_testis_2_all_gene_disease_pmid_associations_FALSE) = Methods.compareUsingGeneName(mart_export_testis_dt, all_gene_disease_pmid_associations_dt, 200);
            Methods.createGoldStandard(mart_export_testis_2_all_gene_disease_pmid_associations_TRUE, mart_export_testis_2_all_gene_disease_pmid_associations_FALSE, "mart_export_testis_2_all_gene_disease_pmid_associations");
        }
    }
}