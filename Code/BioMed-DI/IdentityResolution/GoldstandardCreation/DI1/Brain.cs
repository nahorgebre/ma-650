using System;
using System.Collections.Generic;
using System.IO;

namespace GoldstandardCreation
{
    
    class Brain
    {
        
        public static void run() {

            Brain_2_mart_export_brain_4();

            //Brain_2_mart_export_brain2();

        }

        public static void Brain_2_mart_export_brain2() {

            // ensembl Id
            string comparison = "Brain_2_mart_export_brain";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);

            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);

            Directory.CreateDirectory(directoryName);

            if (!File.Exists(trueFile) | 
                !File.Exists(falseFile))
            {

                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Brain_path, Datasets.mart_export_brain_path, 1, Methods.EnsemblId);

                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);

            }

        }

        
        
        public static void Brain_2_mart_export_brain_4() {
            
            // ensembl Id
            string comparison = "Brain_2_mart_export_brain";
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

                //(List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Brain_path, Datasets.mart_export_brain_path, 1, Methods.EnsemblId);

                (List<Goldstandard> trueCloseList, List<Goldstandard> trueFarList, List<Goldstandard> falseCloseList, List<Goldstandard> falseFarList) = Methods.compareFilesEnsemblIdBlockingComparator(Datasets.Brain_path, Datasets.mart_export_brain_path);
                
                Methods.createOuput(trueCloseFile, trueCloseList);
                Methods.createOuput(trueFarFile, trueFarList);

                Methods.createOuput(falseCloseFile, falseCloseList);
                Methods.createOuput(falseFarFile, falseFarList);

            }

        }

    }

}