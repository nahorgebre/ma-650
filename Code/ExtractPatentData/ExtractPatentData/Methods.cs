using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace ExtractPatentData
{
    class DownloadAndExtractBulkFiles
    {
        public static List<string> downloadBulkFiles(int year)
        {
            List<string> pathList = new List<string>();
            using (var reader = new StreamReader(Environment.CurrentDirectory + @"\data\input\PatentGrantFullTextURL\" + year + "urls.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    using (WebClient webClient = new WebClient())
                    {
                        string directory = Environment.CurrentDirectory + @"\data\input\PatentGrantFullTextData\" + year;
                        Directory.CreateDirectory(directory);
                        int index = line.ToString().LastIndexOf("/");
                        string fileName = line.ToString().Substring(index);
                        webClient.DownloadFile(line.ToString(), directory + fileName);
                        pathList.Add(directory + fileName);
                    }
                }
            }
            return pathList;
        }

        public static void extractBulkFilesToDirectory(List<string> filePaths)
        {
            foreach (var filePath in filePaths)
            {
                string zipPath = filePath;
                string extractPath = filePath.Substring(0, filePath.LastIndexOf("."));
                ZipFile.ExtractToDirectory(zipPath, extractPath);
            }
        }

        public static void deleteBulkFiles(string year)
        {
            string[] downloadedFiles = Directory.GetFiles(Environment.CurrentDirectory + @"\data\input\PatentGrantFullTextData\" + year);
            foreach (var item in downloadedFiles)
            {
                File.Delete(item);
            }
        }

        public static void deleteBulkFolders(string year)
        {
            string[] directoryList = Directory.GetDirectories(Environment.CurrentDirectory + @"\data\input\PatentGrantFullTextData\" + year);
            foreach (var item in directoryList)
            {
                Directory.Delete(item, true);
            }
        }
    }
    
    class ParsePatentGrantFullTextData
    {
        public static List<string> getBulkFilePathList(string year)
        {
            string [] allDirectories =Directory.GetDirectories(Environment.CurrentDirectory + @"\data\input\PatentGrantFullTextData");
            List<string> directoryList = new List<string>(); 
            foreach (var item in allDirectories)
            {
                if (item.ToString().Contains(year))
                {
                   directoryList.Add(item); 
                }
            }
            
            List<string> bulkFilePathList = new List<string>();
            foreach (var directory in directoryList)
            {
                string [] filePathList = Directory.GetFiles(directory);
                foreach (var filePath in filePathList)
                {
                    bulkFilePathList.Add(filePath);
                }
            }
            return bulkFilePathList;
        }

        // PatentNumber - "WKU", 
        // Title - "TTL",
        // Abstract - "ABST",
        // Claims - "CLMS",
        public static void parseBulkFiles(List<string> bulkFilePathList, int year)
        {
            List<TitleFile> titleFileList = new List<TitleFile>();
            List<AbstractFile> abstractFileList = new List<AbstractFile>();
            List<DescriptionFile> descriptionFileList = new List<DescriptionFile>();
            List<ClaimFile> claimFileList = new List<ClaimFile>();

            List<string> givenPatNums = File.ReadAllLines(Environment.CurrentDirectory + @"\data\input\PatNumByyear\patents" + year + ".csv").ToList();

            foreach (var bulkFilePath in bulkFilePathList)
            {
                string readText = File.ReadAllText(bulkFilePath);
                readText = Regex.Replace(readText, "\r\n", string.Empty);
                string[] patents = readText.Split("PATN");
                foreach (string patent in patents.Skip(1))
                {
                    int startIndex = patent.IndexOf("WKU");
                    int length = patent.IndexOf("SRC") - startIndex;
                    string patNum = Regex.Replace(patent.Substring(startIndex, length), @"\s+", string.Empty);
                    foreach (string givenPatNum in givenPatNums)
                    {
                        if (patNum.Contains(givenPatNum))
                        {
                            TitleFile titleFileItem = new TitleFile();
                            titleFileItem.patentNumber = givenPatNum;
                            titleFileItem.patentyear = year.ToString();
                            titleFileItem.titleText = getTitleText(patent);
                            titleFileList.Add(titleFileItem);

                            AbstractFile abstractFileItem = new AbstractFile();
                            abstractFileItem.patentNumber = givenPatNum;
                            abstractFileItem.patentyear = year.ToString();
                            abstractFileItem.abstractText = getAbstractText(patent);
                            abstractFileList.Add(abstractFileItem);

                            DescriptionFile descriptionFileItem = new DescriptionFile();
                            descriptionFileItem.patentNumber = givenPatNum;
                            descriptionFileItem.patentyear = year.ToString();
                            descriptionFileItem.descriptionText = getDescriptionText(patent);
                            descriptionFileList.Add(descriptionFileItem);

                            ClaimFile claimFileItem = new ClaimFile();
                            claimFileItem.patentNumber = givenPatNum;                           
                            claimFileItem.patentyear = year.ToString();
                            claimFileItem.claimText= getClaimsText(patent);
                            claimFileList.Add(claimFileItem);
                        }
                    }


                    var titleCsvFile = new StringBuilder();
                    titleCsvFile.AppendLine("patentNumber,patentyear,titleText"); 
                    foreach (var item in titleFileList)
                    {
                        var newLine = string.Format("{0},{1},{2}", item.patentNumber, item.patentyear, item.titleText);
                        titleCsvFile.AppendLine(newLine);  
                    }
                    File.WriteAllText(Environment.CurrentDirectory + @"\data\output\Titles\" + year + "titles.csv", titleCsvFile.ToString());


                    var abstractCsvFile = new StringBuilder();
                    abstractCsvFile.AppendLine("patentNumber,patentyear,abstractText"); 
                    foreach (var item in abstractFileList)
                    {
                        var newLine = string.Format("{0},{1},{2}", item.patentNumber, item.patentyear, item.abstractText);
                        abstractCsvFile.AppendLine(newLine);  
                    }
                    File.WriteAllText(Environment.CurrentDirectory + @"\data\output\Abstracts\" + year + "abstracts.csv", abstractCsvFile.ToString());


                    var descriptionsCsvFile = new StringBuilder();
                    descriptionsCsvFile.AppendLine("patentNumber,patentyear,descriptionText"); 
                    foreach (var item in descriptionFileList)
                    {
                        var newLine = string.Format("{0},{1},{2}", item.patentNumber, item.patentyear, item.descriptionText);
                        descriptionsCsvFile.AppendLine(newLine);  
                    }
                    File.WriteAllText(Environment.CurrentDirectory + @"\data\output\Descriptions\" + year + "descriptions.csv", descriptionsCsvFile.ToString());


                    var claimsCsvFile = new StringBuilder();
                    claimsCsvFile.AppendLine("patentNumber,patentyear,claimText"); 
                    foreach (var item in claimFileList)
                    {
                        var newLine = string.Format("{0},{1},{2}", item.patentNumber, item.patentyear, item.claimText);
                        claimsCsvFile.AppendLine(newLine);  
                    }
                    File.WriteAllText(Environment.CurrentDirectory + @"\data\output\Descriptions\" + year + "claims.csv", claimsCsvFile.ToString());
                }
            }
        }

        public static string getTitleText(string patent)
        {
            string titleText = string.Empty;
            if (titleText.Contains("TTL"))
            {
                int startIndex = patent.IndexOf("TTL");
                int length = patent.IndexOf("ISD") - startIndex;
                titleText = Regex.Replace(patent.Substring(startIndex, length), "\r\n", string.Empty);
            }
            titleText = titleText.TrimStart().TrimEnd();
            titleText = "\"" + titleText + "\"";
            return titleText;
        }

        public static string getAbstractText(string patent)
        {
            string abstractText = string.Empty;
            if (patent.Contains("ABST") && patent.Contains("PARN"))
            {
                int startIndex = patent.IndexOf("ABST");
                int length = patent.IndexOf("PARN") - startIndex;
                abstractText = Regex.Replace(patent.Substring(startIndex, length), "\r\n", string.Empty);
                if (abstractText.Contains("PAL"))
                {
                    abstractText = Regex.Replace(abstractText, "PAL", string.Empty);
                }
            } 
            else if (patent.Contains("ABST"))
            {
                int startIndex = patent.IndexOf("ABST");
                int length = patent.IndexOf("BSUM") - startIndex;
                abstractText = Regex.Replace(patent.Substring(startIndex, length), "\r\n", string.Empty);
                if (abstractText.Contains("PAL"))
                {
                    abstractText = Regex.Replace(abstractText, "PAL", string.Empty);
                }          
            }
            abstractText = abstractText.TrimStart().TrimEnd();
            abstractText = "\"" + abstractText + "\"";      
            return abstractText;
        }

        public static string getDescriptionText(string patent)
        {
            string descriptionText = string.Empty;
            if (patent.Contains("BSUM"))
            {
                int startIndex = patent.IndexOf("BSUM");
                int length = patent.IndexOf("CLMS") - startIndex;
                descriptionText = Regex.Replace(patent.Substring(startIndex, length), "\r\n", string.Empty);
                if (descriptionText.Contains("DRWD"))
                {
                    descriptionText = Regex.Replace(descriptionText, "DRWD", string.Empty);
                }
                if (descriptionText.Contains("PAR"))
                {
                    descriptionText = Regex.Replace(descriptionText, "PAR", string.Empty);
                }
                if (descriptionText.Contains("PAC"))
                {
                    descriptionText = Regex.Replace(descriptionText, "PAC", string.Empty);
                }
                if (descriptionText.Contains("DETD"))
                {
                    descriptionText = Regex.Replace(descriptionText, "DETD", string.Empty);
                }
            }
            descriptionText = descriptionText.TrimStart().TrimEnd();
            descriptionText = "\"" + descriptionText + "\"";
            return descriptionText;
        }

        public static string getClaimsText(string patent)
        {
            string claimsText = string.Empty;
            if (patent.Contains("CMLS"))
            {
                claimsText = Regex.Replace(patent.Substring(patent.IndexOf("CLMS")), "\r\n", string.Empty);
                if (claimsText.Contains("STM"))
                {
                    claimsText = Regex.Replace(claimsText, "STM", string.Empty);
                }
                if (claimsText.Contains("NUM"))
                {
                    claimsText = Regex.Replace(claimsText, "NUM", string.Empty);
                }
                if (claimsText.Contains("PAR"))
                {
                    claimsText = Regex.Replace(claimsText, "PAR", string.Empty);
                }
                if (claimsText.Contains("PA1"))
                {
                    claimsText = Regex.Replace(claimsText, "PA1", string.Empty);
                }
            }
            claimsText = claimsText.TrimStart().TrimEnd();
            claimsText = "\"" + claimsText + "\"";   
            return claimsText;
        }
    }

    class PatNum
    {
        public static void getPatentsByyear()
        {
            for (int year = 1985; year <= 2016; year++)
            {
                List<string> patentList = new List<string>();
                using (var reader = new StreamReader(Environment.CurrentDirectory + @"\data\input\PatNum\US_Patents_1985_2016_313392.csv"))
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
                File.WriteAllText(Environment.CurrentDirectory + @"\data\input\PatNumByyear\patents" + year.ToString() + ".csv", csv.ToString());
            }
        }
    }
}