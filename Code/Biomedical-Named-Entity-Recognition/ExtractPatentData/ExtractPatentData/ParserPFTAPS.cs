using System;
using System.IO;
using System.Linq;
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

        public static void run()
        {
            try
            {
                for (int year = 1985; year <= 2001; year++)
                {
                    foreach (var zipFile in Directory.GetFiles(string.Format(@"{0}\data\input\PatentGrantFullTextData\{1}", Environment.CurrentDirectory, year.ToString())))
                    {
                        string fileNamePattern = Parser.getFileNamePattern(zipFile, "pftaps", year.ToString());
                        Console.WriteLine(string.Format("{0}File Name: ...{1}.tsv", Environment.NewLine, fileNamePattern));

                        if (OutputByWeek.checkIfOutputExist(year.ToString(), fileNamePattern) == false)
                        {
                            string fileName = FileArchiver.extractSingleFile(zipFile);

                            List<List<string>> patentListByWeek = getAPSContent(fileName);
                            List<Patent> patentListByWeekParsed = parseAPS(patentListByWeek, year.ToString());
                            OutputByWeek.run(patentListByWeekParsed, year.ToString(), fileNamePattern);

                            FileArchiver.deleteExtractedFile(fileName);
                        }
                    }

                    OutputByYear.run(year.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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

        public static List<Patent> parseAPS(List<List<string>> dataList, string year)
        {
            List<Patent> patentList = new List<Patent>();

            foreach (List<string> patentListItem in dataList)
            {
                Patent patent = new Patent();

                foreach (string item in patentListItem)
                {

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
                }

                foreach (TargetPatentNumber targetPatentNumber in Patent.getTargetPatentNumbers(year))
                {
                    if (patent.patentNumber.Contains(targetPatentNumber.targetPatentNumber))
                    {  
                        patent.patentDate = targetPatentNumber.targetPatentDate;
                        patent.patentClaimsCount = targetPatentNumber.targetPatentClaimsCount;

                        patent.patentTitle = StringPreprocessing.run(patent.patentTitle);
                        patent.patentDescription = StringPreprocessing.run(patent.patentDescription);
                        patent.patentClaims = StringPreprocessing.run(patent.patentClaims);
                        patent.patentAbstract = StringPreprocessing.run(patent.patentAbstract);
                        
                        patentList.Add(patent);
                    }
                }
            }

            Console.WriteLine(string.Format("All files for the year {0} are parsed.", year));
            return patentList;
        }
    }
}