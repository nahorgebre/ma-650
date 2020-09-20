using System;
using System.Collections.Generic;
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
            parseXML(directorySelected);
            Console.WriteLine("All files are parsed!");
            generateOutputFile();

            AWSupload.run();
        }

        public static void generateOutputFile()
        {
            string OutputFileName = string.Format("{0}/data/output/{1}", Environment.CurrentDirectory, "PubMedDate.csv");
            using (StreamWriter file = new StreamWriter(OutputFileName))
            {
                file.WriteLine("pmId,year");

                foreach (string fileName in Directory.GetFiles(Environment.CurrentDirectory + "/data/output"))
                {             
                    using (var reader = new StreamReader(fileName))
                    {
                        reader.ReadLine();
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            if (!line.Equals(string.Empty))
                            {
                                string delimiter = ",";
                                try
                                {
                                    String[] values = line.Split(delimiter);
                                    List<string> itemContent = new List<string>()
                                    {
                                        values[0].ToString(),
                                        values[1].ToString()
                                    };
                                    var inputLine = string.Join(delimiter, itemContent);
                                    file.WriteLine(inputLine);
                                }
                                catch (System.Exception)
                                {
                                    Console.WriteLine("Exception in Input File!");
                                    Console.WriteLine("File Name: {0}", fileName);
                                    Console.WriteLine("Patent Number: {0}", line.Split(delimiter)[0].ToString());
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void parseXML(DirectoryInfo directorySelected) 
        {

            foreach (FileInfo fileToParse in directorySelected.GetFiles("*.xml"))
            {              
                string OutputFileName = string.Format("{0}/data/output/{1}.csv", Environment.CurrentDirectory, fileToParse.Name.Substring(0, fileToParse.Name.LastIndexOf(".")));
                if (!File.Exists(OutputFileName))
                {
                    using (StreamWriter file = new StreamWriter(OutputFileName))
                    {
                        file.WriteLine("pmId,year");

                        try
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

                                    file.WriteLine(pmId + "," + year);
                                }
                            } 
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            Console.WriteLine("File name: " + fileToParse.FullName);
                        }
                    }           
                }

            }
        }
    }
}