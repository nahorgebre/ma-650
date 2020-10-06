using System.Collections.Generic;

namespace GoldstandardCreation
{
    class Testis
    {
        public static void run() {
            mart_export_testis_2_all_gene_disease_pmid_associations();
            mart_export_testis_2_gene2pubtatorcentral();
            Testis_2_mart_export_testis();
        }
        
        public static void mart_export_testis_2_all_gene_disease_pmid_associations() {
            List<Goldstandard> goldstandardList = Methods.compareGeneNameLargeFiles(Datasets.mart_export_testis_path, Datasets.all_gene_disease_pmid_associations_path);
            Methods.createOuput("mart_export_testis_2_all_gene_disease_pmid_associations", "true.csv", goldstandardList);
        }

        public static void mart_export_testis_2_gene2pubtatorcentral() {
            List<Goldstandard> goldstandardList = Methods.compareGeneNameLargeFiles(Datasets.mart_export_testis_path, Datasets.gene2pubtatorcentral_path);
            Methods.createOuput("mart_export_testis_2_gene2pubtatorcentral", "true.csv", goldstandardList);
        }

        public static void Testis_2_mart_export_testis() {
            List<Goldstandard> goldstandardList = Methods.compareEnsemblId(Datasets.Testis_path, Datasets.mart_export_testis_path);
            Methods.createOuput("Testis_2_mart_export_testis", "true.csv", goldstandardList);
        }
    }
}