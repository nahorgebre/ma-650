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
            (float ratioDuration2, float ratioAge2) =Input.createTrainingInput();

            // start clustering
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
                "EI",
                "duration",
                "age")
            .Append(mlContext.Clustering.Trainers.KMeans(
                "Features",
                clustersCount: 2));

            // train the model on the data file
            Console.WriteLine("Start training model....");
            var model = pipeline.Fit(trainingData);
            Console.WriteLine("Model training complete!");


            // start prediction
            Console.WriteLine("Predicting disease association!");

            // read input data
            List<Gene> geneList = Parser.getGeneList(new FileInfo(Environment.CurrentDirectory + "/data/input/DI2-fused.xml"));

            // normalize input data
            List<Output> outputList = new List<Output>();

            float maxDuration = new float();

            float maxAge = new float();

            foreach (Gene geneItem in geneList)
            {

                if (geneItem.diseaseAssociations != null)
                {

                    foreach (GeneDiseaseAssociation item in geneItem.diseaseAssociations)
                    {

                        Output output = new Output();

                        output.gene = geneItem.ensemblId;

                        output.disease = item.diseaseIdUMLS;

                        output.score = item.associationScore;


                        float EI = new float();
                        if (!string.IsNullOrEmpty(item.evidenceIndex))
                        {
                            EI = float.Parse(item.evidenceIndex);
                        }

                        output.ei = EI.ToString();


                        float duration = new float();
                        if (!string.IsNullOrEmpty(item.yearInitialReport) &
                            !string.IsNullOrEmpty(item.yearFinalReport))
                        {
                            duration = (Convert.ToInt16(item.yearFinalReport) - Convert.ToInt16(item.yearInitialReport));
                        }

                        if (duration > maxDuration) maxDuration = duration;

                        output.duration = duration.ToString();


                        float age = new float();
                        if (!string.IsNullOrEmpty(item.yearInitialReport))
                        {
                            age = (2020 - Convert.ToInt16(item.yearInitialReport));
                        }

                        if (age > maxAge) maxAge = age;


                        output.age = age.ToString();

                        output.yearInitialReport = item.yearInitialReport;

                        output.yearFinalReport = item.yearFinalReport;

                        outputList.Add(output);

                    }

                }

            }

            float ratioDuration = (float)1.0 / maxDuration;

            float ratioAge = (float)1.0 / maxAge;

            foreach (Output item in outputList)
            {

                //if (!string.IsNullOrEmpty(item.duration)) item.duration = (float.Parse(item.duration) * ratioDuration2).ToString();

                //if (!string.IsNullOrEmpty(item.age)) item.age = (float.Parse(item.age) * ratioAge2).ToString();

            }

            // make prediction
            foreach (Output item in outputList)
            {

                float EI = new float();
                float duration = new float();
                float age = new float();

                if (!string.IsNullOrEmpty(item.ei)) EI = float.Parse(item.ei);

                if (!string.IsNullOrEmpty(item.duration)) duration = float.Parse(item.duration);

                if (!string.IsNullOrEmpty(item.age)) age = float.Parse(item.age);

                var prediction = model.CreatePredictionEngine<InputData, ClusterPrediction>(mlContext).Predict(
                new InputData()
                {
                    EI = EI,
                    duration = duration,
                    age = age
                });


                item.clusterId = prediction.PredictedClusterId.ToString();

                item.distance = string.Join(" ", prediction.Distances);

            }


            // save results
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

                    "duration",

                    "age",

                    "yearInitialReport",

                    "yearFinalReport"

                };

                var firstLine = string.Join("\t", firstLineContent);

                sw.WriteLine(firstLine);

                foreach (Output item in outputList)
                {

                    List<string> lineContent = new List<string>()
                            {

                                item.gene,

                                item.disease,

                                item.clusterId,

                                item.distance,

                                item.score,

                                item.ei,

                                item.duration,

                                item.age,

                                item.yearInitialReport,

                                item.yearFinalReport

                            };

                    var line = string.Join("\t", lineContent);

                    sw.WriteLine(line);

                }

            }

        }

    }

    public class InputData
    {

        [LoadColumn(0)] public float EI;
        [LoadColumn(1)] public float duration;
        [LoadColumn(2)] public float age;

    }


    public class ClusterPrediction
    {

        [ColumnName("PredictedLabel")] public uint PredictedClusterId;
        [ColumnName("Score")] public float[] Distances;

    }

}