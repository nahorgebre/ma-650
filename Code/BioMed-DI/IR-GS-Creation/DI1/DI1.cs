using System;
using System.IO;
using System.Collections.Generic;

namespace IR_GS_Creation
{

    class DI1
    {

        public static void run(string comparison, FileInfo file1, FileInfo file2)
        {

            DirectoryInfo directory = new DirectoryInfo(Environment.CurrentDirectory + "/data/output/DI1/" + comparison);

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

                (List<Goldstandard> goldstandardListTrueClose, 
                List<Goldstandard> goldstandardListTrueFar, 
                List<Goldstandard> goldstandardListFalseClose, 
                List<Goldstandard> goldstandardListFalseFar) = Comparison_EnsemblId.compare(file1, file2);

                Output.createIntermediateOuput(trueFile, goldstandardListTrueClose);

                Output.createIntermediateOuput(trueCornerCaseFile, goldstandardListTrueFar);

                Output.createIntermediateOuput(falseFile, goldstandardListFalseClose);

                Output.createIntermediateOuput(falseCornerCaseFile, goldstandardListFalseFar);

            }

        }

    }

}