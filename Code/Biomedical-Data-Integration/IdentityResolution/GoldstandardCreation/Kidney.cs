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
            List<Goldstandard> goldstandardList = Methods.compareEnsemblId(Datasets.Kidney_path, Datasets.mart_export_kidney_path);
            Methods.createOuput("Kidney_2_mart_export_kidney", goldstandardList);
        }

        public static void mart_export_kidney_2_all_gene_disease_pmid_associations() {
            List<Goldstandard> goldstandardList = Methods.compareGeneNameLargeFiles(Datasets.mart_export_kidney_path, Datasets.all_gene_disease_pmid_associations_path);
            Methods.createOuput("mart_export_kidney_2_all_gene_disease_pmid_associations", goldstandardList);        
        }

        public static void mart_export_kidney_2_gene2pubtatorcentral() {
            List<Goldstandard> goldstandardList = Methods.compareGeneNameLargeFiles(Datasets.mart_export_kidney_path, Datasets.gene2pubtatorcentral_path);
            Methods.createOuput("mart_export_kidney_2_gene2pubtatorcentral", goldstandardList);
        }
    }
}