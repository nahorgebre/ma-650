using System.Collections.Generic;

namespace GoldstandardCreation
{
    class Cerebellum
    {
        public static void run() {
            Cerebellum_2_mart_export_cerebellum();
            mart_export_cerebellum_2_all_gene_disease_pmid_associations();
            mart_export_cerebellum_2_gene2pubtatorcentral();
        }
        public static void Cerebellum_2_mart_export_cerebellum() {
            List<Goldstandard> goldstandardList = Methods.compareEnsemblId(Datasets.Cerebellum_path, Datasets.mart_export_cerebellum_path);
            Methods.createOuput("Cerebellum_2_mart_export_cerebellum", goldstandardList);
        }

        public static void mart_export_cerebellum_2_all_gene_disease_pmid_associations() {
            List<Goldstandard> goldstandardList = Methods.compareGeneNameLargeFiles(Datasets.mart_export_cerebellum_path, Datasets.all_gene_disease_pmid_associations_path);
            Methods.createOuput("mart_export_cerebellum_2_all_gene_disease_pmid_associations", goldstandardList);
        }

        public static void mart_export_cerebellum_2_gene2pubtatorcentral() {
            List<Goldstandard> goldstandardList = Methods.compareGeneNameLargeFiles(Datasets.mart_export_cerebellum_path, Datasets.gene2pubtatorcentral_path);
            Methods.createOuput("mart_export_cerebellum_2_gene2pubtatorcentral", goldstandardList);
        }
    }
}