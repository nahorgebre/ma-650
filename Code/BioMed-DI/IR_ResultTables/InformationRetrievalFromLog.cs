using System;
using System.IO;
using System.Net;
using System.Linq;
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

                                List<string> values = line.Split(":").ToList();

                                string comparison = string.Empty;

                                if (values[1].Contains("_NCBI_Crosswalk")) values[1] = values[1].Replace("_NCBI_Crosswalk", "");

                                if (values[1].Contains("_export")) values[1] = values[1].Replace("_export", "");

                                string[] comparisonValues = values[1].Split("_2_");

                                comparison = @"\vtop{\hbox{\strut " + comparisonValues[0].Replace("_", "\\_") + "\\_2\\_"
                                    + @"}\hbox{\strut " + comparisonValues[1].Replace("_", "\\_") + "}}";

                                /*
                                if (values[1].Length >= 20)
                                {

                                    string[] comparisonValues = values[1].Split("_2_");

                                    comparison = @"\vtop{\hbox{\strut " + comparisonValues[0].Replace("_", "\\_") + "\\_2\\_" 
                                        + @"}\hbox{\strut " + comparisonValues[1].Replace("_", "\\_") + "}}";
 
                                }
                                /*
                                else if (values[1].Trim().Equals(@"mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk"))
                                {

                                    comparison = @"\vtop{\hbox{\strut mart_export_heart_2_}\hbox{\strut H_E_NCBI_Crosswalk}}".Replace("_", "\\_");

                                }
                                else if (values[1].Trim().Equals(@"Heart_2_Heart_Ensembl_NCBI_Crosswalk"))
                                {

                                    comparison =  @"\vtop{\hbox{\strut Heart_2_}\hbox{\strut H_E_NCBI_Crosswalk}}".Replace("_", "\\_");

                                }
                                else
                                {

                                    comparison = values[1].Replace("_", "\\_").Trim();

                                }
                                */


                                result1.Datasets = comparison;

                                result2.Datasets = comparison;

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


                FileInfo blockerResultTable = new FileInfo(directoryItem.FullName + "/blockerResultTable.txt");

                if (File.Exists(blockerResultTable.FullName))
                {

                    using (StreamReader sr = new StreamReader(blockerResultTable.FullName))
                    {

                        var line = sr.ReadLine();

                        string[] values = line.Split(":");

                        double ratio = Convert.ToDouble(values[1].Trim().Replace('.', ','));

                        double adjsutedRatio = Math.Floor(ratio * 100) / 100;

                        result1.ReductionRatio = adjsutedRatio.ToString();

                    }

                }


                FileInfo winterLog = new FileInfo(directoryItem.FullName + "/winter.log");

                if (File.Exists(winterLog.FullName))
                {

                    using (StreamReader sr = new StreamReader(winterLog.FullName))
                    {

                        while (!sr.EndOfStream)
                        {

                            var line = sr.ReadLine();

                            if (line.Contains("blocked pairs"))
                            {

                                string startPattern = "elements;";

                                int startIndex = line.IndexOf(startPattern) + startPattern.Length;

                                string endPattern = "blocked pairs";

                                int length = line.IndexOf(endPattern) - startIndex;

                                result1.BlockedPairs = line.Substring(startIndex, length).Trim();

                            }
                            else if (line.Contains("Identity Resolution finished after"))
                            {

                                string startPattern = "Identity Resolution finished after";

                                int startIndex = line.IndexOf(startPattern) + startPattern.Length;

                                string endPattern = "; found";

                                int length = line.IndexOf(endPattern) - startIndex;

                                string time = line.Substring(startIndex, length).Trim();

                                result1.RunTime = time.Split('.')[0];

                                result2.Time = time.Split('.')[0];

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

                matchingRule = @"\vtop{\hbox{\strut Linear}\hbox{\strut Combination}}";

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

                blockingAlgorithm = @"StBl";

            }
            else if (modelType.Contains("SortedNeighbourhoodBlocker"))
            {

                blockingAlgorithm = @"SoNe";

            }

            return blockingAlgorithm;

        }

    }

}