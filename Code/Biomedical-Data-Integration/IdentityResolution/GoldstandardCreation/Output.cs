using System;
using System.Collections.Generic;
using System.IO;

namespace GoldstandardCreation
{
    class Output
    {

        public static void run(DirectoryInfo directory) {

            Console.WriteLine("Create output files!");

            foreach (DirectoryInfo subDirectory in directory.GetDirectories())
            {

                string trueFile = subDirectory.FullName + "/true.csv";
                string falseFile = subDirectory.FullName + "/false.csv";

                Console.WriteLine("True file: " + trueFile);
                Console.WriteLine("False file: " + falseFile);

                (List<Goldstandard> train_TRUE, List<Goldstandard> test_TRUE) = divideIntoTrainTest(trueFile);
                (List<Goldstandard> train_FALSE, List<Goldstandard> test_FALSE) = divideIntoTrainTest(falseFile);

                createOuputFiles(train_TRUE, train_FALSE, subDirectory.FullName + "/train.csv");
                createOuputFiles(test_TRUE, test_FALSE, subDirectory.FullName + "/test.csv");

            }

        }

        public static void createOuputFiles(List<Goldstandard> trueList, List<Goldstandard> falseList, string fileName)
        {

            var delimiter = ",";

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (Goldstandard trueItem in trueList)
                {
                    List<string> lineContent = new List<string>()
                    {
                        trueItem.recordId1,
                        trueItem.recordId2,
                        trueItem.value
                    };
                    var line = string.Join(delimiter, lineContent);
                    sw.WriteLine(line);
                }

                foreach (Goldstandard falseItem in falseList)
                {
                    List<string> lineContent = new List<string>()
                    {
                        falseItem.recordId1,
                        falseItem.recordId2,
                        falseItem.value
                    };
                    var line = string.Join(delimiter, lineContent);
                    sw.WriteLine(line);
                }

            }
        }


        public static (List<Goldstandard>, List<Goldstandard>) divideIntoTrainTest(string fileName) {

            int lines = File.ReadAllLines(fileName).Length - 1;
            int threshold = lines / 2;

            List<Goldstandard> list1 = new List<Goldstandard>();
            List<Goldstandard> list2 = new List<Goldstandard>();

            var delimiter = "\t";

            using (StreamReader sr = new StreamReader(fileName))
            {
                sr.ReadLine();

                int counter = 0;

                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    String[] values = line.Split(delimiter);

                    Goldstandard goldstandard = new Goldstandard();
                    goldstandard.recordId1 = values[0].Trim();
                    goldstandard.recordId2 =values[1].Trim();
                    goldstandard.value = values[2].Trim();

                    if (counter < threshold)
                    {
                        list1.Add(goldstandard);
                    }
                    else
                    {
                        list2.Add(goldstandard);
                    }

                    counter ++;
                }
            }

            return (list1, list2);
        }

    }
}