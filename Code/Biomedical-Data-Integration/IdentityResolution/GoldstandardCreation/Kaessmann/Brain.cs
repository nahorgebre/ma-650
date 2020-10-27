using System;
using System.Collections.Generic;
using System.IO;

namespace GoldstandardCreation
{
    class Brain
    {
        
        public static void run() {

            Brain_2_mart_export_brain();

        }
        
        public static void Brain_2_mart_export_brain() {
            
            // ensembl Id
            string comparison = "Brain_2_mart_export_brain";
            string directoryName = string.Format("{0}/data/output/Kaessmann/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);
            Directory.CreateDirectory(directoryName);
            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {
                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Brain_path, Datasets.mart_export_brain_path, 1);
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);
            }

        }

    }

}