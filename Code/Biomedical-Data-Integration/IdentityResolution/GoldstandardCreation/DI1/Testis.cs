using System;
using System.Collections.Generic;
using System.IO;

namespace GoldstandardCreation
{
    
    class Testis
    {

        public static void run() {

            Testis_2_mart_export_testis();
            
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
                
                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Testis_path, Datasets.mart_export_testis_path, 1);
                
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);

            }

        }

    }

}