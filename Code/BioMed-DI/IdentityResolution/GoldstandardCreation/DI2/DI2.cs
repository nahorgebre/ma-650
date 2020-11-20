using System;
using System.IO;
using System.Collections.Generic;

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
                string trueCornerCaseFile = string.Format("{0}/trueCornerCase.csv", directoryName);
                string falseFile = string.Format("{0}/false.csv", directoryName);
                string falseCornerCaseFile = string.Format("{0}/falseCornerCase.csv", directoryName);

                Directory.CreateDirectory(directoryName);

                if (!File.Exists(trueFile) | 
                    !File.Exists(trueCornerCaseFile) |
                    !File.Exists(falseFile) |
                    !File.Exists(falseCornerCaseFile))
                {

                    Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                    (List<Goldstandard> gsListTrue, List<Goldstandard> gsListTrueCornerCase, List<Goldstandard> gsListFalse, List<Goldstandard> gsListFalseCornerCase) = Methods2.compareFiles_NcbiId_GeneName(DI2Datasets.kaessmann_path, DI2Datasets.all_gene_disease_pmid_associations_path(i));
                
                    Methods.createOuput(trueFile, gsListTrue);
                    Methods.createOuput(trueCornerCaseFile, gsListTrueCornerCase);

                    Methods.createOuput(falseFile, gsListFalse);
                    Methods.createOuput(falseCornerCaseFile, gsListFalseCornerCase);

                }

            }

        }

    }

}