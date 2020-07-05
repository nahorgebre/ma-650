using System;
using System.IO;
using System.Net;
using System.IO.Compression;
using System.Collections.Generic;

namespace ExtractPatentData
{
    class BulkDownloader
    {
        public static void downloadBulkFiles()
        {
            Patent.getPatentsByyear();
            for (int year = 1985; year <= 2016; year++)
            {
                string yearDirectoty = Environment.CurrentDirectory + @"\data\input\PatentGrantFullTextData\" + year;
                Directory.CreateDirectory(yearDirectoty);

                List<string> pathList = new List<string>();
                using (var reader = new StreamReader(Environment.CurrentDirectory + @"\data\source\" + year.ToString() + ".txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        string filePath = yearDirectoty + @"\" + line.ToString().Substring(line.ToString().LastIndexOf("/")).Trim();
                        if (!File.Exists(filePath))
                        {
                            using (WebClient webClient = new WebClient())
                            {
                                webClient.DownloadFile(line.ToString().Trim(), filePath);
                                pathList.Add(filePath);
                            } 
                        }
                        else
                        {
                            if (!isZipFileValid(filePath))
                            {
                                File.Delete(filePath);
                                using (WebClient webClient = new WebClient())
                                {
                                    webClient.DownloadFile(line.ToString(), filePath);
                                    pathList.Add(filePath);
                                } 
                            }
                        }
                    }
                }               
            }         
        }

        public static bool isZipFileValid(string path)
        {
            try
            {
                using (var zipFile = ZipFile.OpenRead(path))
                {
                    var entries = zipFile.Entries;
                    return true;
                }
            }
            catch (InvalidDataException)
            {
                return false;
            }
        }
    }
}