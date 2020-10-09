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
            string outputDirectory = "./data/output/";
            string outputByWeekDirectory = string.Format(outputDirectory + "outputByWeek{0}/", year);
            string outputByYearDirectory = outputDirectory + "outputByYear/";

            Directory.CreateDirectory(outputByYearDirectory);

            string[] files = Directory.GetFiles(string.Format(outputDirectory + "outputByWeek{0}", year));

            Console.WriteLine("{0}Output by Year:", Environment.NewLine);

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
                    using (StreamWriter file = new StreamWriter(fileNameTitle))
                    {
                        var delimiter = "\t";
                        List<string> firstLineContent = new List<string>()
                        {
                            "patentNumber",
                            "patentDate",
                            "patentTitle"
                        };
                        var firstLine = string.Join(delimiter, firstLineContent);
                        file.WriteLine(firstLine);

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
                                            // ---
                                            try
                                            {
                                                String[] values = line.Split(delimiter);
                                                List<string> itemContent = new List<string>()
                                                {
                                                    values[0].ToString(),
                                                    values[1].ToString(),
                                                    values[2].ToString()
                                                };
                                                var inputLine = string.Join(delimiter, itemContent);
                                                file.WriteLine(inputLine);
                                            }
                                            catch (System.Exception)
                                            {
                                                Console.WriteLine("Exception in Input File!");
                                                Console.WriteLine("File Name: {0}", fileName);
                                                Console.WriteLine("Patent Number: {0}", line.Split(delimiter)[0].ToString());
                                            }
                                            // ---
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("Output patent titles for the year {0} - {1}", year, DateTime.UtcNow.ToString());
        }

        public static void abstractOutputByYear(string[] files, string outputByYearDirectory, string year)
        {
            string fileNameAbstract = string.Format(outputByYearDirectory + string.Format("abstract_y{0}.tsv", year));
            if (!File.Exists(fileNameAbstract))
            {
                using (StreamWriter file = new StreamWriter(fileNameAbstract))
                {
                    var delimiter = "\t";
                    List<string> firstLineContent = new List<string>()
                    {
                        "patentNumber",
                        "patentDate",
                        "patentAbstract"
                    };
                    var firstLine = string.Join(delimiter, firstLineContent);
                    file.WriteLine(firstLine);

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
                                        // ---
                                        try
                                        {
                                            String[] values = line.Split(delimiter);
                                            List<string> itemContent = new List<string>()
                                            {
                                                values[0].ToString(), 
                                                values[1].ToString(), 
                                                values[2].ToString()
                                            };
                                            var inputLine = string.Join(delimiter, itemContent);
                                            file.WriteLine(inputLine);
                                        
                                        }
                                        catch (System.Exception)
                                        {
                                            Console.WriteLine("Exception in Input File!");
                                            Console.WriteLine("File Name: {0}", fileName);
                                            Console.WriteLine("Patent Number: {0}", line.Split(delimiter)[0].ToString());
                                        }
                                        // ---
                                    }                    
                                }
                            } 
                        }
                    }
                }
            }
            Console.WriteLine("Output patent abstracts for the year {0} - {1}", year, DateTime.UtcNow.ToString());
        }

        public static void descriptionOutputByYear(string[] files, string outputByYearDirectory, string year)
        {
            string fileNameDescription = string.Format(outputByYearDirectory + string.Format("description_y{0}.tsv", year));
            if (!File.Exists(fileNameDescription))
            {
                using (StreamWriter file = new StreamWriter(fileNameDescription))
                {
                    var delimiter = "\t";
                    List<string> firstLineContent = new List<string>()
                    {
                        "patentNumber",
                        "patentDate",
                        "patentDescription"
                    };
                    var firstLine = string.Join(delimiter, firstLineContent);
                    file.WriteLine(firstLine);

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
                                        // ---
                                        try
                                        {
                                            String[] values = line.Split(delimiter);
                                            List<string> itemContent = new List<string>()
                                            {
                                                values[0].ToString(), 
                                                values[1].ToString(), 
                                                values[2].ToString()
                                            };
                                            var inputLine = string.Join(delimiter, itemContent);
                                            file.WriteLine(inputLine);
                                        }
                                        catch (System.Exception)
                                        {
                                            Console.WriteLine("Exception in Input File!");
                                            Console.WriteLine("File Name: {0}", fileName);
                                            Console.WriteLine("Patent Number: {0}", line.Split(delimiter)[0].ToString());
                                        }
                                        // ---

                                    }                    
                                }
                            } 
                        }
                    }
                }
            }

            Console.WriteLine("Output patent descriptions for the year {0} - {1}", year, DateTime.UtcNow.ToString());
        }

        public static void claimsOutputByYear(string[] files, string outputByYearDirectory, string year)
        {
            string fileNameClaims = string.Format(outputByYearDirectory + string.Format("claims_y{0}.tsv", year));
            if (!File.Exists(fileNameClaims))
            {
                using (StreamWriter file = new StreamWriter(fileNameClaims))
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
                    file.WriteLine(firstLine);
   
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
                                        // ---
                                        try
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
                                            file.WriteLine(inputLine);
                                        }
                                        catch (System.Exception)
                                        {
                                            Console.WriteLine("Exception in Input File!");
                                            Console.WriteLine("File Name: {0}", fileName);
                                            Console.WriteLine("Patent Number: {0}", line.Split(delimiter)[0].ToString());
                                        }
                                        // ---

                                    }                    
                                }
                            } 
                        }
                    }
                }

            }
            Console.WriteLine("Output patent claims for the year {0} - {1}", year, DateTime.UtcNow.ToString());
        }

        public static void deleteOutputByWeek(string year)
        {       
            string directory = string.Format("./data/output/outputByWeek{0}/", year);
            Directory.Delete(directory, true);
        }
    }
}