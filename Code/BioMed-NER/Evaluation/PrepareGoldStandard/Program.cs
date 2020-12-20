using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace PrepareGoldStandard
{
    class Program
    {
        static void Main(string[] args)
        {

            HashSet<string> patNumHashSet = PatNum.getPatNumHashSet();


            StringBuilder textTestTitle = new StringBuilder();

            StringBuilder textTrainTitle = new StringBuilder();

            StringBuilder textTestAbstract = new StringBuilder();

            StringBuilder textTrainAbstract = new StringBuilder();

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

                            List<string> titleList = new List<string>() { values[0], values[1] };

                            string titleString = string.Join('\t', titleList);

                            textTestTitle.AppendLine(titleString);


                            List<string> abstractList = new List<string>() { values[0], values[2] };

                            string abstractString = string.Join('\t', abstractList);

                            textTestAbstract.AppendLine(abstractString);

                        }
                        else
                        {

                            List<string> titleList = new List<string>() { values[0], values[1] };

                            string titleString = string.Join('\t', titleList);

                            textTrainTitle.AppendLine(titleString);


                            List<string> abstractList = new List<string>() { values[0], values[2] };

                            string abstractString = string.Join('\t', abstractList);

                            textTrainAbstract.AppendLine(abstractString);

                        }

                    }

                }

            }

            FileInfo titleTestFile = new FileInfo(Environment.CurrentDirectory + "/data/output/test_title.txt");

            titleTestFile.Directory.Create();

            File.WriteAllText(titleTestFile.FullName, textTestTitle.ToString());

            FileInfo titleTrainFile = new FileInfo(Environment.CurrentDirectory + "/data/output/train_title.txt");

            titleTrainFile.Directory.Create();

            File.WriteAllText(titleTrainFile.FullName, textTrainTitle.ToString());


            FileInfo abstractTestFile = new FileInfo(Environment.CurrentDirectory + "/data/output/test_abstract.txt");

            abstractTestFile.Directory.Create();

            File.WriteAllText(abstractTestFile.FullName, textTestAbstract.ToString());

            FileInfo abstarctTrainFile = new FileInfo(Environment.CurrentDirectory + "/data/output/train_abstract.txt");

            abstarctTrainFile.Directory.Create();

            File.WriteAllText(abstarctTrainFile.FullName, textTrainAbstract.ToString());



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


            AWSupload.run();

        }
        
    }

}