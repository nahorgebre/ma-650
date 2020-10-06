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
            List<Goldstandard> goldstandardList = Methods.compareEnsemblId(Datasets.Heart_path, Datasets.Heart_Ensembl_NCBI_Crosswalk_path);
            Methods.createOuput("Heart_2_Heart_Ensembl_NCBI_Crosswalk", "true.csv", goldstandardList);
        }

        public static void Heart_Ensembl_NCBI_Crosswalk_2_all_gene_disease_pmid_associations() {
            List<Goldstandard> goldstandardList = Methods.compareGeneNameLargeFiles(Datasets.Heart_Ensembl_NCBI_Crosswalk_path, Datasets.all_gene_disease_pmid_associations_path);
            Methods.createOuput("Heart_Ensembl_NCBI_Crosswalk_2_all_gene_disease_pmid_associations", "true.csv", goldstandardList);       
        }

        public static void Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral() {
            List<Goldstandard> goldstandardList = Methods.compareGeneNameLargeFiles(Datasets.Heart_Ensembl_NCBI_Crosswalk_path, Datasets.gene2pubtatorcentral_path);
            Methods.createOuput("Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral", "true.csv", goldstandardList);
        }

        public static void mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk() {
            List<Goldstandard> goldstandardList = Methods.compareEnsemblId(Datasets.mart_export_brain_path, Datasets.Heart_Ensembl_NCBI_Crosswalk_path);
            Methods.createOuput("mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk", "true.csv", goldstandardList);
        }

    }
}