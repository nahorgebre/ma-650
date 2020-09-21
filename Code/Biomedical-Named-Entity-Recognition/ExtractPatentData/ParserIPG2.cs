using System;
using System.Collections.Generic;
using System.IO;

namespace ExtractPatentData
{
    class ParserIPG2
    {
        public static void run()
        {
            for (int year = 2006; year <= 2016; year++)
            {
                List<string> fileNameList = new List<string>();
                foreach (var zipFile in Directory.GetFiles(string.Format("./data/input/PatentGrantFullTextData/{0}", year.ToString())))
                {
                    string fileNamePattern = Parser.getFileNamePattern(zipFile, "pg", year.ToString());
                    Console.WriteLine(string.Format("{0}File Name: ...{1}.tsv", Environment.NewLine, fileNamePattern));

                    if (OutputByWeek.checkIfOutputExist(year.ToString(), fileNamePattern) == false)
                    {              
                        string fileName = FileArchiver.extractSingleFile(zipFile);
                        fileNameList.Add(fileName);
                    }
                }
            }
        }
    }
}