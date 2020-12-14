using System;
using System.IO;

namespace DiseaseAssociationClustering
{

    class Input
    {

        public static void createTrainingInput()
        {

            FileInfo inputFile = new FileInfo(Environment.CurrentDirectory + "/data/input/training.txt");

            if (!inputFile.Exists)
            {

                using (StreamWriter sw = new StreamWriter(inputFile.FullName))
                {

                    using (StreamReader sr = new StreamReader(Environment.CurrentDirectory + "/data/input/all_gene_disease_pmid_associations.tsv"))
                    {

                        sr.ReadLine();

                        while (!sr.EndOfStream)
                        {

                            var line = sr.ReadLine();

                            string[] values = line.Split("\t");

                            // 9 - score   
                            // 10 - EI 
                            // 11 - YearInitial 
                            // 12 - YearFinal

                            string EI = values[10];


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


                            string age = string.Empty;

                            if (!string.IsNullOrEmpty(YearInitial))
                            {

                                duration = (2020 - Convert.ToInt16(YearInitial)).ToString();
                                
                            }

        
                            sw.WriteLine(EI + "," + duration + "," + age);

                        }

                    }

                }

            }

        }

    }

}