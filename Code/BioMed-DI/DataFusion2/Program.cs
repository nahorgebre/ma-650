using System;
using System.IO;
using System.Collections.Generic;

namespace DataFusion2
{
    class Program
    {
        static void Main(string[] args)
        {

                        Console.WriteLine("Load correspondences!");

            List<Tuple<string, string>> correspondences = Methods.getCorrespondenceList(DI3Correspondences.correspondences);


            Console.WriteLine("Load key dictionary!");

            Dictionary<string, SortedSet<string>> mergedCorrespondences = Correspondences.getKeyDictionaryLeft(correspondences);
            
            Console.WriteLine("Load datasets!");

            HashSet<string> recordIdHashSet = Datasets.getRecordIdHashSet(mergedCorrespondences);

            Dictionary<string, Gene> datasets = Parser.getGeneListforFileList(DI3Datasets.datasets(), recordIdHashSet);



            AWSlistingContents.createCorrespondencesShellScriptOutput("DI1");

            AWSlistingContents.createDatasetsShellScriptOutput("DI1");

            AWSlistingContents.createCorrespondencesShellScriptOutput("DI2");

            AWSlistingContents.createDatasetsShellScriptOutput("DI2");

            AWSlistingContents.createCorrespondencesShellScriptOutput("DI3");

            AWSlistingContents.createDatasetsShellScriptOutput("DI3");

            AWSlistingContents.createCorrespondencesShellScriptOutput("DI4");

            AWSlistingContents.createDatasetsShellScriptOutput("DI4");

            foreach (String parameter in args)
            {
                
                if (parameter.Equals("DI1"))
                {

                    DI1DataFusion.run();

                }
                else if (parameter.Equals("DI2"))
                {

                    DI2DataFusion.run();

                }
                else if (parameter.Equals("DI3"))
                {

                    DI3DataFusion.run();

                }

            }

        }

    }

}