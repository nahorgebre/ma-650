using System;
using System.Collections.Generic;
using System.IO;

namespace GoldstandardCreation
{
    class Liver
    {

        public static void run() {

            Liver_2_mart_export_liver();

        }
        public static void Liver_2_mart_export_liver() {

            // ensembl id
            string comparison = "Liver_2_mart_export_liver";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);
            Directory.CreateDirectory(directoryName);
            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {
                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Liver_path, Datasets.mart_export_liver_path, 1);
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);
            }

        }

    }

}