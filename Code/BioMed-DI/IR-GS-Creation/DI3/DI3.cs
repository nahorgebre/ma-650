using System;
using System.IO;
using System.Collections.Generic;

namespace IR_GS_Creation
{

    class DI3
    {

        public static int kaessmannDiseaseAssociations_2_gene2pubtatorcentral_partitionNumbers = 50;

        public static void run() 
        {

            for (int i = 1; i <= kaessmannDiseaseAssociations_2_gene2pubtatorcentral_partitionNumbers; i++)
            {

                DirectoryInfo directory = new DirectoryInfo(Environment.CurrentDirectory + "/data/output/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_" + i);

                directory.Create();


                Console.WriteLine(directory.Name);


                FileInfo trueFile = new FileInfo(directory.FullName + "/true.csv");

                FileInfo trueCornerCaseFile = new FileInfo(directory.FullName + "/trueCornerCase.csv");

                FileInfo falseFile = new FileInfo(directory.FullName + "/false.csv");

                FileInfo falseCornerCaseFile = new FileInfo(directory.FullName + "/falseCornerCase.csv");


                if (!trueFile.Exists |
                    !trueCornerCaseFile.Exists |
                    !falseFile.Exists |
                    !falseCornerCaseFile.Exists)
                {

                    (
                    List<Goldstandard> gsListTrue, 
                    List<Goldstandard> gsListTrueCornerCase, 
                    List<Goldstandard> gsListFalse, 
                    List<Goldstandard> gsListFalseCornerCase
                    ) = Comparison_NcbiId_GeneNames.compare(DI3Datasets.DI2_dt, 
                        DI3Datasets.getGene2pubtatorcentral_dt(i));


                    Output.createIntermediateOuput(trueFile, gsListTrue);

                    Output.createIntermediateOuput(trueCornerCaseFile, gsListTrueCornerCase);

                    Output.createIntermediateOuput(falseFile, gsListFalse);

                    Output.createIntermediateOuput(falseCornerCaseFile, gsListFalseCornerCase);
                    
                }

            }

        }

    }

}