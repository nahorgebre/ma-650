using System;
using System.IO;
using System.Collections.Generic;

namespace Data_Preparation
{
    class TargetPatentNumber
    {
        public string patentNumber;
        public string patentDate;
        

        public static List<TargetPatentNumber> getTargetPatentNumbers() {
            List<TargetPatentNumber> targetPatentNumberList = new List<TargetPatentNumber>();

            using (StreamReader sr = new StreamReader(Datasests_PatNum.US_Patents_1985_2016_313392.FullName))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    String[] values = line.Split(',');

                    TargetPatentNumber targetPatentNumber = new TargetPatentNumber();
                    targetPatentNumber.patentNumber = values[0].Replace("\"", string.Empty);
                    targetPatentNumber.patentDate = values[1].Replace("\"", string.Empty);

                    targetPatentNumberList.Add(targetPatentNumber);
                }
            }
            
            return targetPatentNumberList;
        }

        public static void getPatentNumbersByYear()
        {
            for (int year = 1985; year <= 2016; year++)
            {

                DirectoryInfo patNumByYearDirectory = new DirectoryInfo(string.Format("{0}/data/input/PatNum/PatNumByYear", Environment.CurrentDirectory));
                patNumByYearDirectory.Create();
                FileInfo patentsByYear = new FileInfo(string.Format("{0}/patents{1}.tsv", patNumByYearDirectory.FullName, year.ToString()));
                patentsByYear.Delete();
                using (StreamWriter sw = new StreamWriter(patentsByYear.FullName))
                {
                    using (StreamReader sr = new StreamReader(Datasests_PatNum.US_Patents_1985_2016_313392.FullName))
                    {
                        sr.ReadLine();
                        while (!sr.EndOfStream)
                        {
                            var line = sr.ReadLine();
                            String[] values = line.Split(',');
                            if (values[1].Contains(year.ToString()))
                            {
                                List<string> inputLineList = new List<string>(){
                                    values[0].Replace("\"", string.Empty),
                                    values[1].Replace("\"", string.Empty),
                                    values[2].Replace("\"", string.Empty)
                                };
                                string inputLine = string.Join("\t", inputLineList);
                                sw.WriteLine(inputLine);
                            }
                        }
                    }
                }

            }
        }
    
    }
}