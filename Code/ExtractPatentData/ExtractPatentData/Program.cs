using System;
using System.Collections.Generic;

namespace ExtractPatentData
{
    class Program
    {
        static void Main(string[] args)
        {
            //downloadAndExtractPatentData();
            //PatNum.getPatentsByyear();

            parseTxtFile();
            parseXmlFile();
        }

        public static void downloadAndExtractPatentData()
        {
            for (int year = 1987; year <= 2016; year++)
            {
                List<string> downloadedFiles = DownloadAndExtractBulkFiles.downloadBulkFiles(year);
                DownloadAndExtractBulkFiles.extractBulkFilesToDirectory(downloadedFiles);
                DownloadAndExtractBulkFiles.deleteBulkFiles(year.ToString());
            }            
        }

        public static void parseTxtFile()
        {
            for (int year = 1985; year <= 2001; year++)
            {
                List<string> bulkFilePathList = ParsePatentGrantFullTextData.getBulkFilePathList(year.ToString());
                ParsePatentGrantFullTextData.parseBulkFiles(bulkFilePathList, year);               
            }
        }

        public static void parseXmlFile()
        {
            for (int year = 2002; year <= 2016; year++)
            {
                
            }
        }
    }
}
