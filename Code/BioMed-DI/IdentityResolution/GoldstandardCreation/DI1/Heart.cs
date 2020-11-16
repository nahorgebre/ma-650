using System;
using System.Collections.Generic;
using System.IO;

namespace GoldstandardCreation
{
    
    class Heart
    {
    
        public static void run() {

            //Heart_2_Heart_Ensembl_NCBI_Crosswalk();
            Heart_2_Heart_Ensembl_NCBI_Crosswalk_4();

            //mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk();
            mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk_4();

        }

        public static void Heart_2_Heart_Ensembl_NCBI_Crosswalk_4() {

            // ensembl Id
            string comparison = "Heart_2_Heart_Ensembl_NCBI_Crosswalk";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);

            string trueCloseFile = string.Format("{0}/trueClose.csv", directoryName);
            string trueFarFile = string.Format("{0}/trueFar.csv", directoryName);
            string falseCloseFile = string.Format("{0}/falseClose.csv", directoryName);
            string falseFarFile = string.Format("{0}/falseFar.csv", directoryName);

            Directory.CreateDirectory(directoryName);

            if (!File.Exists(trueCloseFile) | 
                !File.Exists(trueFarFile) |
                !File.Exists(falseCloseFile) |
                !File.Exists(falseFarFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                (List<Goldstandard> trueCloseList, List<Goldstandard> trueFarList, List<Goldstandard> falseCloseList, List<Goldstandard> falseFarList) = Methods.compareFilesEnsemblIdBlockingComparator(DI1Datasets.Heart_path, DI1Datasets.Heart_Ensembl_NCBI_Crosswalk_path);
                
                Methods.createOuput(trueCloseFile, trueCloseList);
                Methods.createOuput(trueFarFile, trueFarList);

                Methods.createOuput(falseCloseFile, falseCloseList);
                Methods.createOuput(falseFarFile, falseFarList);

            }

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
                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(DI1Datasets.Heart_path, DI1Datasets.Heart_Ensembl_NCBI_Crosswalk_path, 1, Methods.EnsemblId);
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);

            }

        }

        public static void mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk_4() {

            // ensembl Id
            string comparison = "mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);

            string trueCloseFile = string.Format("{0}/trueClose.csv", directoryName);
            string trueFarFile = string.Format("{0}/trueFar.csv", directoryName);
            string falseCloseFile = string.Format("{0}/falseClose.csv", directoryName);
            string falseFarFile = string.Format("{0}/falseFar.csv", directoryName);

            Directory.CreateDirectory(directoryName);

            if (!File.Exists(trueCloseFile) | 
                !File.Exists(trueFarFile) |
                !File.Exists(falseCloseFile) |
                !File.Exists(falseFarFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                (List<Goldstandard> trueCloseList, List<Goldstandard> trueFarList, List<Goldstandard> falseCloseList, List<Goldstandard> falseFarList) = Methods.compareFilesEnsemblIdBlockingComparator(DI1Datasets.mart_export_heart_path, DI1Datasets.Heart_Ensembl_NCBI_Crosswalk_path);
                
                Methods.createOuput(trueCloseFile, trueCloseList);
                Methods.createOuput(trueFarFile, trueFarList);

                Methods.createOuput(falseCloseFile, falseCloseList);
                Methods.createOuput(falseFarFile, falseFarList);

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
                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(DI1Datasets.mart_export_brain_path, DI1Datasets.Heart_Ensembl_NCBI_Crosswalk_path, 1, Methods.EnsemblId);
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);

            }

        }

    }

}