using System;
using System.IO;
using System.Collections.Generic;

namespace IR_GS_Creation
{

    class DI2
    {

        public static int kaessmann_2_all_gene_disease_pmid_associations_partitionNumbers = 7;

        public static void run() 
        {

            for (int i = 1; i <= kaessmann_2_all_gene_disease_pmid_associations_partitionNumbers; i++)
            {

                DirectoryInfo directory = new DirectoryInfo(Environment.CurrentDirectory + "/data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_" + i);

                directory.Create();


                Console.WriteLine(directory.Name + "-------------------------------------------------------------------------------------");


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
                    ) = Comparison_NcbiId_GeneNames.compare(DI2Datasets.DI1_dt, 
                        DI2Datasets.all_gene_disease_pmid_associations_dt(i));


                    Output.createIntermediateOuput(trueFile, gsListTrue);

                    Output.createIntermediateOuput(trueCornerCaseFile, gsListTrueCornerCase);

                    Output.createIntermediateOuput(falseFile, gsListFalse);

                    Output.createIntermediateOuput(falseCornerCaseFile, gsListFalseCornerCase);
                    
                }

            }

        }

    }

}