using System;
using System.IO;
using System.Net;
using System.IO.Compression;
using System.Collections.Generic;

namespace ExtractPatentData
{
    class BulkDownloader
    {
        public static void run()
        {
            Patent.getPatentsByyear();
            for (int year = 1985; year <= 2016; year++)
            {
                string yearDirectoty = string.Format(@"{0}\data\input\PatentGrantFullTextData\{1}", Environment.CurrentDirectory, year);
                Directory.CreateDirectory(yearDirectoty);

                List<string> pathList = new List<string>();
                using (var reader = new StreamReader(string.Format(@"{0}\data\source\{1}.txt", Environment.CurrentDirectory, year.ToString())))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        
                        string filePath = string.Format(@"{0}\{1}", yearDirectoty, line.ToString().Substring(line.ToString().LastIndexOf("/") + 1).Trim());
                        if (!File.Exists(filePath))
                        {
                            using (WebClient webClient = new WebClient())
                            {
                                webClient.DownloadFile(line.ToString().Trim(), filePath);
                                pathList.Add(filePath);
                            }
                            Console.WriteLine(string.Format("{0}Downloading: {1} - {2}", Environment.NewLine, filePath, DateTime.UtcNow.ToString()));
                        }
                        else
                        {
                            if (!isZipFileValid(filePath))
                            {
                                File.Delete(filePath);
                                using (WebClient webClient = new WebClient())
                                {
                                    webClient.DownloadFile(line.ToString().Trim(), filePath);
                                    pathList.Add(filePath);
                                }
                                Console.WriteLine(string.Format("{0}Downloading: {1}", Environment.NewLine, filePath));
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