using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace ExtractPatentData
{
    class OutputByYear
    {
        public static void run(string year)
        {
            string outputDirectory = Environment.CurrentDirectory + @"\data\output\";
            string outputByWeekDirectory = string.Format(outputDirectory + @"outputByWeek{0}\", year);
            string outputByYearDirectory = outputDirectory + @"outputByYear\";

            Directory.CreateDirectory(outputByYearDirectory);

            string[] files = Directory.GetFiles(string.Format(outputDirectory + "outputByWeek{0}", year));

            titleOutputByYear(files, outputByYearDirectory, year);
            abstractOutputByYear(files, outputByYearDirectory, year);
            descriptionOutputByYear(files, outputByYearDirectory, year);
            claimsOutputByYear(files, outputByYearDirectory, year);
        }

        public static void titleOutputByYear(string[] files, string outputByYearDirectory, string year)
        {
            string fileNameTitle = string.Format(outputByYearDirectory + string.Format("title_y{0}.tsv", year));
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

                foreach (string fileName in files)
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

            Console.WriteLine(string.Format("Output patent titles for the year {0} - {1}", year, DateTime.UtcNow.ToString()));
        }

        public static void abstractOutputByYear(string[] files, string outputByYearDirectory, string year)
        {
            string fileNameAbstract = string.Format(outputByYearDirectory + string.Format("abstract_y{0}.tsv", year));
            if (!File.Exists(fileNameAbstract))
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

                foreach (string fileName in files)
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
                File.WriteAllText(fileNameAbstract, tsvFile.ToString());
            }

            Console.WriteLine(string.Format("Output patent abstracts for the year {0} - {1}", year, DateTime.UtcNow.ToString()));
        }

        public static void descriptionOutputByYear(string[] files, string outputByYearDirectory, string year)
        {
            string fileNameDescription = string.Format(outputByYearDirectory + string.Format("description_y{0}.tsv", year));
            if (!File.Exists(fileNameDescription))
            {
                var tsvFile = new StringBuilder();
                var delimiter = "\t";
                List<string> firstLineContent = new List<string>()
                {
                    "patentNumber",
                    "patentDate",
                    "patentDescription"
                };
                var firstLine = string.Join(delimiter, firstLineContent);
                tsvFile.AppendLine(firstLine);

                foreach (string fileName in files)
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
                File.WriteAllText(fileNameDescription, tsvFile.ToString());
            }

            Console.WriteLine(string.Format("Output patent descriptions for the year {0} - {1}", year, DateTime.UtcNow.ToString()));
        }

        public static void claimsOutputByYear(string[] files, string outputByYearDirectory, string year)
        {
            string fileNameClaims = string.Format(outputByYearDirectory + string.Format("claims_y{0}.tsv", year));
            if (!File.Exists(fileNameClaims))
            {
                var tsvFile = new StringBuilder();
                var delimiter = "\t";
                List<string> firstLineContent = new List<string>()
                {
                    "patentNumber",
                    "patentDate",
                    "patentClaimsCount",
                    "patentClaims"
                };
                var firstLine = string.Join(delimiter, firstLineContent);
                tsvFile.AppendLine(firstLine);

                foreach (string fileName in files)
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
                                        values[0], 
                                        values[1], 
                                        values[2],
                                        values[3]
                                    };
                                    var inputLine = string.Join(delimiter, itemContent);
                                    tsvFile.AppendLine(inputLine);
                                }                    
                            }
                        } 
                    }
                }
                File.WriteAllText(fileNameClaims, tsvFile.ToString());
            }
            
            Console.WriteLine(string.Format("Output patent claims for the year {0} - {1}", year, DateTime.UtcNow.ToString()));
        }

        public static void deleteOutputByWeek(string year)
        {
            string directory = Environment.CurrentDirectory + @"\data\output\outputByWeek" + year + @"\";
            Directory.Delete(directory, true);
        }
    }
}