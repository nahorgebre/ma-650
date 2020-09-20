using System;
using System.IO;
using System.Xml;

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
                        int year = Int32.Parse(node.SelectSingleNode(xPathYear).InnerText);

                        if (year >= 1985 && year <= 2016)
                        {
                            file.WriteLine(pmId + "," + year);
                        }           
                    }

                    FileArchiver.deleteExtractedFile(xmlFileName);
                }
            }

            AWSupload.run();
        }
    }
}