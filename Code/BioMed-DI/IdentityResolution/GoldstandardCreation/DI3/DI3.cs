using System;
using System.IO;
using System.Collections.Generic;

namespace GoldstandardCreation
{
    class DI3
    {

        public static int kaessmannDiseaseAssociations_2_gene2pubtatorcentral_partitionNumbers = 50;

        public static void run() 
        {

            for (int i = 1; i <= kaessmannDiseaseAssociations_2_gene2pubtatorcentral_partitionNumbers; i++)
            {

                string comparison = "kaessmannDiseaseAssociations_2_gene2pubtatorcentral_" + i;
                string directoryName = string.Format("{0}/data/output/DI3/{1}", Environment.CurrentDirectory, comparison);

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

                    (List<Goldstandard> gsListTrue, List<Goldstandard> gsListTrueCornerCase, List<Goldstandard> gsListFalse, List<Goldstandard> gsListFalseCornerCase) = Methods2.compareFiles_NcbiId_GeneName(DI3Datasets.kaessmannDiseaseAssociations_path, DI3Datasets.getGene2pubtatorcentral_path(i));
                
                    Methods.createOuput(trueFile, gsListTrue);
                    Methods.createOuput(trueCornerCaseFile, gsListTrueCornerCase);

                    Methods.createOuput(falseFile, gsListFalse);
                    Methods.createOuput(falseCornerCaseFile, gsListFalseCornerCase);

                }

            }
           
        }

    }

}