using System;
using System.IO;
using System.Collections.Generic;

namespace EvaluationMetrics
{

    class CorporaAnnotation
    {

        public string geneName;

        public string startIndex;

        public string endIndex;

        public static Dictionary<string, List<CorporaAnnotation>> getAnnotationPrediction(FileInfo file)
        {

            Dictionary<string, List<CorporaAnnotation>> predictions = new Dictionary<string, List<CorporaAnnotation>>();

            using (StreamReader sr = new StreamReader(file.FullName))
            {

                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] values = line.Split('\t');


                    string geneNameValue = values[1].Trim();

                    string patentNumberValue = values[0];

                    string startIndexValue = values[2];

                    string endIndexValue = values[3];


                    if (predictions.ContainsKey(patentNumberValue))
                    {

                        List<CorporaAnnotation> caList = predictions[patentNumberValue];

                        caList.Add(new CorporaAnnotation { geneName = geneNameValue, startIndex = startIndexValue, endIndex = endIndexValue });

                        predictions[patentNumberValue] = caList;

                    }
                    else
                    {

                        predictions.Add(patentNumberValue, new List<CorporaAnnotation>() { new CorporaAnnotation { geneName = geneNameValue, startIndex = startIndexValue, endIndex = endIndexValue } });

                    }

                }

            }

            return predictions;

        }

        public static Dictionary<string, List<CorporaAnnotation>> getAnnotationGoldStandard(FileInfo file)
        {

            Dictionary<string, List<CorporaAnnotation>> goldStandard = new Dictionary<string, List<CorporaAnnotation>>();

            using (StreamReader sr = new StreamReader(file.FullName))
            {

                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] values = line.Split('\t');


                    string geneNameValue = values[4];

                    string patentNumberValue = values[0];

                    string startIndexValue = values[2];

                    string endIndexValue = values[3];


                    if (goldStandard.ContainsKey(patentNumberValue))
                    {

                        List<CorporaAnnotation> caList = goldStandard[patentNumberValue];

                        caList.Add(new CorporaAnnotation { geneName = geneNameValue, startIndex = startIndexValue, endIndex = endIndexValue });

                        goldStandard[patentNumberValue] = caList;

                    }
                    else
                    {

                        goldStandard.Add(patentNumberValue, new List<CorporaAnnotation>() { new CorporaAnnotation { geneName = geneNameValue, startIndex = startIndexValue, endIndex = endIndexValue } });

                    }

                }

            }

            return goldStandard;

        }

    }

}