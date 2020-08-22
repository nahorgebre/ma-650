using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace ExtractPatentData
{
    class OutputByWeek
    {
        public static void run(List<Patent> patentListByWeekParsed, string year, string fileNamePattern)
        {   
            string directory = string.Format("{0}/data/output/outputByWeek{1}/", Environment.CurrentDirectory, year);
            Directory.CreateDirectory(directory);

            titleOutputByWeek(patentListByWeekParsed, directory, fileNamePattern);
            abstractOutputByWeek(patentListByWeekParsed, directory, fileNamePattern);
            descriptionOutputByWeek(patentListByWeekParsed, directory, fileNamePattern);
            claimsOutputByWeek(patentListByWeekParsed, directory, fileNamePattern);
        }

        public static void titleOutputByWeek(List<Patent> patentListByWeekParsed, string directory, string fileNamePattern)
        {
            string fileNameTitle = directory + string.Format("title{0}.tsv", fileNamePattern);
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
            Console.WriteLine("title{0}.tsv - {1}", fileNamePattern, DateTime.UtcNow.ToString());
        }

        public static void abstractOutputByWeek(List<Patent> patentListByWeekParsed, string directory, string fileNamePattern)
        {        
            string fileNameAbstract = directory + string.Format("abstract{0}.tsv", fileNamePattern);
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
            Console.WriteLine("abstract{0}.tsv - {1}", fileNamePattern, DateTime.UtcNow.ToString());
        }

        public static void descriptionOutputByWeek(List<Patent> patentListByWeekParsed, string directory, string fileNamePattern)
        {
            string fileNameDescription = directory + string.Format("description{0}.tsv", fileNamePattern);
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
            Console.WriteLine("description{0}.tsv - {1}", fileNamePattern, DateTime.UtcNow.ToString());
        }

        public static void claimsOutputByWeek(List<Patent> patentListByWeekParsed, string directory, string fileNamePattern)
        {
            string fileNameClaims = directory + string.Format("claims{0}.tsv", fileNamePattern);
            if (!File.Exists(fileNameClaims))
            {
                var tsvFile = new StringBuilder();
                var delimiter = "\t";
                List<string> firstLineContent = new List<string>()
                {
                    "patentNumber",
                    "patentDate",           
                    "patentClaimsCount",
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
                        patent.patentClaimsCount,
                        string.Format("\"{0}\"", patent.patentClaims),
                    };
                    var line = string.Join(delimiter, itemContent);
                    tsvFile.AppendLine(line);  
                }
                File.WriteAllText(fileNameClaims, tsvFile.ToString());
            }
            Console.WriteLine("claims{0}.tsv - {1}", fileNamePattern, DateTime.UtcNow.ToString());
        }

        public static bool checkIfOutputExist(string year, string fileNamePattern)
        {
            bool status = true;

            string directory = string.Format("{0}/data/output/outputByWeek{1}/", Environment.CurrentDirectory, year);
            Directory.CreateDirectory(directory);
            List<string> fileNameList = new List<string>
            {
                directory + string.Format("title{0}.tsv", fileNamePattern),
                directory + string.Format("abstract{0}.tsv", fileNamePattern),
                directory + string.Format("description{0}.tsv", fileNamePattern),
                directory + string.Format("claims{0}.tsv", fileNamePattern)
            };

            foreach (var item in fileNameList)
            {
                if (!File.Exists(item))
                {
                    status = false;
                    Console.WriteLine("{0} does not exist.", item.Substring(item.LastIndexOf("/")));
                }
            }

            if (status == true)
            {
                Console.WriteLine("All output files do exist.");
            }

            return status;
        }

    }
}