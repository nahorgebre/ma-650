using System;
using System.IO;
using System.Collections.Generic;

namespace EvaluationMetrics
{
    
    class Datasets
    {

        public static FileInfo title_gs = new FileInfo(Environment.CurrentDirectory + "/data/input/goldstandard/test_entity_title.tsv");
        public static FileInfo abstract_gs = new FileInfo(Environment.CurrentDirectory + "/data/input/goldstandard/test_entity_abstract.tsv");
        public static FileInfo title_prediction = new FileInfo(Environment.CurrentDirectory + "/data/input/prediction/scispaCyEvaluationTitle.csv");
        public static FileInfo abstract_prediction = new FileInfo(Environment.CurrentDirectory + "/data/input/prediction/scispaCyEvaluationAbstract.csv");

    }

}