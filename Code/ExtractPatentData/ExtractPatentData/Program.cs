using System;
using System.Collections.Generic;

namespace ExtractPatentData
{
    class Program
    {
        static void Main(string[] args)
        {
            //downloadPatentData();
            //PatNum.getPatentsByyear();

            parsePatentData();
        }

        public static void downloadPatentData()
        {
            for (int year = 1987; year <= 2016; year++)
            {
                List<string> downloadedFiles = BulkDownloader.downloadBulkFiles(year);
                BulkDownloader.extractBulkFilesToDirectory(downloadedFiles);
                BulkDownloader.deleteBulkFiles(year.ToString());
            }            
        }

        public static void parsePatentData()
        {
            for (int year = 1985; year <= 2001; year++)
            {
                List<string> bulkFilePathList = ParsePatentGrantFullTextData.getBulkFilePathList(year.ToString());
                ParsePatentGrantFullTextData.parseBulkFiles(bulkFilePathList, year);               
            }

            for (int year = 2002; year <= 2016; year++)
            {
                
            }
        }
    }
}
