using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace ExtractPatentData
{
    class ParserPG2
    {
        public static void run()
        {
            for (int year = 2002; year <= 2004; year++)
            {                              
                DirectoryInfo directorySelected = new DirectoryInfo(string.Format("{0}/data/input/PatentGrantFullTextData/{1}", Environment.CurrentDirectory, year));

                // 1 - Decompress all files
                DecompressAllFiles(directorySelected);

                // 2 - Merge XML files
                MergeXmlFiles(directorySelected);

                // 3 - Parse XML files
                ParseXML(directorySelected, year.ToString());

                year++;
            }
        }

        public static void DecompressAllFiles(DirectoryInfo directorySelected) 
        {
            foreach (FileInfo fileToDecompress in directorySelected.GetFiles("*.zip"))
            {
                string fileName1 = string.Format("{0}/{1}.xml", fileToDecompress.DirectoryName, fileToDecompress.Name.Substring(0, fileToDecompress.Name.LastIndexOf(".")));
                string fileName2 = string.Format("{0}/{1}.XML", fileToDecompress.DirectoryName, fileToDecompress.Name.Substring(0, fileToDecompress.Name.LastIndexOf(".")));
                if (!File.Exists(fileName1))
                {
                    if (!File.Exists(fileName2))
                    {
                        ZipFile.ExtractToDirectory(fileToDecompress.FullName, directorySelected.FullName);
                    }                   
                }              
            }
        }

        public static void MergeXmlFiles(DirectoryInfo directorySelected)
        {
            foreach (FileInfo item in directorySelected.GetFiles("*.xml"))
            {
                if (!item.Name.Contains("edit"))
                {
                    string fileName = string.Format("{0}/{1}edit.xml", directorySelected.FullName, item.Name.Substring(0, item.Name.LastIndexOf(".")));

                    if (!File.Exists(fileName))
                    {
                        string text = File.ReadAllText(item.FullName, Encoding.UTF8);
                        string pattern = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";

                        text = text.Replace(pattern, "PATENT-TEXT-START" );
                        string[] tokens = text.Split(new[] { "PATENT-TEXT-START" }, StringSplitOptions.None);
                        tokens = tokens.Skip(1).ToArray();
 
                        using (StreamWriter file = new StreamWriter(fileName))
                        {                    
                            string start = string.Format("{0}{1}<root>", pattern, Environment.NewLine);
                            file.Write(start);

                            foreach (var token in tokens)
                            {
                                file.Write(RemoveFirstLine(token));
                            }

                            string end = "</root>";
                            file.Write(end);
                        }   
                    }           
                }
            }
        }

        public static void ParseXML(DirectoryInfo directorySelected, string year) 
        {

            foreach (FileInfo item in directorySelected.GetFiles("*.xml"))
            {
                List<Patent> patentListByWeekParsed = new List<Patent>();

                if (item.Name.Contains("edit"))
                {
                    try
                    {
                        using (XmlReader reader = XmlReader.Create(item.FullName))
                        {
                            while (reader.ReadToFollowing("us-patent-grant"))
                            {

                                // Parsing Patent Number
                                // <B110><DNUM><PDAT>
                                string patentNumber = string.Empty;
                                reader.ReadToFollowing("B110");
                                XmlReader b110Inner = reader.ReadSubtree();
                                b110Inner.ReadToFollowing("PDAT");
                                patentNumber = b110Inner.ReadElementContentAsString();

                                foreach (TargetPatentNumber targetPatentNumber in Patent.getTargetPatentNumbers(year))
                                {
                                    if (patentNumber.Contains(targetPatentNumber.targetPatentNumber))
                                    {

                                        // Create instance of patent
                                        Patent patentItem = new Patent();
                                        patentItem.patentNumber = patentNumber;
                                        patentItem.patentDate = targetPatentNumber.targetPatentDate;
                                        patentItem.patentClaimsCount = targetPatentNumber.targetPatentClaimsCount;

                                        // Parsing Title
                                        string patentTitle = string.Empty;
                                        reader.ReadToFollowing("B540");
                                        XmlReader b540Inner = reader.ReadSubtree();
                                        b540Inner.ReadToFollowing("PDAT");
                                        patentTitle = b540Inner.ReadElementContentAsString();

                                        // Add to patent instance
                                        patentItem.patentTitle = patentTitle;
                                        Console.WriteLine("Title: " + patentItem.patentTitle);

                                        // Parsing Abstract SDOAB
                                        string patentAbstarct = string.Empty;
                                        reader.ReadToFollowing("SDOAB");
                                        XmlReader abstractInner = reader.ReadSubtree();
                                        while (abstractInner.Read())
                                        {
                                            if (abstractInner.HasValue)  
                                            {
                                                if (!abstractInner.Value.Trim().Equals(string.Empty))
                                                {
                                                    patentAbstarct = string.Concat(patentAbstarct, addWhiteSpace(abstractInner.Value));
                                                }
                                            }
                                        }
                                        abstractInner.Close();

                                        // Add to patent instance
                                        patentItem.patentAbstract = patentAbstarct;

                                        // Parsing Descriptions
                                        string patentDescription = string.Empty;
                                        reader.ReadToFollowing("SDODE"); 
                                        XmlReader descriptionInner = reader.ReadSubtree();
                                        while (descriptionInner.Read())
                                        {
                                            if (descriptionInner.HasValue)
                                            {
                                                if (!descriptionInner.Value.Trim().Equals(string.Empty))
                                                {
                                                    patentDescription = string.Concat(patentDescription, descriptionInner.Value);                                   
                                                }
                                            }
                                        }
                                        descriptionInner.Close();
                                        patentDescription = RemoveLineBreaks(patentDescription);

                                        // Add to patent instance
                                        patentItem.patentDescription = patentDescription;

                                        // Parsing Claims
                                        string patentClaims = string.Empty;
                                        reader.ReadToFollowing("SDOCL"); 
                                        XmlReader claimsInner = reader.ReadSubtree();
                                        while (claimsInner.Read())
                                        {
                                            if (claimsInner.HasValue)
                                            {
                                                if (!claimsInner.Value.Trim().Equals(string.Empty))
                                                {
                                                    patentClaims = string.Concat(patentClaims, claimsInner.Value);                                   
                                                }
                                            }
                                        }
                                        claimsInner.Close();
                                        patentClaims = RemoveLineBreaks(patentClaims);

                                        // Add to patent instance
                                        patentItem.patentClaims = patentClaims;

                                        // Add patent item to list
                                        patentListByWeekParsed.Add(patentItem);

                                        Console.WriteLine("Inside try catch: " + patentListByWeekParsed.Count);                  
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }

                Console.WriteLine("Before Initialization: " + patentListByWeekParsed.Count);

                // Create output files
                createTitleOutput(patentListByWeekParsed, year, getFileNamePattern(item.Name));
                createAbstractOutput(patentListByWeekParsed, year, getFileNamePattern(item.Name));
                //createDescriptionOutput(patentListByWeekParsed, year, getFileNamePattern(item.Name));
                //createClaimsOutput(patentListByWeekParsed, year, getFileNamePattern(item.Name));

                OutputByWeek.run(patentListByWeekParsed, year, getFileNamePattern(item.Name));
            }
        }

        public static void createTitleOutput(List<Patent> patentListByWeekParsed, string year, string fileNamePattern)
        {
            Console.WriteLine("In Output Method: " + patentListByWeekParsed.Count);

            string directory = string.Format("./data/output/outputByWeek{0}/", year);
            Directory.CreateDirectory(directory);

            string fileNameTitle = directory + string.Format("title{0}.tsv", fileNamePattern);

            File.Delete(fileNameTitle);

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

                foreach (var patent in patentListByWeekParsed)
                {
                    List<string> itemContent = new List<string>()
                    {
                        patent.patentNumber,
                        patent.patentDate,
                        string.Format("\"{0}\"", patent.patentTitle)
                    };
                    var line = string.Join(delimiter, itemContent);
                    tsvFile.AppendLine(line);  
                }
                File.WriteAllText(fileNameTitle, tsvFile.ToString());
            }
        }

        public static void createAbstractOutput(List<Patent> patentListByWeekParsed, string year, string fileNamePattern)
        {
            string directory = string.Format("./data/output/outputByWeek{0}/", year);
            Directory.CreateDirectory(directory);

            string fileNameAbstract = directory + string.Format("abstract{0}.tsv", fileNamePattern);

            File.Delete(fileNameAbstract);

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

                foreach (var patent in patentListByWeekParsed)
                {
                    List<string> itemContent = new List<string>()
                    {
                        patent.patentNumber,
                        patent.patentDate,
                        string.Format("\"{0}\"", patent.patentAbstract)
                    };
                    var line = string.Join(delimiter, itemContent);
                    tsvFile.AppendLine(line);  
                }
                File.WriteAllText(fileNameAbstract, tsvFile.ToString());
            }
        }

        public static void createDescriptionOutput(List<Patent> patentListByWeekParsed, string year, string fileNamePattern)
        {
            string directory = string.Format("./data/output/outputByWeek{0}/", year);
            Directory.CreateDirectory(directory);

            string fileNameDescription = directory + string.Format("description{0}.tsv", fileNamePattern);

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

                foreach (var patent in patentListByWeekParsed)
                {
                    List<string> itemContent = new List<string>()
                    {
                        patent.patentNumber,
                        patent.patentDate,
                        string.Format("\"{0}\"", patent.patentDescription)
                    };
                    var line = string.Join(delimiter, itemContent);
                    tsvFile.AppendLine(line);  
                }
                File.WriteAllText(fileNameDescription, tsvFile.ToString());
            }
        }

        public static void createClaimsOutput(List<Patent> patentListByWeekParsed, string year, string fileNamePattern)
        {
            string directory = string.Format("./data/output/outputByWeek{0}/", year);
            Directory.CreateDirectory(directory);

            string fileName = directory + string.Format("claims{0}.tsv", fileNamePattern);

            if (!File.Exists(fileName))
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

                foreach (var patent in patentListByWeekParsed)
                {
                    List<string> itemContent = new List<string>()
                    {
                        patent.patentNumber,
                        patent.patentDate,
                        patent.patentClaimsCount,
                        string.Format("\"{0}\"", patent.patentClaims)
                    };
                    var line = string.Join(delimiter, itemContent);
                    tsvFile.AppendLine(line);  
                }
                File.WriteAllText(fileName, tsvFile.ToString());
            }
        }

        public static string getFileNamePattern(string fileName)
        {
            string year = fileName.Substring(2, 2);
            string month = fileName.Substring(4, 2);
            string day = fileName.Substring(6, 2);
            return string.Format("_y{0}_m{1}_d{2}", year, month, day);
        }

        public static string addWhiteSpace(string text)
        {
            if (!text.Substring(text.Length - 1).Equals(" "))
            {
                text = string.Format("{0} ", text);
            }
            return text;
        }

        public static string RemoveFirstLine(string s) 
        {
            return s.Substring(s.IndexOf(">") + 1);
        }

        public static string RemoveLineBreaks(string s)
        {
            return Regex.Replace(s, @"\t|\n|\r", string.Empty);
        }

    }
}