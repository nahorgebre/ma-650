using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Collections;
using System.Collections.Generic;

namespace ExtractPatentData
{
    class Parser
    {
        public static string getFileNamePattern(string zipFileName, string prefix, string year)
        {
            string fileNamePattern = string.Empty;

            if (prefix.Equals("pftaps"))
            {
                // e.g. pftaps19850101_wk01
                string month = (zipFileName.Substring(zipFileName.LastIndexOf(@"\"))).Substring((zipFileName.Substring(zipFileName.LastIndexOf(@"\"))).IndexOf("pftaps") + 10, 2);
                string day = (zipFileName.Substring(zipFileName.LastIndexOf(@"\"))).Substring((zipFileName.Substring(zipFileName.LastIndexOf(@"\"))).IndexOf("pftaps") + 12, 2);
                fileNamePattern = string.Format("_y{0}_m{1}_d{2}", year, month, day);
            } 
            else if (prefix.Equals("pg"))
            {
                // e.g. pg020101
                string month = (zipFileName.Substring(zipFileName.LastIndexOf(@"\"))).Substring((zipFileName.Substring(zipFileName.LastIndexOf(@"\"))).IndexOf("pg") + 4, 2);
                string day = (zipFileName.Substring(zipFileName.LastIndexOf(@"\"))).Substring((zipFileName.Substring(zipFileName.LastIndexOf(@"\"))).IndexOf("pg") + 6, 2);
                fileNamePattern = string.Format("_y{0}_m{1}_d{2}", year, month, day);
            }
            else if (prefix.Equals("ipg"))
            {
                // e.g. ipg050104
                string month = (zipFileName.Substring(zipFileName.LastIndexOf(@"\"))).Substring((zipFileName.Substring(zipFileName.LastIndexOf(@"\"))).IndexOf("ipg") + 5, 2);
                string day = (zipFileName.Substring(zipFileName.LastIndexOf(@"\"))).Substring((zipFileName.Substring(zipFileName.LastIndexOf(@"\"))).IndexOf("ipg") + 7, 2);
                fileNamePattern = string.Format("_y{0}_m{1}_d{2}", year, month, day);
            }
            
            return fileNamePattern;
        }

        public static string getXmlInnerText(string xmlInput, string xPathQuery)
        {
            List<string> innerTextList = new List<string>();

            foreach (XText text in (IEnumerable)XDocument.Parse(xmlInput).XPathEvaluate(xPathQuery))
            {
                innerTextList.Add(text.Value.Trim());
            }

            return string.Join(" ", innerTextList);
        }

        public static List<string> getXmlPerPatent(string sourceFileName)
        {
            List<string> patentListByWeek = new List<string>();
           
            string text = File.ReadAllText(sourceFileName, Encoding.UTF8);
            Console.WriteLine(string.Format("Source File Name: {0}", sourceFileName));
            string pattern = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            text = text.Replace(pattern, "PATENT-TEXT-START" + Environment.NewLine + pattern);

            string[] tokens = text.Split(new[] { "PATENT-TEXT-START" }, StringSplitOptions.None);

            string fileDirectory = string.Format(@"{0}\xmlPerPatent\", sourceFileName.Substring(0, sourceFileName.LastIndexOf(@"\")));
            Directory.CreateDirectory(fileDirectory);
            Console.WriteLine(string.Format("XML per Patent Directory: {0}", fileDirectory));

            int counter = 1;
            foreach (var item in tokens.Skip(1))
            {
                string patentText = removeSpecialCharacters(item, getInvalidSpecialCharInXml(item)).Trim();
                
                string fileName = string.Format("{0}{1}.xml", fileDirectory, counter.ToString());
                File.WriteAllText(fileName, patentText, Encoding.UTF8);
                counter ++;
                patentListByWeek.Add(fileName);
            }

            Console.WriteLine("XML per Patent.");

            return patentListByWeek;
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

            return patentText;
        }

        public static HashSet<string> getInvalidSpecialCharInXml(string text)
        {
            HashSet<string> specialCharacterList = new HashSet<string>();

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
    }
}