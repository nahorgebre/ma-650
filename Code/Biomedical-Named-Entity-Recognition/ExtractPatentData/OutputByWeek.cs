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
            FileInfo fileNameTitle = new FileInfo(directory + string.Format("title{0}.tsv", fileNamePattern));

            if (!File.Exists(fileNameTitle.FullName))
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

                foreach (var patent in patentListByWeekParsed)
                {
                    List<string> itemContent = new List<string>()
                    {
                        patent.patentNumber,
                        patent.patentDate,
                        patent.patentTitle
                    };
                    var line = string.Join(delimiter, itemContent);
                    tsvFile.AppendLine(line);  
                }
                File.WriteAllText(fileNameTitle.FullName, tsvFile.ToString());
            }
            outputByWeekInfo(fileNameTitle);      
        }

        public static void abstractOutputByWeek(List<Patent> patentListByWeekParsed, string directory, string fileNamePattern)
        { 
            FileInfo fileNameAbstract = new FileInfo(directory + string.Format("abstract{0}.tsv", fileNamePattern));

            if (!File.Exists(fileNameAbstract.FullName))
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
                foreach (var patent in patentListByWeekParsed)
                {
                    List<string> itemContent = new List<string>()
                    {
                        patent.patentNumber,
                        patent.patentDate,
                        patent.patentAbstract
                    };
                    var line = string.Join(delimiter, itemContent);
                    tsvFile.AppendLine(line);  
                }
                File.WriteAllText(fileNameAbstract.FullName, tsvFile.ToString());
            }
            outputByWeekInfo(fileNameAbstract);       
        }

        public static void descriptionOutputByWeek(List<Patent> patentListByWeekParsed, string directory, string fileNamePattern)
        {
            FileInfo fileNameDescription = new FileInfo(directory + string.Format("description{0}.tsv", fileNamePattern));

            if (!File.Exists(fileNameDescription.FullName))
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
                foreach (var patent in patentListByWeekParsed)
                {
                    List<string> itemContent = new List<string>()
                    {
                        patent.patentNumber,
                        patent.patentDate,
                        patent.patentDescription
                    };
                    var line = string.Join(delimiter, itemContent);
                    tsvFile.AppendLine(line);  
                }
                File.WriteAllText(fileNameDescription.FullName, tsvFile.ToString());              
            }
            outputByWeekInfo(fileNameDescription);    
        }

        public static void claimsOutputByWeek(List<Patent> patentListByWeekParsed, string directory, string fileNamePattern)
        {
            FileInfo fileNameClaims = new FileInfo(directory + string.Format("claims{0}.tsv", fileNamePattern));

            if (!File.Exists(fileNameClaims.FullName))
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
                        patent.patentClaims
                    };
                    var line = string.Join(delimiter, itemContent);
                    tsvFile.AppendLine(line);  
                }
                File.WriteAllText(fileNameClaims.FullName, tsvFile.ToString());              
            }
            outputByWeekInfo(fileNameClaims);   
        }

        public static void outputByWeekInfo(FileInfo file)
        {
            Console.WriteLine(string.Format("{0} - {1} - {2}", file.Name, DateTime.UtcNow.ToString(), file.Length));
        }

        public static bool checkIfOutputExist(string year, string fileNamePattern)
        {
            // files do exist
            bool status = true;

            DirectoryInfo directory = new DirectoryInfo(string.Format("{0}/data/output/outputByWeek{1}", Environment.CurrentDirectory, year));

            List<FileInfo> fileList = new List<FileInfo>
            {
                new FileInfo(string.Format("{0}/title{1}.tsv", directory.FullName, fileNamePattern)),
                new FileInfo(string.Format("{0}/abstract{1}.tsv", directory.FullName, fileNamePattern)),
                new FileInfo(string.Format("{0}/description{1}.tsv", directory.FullName, fileNamePattern)),
                new FileInfo(string.Format("{0}/claims{1}.tsv", directory.FullName, fileNamePattern))
            };

            foreach (var file in fileList)
            {

                if (!File.Exists(file.FullName))
                {
                    // files do not exist
                    status = false;
                    Console.WriteLine("{0} does not exist.", file.FullName);
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