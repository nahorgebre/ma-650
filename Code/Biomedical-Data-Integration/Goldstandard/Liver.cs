using System;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;

namespace Goldstandard
{
    class Liver
    {
        public static void liverGoldStandard()
        {
            Liver_2_mart_export_liver(Datasets.Liver_dt, Datasets.mart_export_liver_dt);
            mart_export_liver_2_all_gene_disease_pmid_associations(Datasets.mart_export_liver_dt, Datasets.all_gene_disease_pmid_associations_dt);
            mart_export_liver_2_gene2pubtatorcentral(Datasets.mart_export_liver_dt, Datasets.gene2pubtatorcentral_dt);
        }

        public static void mart_export_liver_2_gene2pubtatorcentral(List<Gene> mart_export_liver_dt, List<Gene> gene2pubtatorcentral_dt)
        {
            (List<Goldstandard> mart_export_liver_2_gene2pubtatorcentral_TRUE, List<Goldstandard> mart_export_liver_2_gene2pubtatorcentral_FALSE) = Methods.compareUsingGeneName(mart_export_liver_dt, gene2pubtatorcentral_dt, 200);
            Methods.createGoldStandard(mart_export_liver_2_gene2pubtatorcentral_TRUE, mart_export_liver_2_gene2pubtatorcentral_FALSE, "mart_export_liver_2_gene2pubtatorcentral");
        }

        public static void Liver_2_mart_export_liver(List<Gene> Liver_dt, List<Gene> mart_export_liver_dt)
        {
            (List<Goldstandard> Liver_2_mart_export_liver_TRUE, List<Goldstandard> Liver_2_mart_export_liver_FALSE) = Methods.compareUsingGeneId(Liver_dt, mart_export_liver_dt, 200);
            Methods.createGoldStandard(Liver_2_mart_export_liver_TRUE, Liver_2_mart_export_liver_FALSE, "Liver_2_mart_export_liver");
        }

        public static void mart_export_liver_2_all_gene_disease_pmid_associations(List<Gene> mart_export_liver_dt, List<Gene> all_gene_disease_pmid_associations_dt)
        {
            (List<Goldstandard> mart_export_liver_2_all_gene_disease_pmid_associations_TRUE, List<Goldstandard> mart_export_liver_2_all_gene_disease_pmid_associations_FALSE) = Methods.compareUsingGeneName(mart_export_liver_dt, all_gene_disease_pmid_associations_dt, 200);
            Methods.createGoldStandard(mart_export_liver_2_all_gene_disease_pmid_associations_TRUE, mart_export_liver_2_all_gene_disease_pmid_associations_FALSE, "mart_export_liver_2_all_gene_disease_pmid_associations");
        }
    }
}