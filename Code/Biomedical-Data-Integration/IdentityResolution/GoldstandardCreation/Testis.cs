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
            // gene name
            (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.mart_export_testis_path, Datasets.all_gene_disease_pmid_associations_path, 3);
            Methods.createOuput("mart_export_testis_2_all_gene_disease_pmid_associations", "true.csv", trueList);
            Methods.createOuput("mart_export_testis_2_all_gene_disease_pmid_associations", "false.csv", falseList);
        }

        public static void mart_export_testis_2_gene2pubtatorcentral() {
            // gene name
            (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.mart_export_testis_path, Datasets.gene2pubtatorcentral_path, 3);
            Methods.createOuput("mart_export_testis_2_gene2pubtatorcentral", "true.csv", trueList);
            Methods.createOuput("mart_export_testis_2_gene2pubtatorcentral", "false.csv", falseList);
        }

        public static void Testis_2_mart_export_testis() {
            // ensembl id
            (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Testis_path, Datasets.mart_export_testis_path, 1);
            Methods.createOuput("Testis_2_mart_export_testis", "true.csv", trueList);
            Methods.createOuput("Testis_2_mart_export_testis", "False.csv", falseList);
        }

    }
}