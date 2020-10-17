using System;
using System.Collections.Generic;
using System.IO;

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
            string comparison = "Brain_2_mart_export_brain";
            string directoryName = string.Format("{0}/data/output/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);
            Directory.CreateDirectory(directoryName);
            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {
                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Brain_path, Datasets.mart_export_brain_path, 1);
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);
            }

        }
        
        public static void mart_export_brain_2_all_gene_disease_pmid_associations() {
            // gene name
            string comparison = "mart_export_brain_2_all_gene_disease_pmid_associations";
            string directoryName = string.Format("{0}/data/output/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);
            Directory.CreateDirectory(directoryName);
            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {
                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.mart_export_brain_path, Datasets.all_gene_disease_pmid_associations_path, 3);
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);
            }
        }
        
        public static void mart_export_brain_2_gene2pubtatorcentral() {
            for (int i = 0; i <= 15; i++)
            {
                // gene name
                string comparison = "mart_export_brain_2_gene2pubtatorcentral_" + i;
                string directoryName = string.Format("{0}/data/output/{1}", Environment.CurrentDirectory, comparison);
                string trueFile = string.Format("{0}/true.csv", directoryName);
                string falseFile = string.Format("{0}/false.csv", directoryName);
                Directory.CreateDirectory(directoryName);
                if (!File.Exists(trueFile) | !File.Exists(falseFile))
                {
                    (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.mart_export_brain_path, Datasets.getGene2pubtatorcentral_path(i), 3);
                    Methods.createOuput(trueFile, trueList);
                    Methods.createOuput(falseFile, falseList);
                } 
            }
        }

    }
}