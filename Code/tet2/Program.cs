using System;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace tet2
{
    class Program
    {
        static void Main(string[] args)
        {        
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            string fileName = @"C:\Users\nahor\Pictures\tet2\data\pg020101.xml";
            HashSet<string> specialCharacterList = getInvalidSpecialCharInXml(fileName);

            // File used to check results
            var txtFile = new StringBuilder();
            foreach (string specialCharacter in specialCharacterList)
            {
                txtFile.Append(specialCharacter + Environment.NewLine);
            }
            string fileName2 = Environment.CurrentDirectory + @"\test.txt";
            File.WriteAllText(fileName2, txtFile.ToString());
            
            List<string> patentListByWeek = getXmlContent(fileName, specialCharacterList);
            parseXML(patentListByWeek);

            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
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

        public static void parseXML(List<string> patentList)
        {
            try
            {
                Patent patent = new Patent();

                foreach (string patentItem in patentList)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(patentItem);

                    XmlNodeList patentNumberNodes = doc.DocumentElement.SelectNodes("/PATDOC/SDOBI/B100/B110/DNUM");
                    foreach (XmlNode node in patentNumberNodes)
                    {
                        patent.patentNumber = node.SelectSingleNode("PDAT").InnerText;
                    }

                    XmlNodeList patentDateNodes = doc.DocumentElement.SelectNodes("/PATDOC/SDOBI/B100/B140/DATE");
                    foreach (XmlNode node in patentDateNodes)
                    {
                        patent.patentDate = node.SelectSingleNode("PDAT").InnerText;
                    }

                    XmlNodeList patentAbstractNodes = doc.DocumentElement.SelectNodes("/PATDOC/SDOBI/B500/B540/STEXT");
                    foreach (XmlNode node in patentAbstractNodes)
                    {
                        patent.patentAbstract = node.SelectSingleNode("PDAT").InnerText;
                    }

                    XmlNodeList patentClaimsNodes = doc.DocumentElement.SelectNodes("/PATDOC/SDOCL");
                    foreach (XmlNode node in patentClaimsNodes)
                    {
                        string title = node.SelectSingleNode("/H/STEXT/PDAT").InnerText;
                        
                    }

                    // /PATDOC/SDOCL
                    // /H/STEXT/PDAT (Title)
                    // /CL/CLM/PARA/PTEXT/PDAT (Nummerierung)
                    // /CL/CLM/CLMSTEP/PTEXT/PDAT (Content)

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static List<string> getXmlContent(string fileName, HashSet<string> specialCharacterList)
        {
            List<string> patentListByWeek = new List<string>();

            string text = File.ReadAllText(fileName, Encoding.UTF8);
            string pattern = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            text = text.Replace(pattern, "PATENT-TEXT-START" + Environment.NewLine + pattern);

            string[] tokens = text.Split(new[] { "PATENT-TEXT-START" }, StringSplitOptions.None);

            int count = 0;
            foreach (var item in tokens.Skip(1))
            {
                count += 1;
                string fileNametxt = Environment.CurrentDirectory + @"\data\" + count.ToString() + "patent.txt";
                string patentText = removeSpecialCharacters(item, specialCharacterList).Trim();
                File.WriteAllText(fileNametxt, patentText);
                patentListByWeek.Add(patentText);
            }

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

            return patentText.Trim();
        }
    }

    class Patent
    {
        public string patentNumber = string.Empty;
        public string patentDate = string.Empty;
        public string patentTitle = string.Empty;
        public string patentClaims = string.Empty;
        public string patentAbstract = string.Empty;
        public string patentDescription = string.Empty;
    }
}
