using System;
using System.IO;
using System.Net;
using System.Collections.Generic;

namespace IR_ResultTables
{

    class InformationRetrievalFromLog
    {

        public static (List<Result1>, List<Result2>) retrieveFromResultLogs(String parameter)
        {

            DirectoryInfo directory = new DirectoryInfo(Environment.CurrentDirectory + "/data/input/" + parameter);

            List<Result1> result1List = new List<Result1>();

            List<Result2> result2List = new List<Result2>();

            foreach (DirectoryInfo directoryItem in directory.GetDirectories())
            {

                Result1 result1 = new Result1();

                Result2 result2 = new Result2();


                FileInfo correspondencesResultTable = new FileInfo(directoryItem.FullName + "/correspondencesResultTable.txt");

                if (File.Exists(correspondencesResultTable.FullName))
                {

                    using (StreamReader sr = new StreamReader(correspondencesResultTable.FullName))
                    {

                        while (!sr.EndOfStream)
                        {

                            var line = sr.ReadLine();

                            if (line.Contains("CorrespondencesSize"))
                            {

                                string[] values = line.Split(":");

                                result1.Correspondences = values[1].Trim();

                                result2.Correspondences = values[1].Trim();

                            }
                            
                        }
                        
                    }
 
                }


                FileInfo evaluationResultTable = new FileInfo(directoryItem.FullName + "/evaluationResultTable.txt");

                if (File.Exists(evaluationResultTable.FullName))
                {

                    using (StreamReader sr = new StreamReader(evaluationResultTable.FullName))
                    {

                        while (!sr.EndOfStream)
                        {

                            var line = sr.ReadLine();

                            if (line.Contains("Comparison"))
                            {

                                string[] values = line.Split(":");

                                result1.Datasets = values[1].Trim();

                                result2.Datasets = values[1].Trim();
                                
                            }
                            else if (line.Contains("Model type"))
                            {

                                string[] values = line.Split(":");

                                result1.MatchingRule = getMatchingRule(line);

                                result2.MatchingRule = getMatchingRule(line);

                                result2.Blocker = getBlockingAlgorithm(line);

                                result1.BlockingAlgorithm = getBlockingAlgorithm(line);
                                 
                            }
                            else if (line.Contains("Precision"))
                            {

                                string[] values = line.Split(":");

                                result2.Precision = values[1].Trim();

                            }
                            else if (line.Contains("Recall"))
                            {

                                string[] values = line.Split(":");

                                result2.Recall = values[1].Trim();

                            }
                            else if (line.Contains("F1"))
                            {

                                string[] values = line.Split(":");

                                result2.F1 = values[1].Trim();
                                
                            }
                            
                        }
                        
                    }
                    
                }

                result1List.Add(result1);

                result2List.Add(result2);
                
            }

            return (result1List, result2List);

        }

        public static string getMatchingRule(string modelType)
        {

            string matchingRule = string.Empty;

            if (modelType.Contains("LinearCombination"))
            {

                matchingRule = "Linear Combination";
                
            }
            else if (modelType.Contains("ML_SimpleLogistic"))
            {

                matchingRule = "Simple Logistic";

            }
            else if (modelType.Contains("ML_KNN"))
            {

                matchingRule = "K-NN";

            }
            else if (modelType.Contains("ML_DecisionTree"))
            {

                matchingRule = "Decision Tree";

            }
            else if (modelType.Contains("ML_AdaBoost"))
            {

                matchingRule = "Ada Boost";

            }

            return matchingRule;

        }

        public static string getBlockingAlgorithm(string modelType)
        {

            string blockingAlgorithm = string.Empty;

            if (modelType.Contains("StandardRecordBlocker"))
            {

                blockingAlgorithm = "Standard Record Blocker";

            }
            else if (modelType.Contains("SortedNeighbourhoodBlocker"))
            {

                blockingAlgorithm = "Sorted Neighbourhood Blocker";

            }

            return blockingAlgorithm;

        }

    }

}