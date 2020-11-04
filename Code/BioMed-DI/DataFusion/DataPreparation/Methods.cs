using System;
using System.Collections.Generic;
using System.IO;

namespace DataPreparation
{

    class Methods
    {

        public static void getDistinctRecordIds(List<(int, String)> recordIdList, string fileName) 
        {

            HashSet<String> recordIdHashSet = new HashSet<String>();

            foreach (var recordId in recordIdList)
            {
                using (StreamReader sr = new StreamReader(recordId.Item2.ToString()))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        String[] values = line.Split(',');

                        recordIdHashSet.Add(values[recordId.Item1 - 1].Trim());
                    }
                }
            }

            DirectoryInfo directory = new DirectoryInfo(string.Format("{0}/data/output/recordIds", Environment.CurrentDirectory));
            directory.Create();

            using (StreamWriter sw = new StreamWriter(string.Format("{0}/{1}.tsv", directory.FullName, fileName)))
            {
                foreach (String item in recordIdHashSet)
                {
                    sw.WriteLine(item);
                }
            }

        }

        public static void filterDataTranslationOutput(String dataTranslationOutputFileName, String recordIdFileName, String fileName) {

            DirectoryInfo directory = new DirectoryInfo(string.Format("{0}/data/output/dataFusionInput", Environment.CurrentDirectory));
            directory.Create();

            FileInfo file = new FileInfo(string.Format("{0}/{1}.xml", directory.FullName, fileName));

            using (StreamWriter sw = new StreamWriter(file.FullName))
            {
                
            }

            // Loop record Id ...
            foreach (String recordId in getRecordIdList(recordIdFileName))
            {
                
            }
        }

        public static List<string> getRecordIdList(String recordIdFileName)
        {
           List<String> recordIdList = new List<string>();

           using (StreamReader sr = new StreamReader(recordIdFileName))
           {
               while (!sr.EndOfStream)
               {
                   string line = sr.ReadLine().Trim();
                   recordIdList.Add(line);
               }
           }
           
           return recordIdList; 
        }

    }
}