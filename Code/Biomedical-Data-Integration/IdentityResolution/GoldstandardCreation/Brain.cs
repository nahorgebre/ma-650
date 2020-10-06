using System.Collections.Generic;

namespace GoldstandardCreation
{
    class Brain
    {
        
        public static void run() {
            Brain_2_mart_export_brain();
            mart_export_brain_2_all_gene_disease_pmid_associations();
            mart_export_brain_2_gene2pubtatorcentral();
        }
        
        public static void Brain_2_mart_export_brain() {
            // ensembl Id
            (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Brain_path, Datasets.mart_export_brain_path, 1);
            Methods.createOuput("Brain_2_mart_export_brain", "true.csv", trueList);
            Methods.createOuput("Brain_2_mart_export_brain", "false.csv", falseList);
        }
        
        public static void mart_export_brain_2_all_gene_disease_pmid_associations() {
            // gene name
            (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.mart_export_brain_path, Datasets.all_gene_disease_pmid_associations_path, 3);
            Methods.createOuput("mart_export_brain_2_all_gene_disease_pmid_associations", "true.csv", trueList);
            Methods.createOuput("mart_export_brain_2_all_gene_disease_pmid_associations", "false.csv", falseList);
        }
        
        public static void mart_export_brain_2_gene2pubtatorcentral() {
            // gene name
            (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.mart_export_brain_path, Datasets.gene2pubtatorcentral_path, 3);
            Methods.createOuput("mart_export_brain_2_gene2pubtatorcentral", "true.csv", trueList);
            Methods.createOuput("mart_export_brain_2_gene2pubtatorcentral", "false.csv", falseList);
        }

    }
}