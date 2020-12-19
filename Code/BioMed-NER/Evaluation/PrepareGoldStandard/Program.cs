using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace PrepareGoldStandard
{
    class Program
    {
        static void Main(string[] args)
        {

            HashSet<string> patNumHashSet = PatNum.getPatNumHashSet();


            StringBuilder textTest = new StringBuilder();

            StringBuilder textTrain = new StringBuilder();

            foreach (FileInfo file in Datasets.gs_text)
            {

                using (StreamReader sr = new StreamReader(file.FullName))
                {

                    while (!sr.EndOfStream)
                    {

                        var line = sr.ReadLine();

                        string[] values = line.Split('\t');

                        if (patNumHashSet.Contains( (values[0].Trim()).Replace("US", string.Empty) ))
                        {


                            textTest.AppendLine(line);

                        }
                        else
                        {

                            textTrain.AppendLine(line);

                        }

                    }

                }

            }

            FileInfo textTestFile = new FileInfo(Environment.CurrentDirectory + "/data/output/test_text.txt");

            textTestFile.Directory.Create();

            File.WriteAllText(textTestFile.FullName, textTest.ToString());

            FileInfo textTrainFile = new FileInfo(Environment.CurrentDirectory + "/data/output/train_text.txt");

            textTestFile.Directory.Create();

            File.WriteAllText(textTrainFile.FullName, textTrain.ToString());



            StringBuilder entityTestTitle = new StringBuilder();

            StringBuilder entityTrainTitle = new StringBuilder();

            StringBuilder entityTestAbstract = new StringBuilder();

            StringBuilder entityTrainAbstarct = new StringBuilder();

            foreach (FileInfo file in Datasets.gs_entity)
            {

                using (StreamReader sr = new StreamReader(file.FullName))
                {

                    while (!sr.EndOfStream)
                    {

                        var line = sr.ReadLine();

                        string[] values = line.Split('\t');

                        if (patNumHashSet.Contains( (values[0].Trim()).Replace("US", string.Empty) ))
                        {

                            if (values[1].Contains("T"))
                            {

                                entityTestTitle.AppendLine(line);
                                
                            }
                            else if (values[1].Contains("A"))
                            {

                                entityTestAbstract.AppendLine(line);

                            }

                        }
                        else
                        {

                            if (values[1].Contains("T"))
                            {

                                entityTrainTitle.AppendLine(line);
                                
                            }
                            else if (values[1].Contains("A"))
                            {

                                entityTrainAbstarct.AppendLine(line);
                                
                            }

                        }

                    }

                }

            }


            FileInfo entityTestTitleFile = new FileInfo(Environment.CurrentDirectory + "/data/output/test_entity_title.tsv");

            entityTestTitleFile.Directory.Create();

            File.WriteAllText(entityTestTitleFile.FullName, entityTestTitle.ToString());


            FileInfo entityTestAbstractFile = new FileInfo(Environment.CurrentDirectory + "/data/output/test_entity_abstract.tsv");

            entityTestAbstractFile.Directory.Create();

            File.WriteAllText(entityTestAbstractFile.FullName, entityTestAbstract.ToString());


            FileInfo entityTrainTitleFile = new FileInfo(Environment.CurrentDirectory + "/data/output/train_entity_title.tsv");

            entityTrainTitleFile.Directory.Create();

            File.WriteAllText(entityTrainTitleFile.FullName, entityTrainTitle.ToString());


            FileInfo entityTrainAbstractFile = new FileInfo(Environment.CurrentDirectory + "/data/output/train_entity_abstract.tsv");

            entityTrainAbstractFile.Directory.Create();

            File.WriteAllText(entityTrainAbstractFile.FullName, entityTrainAbstarct.ToString());

        }
        
    }

}