using System;
using System.IO;
using System.Xml;

namespace PubMedDate
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo directorySelected = new DirectoryInfo(Environment.CurrentDirectory + "/data/input");

            foreach (FileInfo fileToDecompress in directorySelected.GetFiles("*.gz"))
            {
                string fileName = fileToDecompress.Name.Substring(0, fileToDecompress.Name.LastIndexOf("."));

                if (!File.Exists(Environment.CurrentDirectory + "/data/input/" + fileName))
                {
                    FileArchiver.Decompress(fileToDecompress);
                }          
            }

            foreach (FileInfo fileToParse in directorySelected.GetFiles("*.xml"))
            {
                string fileName = fileToParse.Name.Substring(0, fileToParse.Name.LastIndexOf(".") - 1);

                Directory.CreateDirectory(Environment.CurrentDirectory + "data/output");
                using (StreamWriter file = new StreamWriter(Environment.CurrentDirectory + "data/output/" + fileName + ".csv"))
                {
                    file.WriteLine("pmId,year");

                    XmlDocument doc = new XmlDocument();
                    doc.Load(Environment.CurrentDirectory + "data/input/" + fileName);

                    XmlNodeList nodes = doc.DocumentElement.SelectNodes("/PubmedArticleSet/PubmedArticle");

                    foreach (XmlNode node in nodes)
                    {
                        string xPathPmId = "/MedlineCitation/PMID";
                        string pmId = node.SelectSingleNode(xPathPmId).InnerText;

                        string xPathYear = "/MedlineCitation/Article/Journal/JournalIssue/PubDate/Year";
                        int year = Int32.Parse(node.SelectSingleNode(xPathYear).InnerText);

                        if (year >= 1985 && year <= 2016)
                        {
                            file.WriteLine(pmId + "," + year);
                        }           
                    }
                }
            }

            AWSupload.run();
        }
    }
}