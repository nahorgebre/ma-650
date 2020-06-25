using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExtractPatentData
{
    class Patent
    {
        public string patentNumber = string.Empty;
        public string patentYear = string.Empty;
        public string patentTitle = string.Empty;
        public string patentClaims = string.Empty;
        public string patentAbstract = string.Empty;
        public string patentDescription = string.Empty;

        public static void getPatentsByyear()
        {
            for (int year = 1985; year <= 2016; year++)
            {
                List<string> patentList = new List<string>();
                using (var reader = new StreamReader(Environment.CurrentDirectory + @"\data\PatNum\US_Patents_1985_2016_313392.csv"))
                {
                    reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        String[] values = line.Split(',');
                        if (values[1].Contains(year.ToString()))
                        {
                            patentList.Add(values[0].Replace("\"", ""));
                        }                
                    }
                }
                var csv = new StringBuilder();
                foreach (var patent in patentList)
                {
                    csv.AppendLine(patent); 
                }
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\data\input\PatNumByYear");
                File.WriteAllText(Environment.CurrentDirectory + @"\data\input\PatNumByYear\patents" + year.ToString() + ".csv", csv.ToString());
            }
        }
    
        public static List<string> getTargetPatentNumbers(string year)
        {
            List<string> targetPatentNumbers = new List<string>();

            using (var reader = new StreamReader(Environment.CurrentDirectory + @"\data\input\PatNumByYear\patents" + year.ToString() + ".csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (!line.Equals(string.Empty))
                    {
                        targetPatentNumbers.Add(line.Trim());
                    }
                }
            }   
            return targetPatentNumbers;
        }
    }
}