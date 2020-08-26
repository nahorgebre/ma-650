using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
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
                string month = (zipFileName.Substring(zipFileName.LastIndexOf("/"))).Substring((zipFileName.Substring(zipFileName.LastIndexOf("/"))).IndexOf("pftaps") + 10, 2);
                string day = (zipFileName.Substring(zipFileName.LastIndexOf("/"))).Substring((zipFileName.Substring(zipFileName.LastIndexOf("/"))).IndexOf("pftaps") + 12, 2);
                fileNamePattern = string.Format("_y{0}_m{1}_d{2}", year, month, day);
            } 
            else if (prefix.Equals("pg"))
            {
                string month = (zipFileName.Substring(zipFileName.LastIndexOf("/"))).Substring((zipFileName.Substring(zipFileName.LastIndexOf("/"))).IndexOf("pg") + 4, 2);
                string day = (zipFileName.Substring(zipFileName.LastIndexOf("/"))).Substring((zipFileName.Substring(zipFileName.LastIndexOf("/"))).IndexOf("pg") + 6, 2);
                fileNamePattern = string.Format("_y{0}_m{1}_d{2}", year, month, day);
            }
            else if (prefix.Equals("ipg"))
            {
                string month = (zipFileName.Substring(zipFileName.LastIndexOf("/"))).Substring((zipFileName.Substring(zipFileName.LastIndexOf("/"))).IndexOf("ipg") + 5, 2);
                string day = (zipFileName.Substring(zipFileName.LastIndexOf("/"))).Substring((zipFileName.Substring(zipFileName.LastIndexOf("/"))).IndexOf("ipg") + 7, 2);
                fileNamePattern = string.Format("_y{0}_m{1}_d{2}", year, month, day);
            }
            
            return fileNamePattern;
        }

        public static string getXmlInnerTextFromSingleNode(XmlDocument doc, string xPath)
        {
            string xmlInnerText = string.Empty;
            if (doc.SelectSingleNode(xPath)!=null)
            {
                xmlInnerText = doc.DocumentElement.SelectSingleNode(xPath).InnerText;
            }
            return StringPreprocessing.run(xmlInnerText);   
        }

        public static string getXmlInnerTextFromMultipleNodes(XmlDocument doc, string xPath, string xml, string xPathText)
        {
            string xmlInnerText = string.Empty;
            if (doc.SelectSingleNode(xPath)!=null)
            {
                List<string> xmlInnerTextList = new List<string>();
                foreach (XText text in (IEnumerable)XDocument.Parse(xml).XPathEvaluate(xPathText))
                {
                    xmlInnerTextList.Add(text.Value.Trim());
                }
                xmlInnerText = string.Join(" ", xmlInnerTextList);
            }
            return StringPreprocessing.run(xmlInnerText);
        }

        public static string[] getXmlPerPatent(string sourceFileName)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<string> patentListByWeek = new List<string>();
           
            string text = File.ReadAllText(sourceFileName, Encoding.UTF8);
            string pattern = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            text = text.Replace(pattern, "PATENT-TEXT-START" + Environment.NewLine + pattern);

            string[] tokens = text.Split(new[] { "PATENT-TEXT-START" + Environment.NewLine }, StringSplitOptions.None);

            tokens = tokens.Skip(1).ToArray();  

            watch.Stop();
            Console.WriteLine("Parser.getXmlPerPatent() - Elapsed Time: {0} Milliseconds", watch.ElapsedMilliseconds);

            return tokens;
        }

        public static string removeSpecialCharacters(string patentText)
        {
            HashSet<string> specialCharacterList = getInvalidSpecialCharInXml(patentText);

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