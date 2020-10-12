using System;
using System.Collections.Generic;
using System.IO;

namespace Data_Preparation
{
    class CreateTrainGoldStandardDatasets
    {
        public string patNumber;
        public string textType;
        public string startOffset;
        public string endOffset;
        public string entityMention;
        public string entityMentionType;
        public string databaseIdentifier;

        // 1- Patent identifier
        // 2- Type of text from which the annotation was derived (T: Title, A: Abstract)
        // 3- Start offset
        // 4- End offset
        // 5- Text string of the entity mention
        // 6- Type of GPRO entity mention (NO CLASS,NESTED MENTIONS,IDENTIFIER,SEQUENCE, FULL NAME,ABBREVIATION,FAMILY,MULTIPLE)
        // 7- Database identifier of type 1 GPRO mentions, otherwise the tag 'GPRO_TYPE_2' if provided.

        public static void run() {
            DirectoryInfo outputDirectory = new DirectoryInfo(string.Format("{0}/data/output/goldstandard", Environment.CurrentDirectory));
            outputDirectory.Create();

            List<FileInfo> patents_goldstandard_list = new List<FileInfo>()
            {
                Datasets_gpro_development_set.chemdner_gpro_gold_standard_development,
                Datasets_gpro_training_set_v02.chemdner_gpro_gold_standard_train_v02
            };

            create_patents_test_gold_title(outputDirectory, patents_goldstandard_list);
            create_patents_test_gold_abstract(outputDirectory, patents_goldstandard_list);
        }

        public static void create_patents_test_gold_title(DirectoryInfo outputDirectory, List<FileInfo> patents_goldstandard_list) {
            FileInfo fileName = new FileInfo(string.Format("{0}/patents_train_gold_title.txt", outputDirectory.FullName));
            fileName.Delete();

            using (StreamWriter sw = new StreamWriter(fileName.FullName))
            {
                var delimiter = "\t";
                List<string> firstLineContent = new List<string>()
                {
                    "patentNumber",
                    "startOffset",
                    "endOffset",
                    "entityMention",
                    "entityMentionType",
                    "databaseIdentifier"
                };
                var firstLine = string.Join(delimiter, firstLineContent);
                sw.WriteLine(firstLine);  

                foreach (FileInfo patents_goldstandard in patents_goldstandard_list)
                {
                    using (StreamReader sr = new StreamReader(patents_goldstandard.FullName))
                    {
                        while (!sr.EndOfStream)
                        {
                            var line = sr.ReadLine();
                            if (!line.Equals(string.Empty))
                            {
                                
                                String[] values = line.Split(delimiter);

                                CreateTestGoldStandardDatasets gs = new CreateTestGoldStandardDatasets();
                                gs.patNumber = values[0].Trim();
                                gs.textType = values[1].Trim();
                                gs.startOffset = values[2].Trim();
                                gs.endOffset = values[3].Trim();
                                gs.entityMention = values[4].Trim();
                                gs.entityMentionType = values[5].Trim();
                                gs.databaseIdentifier = values[6].Trim();

                                if (gs.textType.Equals("T"))
                                {
                                    foreach (TargetPatentNumber patNum in TargetPatentNumber.getTargetPatentNumbers())
                                    {
                                        if (!gs.patNumber.Contains(patNum.patentNumber))
                                        {
                                            List<string> itemContent = new List<string>()
                                            {
                                                gs.patNumber,
                                                gs.startOffset,
                                                gs.endOffset,
                                                gs.entityMention,
                                                gs.entityMentionType,
                                                gs.databaseIdentifier
                                            };
                                            var inpuLine = string.Join(delimiter, itemContent);
                                            sw.WriteLine(inpuLine);  
                                        }
                                    }
                                }
   
                            }
                        }
                    }
                }
            
            
            }
        }

        public static void create_patents_test_gold_abstract(DirectoryInfo outputDirectory, List<FileInfo> patents_goldstandard_list) {
            FileInfo fileName = new FileInfo(string.Format("{0}/patents_train_gold_abstract.txt", outputDirectory.FullName));
            fileName.Delete();

            using (StreamWriter sw = new StreamWriter(fileName.FullName))
            {
                var delimiter = "\t";
                List<string> firstLineContent = new List<string>()
                {
                    "patentNumber",
                    "startOffset",
                    "endOffset",
                    "entityMention",
                    "entityMentionType",
                    "databaseIdentifier"
                };
                var firstLine = string.Join(delimiter, firstLineContent);
                sw.WriteLine(firstLine);  

                foreach (FileInfo patents_goldstandard in patents_goldstandard_list)
                {
                    using (StreamReader sr = new StreamReader(patents_goldstandard.FullName))
                    {
                        while (!sr.EndOfStream)
                        {
                            var line = sr.ReadLine();
                            if (!line.Equals(string.Empty))
                            {
                                
                                String[] values = line.Split(delimiter);

                                CreateTestGoldStandardDatasets gs = new CreateTestGoldStandardDatasets();
                                gs.patNumber = values[0].Trim();
                                gs.textType = values[1].Trim();
                                gs.startOffset = values[2].Trim();
                                gs.endOffset = values[3].Trim();
                                gs.entityMention = values[4].Trim();
                                gs.entityMentionType = values[5].Trim();
                                gs.databaseIdentifier = values[6].Trim();

                                if (gs.textType.Equals("A"))
                                {
                                    foreach (TargetPatentNumber patNum in TargetPatentNumber.getTargetPatentNumbers())
                                    {
                                        if (!gs.patNumber.Contains(patNum.patentNumber))
                                        {
                                            List<string> itemContent = new List<string>()
                                            {
                                                gs.patNumber,
                                                gs.startOffset,
                                                gs.endOffset,
                                                gs.entityMention,
                                                gs.entityMentionType,
                                                gs.databaseIdentifier
                                            };
                                            var inpuLine = string.Join(delimiter, itemContent);
                                            sw.WriteLine(inpuLine);  
                                        }
                                    }
                                }
   
                            }
                        }
                    }
                }
            
            }
        }  
    }
}