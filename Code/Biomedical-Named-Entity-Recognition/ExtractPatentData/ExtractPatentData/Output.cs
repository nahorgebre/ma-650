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
            descriptionOutput(fileNameList, outputDirectory);
            claimsOutput(fileNameList, outputDirectory);
        }

        public static void titleOutput(string[] fileNameList, string outputDirectory)
        {
            string fileNameTitle = outputDirectory + "title.tsv";
            if (!File.Exists(fileNameTitle))
            {
                using (StreamWriter sw = new StreamWriter(fileNameTitle)) 
                {
                    var delimiter = "\t";
                    List<string> firstLineContent = new List<string>()
                    {
                        "patentNumber",
                        "patentDate",
                        "patentTitle"
                    };
                    var firstLine = string.Join(delimiter, firstLineContent);
                    sw.WriteLine(firstLine);

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
                                            values[0].ToString(), 
                                            values[1].ToString(), 
                                            values[2].ToString()
                                        };
                                        var inputLine = string.Join(delimiter, itemContent);
                                        sw.WriteLine(inputLine);
                                    }                    
                                }
                            } 
                        }
                    }
                }
            }
            Console.WriteLine(string.Format("title.tsv - {0}", DateTime.UtcNow.ToString()));
        }

        public static void abstarctOutput(string[] fileNameList, string outputDirectory)
        {
            string fileNameAbstract = outputDirectory + "abstract.tsv";
            if (!File.Exists(fileNameAbstract))
            {
                using (StreamWriter sw = new StreamWriter(fileNameAbstract)) 
                {
                    var delimiter = "\t";
                    List<string> firstLineContent = new List<string>()
                    {
                        "patentNumber",
                        "patentDate",
                        "patentAbstract"
                    };
                    var firstLine = string.Join(delimiter, firstLineContent);
                    sw.WriteLine(firstLine);

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
                                            values[0].ToString(), 
                                            values[1].ToString(), 
                                            values[2].ToString()
                                        };
                                        var inputLine = string.Join(delimiter, itemContent);
                                        sw.WriteLine(inputLine);
                                    }                    
                                }
                            } 
                        }
                    }
                }
            }
            Console.WriteLine(string.Format("abstract.tsv - {0}", DateTime.UtcNow.ToString()));
        }

        public static void descriptionOutput(string[] fileNameList, string outputDirectory)
        {
            string fileNameDescription = outputDirectory + "description.tsv";
            if (!File.Exists(fileNameDescription))
            {
                using (StreamWriter sw = new StreamWriter(fileNameDescription)) 
                {
                    var delimiter = "\t";
                    List<string> firstLineContent = new List<string>()
                    {
                        "patentNumber",
                        "patentDate",
                        "patentDescription"
                    };
                    var firstLine = string.Join(delimiter, firstLineContent);
                    sw.WriteLine(firstLine);

                    foreach (var fileName in fileNameList)
                    {
                        if (fileName.Contains("description"))
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
                                            values[0].ToString(), 
                                            values[1].ToString(), 
                                            values[2].ToString()
                                        };
                                        var inputLine = string.Join(delimiter, itemContent);
                                        sw.WriteLine(inputLine);
                                    }                    
                                }
                            } 
                        }
                    }
                }
            }
            Console.WriteLine(string.Format("description.tsv - {0}", DateTime.UtcNow.ToString()));
        }

        public static void claimsOutput(string[] fileNameList, string outputDirectory)
        {
            string fileNameClaims = outputDirectory + "claims.tsv";
            if (!File.Exists(fileNameClaims))
            {
                using (StreamWriter sw = new StreamWriter(fileNameClaims)) 
                {
                    var delimiter = "\t";
                    List<string> firstLineContent = new List<string>()
                    {
                        "patentNumber",
                        "patentDate",
                        "patentClaimsCount",
                        "patentClaims"
                    };
                    var firstLine = string.Join(delimiter, firstLineContent);
                    sw.WriteLine(firstLine);

                    foreach (var fileName in fileNameList)
                    {
                        if (fileName.Contains("claims"))
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
                                            values[0].ToString(), 
                                            values[1].ToString(), 
                                            values[2].ToString(),
                                            values[3].ToString()
                                        };
                                        var inputLine = string.Join(delimiter, itemContent);
                                        sw.WriteLine(inputLine);
                                    }                    
                                }
                            } 
                        }
                    }
                }
            }
            Console.WriteLine(string.Format("claims.tsv - {0}", DateTime.UtcNow.ToString()));
        }

        public static void deleteOutputByYear(string outputByYearDirectory)
        {
            Directory.Delete(outputByYearDirectory, true);
        }
 
    }
}