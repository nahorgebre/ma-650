using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace ExtractPatentData
{
    class Output
    {
        public static void run()
        {
            string outputDirectory = Environment.CurrentDirectory + @"\data\output\";
            string outputByYearDirectory = outputDirectory + @"outputByYear\";

            string[] fileNameList = Directory.GetFiles(outputByYearDirectory);

            titleOutput(fileNameList, outputDirectory);
            abstarctOutput(fileNameList, outputDirectory);

        }

        public static void titleOutput(string[] fileNameList, string outputDirectory)
        {
            string fileNameTitle = outputDirectory + "title.tsv";
            if (!File.Exists(fileNameTitle))
            {
                var tsvFile = new StringBuilder();
                var delimiter = "\t";
                List<string> firstLineContent = new List<string>()
                {
                    "patentNumber",
                    "patentDate",
                    "patentTitle"
                };
                var firstLine = string.Join(delimiter, firstLineContent);
                tsvFile.AppendLine(firstLine);

                foreach (var fileName in fileNameList)
                {
                    if (fileName.Contains("title"))
                    {
                        using (var reader = new StreamReader(fileName))
                        {
                            reader.ReadLine();
                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                if (!line.Equals(string.Empty))
                                {
                                    String[] values = line.Split(delimiter);
                                    List<string> itemContent = new List<string>()
                                    {
                                        values[0], 
                                        values[1], 
                                        values[2]
                                    };
                                    var inputLine = string.Join(delimiter, itemContent);
                                    tsvFile.AppendLine(inputLine); 
                                }                    
                            }
                        } 
                    }
                }
                File.WriteAllText(fileNameTitle, tsvFile.ToString());
            }
            Console.WriteLine("Output all patent titles for the year.");
        }

        public static void abstarctOutput(string[] fileNameList, string outputDirectory)
        {
            string fileNameTitle = outputDirectory + "abstract.tsv";
            if (!File.Exists(fileNameTitle))
            {
                var tsvFile = new StringBuilder();
                var delimiter = "\t";
                List<string> firstLineContent = new List<string>()
                {
                    "patentNumber",
                    "patentDate",
                    "patentAbstract"
                };
                var firstLine = string.Join(delimiter, firstLineContent);
                tsvFile.AppendLine(firstLine);

                foreach (var fileName in fileNameList)
                {
                    if (fileName.Contains("abstract"))
                    {
                        using (var reader = new StreamReader(fileName))
                        {
                            reader.ReadLine();
                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                if (!line.Equals(string.Empty))
                                {
                                    String[] values = line.Split(delimiter);
                                    List<string> itemContent = new List<string>()
                                    {
                                        values[0], 
                                        values[1], 
                                        values[2]
                                    };
                                    var inputLine = string.Join(delimiter, itemContent);
                                    tsvFile.AppendLine(inputLine); 
                                }                    
                            }
                        } 
                    }
                }
                File.WriteAllText(fileNameTitle, tsvFile.ToString());
            }
            Console.WriteLine("Output all patent abstracts for the year.");
        }

        public static void deleteOutputByYear(string outputByYearDirectory)
        {
            Directory.Delete(outputByYearDirectory, true);
        }
 
    }
}