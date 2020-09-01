using System;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;

namespace Goldstandard
{
    class Brain
    {
        public static void brainGoldStandard()
        {  
            Brain_2_mart_export_brain(Datasets.Brain_dt, Datasets.mart_export_brain_dt);
            mart_export_brain_2_all_gene_disease_pmid_associations(Datasets.mart_export_brain_dt, Datasets.all_gene_disease_pmid_associations_dt);
            mart_export_brain_2_gene2pubtatorcentral(Datasets.mart_export_brain_dt, Datasets.gene2pubtatorcentral_dt);
        }

        public static void mart_export_brain_2_gene2pubtatorcentral(List<Gene> mart_export_brain_dt, List<Gene> gene2pubtatorcentral_dt)
        {
            (List<Goldstandard> mart_export_brain_2_gene2pubtatorcentral_TRUE, List<Goldstandard> mart_export_brain_2_gene2pubtatorcentral_FALSE) = Methods.compareUsingGeneName(mart_export_brain_dt, gene2pubtatorcentral_dt, 200);
            Methods.createGoldStandard(mart_export_brain_2_gene2pubtatorcentral_TRUE, mart_export_brain_2_gene2pubtatorcentral_FALSE, "mart_export_brain_2_gene2pubtatorcentral");
        }

        public static void Brain_2_mart_export_brain(List<Gene> Brain_dt, List<Gene> mart_export_brain_dt)
        {
            (List<Goldstandard> Brain_2_mart_export_brain_TRUE, List<Goldstandard> Brain_2_mart_export_brain_FALSE) = Methods.compareUsingGeneId(Brain_dt, mart_export_brain_dt, 200);
            Methods.createGoldStandard(Brain_2_mart_export_brain_TRUE, Brain_2_mart_export_brain_FALSE, "Brain_2_mart_export_brain");
        }

        public static void mart_export_brain_2_all_gene_disease_pmid_associations(List<Gene> mart_export_brain_dt, List<Gene> all_gene_disease_pmid_associations_dt)
        {
            (List<Goldstandard> mart_export_brain_2_all_gene_disease_pmid_associations_TRUE, List<Goldstandard> mart_export_brain_2_all_gene_disease_pmid_associations_FALSE) = Methods.compareUsingGeneName(mart_export_brain_dt, all_gene_disease_pmid_associations_dt, 200);
            Methods.createGoldStandard(mart_export_brain_2_all_gene_disease_pmid_associations_TRUE, mart_export_brain_2_all_gene_disease_pmid_associations_FALSE, "mart_export_brain_2_all_gene_disease_pmid_associations");
        }
    }
}