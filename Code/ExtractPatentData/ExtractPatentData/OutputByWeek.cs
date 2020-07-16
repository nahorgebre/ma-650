using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace ExtractPatentData
{
    class OutputByWeek
    {
        public static void run(List<Patent> patentListByWeekParsed, string year, string week)
        {   
            string directory = string.Format(Environment.CurrentDirectory + @"\data\output\outputByWeek{0}\", year);
            Directory.CreateDirectory(directory);

            titleOutputByWeek(patentListByWeekParsed, directory, year, week);
            abstractOutputByWeek(patentListByWeekParsed, directory, year, week);
        }

        public static void titleOutputByWeek(List<Patent> patentListByWeekParsed, string directory, string year, string week)
        {
            string fileNameTitle = directory + string.Format("title_y{0}_w{1}.tsv", year, week);
            if (!File.Exists(fileNameTitle))
            {
                var tsvFile = new StringBuilder();
                var delimiter = "\t";
                List<string> firstLineContent = new List<string>()
                {
                    "patentNumber",
                    "patentDate",
                    "patentTitle"
                };
                var firstLine = string.Join(delimiter, firstLineContent);
                tsvFile.AppendLine(firstLine);
                foreach (Patent patent in patentListByWeekParsed)
                {
                    List<string> itemContent = new List<string>()
                    {
                        patent.patentNumber,
                        patent.patentDate,
                        string.Format("\"{0}\"", patent.patentTitle)
                    };
                    var line = string.Join(delimiter, itemContent);
                    tsvFile.AppendLine(line);  
                }
                File.WriteAllText(fileNameTitle, tsvFile.ToString());
            }
            Console.WriteLine(string.Format("Output patent titles for the week {0} (year: {1}).", week, year));
        }

        public static void abstractOutputByWeek(List<Patent> patentListByWeekParsed, string directory, string year, string week)
        {        
            string fileNameAbstract = directory + string.Format("abstract_y{0}_w{1}.tsv", year, week);
            if (!File.Exists(fileNameAbstract))
            {
                var tsvFile = new StringBuilder();
                var delimiter = "\t";
                List<string> firstLineContent = new List<string>()
                {
                    "patentNumber",
                    "patentDate",
                    "patentAbstract"
                };
                var firstLine = string.Join(delimiter, firstLineContent);
                tsvFile.AppendLine(firstLine);
                foreach (Patent patent in patentListByWeekParsed)
                {
                    List<string> itemContent = new List<string>()
                    {
                        patent.patentNumber,
                        patent.patentDate,
                        string.Format("\"{0}\"", patent.patentAbstract)
                    };
                    var line = string.Join(delimiter, itemContent);
                    tsvFile.AppendLine(line);  
                }
                File.WriteAllText(fileNameAbstract, tsvFile.ToString());
            }
            Console.WriteLine(string.Format("Output patent abstracts for the week {0} (year: {1}).", week, year));
        }

        
    }
}