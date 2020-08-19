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
            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<string> innerTextList = new List<string>();

            foreach (XText text in (IEnumerable)XDocument.Parse(xmlInput).XPathEvaluate(xPathQuery))
            {
                innerTextList.Add(text.Value.Trim());
            }

            string innerText = string.Join(" ", innerTextList);
 
            watch.Stop();
            //SConsole.WriteLine("Parser.getXmlInnerText() - Elapsed Time: {0} Milliseconds", watch.ElapsedMilliseconds);

            return innerText;
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
            var watch = System.Diagnostics.Stopwatch.StartNew();

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

            watch.Stop();
            //Console.WriteLine("Parser.removeSpecialCharacters() - Elapsed Time: {0} Milliseconds", watch.ElapsedMilliseconds);

            return patentText;
        }

        public static HashSet<string> getInvalidSpecialCharInXml(string text)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

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

            watch.Stop();
            //Console.WriteLine("Parser.getInvalidSpecialCharInXml() - Elapsed Time: {0} Milliseconds", watch.ElapsedMilliseconds);
            
            return specialCharacterList;
        }
    }
}