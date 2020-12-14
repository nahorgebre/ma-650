using System;
using System.IO;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using System.Collections.Generic;

namespace DiseaseAssociationClustering
{

    class Program
    {

        static void Main(string[] args)
        {

            // create training set
            Input.createTrainingInput();

            Console.WriteLine("Start Clustering!");

            var mlContext = new MLContext();

            // read training data
            var trainingData = mlContext.Data.ReadFromTextFile<InputData>(
                path: "data/input/training.txt",
                hasHeader: false,
                separatorChar: ',');

            // training pipeline
            var pipeline = mlContext.Transforms.Concatenate(
                "Features",
                "score",
                "EI",
                "duration")
            .Append(mlContext.Clustering.Trainers.KMeans(
                "Features",
                clustersCount: 2));

            // train the model on the data file
            Console.WriteLine("Start training model....");
            var model = pipeline.Fit(trainingData);
            Console.WriteLine("Model training complete!");


            Console.WriteLine("Predicting disease association!");

            //float x = float.Parse("");

            for (int i = 0; i < 3; i++)
            {
                var prediction = model.CreatePredictionEngine<InputData, ClusterPrediction>(mlContext).Predict(
    new InputData()
    {
        score = float.Parse("3.3"),
        EI = float.Parse("1.6"),
        duration = new float()
    });

                string clusterIdentifier = prediction.PredictedClusterId.ToString();
                string distance = string.Join(" ", prediction.Distances);

                Console.WriteLine("Cluster: " + clusterIdentifier);
                Console.WriteLine("Distance: " + distance);

                //Console.WriteLine($"Cluster: {prediction.PredictedClusterId}");
                //Console.WriteLine($"Distances: {string.Join(" ", prediction.Distances)}");
            }




            
            /*
            List<Gene> geneList = Parser.getGeneList(new FileInfo(Environment.CurrentDirectory + "/data/input/DI2-fused.xml"));

            FileInfo outputFile = new FileInfo(Environment.CurrentDirectory + "/data/output/clustering-result.tsv");

            outputFile.Directory.Create();


            using (StreamWriter sw = new StreamWriter(outputFile.FullName))
            {

                List<string> firstLineContent = new List<string>()
                {

                    "gene",

                    "desease",

                    "clusterId",

                    "distance",

                    "score",

                    "ei",

                    "yearInitialReport",

                    "yearFinalReport"

                };

                var firstLine = string.Join("\t", firstLineContent);

                sw.WriteLine(firstLine);


                foreach (Gene gene in geneList)
                {

                    if ((gene.diseaseAssociations != null) 
                    //& (!gene.diseaseAssociations.Any())
                    )
                    {

                        foreach (GeneDiseaseAssociation item in gene.diseaseAssociations)
                        {

                            string score = string.Empty;
                            if (!string.IsNullOrEmpty(item.associationScore))
                            {
                                score = item.associationScore;
                            }

                            string EI = string.Empty;
                            if (!string.IsNullOrEmpty(item.evidenceIndex))
                            {
                                EI = item.evidenceIndex;
                            }


                            string duration = string.Empty;
                            if (!string.IsNullOrEmpty(item.yearInitialReport) &
                                !string.IsNullOrEmpty(item.yearFinalReport))
                            {
                                duration = (Convert.ToInt16(item.yearFinalReport) - Convert.ToInt16(item.yearInitialReport)).ToString();
                            }

                            Console.WriteLine(score + "-" + EI + "-" + duration);


                            var prediction = model.CreatePredictionEngine<TrainingData, ClusterPrediction>(mlContext).Predict(
                                new TrainingData()
                                {
                                    score = float.Parse(score),
                                    EI = float.Parse(EI),
                                    duration = float.Parse(duration)
                                });

                            
                            string clusterId = prediction.PredictedClusterId.ToString();

                            string distance = string.Join(" ", prediction.Distances);


                            List<string> lineContent = new List<string>()
                            {

                                gene.ensemblId,

                                item.diseaseIdUMLS,

                                clusterId,

                                distance,

                                item.associationScore,

                                item.evidenceIndex,

                                item.yearInitialReport,

                                item.yearFinalReport

                            };

                            var line = string.Join("\t", lineContent);

                            sw.WriteLine(line);

                        }

                    }

                }

            }
            */

        }

    }

    public class InputData
    {

        [LoadColumn(0)] public float score;
        [LoadColumn(1)] public float EI;
        [LoadColumn(2)] public float duration;

    }


    public class ClusterPrediction
    {

        [ColumnName("PredictedLabel")] public uint PredictedClusterId;
        [ColumnName("Score")] public float[] Distances;

    }

}