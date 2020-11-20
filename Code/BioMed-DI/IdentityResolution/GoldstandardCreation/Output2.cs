using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GoldstandardCreation
{
    class Output2
    {

        public static void runWithCornerCases(DirectoryInfo directory) {

            foreach (DirectoryInfo subDirectory in directory.GetDirectories())
            {

                string trueFile = subDirectory.FullName + "/true.csv";
                string trueCornerCaseFile = subDirectory.FullName + "/trueCornerCase.csv";
                string falseFile = subDirectory.FullName + "/false.csv";
                string falseCornerCaseFile = subDirectory.FullName + "/falseCornerCase.csv";

                (List<Goldstandard> train_TRUE_WOCC, List<Goldstandard> test_TRUE_WOC) = divideIntoTrainTest(trueFile);
                (List<Goldstandard> train_TRUE_WCC, List<Goldstandard> test_TRUE_WCC) = divideIntoTrainTest(trueCornerCaseFile);

                (List<Goldstandard> train_FALSE_WOCC, List<Goldstandard> test_FALSE_WOCC) = divideIntoTrainTest(falseFile);
                (List<Goldstandard> train_FALSE_WCC, List<Goldstandard> test_FALSE_WCC) = divideIntoTrainTest(falseCornerCaseFile);

                List<Goldstandard> train_FALSE = train_FALSE_WOCC.Concat(train_FALSE_WCC).ToList();
                List<Goldstandard> test_FALSE = test_FALSE_WOCC.Concat(test_FALSE_WCC).ToList();

                List<Goldstandard> train_TRUE = train_TRUE_WOCC.Concat(train_TRUE_WCC).ToList();
                List<Goldstandard> test_TRUE = test_TRUE_WOC.Concat(test_TRUE_WCC).ToList();

                createOuputFiles(train_TRUE, train_FALSE, subDirectory.FullName + "/train.csv");
                createOuputFiles(test_TRUE, test_FALSE, subDirectory.FullName + "/test.csv");
            
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
                    goldstandard.recordId2 =values[2].Trim();
                    goldstandard.boolValue = values[4].Trim();

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
                        trueItem.boolValue
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
                        falseItem.boolValue
                    };
                    var line = string.Join(delimiter, lineContent);
                    sw.WriteLine(line);
                }

            }

        }
    
    }

}