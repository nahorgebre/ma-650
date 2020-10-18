using System;
using System.Collections.Generic;
using System.IO;

namespace GoldstandardCreation
{
    class Publication
    {
        public static void run() {
            gene2pubtatorcentral_2_PubMedDate();
        }

        public static void gene2pubtatorcentral_2_PubMedDate() {

            for (int i = 1; i <= 15; i++)
            {
                string comparison = "gene2pubtatorcentral_" + i + "_2_PubMedDate";
                string directoryName = string.Format("{0}/data/output/{1}", Environment.CurrentDirectory, comparison);
                string trueFile = string.Format("{0}/true.csv", directoryName);
                string falseFile = string.Format("{0}/false.csv", directoryName);
                Directory.CreateDirectory(directoryName);
                if (!File.Exists(trueFile) | !File.Exists(falseFile))
                {
                    Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
                    (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.getGene2pubtatorcentral_path(i), Datasets.PubMedDate_path, 4);
                    Methods.createOuput(trueFile, trueList);
                    Methods.createOuput(falseFile, falseList);
                }
            }

        }
        
        public static void gene2pubtatorcentral_2_PubMedDate2() {
            string comparison = "gene2pubtatorcentral_2_PubMedDate";
            string directoryName = string.Format("{0}/data/output/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);
            Directory.CreateDirectory(directoryName);
            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {
                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.gene2pubtatorcentral_path, Datasets.PubMedDate_path, 4);
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);
            }
        }
    }
}