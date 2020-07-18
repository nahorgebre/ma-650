using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ExtractPatentData
{

    class ParserPFTAPS
    {
        public static List<string> LogicalGroupsAPS = new List<string>()
        {
            "PATN", "INVT", "ASSG", "PRIR", "PCTA", "ABST", "GOVT", "PARN", "BSUM", "DRWD", "DETD", "CLMS", "DCLM"
        };

        public static void parseAPS()
        {
            for (int year = 1996; year <= 2001; year++)
            {
                HashSet<string> fileNameList = FileArchiver.extractFiles(year.ToString());

                int week = 1;
                foreach (string fileName in fileNameList)
                {
                    List<List<string>> patentListByWeek = getAPSContent(fileName);
                    List<Patent> patentListByWeekParsed = extractAPS(patentListByWeek, year.ToString());
                    OutputByWeek.run(patentListByWeekParsed, year.ToString(), week.ToString());
                    week += 1;
                }

                OutputByYear.run(year.ToString());

                FileArchiver.deleteExtractedFiles(year.ToString());
            }
        }

        public static List<List<string>> getAPSContent(string filePath)
        {
            List<List<string>> patentListByWeek = new List<List<string>>();
      
            foreach (string patentItem in Regex.Split(File.ReadAllText(filePath), "PATN").Skip(1))
            {
                List<string> patent = new List<string>();
                string header = string.Empty;

                foreach (var line in ("PATN\r\n" + patentItem).Split("\r\n"))
                {
                    if (line.Length > 0)
                    {
                        if (line.Trim().Length == 4 && LogicalGroupsAPS.Contains(line.Trim()))
                        {
                            patent.Add("END|" + header);
                            header = line.Trim();
                            if (header == "PATN")
                            {
                                patent.Add("END|***");
                            }
                        }

                        if (line.Length >= 4)
                        {
                            if (line.Substring(0,4).Trim().Length == 0)
                            {
                                patent[patent.Count - 1] += " " + line.Trim();
                            }
                            else
                            {
                                patent.Add(header + "|" + line.Trim());
                            }
                        }
                        else
                        {
                            Console.WriteLine(filePath + ": '" + line + "'");
                        }

                    }
                }
                patentListByWeek.Add(patent);
            }
        return patentListByWeek;
        }

        public static List<Patent> extractAPS(List<List<string>> dataList, string year)
        {
            List<Patent> patentList = new List<Patent>();
            List<TargetPatentNumber> targetPatentNumbers = Patent.getTargetPatentNumbers(year);

            foreach (List<string> patentListItem in dataList)
            {

                StringBuilder apsLogFile = new StringBuilder();

                Patent patent = new Patent();
                foreach (string item in patentListItem)
                {
                    apsLogFile.Append(Environment.NewLine + item);

                    if (item.Length >= 9)
                    {
                        string header = item.Substring(0,9).Trim();

                        if (item.Contains("PATN|WKU"))
                        {
                            patent.patentNumber = item.Substring(9,item.Length - 9).Trim();
                        }
                    
                        if (item.Contains("PATN|TTL"))
                        {
                            patent.patentTitle = item.Substring(9,item.Length - 9).Trim();
                        }

                        if (item.Contains("BSUM") || item.Contains("DRWD") || item.Contains("DETD"))
                        {
                            if (patent.patentDescription.Equals(string.Empty))
                            {
                                patent.patentDescription = item.Substring(9,item.Length - 9).Trim();
                            }
                            else
                            {
                                patent.patentDescription += " " + item.Substring(9,item.Length - 9).Trim();
                            }     
                        }

                        if (item.Contains("DCLM") || item.Contains("CLMS"))
                        {
                            if (patent.patentClaims.Equals(string.Empty))
                            {
                                patent.patentClaims = item.Substring(9,item.Length - 9).Trim();
                            }
                            else
                            {
                                patent.patentClaims += " " + item.Substring(9,item.Length - 9).Trim();
                            }     
                        }

                        if (item.Contains("ABST"))
                        {
                            if (patent.patentAbstract.Equals(string.Empty))
                            {
                                patent.patentAbstract = item.Substring(9,item.Length - 9).Trim();
                            }
                            else
                            {
                                patent.patentAbstract += " " + item.Substring(9,item.Length - 9).Trim();
                            }                   
                        }
                    }

                    foreach (TargetPatentNumber targetPatentNumber in targetPatentNumbers)
                    {
                        if (patent.patentNumber.Contains(targetPatentNumber.targetPatentNumber))
                        {                                   
                            string directory = string.Format(Environment.CurrentDirectory + @"\data\log\aps{0}\", year);
                            Directory.CreateDirectory(directory);
                            string logFileName = string.Format(directory + "{0}.log", targetPatentNumber.targetPatentNumber);
                            if (File.Exists(logFileName))
                            {
                                File.Delete(logFileName);
                            }
                            File.AppendAllText(logFileName, apsLogFile.ToString());
                        }
                    }

                }

                foreach (TargetPatentNumber targetPatentNumber in targetPatentNumbers)
                {
                    if (patent.patentNumber.Contains(targetPatentNumber.targetPatentNumber))
                    {
                        patent.patentDate = targetPatentNumber.targetPatentDate;
                        patentList.Add(patent);
                    }
                }
            }
            Console.WriteLine("All files for the year " + year + " are parsed.");
            return patentList;
        }
    }
}