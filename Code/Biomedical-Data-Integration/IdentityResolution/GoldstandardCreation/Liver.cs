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
            // ensembl id
            (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Liver_path, Datasets.mart_export_liver_path, 1);
            Methods.createOuput("Liver_2_mart_export_liver", "true.csv", trueList);
            Methods.createOuput("Liver_2_mart_export_liver", "false.csv", falseList);
        }

        public static void mart_export_liver_2_all_gene_disease_pmid_associations() {
            // gene name
            (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.mart_export_liver_path, Datasets.all_gene_disease_pmid_associations_path, 3);
            Methods.createOuput("mart_export_liver_2_all_gene_disease_pmid_associations", "true.csv", trueList);
            Methods.createOuput("mart_export_liver_2_all_gene_disease_pmid_associations", "false.csv", falseList);
        }

        public static void mart_export_liver_2_gene2pubtatorcentral() {
            // gene name
            (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.mart_export_liver_path, Datasets.gene2pubtatorcentral_path, 3);
            Methods.createOuput("mart_export_liver_2_gene2pubtatorcentral", "true.csv", trueList);
            Methods.createOuput("mart_export_liver_2_gene2pubtatorcentral", "false.csv", falseList);
        }
    
    }
}