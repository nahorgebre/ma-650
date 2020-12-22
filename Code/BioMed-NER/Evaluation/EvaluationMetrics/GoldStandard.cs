using System;
using System.IO;
using System.Collections.Generic;

namespace EvaluationMetrics
{

    class CorporaAnnotation
    {

        public string patentNumber;

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


                    string geneName = values[1].Trim();
                    
                    string patentNumber = values[0];
                    
                    string startIndex = values[2];
                    
                    string endIndex  = values[3];


                    if (predictions.ContainsKey(geneName))
                    {

                        List<CorporaAnnotation> caList = predictions[geneName];

                        caList.Add(new CorporaAnnotation{patentNumber = patentNumber, startIndex = startIndex, endIndex = endIndex});
                        
                    }
                    else
                    {

                        predictions.Add(geneName, new List<CorporaAnnotation>(){ new CorporaAnnotation{patentNumber = patentNumber, startIndex = startIndex, endIndex = endIndex} });

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


                    string geneName = values[4];
                    
                    string patentNumber = values[0];
                    
                    string startIndex = values[2];
                    
                    string endIndex  = values[3];


                    if (goldStandard.ContainsKey(geneName))
                    {

                        List<CorporaAnnotation> caList = goldStandard[geneName];

                        caList.Add(new CorporaAnnotation{patentNumber = patentNumber, startIndex = startIndex, endIndex = endIndex});
                        
                    }
                    else
                    {

                        goldStandard.Add(geneName, new List<CorporaAnnotation>(){ new CorporaAnnotation{patentNumber = patentNumber, startIndex = startIndex, endIndex = endIndex} });

                    }
                    
                }

            }

            return goldStandard;

        }

    }

}