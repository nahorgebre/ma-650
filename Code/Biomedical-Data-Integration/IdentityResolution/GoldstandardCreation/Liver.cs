using System.Collections.Generic;

namespace GoldstandardCreation
{
    class Liver
    {
        public static void run() {
            Liver_2_mart_export_liver();
            mart_export_liver_2_all_gene_disease_pmid_associations();
            mart_export_liver_2_gene2pubtatorcentral();
        }
        public static void Liver_2_mart_export_liver() {

        }

        public static void mart_export_liver_2_all_gene_disease_pmid_associations() {
            List<Goldstandard> goldstandardList = Methods.compareGeneNameLargeFiles(Datasets.mart_export_liver_path, Datasets.all_gene_disease_pmid_associations_path);
        }

        public static void mart_export_liver_2_gene2pubtatorcentral() {
            List<Goldstandard> goldstandardList = Methods.compareGeneNameLargeFiles(Datasets.mart_export_liver_path, Datasets.gene2pubtatorcentral_path);
        }
    }
}