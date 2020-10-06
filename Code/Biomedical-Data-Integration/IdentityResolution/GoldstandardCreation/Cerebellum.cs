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

        }

        public static void mart_export_cerebellum_2_all_gene_disease_pmid_associations() {
            List<Goldstandard> goldstandardList = Methods.compareGeneNameLargeFiles(Datasets.mart_export_cerebellum_path, Datasets.all_gene_disease_pmid_associations_path);
        }

        public static void mart_export_cerebellum_2_gene2pubtatorcentral() {
            List<Goldstandard> goldstandardList = Methods.compareGeneNameLargeFiles(Datasets.mart_export_cerebellum_path, Datasets.gene2pubtatorcentral_path);
        }
    }
}