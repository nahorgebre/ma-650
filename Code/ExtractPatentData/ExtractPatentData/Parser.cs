using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;

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
            for (int year = 1985; year <= 2001; year++)
            {
                HashSet<string> fileNameList = FileArchiver.extractFiles(year.ToString());

                List<List<string>> patentListByYear = new List<List<string>>();
                foreach (string fileName in fileNameList)
                {
                    List<List<string>> patentListByWeek = getAPSContent(fileName);
                    patentListByYear.AddRange(patentListByWeek);
                }

                List<Patent> patentListByYearParsed = extractAPS(patentListByYear, year.ToString());

                Output.writePatentTitleCsvByYear(patentListByYearParsed, year.ToString());
                Output.writePatentAbstractCsvByYear(patentListByYearParsed, year.ToString());
                Output.writePatentDescriptionCsvByYear(patentListByYearParsed, year.ToString());
                Output.writePatentClaimsCsvByYear(patentListByYearParsed, year.ToString());

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
                        if (line.Substring(0,4).Trim().Length == 0)
                        {
                            patent[patent.Count - 1] += " " + line.Trim();
                        }
                        else
                        {
                            patent.Add(header + "|" + line.Trim());
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
            List<string> targetPatentNumbers = Patent.getTargetPatentNumbers(year);

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

                        if (item.Equals("PATN|ISD"))
                        {
                            patent.patentYear = item.Substring(9,13).Trim();
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

                foreach (string targetPatentNumber in targetPatentNumbers)
                {
                    if (patent.patentNumber.Contains(targetPatentNumber))
                    {
                        patentList.Add(patent);
                    }
                }
            }
            return patentList;
        }
    }

    class ParserPG
    {
        public static void parseXML()
        {
            for (int year = 2002; year <= 2004; year++)
            {
                HashSet<string> fileNameList = FileArchiver.extractFiles(year.ToString());

                List<List<string>> patentListByYear = new List<List<string>>();
                foreach (string fileName in fileNameList)
                {
                    List<List<string>> patentListByWeek = getAPSContent(fileName);
                    patentListByYear.AddRange(patentListByWeek);
                }
            }
        }

        
    }

    class ParserIPG
    {
        public static void parseXML()
        {

        }
    }
}