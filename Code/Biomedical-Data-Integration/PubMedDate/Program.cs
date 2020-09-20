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
                string folderName = fileToDecompress.Name.Substring(0, fileToDecompress.Name.LastIndexOf(".") - 1);
                if (!Directory.Exists(Environment.CurrentDirectory + "/data/input/" + folderName))
                {
                    FileArchiver.Decompress(fileToDecompress);
                }               
            }

            Directory.CreateDirectory(Environment.CurrentDirectory + "data/output");
            using (StreamWriter file = new StreamWriter(Environment.CurrentDirectory + "data/output/PubMedDate.csv"))
            {
                file.WriteLine("pmId,year");

                foreach (var directory in Directory.GetDirectories(Environment.CurrentDirectory + "/data/input"))
                {
                    string xmlFileName = string.Empty;
                    foreach (string directoryFile in Directory.GetFiles(directory))
                    {
                        if (directoryFile.Contains("pubmed"))
                        {
                            xmlFileName = directoryFile;
                        }
                    }

                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlFileName);

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