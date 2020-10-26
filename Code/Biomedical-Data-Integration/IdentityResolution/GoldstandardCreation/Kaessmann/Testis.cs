using System;
using System.Collections.Generic;
using System.IO;

namespace GoldstandardCreation
{
    class Testis
    {

        public static void run() {
            mart_export_testis_2_all_gene_disease_pmid_associations();
            mart_export_testis_2_gene2pubtatorcentral();
            Testis_2_mart_export_testis();
        }
        
        public static void mart_export_testis_2_all_gene_disease_pmid_associations() {
            // gene name
            string comparison = "mart_export_testis_2_all_gene_disease_pmid_associations";
            string directoryName = string.Format("{0}/data/output/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);
            Directory.CreateDirectory(directoryName);
            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {
                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.mart_export_testis_path, Datasets.all_gene_disease_pmid_associations_path, 3);
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);
            }
        }

        public static void mart_export_testis_2_gene2pubtatorcentral() {
            for (int i = 1; i <= Publication.pubTatorPartitionSize; i++)
            {
                // gene name
                string comparison = "mart_export_testis_2_gene2pubtatorcentral_" + i;
                string directoryName = string.Format("{0}/data/output/{1}", Environment.CurrentDirectory, comparison);
                string trueFile = string.Format("{0}/true.csv", directoryName);
                string falseFile = string.Format("{0}/false.csv", directoryName);
                Directory.CreateDirectory(directoryName);
                if (!File.Exists(trueFile) | !File.Exists(falseFile))
                {
                    Console.WriteLine(comparison);
                    (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFilesPubTator(Datasets.mart_export_testis_path, Datasets.getGene2pubtatorcentral_path(i), 3);
                    Methods.createOuput(trueFile, trueList);
                    Methods.createOuput(falseFile, falseList);
                }
            }
        }

        public static void Testis_2_mart_export_testis() {
            // ensembl id
            string comparison = "Testis_2_mart_export_testis";
            string directoryName = string.Format("{0}/data/output/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);
            Directory.CreateDirectory(directoryName);
            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {
                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Testis_path, Datasets.mart_export_testis_path, 1);
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);
            }
        }

    }
}