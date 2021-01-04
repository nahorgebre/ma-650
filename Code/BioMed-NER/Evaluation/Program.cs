using System;
using System.Collections.Generic;

namespace EvaluationMetrics
{

    class Program
    {

        static void Main(string[] args)
        {

            //evaluateTitleScispaCy();

            evaluateTitleHunFlair();

        }

        public static void evaluateTitleScispaCy()
        {
            /*
            int TP = EvaluationMetrics.getTruePositive(predictionFile: Datasets.title_prediction, goldStandardFile: Datasets.title_gs);

            int FP = EvaluationMetrics.getFalsePositive(predictionFile: Datasets.title_prediction, goldStandardFile: Datasets.title_gs);

            int FN = EvaluationMetrics.getFalseNegative(predictionFile: Datasets.title_prediction, goldStandardFile: Datasets.title_gs);
            */

            (int TP, int FP, int FN) = EvaluationMetrics.getEvaluationMetrics(predictionFile: Datasets.scispacy_title_prediction, goldStandardFile: Datasets.title_gs);



            Console.WriteLine("TP: " + TP);

            Console.WriteLine("FP: " + FP);

            Console.WriteLine("FN: " + FN);


            double precision = EvaluationMetrics.getPrecision(TP: TP, FP: FP);

            double recall = EvaluationMetrics.getRecall(TP: TP, FN: FN);

            double f1 = EvaluationMetrics.getF1(precision: precision, recall: recall);


            Console.WriteLine("Precision: " + precision);

            Console.WriteLine("Recall: " + recall);

            Console.WriteLine("F1: " + f1);

        }

        public static void evaluateTitleHunFlair()
        {

            Console.WriteLine("HunFlair - Title");

            (int TP, int FP, int FN) = EvaluationMetrics.getEvaluationMetrics(predictionFile: Datasets.hunflair_title_prediction, goldStandardFile: Datasets.title_gs);

            Console.WriteLine("TP: " + TP);

            Console.WriteLine("FP: " + FP);

            Console.WriteLine("FN: " + FN);


            double precision = EvaluationMetrics.getPrecision(TP: TP, FP: FP);

            double recall = EvaluationMetrics.getRecall(TP: TP, FN: FN);

            double f1 = EvaluationMetrics.getF1(precision: precision, recall: recall);


            Console.WriteLine("Precision: " + precision);

            Console.WriteLine("Recall: " + recall);

            Console.WriteLine("F1: " + f1);

        }

    }

}