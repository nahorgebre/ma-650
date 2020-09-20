using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace PubMedDate
{
    class Program
    {
        static void Main(string[] args)
        {

            using (StreamWriter file = new StreamWriter(Environment.CurrentDirectory + "data/output/PubMedDate.csv"))
            {
                foreach (string sourceArchiveFileName in Directory.GetFiles(Environment.CurrentDirectory + "/data/input"))
                {
                    file.WriteLine("pmId,year");

                    string xmlFileName = FileArchiver.extractSingleFile(sourceArchiveFileName);

                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlFileName);

                    XmlNodeList nodes = doc.DocumentElement.SelectNodes("/PubmedArticleSet/PubmedArticle");

                    foreach (XmlNode node in nodes)
                    {
                        string xPathPmId = "/MedlineCitation/PMID";
                        string pmId = node.SelectSingleNode(xPathPmId).InnerText;

                        string xPathYear = "/MedlineCitation/Article/Journal/JournalIssue/PubDate/Year";
                        string year = node.SelectSingleNode(xPathYear).InnerText;

                        file.WriteLine(pmId + "," + year);
                    }
                }
            }
            //createBashFile();
        }

        public static void createBashFile() {
            
            using (StreamWriter file = new StreamWriter(Environment.CurrentDirectory + "/test.txt"))
            {
                string[] readText = File.ReadAllLines(Environment.CurrentDirectory + "/input.txt");
                foreach (string s in readText)
                {
                    int index = s.IndexOf("\"") + 1;
                    int length = s.LastIndexOf("\"") - index;
                    string downloadFile = s.Substring(index, length);

                    if (!downloadFile.Contains("md5"))
                    {
                        string wget = "wget ftp://ftp.ncbi.nlm.nih.gov/pubmed/baseline/" + downloadFile + " -O data/input/" + downloadFile;
                        file.WriteLine(wget);
                    }
                }
            }
        }
    }
}
