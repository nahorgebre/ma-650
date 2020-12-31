using System.IO;
using System.Collections.Generic;

namespace EvaluationMetrics
{

    class EvaluationMetrics
    {

        public static bool conditionSet1(CorporaAnnotation annotation1, CorporaAnnotation annotation2)
        {

            return annotation1.geneName.Contains(annotation2.geneName) 
                | annotation2.geneName.Contains(annotation1.geneName);

        }

        public static bool conditionSet2(CorporaAnnotation annotation1, CorporaAnnotation annotation2)
        {

            return annotation1.geneName.Equals(annotation2.geneName)
                & annotation1.startIndex.ToString().Equals(annotation2.startIndex.ToString())
                & annotation1.endIndex.ToString().Equals(annotation2.endIndex.ToString());

        }

        public static (int, int, int) getEvaluationMetrics(FileInfo predictionFile, FileInfo goldStandardFile)
        {

            int truePositive = 0; //TP - True Positive - System provides an annotation that exists in the curated corpus

            int falsePositive = 0; //FP - False Positive - System provides an annotation that does not exist in the curated corpus

            int falseNegative = 0; //FN - False Negative - System does not provide an annotation that is present in the curated corpus


            Dictionary<string, List<CorporaAnnotation>> predictions = CorporaAnnotation.getAnnotationPrediction(predictionFile);

            Dictionary<string, List<CorporaAnnotation>> goldStandard = CorporaAnnotation.getAnnotationGoldStandard(goldStandardFile);


            foreach (KeyValuePair<string, List<CorporaAnnotation>> item in predictions)
            {

                List<CorporaAnnotation> predictionList = item.Value;

                if (goldStandard.ContainsKey(item.Key))
                {

                    List<CorporaAnnotation> goldstandardList = goldStandard[item.Key];


                    foreach (var predictionItem in predictionList)
                    {

                        bool gsDoesNotContainPrediction = true;

                        foreach (var goldstandardItem in goldstandardList)
                        {

                            if (
                                conditionSet2(predictionItem, goldstandardItem)
                                )
                            {

                                truePositive++;

                                gsDoesNotContainPrediction = false;

                            }

                        }

                        if (gsDoesNotContainPrediction == true)
                        {

                            falsePositive++;

                        }

                    }

                    foreach (var goldstandardItem in goldstandardList)
                    {

                        bool gsItemIsNotContainedInPrediction = true;

                        foreach (var predictionItem in predictionList)
                        {

                            if (
                                conditionSet2(predictionItem, goldstandardItem)
                                )
                            {

                                gsItemIsNotContainedInPrediction = false;

                            }

                        }

                        if (gsItemIsNotContainedInPrediction == true)
                        {

                            falseNegative++;

                        }

                    }

                }

            }

            return (truePositive, falsePositive, falseNegative);

        }


        //TP - True Positive - System provides an annotation that exists in the curated corpus
        public static int getTruePositive(FileInfo predictionFile, FileInfo goldStandardFile)
        {

            int truePositive = 0;

            Dictionary<string, List<CorporaAnnotation>> predictions = CorporaAnnotation.getAnnotationPrediction(predictionFile);

            Dictionary<string, List<CorporaAnnotation>> goldStandard = CorporaAnnotation.getAnnotationGoldStandard(goldStandardFile);

            foreach (KeyValuePair<string, List<CorporaAnnotation>> item in predictions)
            {

                List<CorporaAnnotation> predictionList = item.Value;

                List<CorporaAnnotation> goldstandardList = goldStandard[item.Key];

            }



            // -----

            foreach (KeyValuePair<string, List<CorporaAnnotation>> item in predictions)
            {

                if (goldStandard.ContainsKey(item.Key))
                {

                    List<CorporaAnnotation> predictionList = item.Value;

                    List<CorporaAnnotation> goldStandardList = goldStandard[item.Key];


                    foreach (CorporaAnnotation predictionItem in predictionList)
                    {

                        foreach (CorporaAnnotation goldStandardItem in goldStandardList)
                        {

                            if (predictionItem.geneName.Equals(goldStandardItem.geneName)
                                & predictionItem.startIndex.ToString().Equals(goldStandardItem.startIndex.ToString())
                                & predictionItem.endIndex.ToString().Equals(goldStandardItem.endIndex.ToString()))
                            {

                                truePositive++;

                            }

                        }

                    }

                }

            }

            return truePositive;

        }

