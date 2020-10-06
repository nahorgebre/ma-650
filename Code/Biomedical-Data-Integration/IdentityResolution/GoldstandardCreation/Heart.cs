using System.Collections.Generic;

namespace GoldstandardCreation
{
    class Heart
    {
    
        public static void run() {
            Heart_2_Heart_Ensembl_NCBI_Crosswalk();
            Heart_Ensembl_NCBI_Crosswalk_2_all_gene_disease_pmid_associations();
            Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral();
            mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk();
        }
        
        public static void Heart_2_Heart_Ensembl_NCBI_Crosswalk() {
            // ensembl id
            (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Heart_path, Datasets.Heart_Ensembl_NCBI_Crosswalk_path, 1);
            Methods.createOuput("Heart_2_Heart_Ensembl_NCBI_Crosswalk", "true.csv", trueList);
            Methods.createOuput("Heart_2_Heart_Ensembl_NCBI_Crosswalk", "false.csv", falseList);
        }

        public static void Heart_Ensembl_NCBI_Crosswalk_2_all_gene_disease_pmid_associations() {
            // gene name
            (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Heart_Ensembl_NCBI_Crosswalk_path, Datasets.all_gene_disease_pmid_associations_path, 3);
            Methods.createOuput("Heart_Ensembl_NCBI_Crosswalk_2_all_gene_disease_pmid_associations", "true.csv", trueList);
            Methods.createOuput("Heart_Ensembl_NCBI_Crosswalk_2_all_gene_disease_pmid_associations", "false.csv", falseList);      
        }

        public static void Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral() {
            // gene name
            (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Heart_Ensembl_NCBI_Crosswalk_path, Datasets.gene2pubtatorcentral_path, 3);
            Methods.createOuput("Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral", "true.csv", trueList);
            Methods.createOuput("Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral", "false.csv", falseList);
        }

        public static void mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk() {
            // ensembl id
            (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.mart_export_brain_path, Datasets.Heart_Ensembl_NCBI_Crosswalk_path, 1);
            Methods.createOuput("mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk", "true.csv", trueList);
            Methods.createOuput("mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk", "false.csv", falseList);
        }

    }
}