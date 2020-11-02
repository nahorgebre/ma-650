using System;
using System.Collections.Generic;
using System.IO;

namespace GoldstandardCreation
{
    
    class Heart
    {
    
        public static void run() {

            Heart_2_Heart_Ensembl_NCBI_Crosswalk();

            mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk();

        }
        
        public static void Heart_2_Heart_Ensembl_NCBI_Crosswalk() {

            // ensembl id
            string comparison = "Heart_2_Heart_Ensembl_NCBI_Crosswalk";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);

            Directory.CreateDirectory(directoryName);

            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Heart_path, Datasets.Heart_Ensembl_NCBI_Crosswalk_path, 1);
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);

            }

        }

        public static void mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk() {

            // ensembl id
            string comparison = "mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);

            Directory.CreateDirectory(directoryName);

            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.mart_export_brain_path, Datasets.Heart_Ensembl_NCBI_Crosswalk_path, 1);
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);

            }

        }

    }

}