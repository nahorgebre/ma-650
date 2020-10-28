using System;
using System.Collections.Generic;
using System.IO;

namespace GoldstandardCreation
{
    class Kidney
    {

        public static void run() {

            Kidney_2_mart_export_kidney();

        }
        
        public static void Kidney_2_mart_export_kidney() {

            // ensembl id
            string comparison = "Kidney_2_mart_export_kidney";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);
            Directory.CreateDirectory(directoryName);
            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {
                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Kidney_path, Datasets.mart_export_kidney_path, 1);
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);
            }

        }
    
    }

}