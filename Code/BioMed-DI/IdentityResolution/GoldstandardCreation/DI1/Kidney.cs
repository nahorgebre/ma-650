using System;
using System.Collections.Generic;
using System.IO;

namespace GoldstandardCreation
{
    
    class Kidney
    {

        public static void run() {

            //Kidney_2_mart_export_kidney();

            Kidney_2_mart_export_kidney_4();

        }

        public static void Kidney_2_mart_export_kidney_4() {

            // ensembl Id
            string comparison = "Kidney_2_mart_export_kidney";
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

                (List<Goldstandard> trueCloseList, List<Goldstandard> trueFarList, List<Goldstandard> falseCloseList, List<Goldstandard> falseFarList) = Methods.compareFilesEnsemblIdBlockingComparator(Datasets.Kidney_path, Datasets.mart_export_kidney_path);
                
                Methods.createOuput(trueCloseFile, trueCloseList);
                Methods.createOuput(trueFarFile, trueFarList);

                Methods.createOuput(falseCloseFile, falseCloseList);
                Methods.createOuput(falseFarFile, falseFarList);

            }

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
                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Kidney_path, Datasets.mart_export_kidney_path, 1, Methods.EnsemblId);
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);

            }

        }
    
    }

}