using System;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections.Generic;

namespace ExtractPatentData
{
    class ParserPG
    {

        public static void parseXML()
        {
            for (int year = 2002; year <= 2004; year++)
            {
                foreach (var zipFile in Directory.GetFiles(Environment.CurrentDirectory + @"\data\input\PatentGrantFullTextData\" + year.ToString()))
                {
                    string month = (zipFile.Substring(zipFile.LastIndexOf(@"\"))).Substring((zipFile.Substring(zipFile.LastIndexOf(@"\"))).IndexOf("pg") + 4, 2);
                    string day = (zipFile.Substring(zipFile.LastIndexOf(@"\"))).Substring((zipFile.Substring(zipFile.LastIndexOf(@"\"))).IndexOf("pg") + 6, 2);                                     
                    string fileNamePattern = string.Format("_y{0}_m{1}_d{2}", year, month, day);

                    string directory = string.Format(Environment.CurrentDirectory + @"\data\output\outputByWeek{0}\", year);
                    List<string> titleAbstractDescriptionClaims= new List<string>
                    {
                        directory + string.Format("title{0}.tsv", fileNamePattern),
                        directory + string.Format("abstract{0}.tsv", fileNamePattern),
                        directory + string.Format("description{0}.tsv", fileNamePattern),
                        directory + string.Format("claims{0}.tsv", fileNamePattern)
                    };

                    if (checkIfFileExists(titleAbstractDescriptionClaims) == false)
                    {
                        string fileName = FileArchiver.extractSingleFile(zipFile);

                        List<string> patentListByWeek = getXmlContent(fileName);
                        List<Patent> patentListByWeekParsed = extractXML(patentListByWeek, year.ToString());
                        OutputByWeek.run(patentListByWeekParsed, year.ToString(), fileNamePattern);
                        
                        FileArchiver.deleteExtractedFile(fileName);
                    }
                }
                OutputByYear.run(year.ToString());
            }
        }

        public static void parseXML2()
        {
            for (int year = 2002; year <= 2004; year++)
            {
                HashSet<string> fileNameList = FileArchiver.extractFiles(year.ToString());

                foreach (string fileName in fileNameList)
                {
                    string month = (fileName.Substring(fileName.LastIndexOf(@"\"))).Substring((fileName.Substring(fileName.LastIndexOf(@"\"))).IndexOf("pg") + 4, 2);
                    string day = (fileName.Substring(fileName.LastIndexOf(@"\"))).Substring((fileName.Substring(fileName.LastIndexOf(@"\"))).IndexOf("pg") + 6, 2);                                     
                    string fileNamePattern = string.Format("_y{0}_m{1}_d{2}", year, month, day);

                    string directory = string.Format(Environment.CurrentDirectory + @"\data\output\outputByWeek{0}\", year);
                    List<string> titleAbstractDescriptionClaims= new List<string>
                    {
                        directory + string.Format("title{0}.tsv", fileNamePattern),
                        directory + string.Format("abstract{0}.tsv", fileNamePattern),
                        directory + string.Format("description{0}.tsv", fileNamePattern),
                        directory + string.Format("claims{0}.tsv", fileNamePattern)
                    };

                    if (checkIfFileExists(titleAbstractDescriptionClaims) == false)
                    {
                        List<string> patentListByWeek = getXmlContent(fileName);
                        List<Patent> patentListByWeekParsed = extractXML(patentListByWeek, year.ToString());
                        OutputByWeek.run(patentListByWeekParsed, year.ToString(), fileNamePattern);
                    }
                }
              
                OutputByYear.run(year.ToString());

                FileArchiver.deleteExtractedFiles(year.ToString());
            }
        }

        public static bool checkIfFileExists(List<string> fileNameList)
        {
            bool status = true;
            foreach (var item in fileNameList)
            {
                if (!File.Exists(item))
                {
                    status = false;
                }
            }
            return status;
        }

        public static List<string> getXmlContent(string fileName)
        {
            List<string> patentListByWeek = new List<string>();

            string text = File.ReadAllText(fileName, Encoding.UTF8);
            string pattern = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            text = text.Replace(pattern, "PATENT-TEXT-START" + Environment.NewLine + pattern);

            string[] tokens = text.Split(new[] { "PATENT-TEXT-START" }, StringSplitOptions.None);

            foreach (var item in tokens.Skip(1))
            {
                string patentText = removeSpecialCharacters(item, getInvalidSpecialCharInXml(fileName)).Trim();
                patentListByWeek.Add(patentText);
            }
            Console.WriteLine("Get XML content.");
            return patentListByWeek;
        }

        public static HashSet<string> getInvalidSpecialCharInXml(string fileName)
        {
            HashSet<string> specialCharacterList = new HashSet<string>();

            string text = File.ReadAllText(fileName, Encoding.UTF8);
            text = text.Replace(Environment.NewLine, " ");
            string[] tokens = text.Split(new[] { "&" }, StringSplitOptions.None);

            foreach (string token in tokens.Skip(1))
            {
                string firstWord = string.Empty;

                if (token.Contains(";"))
                {
                    int index = token.IndexOf(";");
                    firstWord = token.Substring(0, index + 1);
                }

                specialCharacterList.Add("&" + firstWord);
            }
            return specialCharacterList;
        }

        public static string removeSpecialCharacters(string patentText, HashSet<string> specialCharacterList)
        {
            foreach (string specialCharacter in specialCharacterList)
            {
                while (patentText.Contains(specialCharacter))
                {
                    int index = patentText.IndexOf(specialCharacter);
                    int length = specialCharacter.Length;
                    patentText = patentText.Remove(index, length);
                }
            }
            return patentText.Trim();
        }

        public static List<Patent> extractXML(List<string> dataList, string year)
        {
            List<Patent> patentList = new List<Patent>();
            List<TargetPatentNumber> targetPatentNumbers = Patent.getTargetPatentNumbers(year);

            foreach (string patentItem in dataList)
            {
                Patent patent = new Patent();

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(patentItem);

                XmlNodeList patentNumberNodes = doc.DocumentElement.SelectNodes("/PATDOC/SDOBI/B100/B110/DNUM");
                foreach (XmlNode node in patentNumberNodes)
                {
                    patent.patentNumber = node.SelectSingleNode("PDAT").InnerText;
                }

                XmlNodeList patentTitleNodes = doc.DocumentElement.SelectNodes("/PATDOC/SDOBI/B500/B540/STEXT");
                foreach (XmlNode node in patentTitleNodes)
                {
                    patent.patentTitle = node.SelectSingleNode("PDAT").InnerText;
                }

                XmlNodeList patentAbstarctNodes = doc.DocumentElement.SelectNodes("/PATDOC/SDOAB/BTEXT/PARA/PTEXT");
                foreach (XmlNode node in patentAbstarctNodes)
                {
                    patent.patentAbstract = node.SelectSingleNode("PDAT").InnerText;
                }
            
                foreach (TargetPatentNumber targetPatentNumber in targetPatentNumbers)
                {
                    if (patent.patentNumber.Contains(targetPatentNumber.targetPatentNumber))
                    {
                        patent.patentDate = targetPatentNumber.targetPatentDate;
                        patentList.Add(patent);
                    }
                }
            }

            Console.WriteLine("Parse XML.");
            return patentList;
        }      
    }

}