using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace ExtractPatentData
{
    class BulkDownloader
    {
        public static List<string> downloadBulkFiles(int year)
        {
            List<string> pathList = new List<string>();
            using (var reader = new StreamReader(Environment.CurrentDirectory + @"\data\source\" + year + "urls.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    using (WebClient webClient = new WebClient())
                    {
                        string directory = Environment.CurrentDirectory + @"\data\input\PatentGrantFullTextData\" + year;
                        Directory.CreateDirectory(directory);
                        int index = line.ToString()
                                        .LastIndexOf("/");
                        string fileName = line.ToString()
                                              .Substring(index);
                        webClient.DownloadFile(line.ToString(),
                                               directory + fileName);
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
}