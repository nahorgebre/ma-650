using System;
using System.Collections.Generic;
using System.IO;

namespace GoldstandardCreation
{
    
    class Testis
    {

        public static void run() {

            //Testis_2_mart_export_testis();

            Testis_2_mart_export_testis_4();
            
        }

        public static void Testis_2_mart_export_testis_4() {

            // ensembl Id
            string comparison = "Testis_2_mart_export_testis";
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

                (List<Goldstandard> trueCloseList, List<Goldstandard> trueFarList, List<Goldstandard> falseCloseList, List<Goldstandard> falseFarList) = Methods.compareFilesEnsemblIdBlockingComparator(Datasets.Testis_path, Datasets.mart_export_testis_path);
                
                Methods.createOuput(trueCloseFile, trueCloseList);
                Methods.createOuput(trueFarFile, trueFarList);

                Methods.createOuput(falseCloseFile, falseCloseList);
                Methods.createOuput(falseFarFile, falseFarList);

            }

        }

        public static void Testis_2_mart_export_testis() {

            // ensembl id
            string comparison = "Testis_2_mart_export_testis";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);

            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                Directory.CreateDirectory(directoryName);
                
                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Testis_path, Datasets.mart_export_testis_path, 1, Methods.EnsemblId);
                
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);

            }

        }

    }

}