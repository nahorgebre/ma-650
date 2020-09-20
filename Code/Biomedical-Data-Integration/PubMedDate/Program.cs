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

            Console.WriteLine("Starting parsing!");

            Directory.CreateDirectory(Environment.CurrentDirectory + "/data/output");
            string OutputFileName = string.Format("{0}/data/output/{1}", Environment.CurrentDirectory, "PubMedDate.csv");
       
            using (StreamWriter file = new StreamWriter(OutputFileName))
            {
                file.WriteLine("pmId,year");

                foreach (FileInfo fileToParse in directorySelected.GetFiles("*.xml"))
                {
                    using (XmlTextReader reader = new XmlTextReader(fileToParse.FullName))
                    {
                        while (reader.ReadToFollowing("PubmedArticle"))
                        {
                            string pmId = string.Empty;
                            string year = string.Empty;

                            reader.ReadToFollowing("PMID");
                            pmId = reader.ReadElementContentAsString();

                            reader.ReadToFollowing("PubDate");

                            reader.ReadToFollowing("Year");
                            year = reader.ReadElementContentAsString();

                            int yearInt = Int32.Parse(year);
                                                
                            if (yearInt >= 1985 && yearInt <= 2016)
                            {
                                file.WriteLine(pmId + "," + year);
                            } 

                        }
                    }        
                }
            }

            Console.WriteLine("All files are parsed!");

            AWSupload.run();
        }
    }
}