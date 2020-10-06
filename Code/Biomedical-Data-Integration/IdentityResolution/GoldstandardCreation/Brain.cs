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
            List<Goldstandard> goldstandardList = Methods.compareEnsemblId(Datasets.Brain_path, Datasets.mart_export_brain_path);
            Methods.createOuput("Brain_2_mart_export_brain", "true.csv", goldstandardList);
        }
        
        public static void mart_export_brain_2_all_gene_disease_pmid_associations() {
            List<Goldstandard> goldstandardList = Methods.compareGeneNameLargeFiles(Datasets.mart_export_brain_path, Datasets.all_gene_disease_pmid_associations_path);
            Methods.createOuput("mart_export_brain_2_all_gene_disease_pmid_associations", "true.csv", goldstandardList);
        }
        
        public static void mart_export_brain_2_gene2pubtatorcentral() {
            List<Goldstandard> goldstandardList = Methods.compareGeneNameLargeFiles(Datasets.mart_export_brain_path, Datasets.gene2pubtatorcentral_path);
            Methods.createOuput("mart_export_brain_2_gene2pubtatorcentral", "true.csv", goldstandardList);
        }
    }
}