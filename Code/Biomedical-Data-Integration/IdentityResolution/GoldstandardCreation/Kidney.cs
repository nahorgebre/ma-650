using System.Collections.Generic;

namespace GoldstandardCreation
{
    class Kidney
    {

        public static void run() {
            Kidney_2_mart_export_kidney();
            mart_export_kidney_2_all_gene_disease_pmid_associations();
            mart_export_kidney_2_gene2pubtatorcentral();
        }
        
        public static void Kidney_2_mart_export_kidney() {
            // ensembl id
            (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Kidney_path, Datasets.mart_export_kidney_path, 1);
            Methods.createOuput("Kidney_2_mart_export_kidney", "true.csv", trueList);
            Methods.createOuput("Kidney_2_mart_export_kidney", "false.csv", falseList);
        }

        public static void mart_export_kidney_2_all_gene_disease_pmid_associations() {
            // gene name
            (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.mart_export_kidney_path, Datasets.all_gene_disease_pmid_associations_path, 3);
            Methods.createOuput("mart_export_kidney_2_all_gene_disease_pmid_associations", "true.csv", trueList);
            Methods.createOuput("mart_export_kidney_2_all_gene_disease_pmid_associations", "false.csv", falseList);         
        }

        public static void mart_export_kidney_2_gene2pubtatorcentral() {
            // gene name
            (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.mart_export_kidney_path, Datasets.gene2pubtatorcentral_path, 3);
            Methods.createOuput("mart_export_kidney_2_gene2pubtatorcentral", "true.csv", trueList);
            Methods.createOuput("mart_export_kidney_2_gene2pubtatorcentral", "false.csv", falseList);
        }
        
    }
}