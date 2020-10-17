using System;

namespace GoldstandardCreation
{
    class Datasets
    {
        // Brain
        public static string Brain_path = Environment.CurrentDirectory + "/data/input/Brain/Brain_dt.tsv";
        public static string mart_export_brain_path = Environment.CurrentDirectory + "/data/input/Brain/mart_export_brain_dt.tsv";

        // Cerebellum
        public static string Cerebellum_path = Environment.CurrentDirectory + "/data/input/Cerebellum/Cerebellum_dt.tsv";
        public static string mart_export_cerebellum_path = Environment.CurrentDirectory + "/data/input/Cerebellum/mart_export_cerebellum_dt.tsv";

        // Heart
        public static string Heart_Ensembl_NCBI_Crosswalk_path = Environment.CurrentDirectory + "/data/input/Heart/Heart_Ensembl_NCBI_Crosswalk_dt.tsv";
        public static string Heart_path = Environment.CurrentDirectory + "/data/input/Heart/Heart_dt.tsv";
        public static string mart_export_heart_path = Environment.CurrentDirectory + "/data/input/Heart/mart_export_heart_dt.tsv";

        // Kidney
        public static string Kidney_path = Environment.CurrentDirectory + "/data/input/Kidney/Kidney_dt.tsv";
        public static string mart_export_kidney_path = Environment.CurrentDirectory + "/data/input/Kidney/mart_export_kidney_dt.tsv";

        // Liver
        public static string Liver_path = Environment.CurrentDirectory + "/data/input/Liver/Liver_dt.tsv";
        public static string mart_export_liver_path = Environment.CurrentDirectory + "/data/input/Liver/mart_export_liver_dt.tsv";

        // Publication
        public static string PubMedDate_path = Environment.CurrentDirectory + "/data/input/Publication/PubMedDate_dt.tsv";
        public static string getGene2pubtatorcentral_path(int fileNumber) {
            String gene2pubtatorcentral_path = Environment.CurrentDirectory + "/data/input/Publication/gene2pubtatorcentral_" + fileNumber + "_dt.tsv";
            return gene2pubtatorcentral_path;
        }
        public static string gene2pubtatorcentral_path = Environment.CurrentDirectory + "/data/input/Publication/gene2pubtatorcentral_dt.tsv";
        
        // Testis
        public static string Testis_path = Environment.CurrentDirectory + "/data/input/Testis/Testis_dt.tsv";
        public static string mart_export_testis_path = Environment.CurrentDirectory + "/data/input/Testis/mart_export_testis_dt.tsv";

        // Disease
        public static string all_gene_disease_pmid_associations_path = Environment.CurrentDirectory + "/data/input/Disease/all_gene_disease_pmid_associations_dt.tsv";
    }
}