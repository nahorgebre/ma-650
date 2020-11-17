using System;
using System.Collections.Generic;
using System.IO;

namespace GoldstandardCreation
{
    class DI2
    {

        public static int kaessmann_2_all_gene_disease_pmid_associations_partitionNumbers = 7;

        public static void run() 
        {

            for (int i = 1; i <= kaessmann_2_all_gene_disease_pmid_associations_partitionNumbers; i++)
            {
                string comparison = "kaessmann_2_all_gene_disease_pmid_associations_" + i;
                string directoryName = string.Format("{0}/data/output/DI2/{1}", Environment.CurrentDirectory, comparison);
                string trueFile = string.Format("{0}/true.csv", directoryName);
                string falseFile = string.Format("{0}/false.csv", directoryName);

                Directory.CreateDirectory(directoryName);

                if (!File.Exists(trueFile) | !File.Exists(falseFile))
                {

                    Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
                    
                    (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles_NcbiId_GeneName(DI2Datasets.kaessmann_path, DI2Datasets.all_gene_disease_pmid_associations_path(i));
                    
                    Methods.createOuput(trueFile, trueList);

                    Methods.createOuput(falseFile, falseList);

                }

            }

        }

    }

}