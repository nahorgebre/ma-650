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
            // ensembl id
            (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Cerebellum_path, Datasets.mart_export_cerebellum_path, 1);
            Methods.createOuput("Cerebellum_2_mart_export_cerebellum", "true.csv", trueList);
            Methods.createOuput("Cerebellum_2_mart_export_cerebellum", "false.csv", falseList);
        }

        public static void mart_export_cerebellum_2_all_gene_disease_pmid_associations() {
            // gene name
            (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.mart_export_cerebellum_path, Datasets.all_gene_disease_pmid_associations_path, 3);
            Methods.createOuput("mart_export_cerebellum_2_all_gene_disease_pmid_associations", "true.csv", trueList);
            Methods.createOuput("mart_export_cerebellum_2_all_gene_disease_pmid_associations", "false.csv", falseList);
        }

        public static void mart_export_cerebellum_2_gene2pubtatorcentral() {
            // gene name
            (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.mart_export_cerebellum_path, Datasets.gene2pubtatorcentral_path, 3);
            Methods.createOuput("mart_export_cerebellum_2_gene2pubtatorcentral", "true.csv", trueList);
            Methods.createOuput("mart_export_cerebellum_2_gene2pubtatorcentral", "false.csv", falseList);
        }

    }
}