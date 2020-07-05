using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections.Generic;

namespace ExtractPatentData
{
    class ParserIPG
    {
        public static void parseXML()
        {
            for (int year = 2005; year <= 2016; year++)
            {
                HashSet<string> fileNameList = FileArchiver.extractFiles(year.ToString());

                int week = 1;
                foreach (string fileName in fileNameList)
                {
                    List<string> patentListByWeek = getXmlContent(fileName);
                    List<Patent> patentListByWeekParsed = extractXML(patentListByWeek, year.ToString());
                    OutputByWeek.run(patentListByWeekParsed, year.ToString(), week.ToString());
                    week += 1;
                }

                OutputByYear.run(year.ToString());

                FileArchiver.deleteExtractedFiles(year.ToString());
            }
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

                XmlNodeList patentNumberNodes = doc.DocumentElement.SelectNodes("/us-patent-grant/us-bibliographic-data-grant/publication-reference/document-id");
                foreach (XmlNode node in patentNumberNodes)
                {
                    patent.patentNumber = (node?.SelectSingleNode("doc-number").InnerText ?? null);                 
                }

                XmlNodeList patentTitleNodes = doc.DocumentElement.SelectNodes("/us-patent-grant/us-bibliographic-data-grant");
                foreach (XmlNode node in patentTitleNodes)
                {
                    patent.patentTitle = (node?.SelectSingleNode("invention-title").InnerText ?? null);
                }

                XmlNodeList patentAbstarctNodes = doc.DocumentElement.SelectNodes("/us-patent-grant/abstract");
                foreach (XmlNode node in patentAbstarctNodes)
                {
                    patent.patentAbstract = (node?.SelectSingleNode("p").InnerText ?? null);
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
            return patentList;
        }      
    }
}