        //FP - False Positive - System provides an annotation that does not exist in the curated corpus
        public static int getFalsePositive(FileInfo predictionFile, FileInfo goldStandardFile)
        {

            int falsePositive = 0;

            Dictionary<string, List<CorporaAnnotation>> predictions = CorporaAnnotation.getAnnotationPrediction(predictionFile);

            Dictionary<string, List<CorporaAnnotation>> goldStandard = CorporaAnnotation.getAnnotationGoldStandard(goldStandardFile);


            foreach (KeyValuePair<string, List<CorporaAnnotation>> item in predictions)
            {
                List<CorporaAnnotation> predictionList = item.Value;

                foreach (CorporaAnnotation predictionItem in predictionList)
                {

                    if (goldStandard.ContainsKey(item.Key))
                    {

                        List<CorporaAnnotation> goldStandardList = goldStandard[item.Key];

                        bool doesNotContainItem = false;

                        foreach (CorporaAnnotation goldStandardItem in goldStandardList)
                        {

                            if (predictionItem.geneName.Equals(goldStandardItem.geneName)
                                & predictionItem.startIndex.ToString().Equals(goldStandardItem.startIndex.ToString())
                                & predictionItem.endIndex.ToString().Equals(goldStandardItem.endIndex.ToString()))
                            {

                                doesNotContainItem = true;

                            }

                        }

                        if (doesNotContainItem == false)
                        {

                            falsePositive++;

                        }

                    }
                    else
                    {

                        falsePositive++;

                    }

                }

            }

            return falsePositive;

        }

        //FN - False Negative - System does not provide an annotation that is present in the curated corpus
        public static int getFalseNegative(FileInfo predictionFile, FileInfo goldStandardFile)
        {

            int falseNegative = 0;

            Dictionary<string, List<CorporaAnnotation>> predictions = CorporaAnnotation.getAnnotationPrediction(predictionFile);

            Dictionary<string, List<CorporaAnnotation>> goldStandard = CorporaAnnotation.getAnnotationGoldStandard(goldStandardFile);

            foreach (KeyValuePair<string, List<CorporaAnnotation>> item in goldStandard)
            {

                List<CorporaAnnotation> goldStandardList = item.Value;

                foreach (CorporaAnnotation goldStandardItem in goldStandardList)
                {

                    if (predictions.ContainsKey(item.Key))
                    {

                        List<CorporaAnnotation> predictionList = predictions[item.Key];

                        bool doesNotContainItem = false;

                        foreach (CorporaAnnotation predictionItem in predictionList)
                        {

                            if (predictionItem.geneName.Equals(goldStandardItem.geneName)
                                & predictionItem.startIndex.ToString().Equals(goldStandardItem.startIndex.ToString())
                                & predictionItem.endIndex.ToString().Equals(goldStandardItem.endIndex.ToString()))
                            {

                                doesNotContainItem = true;

                            }

                        }

                        if (doesNotContainItem == false)
                        {

                            falseNegative++;

                        }

                    }
                    else
                    {

                        falseNegative++;

                    }

                }

            }

            return falseNegative;

        }

        public static double getPrecision(double TP, double FP)
        {

            double precision = new double();

            precision = TP / (TP + FP);

            return precision;

        }

        public static double getRecall(double TP, double FN)
        {

            double recall = new double();

            recall = TP / (TP + FN);

            return recall;

        }

        public static double getF1(double precision, double recall)
        {

            double f1 = new double();

            f1 = 2 * ( (precision * recall) / (precision + recall) );

            return f1;

        }

    }

}