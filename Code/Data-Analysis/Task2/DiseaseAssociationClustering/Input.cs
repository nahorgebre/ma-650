using System;
using System.IO;
using System.Collections.Generic;

namespace DiseaseAssociationClustering
{

    class Input
    {

        public string EI;

        public string duration;

        public string age;

        public static (float, float) createTrainingInput()
        {

            // read values into list
            List<Input> inputList = new List<Input>();

            using (StreamReader sr = new StreamReader(Environment.CurrentDirectory + "/data/input/all_gene_disease_pmid_associations.tsv"))
            {

                sr.ReadLine();

                while (!sr.EndOfStream)
                {

                    Input inputItem = new Input();

                    var line = sr.ReadLine();

                    string[] values = line.Split("\t");

                    // 9 - score   
                    // 10 - EI 
                    // 11 - YearInitial 
                    // 12 - YearFinal

                    string EI = values[10];

                    inputItem.EI = EI;


                    string YearInitial = string.Empty;

                    if (!string.IsNullOrWhiteSpace(values[11]))
                    {

                        if (!string.IsNullOrEmpty(values[11]))
                        {

                            YearInitial = values[11];

                        }

                    }



                    string YearFinal = string.Empty;

                    if (!string.IsNullOrWhiteSpace(values[12]))
                    {

                        if (!string.IsNullOrEmpty(values[12]))
                        {

                            YearFinal = values[12];

                        }

                    }


                    string duration = string.Empty;

                    if (!string.IsNullOrEmpty(YearInitial) &
                        !string.IsNullOrEmpty(YearFinal))
                    {

                        duration = (Convert.ToInt16(YearFinal) - Convert.ToInt16(YearInitial)).ToString();

                    }

                    inputItem.duration = duration;


                    string age = string.Empty;

                    if (!string.IsNullOrEmpty(YearInitial))
                    {

                        age = (2020 - Convert.ToInt16(YearInitial)).ToString();

                    }

                    inputItem.age = age;

                    inputList.Add(inputItem);


                }

            }

            // normalize values

            float maxDuration = new float();

            float maxAge = new float();

            foreach (Input inputItem in inputList)
            {

                if (!inputItem.duration.Equals(string.Empty))
                {

                    float duration = float.Parse(inputItem.duration);

                    if (duration > maxDuration) maxDuration = duration;

                }

                if (!inputItem.age.Equals(string.Empty))
                {

                    float age = float.Parse(inputItem.age);

                    if (age > maxAge) maxAge = age;

                }

            }

            float ratioDuration = (float)1.0 / maxDuration;

            float ratioAge = (float)1.0 / maxAge;


            foreach (Input inputItem in inputList)
            {

                //if (!inputItem.duration.Equals(string.Empty)) inputItem.duration = (float.Parse(inputItem.duration) * ratioDuration).ToString();

                //if (!inputItem.age.Equals(string.Empty)) inputItem.age = (float.Parse(inputItem.age) * ratioAge).ToString();

            }


            FileInfo inputFile = new FileInfo(Environment.CurrentDirectory + "/data/input/training.txt");

            if (!inputFile.Exists)
            {

                using (StreamWriter sw = new StreamWriter(inputFile.FullName))
                {

                    foreach (Input inputItem in inputList)
                    {

                        sw.WriteLine(inputItem.EI + "," + inputItem.duration + "," + inputItem.age);

                    }   

                }

            }

            return (ratioDuration, ratioAge);

        }

    }

}