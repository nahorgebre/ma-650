using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace IR_GS_Creation
{

    class Output
    {

        public static void createIntermediateOuput(FileInfo file, List<Goldstandard> goldstandardList)
        {

            using (StreamWriter sw = new StreamWriter(file.FullName))
            {
                
                foreach (Goldstandard item in goldstandardList)
                {

                    var delimiter = "\t";

                    List<string> lineContent = new List<string>()
                    {

                        item.recordId1, // 0
                        item.geneNames1, // 1
                        item.ncbiId1, // 2
                        item.ensemblId1, // 3

                        item.recordId2, // 4
                        item.geneNames2, // 5
                        item.ncbiId2, // 6
                        item.ensemblId2, // 7

                        item.boolValue, // 8

                        item.geneNamesSim.ToString(), // 9
                        item.ncbiIdSim.ToString(), // 10
                        item.ensemblIdSim.ToString(), // 11

                        item.geneNamesBlockingKey, // 12
                        item.ncbiIdBlockingKey, // 13
                        item.ensemblIdBlockingKey  // 14

                    };

                    var line = string.Join(delimiter, lineContent);

                    sw.WriteLine(line);

                }

            }

        }

        public static void createOutputWithCornerCases(DirectoryInfo directory) {

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

                    goldstandard.recordId2 =values[4].Trim();

                    goldstandard.boolValue = values[8].Trim();

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