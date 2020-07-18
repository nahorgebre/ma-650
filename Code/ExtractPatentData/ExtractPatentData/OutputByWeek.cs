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
            descriptionOutputByWeek(patentListByWeekParsed, directory, year, week);
            claimsOutputByWeek(patentListByWeekParsed, directory, year, week);
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
            Console.WriteLine(string.Format("Output patent titles for the week {0} (year: {1}) - {2}", week, year, DateTime.UtcNow.ToString()));
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
            Console.WriteLine(string.Format("Output patent abstracts for the week {0} (year: {1}) - {2}", week, year, DateTime.UtcNow.ToString()));
        }

        public static void descriptionOutputByWeek(List<Patent> patentListByWeekParsed, string directory, string year, string week)
        {
            string fileNameDescription = directory + string.Format("description_y{0}_w{1}.tsv", year, week);
            if (!File.Exists(fileNameDescription))
            {
                var tsvFile = new StringBuilder();
                var delimiter = "\t";
                List<string> firstLineContent = new List<string>()
                {
                    "patentNumber",
                    "patentDate",
                    "patentDescription"
                };
                var firstLine = string.Join(delimiter, firstLineContent);
                tsvFile.AppendLine(firstLine);
                foreach (Patent patent in patentListByWeekParsed)
                {
                    List<string> itemContent = new List<string>()
                    {
                        patent.patentNumber,
                        patent.patentDate,
                        string.Format("\"{0}\"", patent.patentDescription)
                    };
                    var line = string.Join(delimiter, itemContent);
                    tsvFile.AppendLine(line);  
                }
                File.WriteAllText(fileNameDescription, tsvFile.ToString());
            }
            Console.WriteLine(string.Format("Output patent decriptions for the week {0} (year: {1}) - {2}", week, year, DateTime.UtcNow.ToString()));
        }

        public static void claimsOutputByWeek(List<Patent> patentListByWeekParsed, string directory, string year, string week)
        {
            string fileNameClaims = directory + string.Format("claims_y{0}_w{1}.tsv", year, week);
            if (!File.Exists(fileNameClaims))
            {
                var tsvFile = new StringBuilder();
                var delimiter = "\t";
                List<string> firstLineContent = new List<string>()
                {
                    "patentNumber",
                    "patentDate",
                    "patentClaims"
                };
                var firstLine = string.Join(delimiter, firstLineContent);
                tsvFile.AppendLine(firstLine);
                foreach (Patent patent in patentListByWeekParsed)
                {
                    List<string> itemContent = new List<string>()
                    {
                        patent.patentNumber,
                        patent.patentDate,
                        string.Format("\"{0}\"", patent.patentClaims)
                    };
                    var line = string.Join(delimiter, itemContent);
                    tsvFile.AppendLine(line);  
                }
                File.WriteAllText(fileNameClaims, tsvFile.ToString());
            }
            Console.WriteLine(string.Format("Output patent claims for the week {0} (year: {1}) - {2}", week, year, DateTime.UtcNow.ToString()));
        }
    }
}