using System;
using System.IO;
using System.Collections.Generic;

namespace EvaluationMetrics
{

    class EvaluationMetrics
    {

        //TP - True Positive - System provides an annotation that exists in the curated corpus
        public static int getTruePositive(FileInfo predictionFile, FileInfo goldStandardFile) {

            int truePositive = 0;

            Dictionary<string, List<CorporaAnnotation>> predictions = CorporaAnnotation.getAnnotationPrediction(predictionFile);

            Dictionary<string, List<CorporaAnnotation>> goldStandard = CorporaAnnotation.getAnnotationGoldStandard(goldStandardFile);


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

                            if (predictionItem.patentNumber.Equals(goldStandardItem.patentNumber)
                                & predictionItem.startIndex.ToString().Equals(goldStandardItem.startIndex.ToString())
                                & predictionItem.endIndex.ToString().Equals(goldStandardItem.endIndex.ToString()))
                            {
                                
                                truePositive ++;

                            }
                            
                        }
                        
                    }

                }
                
            }

            return truePositive;

        }

        //FP - False Positive - System provides an annotation that does not exist in the curated corpus
        public static int getFalsePositive(FileInfo predictionFile, FileInfo goldStandardFile) {

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

                            if (predictionItem.patentNumber.Equals(goldStandardItem.patentNumber)
                                & predictionItem.startIndex.ToString().Equals(goldStandardItem.startIndex.ToString())
                                & predictionItem.endIndex.ToString().Equals(goldStandardItem.endIndex.ToString()))
                            {
                                
                                doesNotContainItem = true;

                            }

                        }

                        if (doesNotContainItem == false)
                        {

                            falsePositive ++;
                            
                        }

                    }
                    else
                    {

                        falsePositive ++;

                    }
                    
                }
  
            }

            return falsePositive;

        } 

        //FN - False Negative - System does not provide an annotation that is present in the curated corpus
        public static int getFalseNegative(FileInfo predictionFile, FileInfo goldStandardFile) {

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

                            if (predictionItem.patentNumber.Equals(goldStandardItem.patentNumber)
                                & predictionItem.startIndex.ToString().Equals(goldStandardItem.startIndex.ToString())
                                & predictionItem.endIndex.ToString().Equals(goldStandardItem.endIndex.ToString()))
                            {
                                
                                doesNotContainItem = true;

                            }
                            
                        }

                        if (doesNotContainItem == false)
                        {

                            falseNegative ++;
                            
                        }

                    }
                    else
                    {

                        falseNegative ++;

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

            f1 = (precision * recall) / (precision * recall);

            return f1;

        }

    }

}