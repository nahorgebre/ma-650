using System;
using System.Collections.Generic;
using System.IO;

namespace GoldstandardCreation
{
    class DI2
    {

        public static void runDataTranslation() 
        {

            string comparison = "kaessmann_2_all_gene_disease_pmid_associations";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);

            Directory.CreateDirectory(directoryName);

            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.k, Datasets.all, 1, Methods.EnsemblId);
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);

            }

        }

    }

}