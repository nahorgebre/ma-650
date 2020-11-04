using System;
using System.Collections.Generic;
using System.IO;

namespace Data_Preparation
{
    class CreateTestTextDatasets
    {

        public string patentNumber;
        public string patentTitle;
        public string patentAbstract;

        public static void run()
        {
            create_patents_test_text_title();
            create_patents_test_text_abstract();
        }


        public static void create_patents_test_text_title() {

            List<FileInfo> patents_text_list = new List<FileInfo>()
            {
                Datasets_gpro_training_set_v02.chemdner_patents_train_text,
                Datasets_gpro_development_set.chemdner_patents_development_text
            };

            DirectoryInfo outputDirectory = new DirectoryInfo(string.Format("{0}/data/output/text", Environment.CurrentDirectory));
            outputDirectory.Create();
 
            FileInfo fileName = new FileInfo(string.Format("{0}/patents_test_text_title.txt", outputDirectory.FullName));
            fileName.Delete();

            using(StreamWriter sw = new StreamWriter(fileName.FullName))
            {

                List<string> firstLineContent = new List<string>()
                {
                    "patentNumber",
                    "patentDate",
                    "patentTitle"
                };
                var firstLine = string.Join("\t", firstLineContent);
                sw.WriteLine(firstLine);

                foreach (FileInfo patents_text in patents_text_list)
                {
                    using (StreamReader sr = new StreamReader(patents_text.FullName))
                    {

                        while(!sr.EndOfStream)
                        {
                            var line = sr.ReadLine();      
                            String[] values = line.Split("\t");
                            CreateTestTextDatasets datasetItem = new CreateTestTextDatasets();
                            datasetItem.patentNumber = values[0].ToString().Trim();
                            datasetItem.patentTitle = values[1].ToString().Trim();

                            foreach (TargetPatentNumber patNum in TargetPatentNumber.getTargetPatentNumbers())
                            {
                                /*
                                Console.WriteLine("PatNum: " + patNum.patentNumber);
                                Console.WriteLine("DatasetItem: " + datasetItem.patentNumber);

                                Environment.Exit(0);
                                */

                                if (datasetItem.patentNumber.Contains(patNum.patentNumber))
                                {
                                    List<string> inputLineList = new List<string>()
                                    {
                                        datasetItem.patentNumber,
                                        patNum.patentDate,
                                        datasetItem.patentTitle
                                    };
                                    var inputLine = string.Join("\t", inputLineList);
                                    sw.WriteLine(inputLine);     
                                }
                            }
                         
                        }
                    }
                }     
            }
        }

        public static void create_patents_test_text_abstract() {

            List<FileInfo> patents_text_list = new List<FileInfo>()
            {
                Datasets_gpro_training_set_v02.chemdner_patents_train_text,
                Datasets_gpro_development_set.chemdner_patents_development_text
            };

            DirectoryInfo outputDirectory = new DirectoryInfo(string.Format("{0}/data/output/text", Environment.CurrentDirectory));
            outputDirectory.Create();
 
            FileInfo fileName = new FileInfo(string.Format("{0}/patents_test_text_abstract.txt", outputDirectory.FullName));
            fileName.Delete();

            using(StreamWriter sw = new StreamWriter(fileName.FullName))
            {

                List<string> firstLineContent = new List<string>()
                {
                    "patentNumber",
                    "patentDate",
                    "patentAbstract"
                };
                var firstLine = string.Join("\t", firstLineContent);
                sw.WriteLine(firstLine);

                foreach (FileInfo patents_text in patents_text_list)
                {
                    using (StreamReader sr = new StreamReader(patents_text.FullName))
                    {

                        while(!sr.EndOfStream)
                        {
                            var line = sr.ReadLine();      
                            String[] values = line.Split("\t");
                            CreateTestTextDatasets datasetItem = new CreateTestTextDatasets();
                            datasetItem.patentNumber = values[0].ToString().Trim();
                            datasetItem.patentAbstract = values[2].ToString().Trim();

                            foreach (TargetPatentNumber patNum in TargetPatentNumber.getTargetPatentNumbers())
                            {

                                if (datasetItem.patentNumber.Contains(patNum.patentNumber))
                                {
                                    List<string> inputLineList = new List<string>()
                                    {
                                        datasetItem.patentNumber,
                                        patNum.patentDate,
                                        datasetItem.patentAbstract
                                    };
                                    var inputLine = string.Join("\t", inputLineList);
                                    sw.WriteLine(inputLine);     
                                }
                            }
                         
                        }
                    }
                }     
            }
        }
    
    }
}