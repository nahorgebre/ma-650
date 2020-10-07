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
            string comparison = "gene2pubtatorcentral_2_PubMedDate";
            string directoryName = string.Format("{0}/data/output/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/true.csv", directoryName);
            Directory.CreateDirectory(directoryName);
            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {
                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.gene2pubtatorcentral_path, Datasets.PubMedDate_path, 4);
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);
            }
        }
    }
}