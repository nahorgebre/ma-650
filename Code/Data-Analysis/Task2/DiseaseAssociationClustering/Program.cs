using System;
using System.IO;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace DiseaseAssociationClustering
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var mlContext = new MLContext(seed: 5);

            // read training data
            var trainingData = mlContext.Data.ReadFromTextFile<TrainingData>(
                path: "iris-data.txt",
                hasHeader: false,
                separatorChar: ',');

            // training pipeline
            var pipeline = mlContext.Transforms.Concatenate(
                "Features",
                "SepalLength",
                "SepalWidth",
                "PetalLength",
                "PetalWidth")
            .Append(mlContext.Clustering.Trainers.KMeans(
                "Features",
                clustersCount: 2));

            // train the model on the data file
            Console.WriteLine("Start training model....");
            var model = pipeline.Fit(trainingData);
            Console.WriteLine("Model training complete!");


            Console.WriteLine("Predicting a sample flower....");
            var prediction = model.CreatePredictionEngine<TrainingData, ClusterPrediction>(mlContext).Predict(
                new TrainingData()
                {
                    SepalLength = 3.3f,
                    SepalWidth = 1.6f,
                    PetalLength = 0.2f,
                    PetalWidth = 5.1f,
                });

            Console.WriteLine($"Cluster: {prediction.PredictedClusterId}");
            Console.WriteLine($"Distances: {string.Join(" ", prediction.Distances)}");

        }

        public static void clustering()
        {

        }
        
    }

    public class TrainingData
    {
        [LoadColumn(0)] public float SepalLength;
        [LoadColumn(1)] public float SepalWidth;
        [LoadColumn(2)] public float PetalLength;
        [LoadColumn(3)] public float PetalWidth;
        [LoadColumn(4)] public string Label;  // ignored during training
    }


    public class ClusterPrediction
    {
        [ColumnName("PredictedLabel")] public uint PredictedClusterId;
        [ColumnName("Score")] public float[] Distances;
    }

}
