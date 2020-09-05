using System.Collections.Generic;

namespace Goldstandard
{
    class Brain
    {
        public static void brainGoldStandard()
        {  
            Brain_2_mart_export_brain();
            mart_export_brain_2_all_gene_disease_pmid_associations();
            mart_export_brain_2_gene2pubtatorcentral();
        }

        public static void mart_export_brain_2_gene2pubtatorcentral()
        {
            List<Gene> mart_export_brain_dt = Methods.readXmlFile(Datasets.mart_export_brain_Path);
            List<Gene> gene2pubtatorcentral_dt = Methods.readXmlFile(Datasets.gene2pubtatorcentral_Path);

            (List<Goldstandard> mart_export_brain_2_gene2pubtatorcentral_TRUE, List<Goldstandard> mart_export_brain_2_gene2pubtatorcentral_FALSE) = Methods.compareUsingGeneName(mart_export_brain_dt, gene2pubtatorcentral_dt, 200);
            Methods.createGoldStandard(mart_export_brain_2_gene2pubtatorcentral_TRUE, mart_export_brain_2_gene2pubtatorcentral_FALSE, "mart_export_brain_2_gene2pubtatorcentral");
        }

        public static void Brain_2_mart_export_brain()
        {
            List<Gene> Brain_dt = Methods.readXmlFile(Datasets.Brain_Path);
            List<Gene> mart_export_brain_dt = Methods.readXmlFile(Datasets.mart_export_brain_Path);

            (List<Goldstandard> Brain_2_mart_export_brain_TRUE, List<Goldstandard> Brain_2_mart_export_brain_FALSE) = Methods.compareUsingGeneId(Brain_dt, mart_export_brain_dt, 200);
            Methods.createGoldStandard(Brain_2_mart_export_brain_TRUE, Brain_2_mart_export_brain_FALSE, "Brain_2_mart_export_brain");
        }

        public static void mart_export_brain_2_all_gene_disease_pmid_associations()
        {
            List<Gene> mart_export_brain_dt = Methods.readXmlFile(Datasets.mart_export_brain_Path);
            List<Gene> all_gene_disease_pmid_associations_dt = Methods.readXmlFile(Datasets.all_gene_disease_pmid_associations_Path);

            (List<Goldstandard> mart_export_brain_2_all_gene_disease_pmid_associations_TRUE, List<Goldstandard> mart_export_brain_2_all_gene_disease_pmid_associations_FALSE) = Methods.compareUsingGeneName(mart_export_brain_dt, all_gene_disease_pmid_associations_dt, 200);
            Methods.createGoldStandard(mart_export_brain_2_all_gene_disease_pmid_associations_TRUE, mart_export_brain_2_all_gene_disease_pmid_associations_FALSE, "mart_export_brain_2_all_gene_disease_pmid_associations");
        }
    }
}