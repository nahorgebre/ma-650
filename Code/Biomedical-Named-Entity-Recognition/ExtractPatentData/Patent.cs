using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace ExtractPatentData
{
    class Patent
    {
        public string patentNumber = string.Empty;
        public string patentDate = string.Empty;
        public string patentTitle = string.Empty;
        public string patentClaims = string.Empty;
        public string patentClaimsCount = string.Empty;
        public string patentAbstract = string.Empty;
        public string patentDescription = string.Empty;

        public static void getPatentsByyear()
        {
            for (int year = 1985; year <= 2016; year++)
            {
                List<TargetPatentNumber> targetPatentNumberList = new List<TargetPatentNumber>();
                using (var reader = new StreamReader(string.Format("{0}/data/PatNum/US_Patents_1985_2016_313392.csv", Environment.CurrentDirectory)))
                {
                    reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        TargetPatentNumber targetPatentNumber = new TargetPatentNumber();
                        var line = reader.ReadLine();
                        String[] values = line.Split(',');
                        if (values[1].Contains(year.ToString()))
                        {
                            targetPatentNumber.targetPatentNumber = values[0].Replace("\"", "");
                            targetPatentNumber.targetPatentDate = values[1].Replace("\"", "");
                            targetPatentNumber.targetPatentClaimsCount = values[2].Replace("\"", "");
                            targetPatentNumberList.Add(targetPatentNumber);
                        }                
                    }
                }

                var csv = new StringBuilder();
                foreach (TargetPatentNumber targetPatentNumber in targetPatentNumberList)
                {
                    csv.Append(                     
                        targetPatentNumber.targetPatentNumber + "," +
                        targetPatentNumber.targetPatentDate + "," +
                        targetPatentNumber.targetPatentClaimsCount +
                        Environment.NewLine
                    );
                }
                Directory.CreateDirectory(string.Format("{0}/data/input/PatNumByYear", Environment.CurrentDirectory));     
                File.WriteAllText(string.Format("{0}/data/input/PatNumByYear/patents{1}.csv", Environment.CurrentDirectory, year.ToString()), csv.ToString());
            }
        }
    
        public static List<TargetPatentNumber> getTargetPatentNumbers(string year)
        {
            List<TargetPatentNumber> targetPatentNumberList = new List<TargetPatentNumber>();

            using (var reader = new StreamReader(string.Format("{0}/data/input/PatNumByYear/patents{1}.csv", Environment.CurrentDirectory, year.ToString())))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split(',');

                    if (!values[0].Equals(string.Empty))
                    {
                        TargetPatentNumber targetPatentNumber = new TargetPatentNumber();
                        targetPatentNumber.targetPatentNumber = values[0].Trim();
                        targetPatentNumber.targetPatentDate = values[1].Trim();
                        targetPatentNumber.targetPatentClaimsCount = values[2].Trim();
                        targetPatentNumberList.Add(targetPatentNumber);
                    }
                }
            }   
            return targetPatentNumberList;
        }
    }
}