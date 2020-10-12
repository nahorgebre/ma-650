using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace ExtractPatentData
{
    class ParserPG2
    {
        public static void run()
        {
            for (int year = 2002; year <= 2004; year++)
            {

                DirectoryInfo directorySelected = new DirectoryInfo(string.Format("{0}/data/input/PatentGrantFullTextData/{1}", Environment.CurrentDirectory, year));

                // 1 - Decompress all files
                Parser.DecompressAllXmlFiles(directorySelected);

                // 2 - Merge XML files
                MergeXmlFiles(directorySelected, year);

                // 3 - Parse XML files
                ParseXML(directorySelected, year.ToString());

                OutputByYear.run(year.ToString());

            }
        }

        public static void MergeXmlFiles(DirectoryInfo directorySelected, int year)
        {
            List<FileInfo> xmlFileList1 = directorySelected.GetFiles("*.xml").ToList();
            List<FileInfo> xmlFileList2 = directorySelected.GetFiles("*.XML").ToList();
            List<FileInfo> xmlFileList = (xmlFileList1.Concat(xmlFileList2).Distinct()).ToList();

            foreach (FileInfo item in xmlFileList)
            {
                if (!item.Name.Contains("edit"))
                {                  
                    string fileName = string.Format("{0}/{1}edit.xml", directorySelected.FullName, item.Name.Substring(0, item.Name.LastIndexOf(".")));

                    if (!File.Exists(fileName))
                    {
                        Console.WriteLine("Merge XML files: " + item.Name);

                        string text = File.ReadAllText(item.FullName, Encoding.UTF8);
                        string xmlVersionEncoding = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";

                        text = text.Replace(xmlVersionEncoding, "PATENT-TEXT-START" );
                        string[] tokens = text.Split(new[] { "PATENT-TEXT-START" }, StringSplitOptions.None);
                        tokens = tokens.Skip(1).ToArray();

                        using (StreamWriter file = new StreamWriter(fileName))
                        {
                            file.WriteLine(xmlVersionEncoding);

                            string documentTypeDeclaration = Parser.getMergedDocumentTypeDeclaration(tokens, year);
                            file.Write(documentTypeDeclaration + Environment.NewLine);

                            string rootBegin = "<root>";
                            file.WriteLine(rootBegin);

                            foreach (var token in tokens)
                            {
                                string removeDTT = Parser.removeDocumentTypeDeclaration(token);
                                string removeSpecialChar = Parser.removeSpecialCharactersUsingRegex(removeDTT);
                                file.Write(removeSpecialChar);
                            }

                            string rootEnd = "</root>";
                            file.WriteLine(rootEnd);
                        }

                        Console.WriteLine("XML files are merged: " + item.Name);   
                    }           
                }
            }
        }

        public static void ParseXML(DirectoryInfo directorySelected, string year) 
        {
            foreach (FileInfo item in directorySelected.GetFiles("*edit*"))
            {
                // check if output files exist
                if (OutputByWeek.checkIfOutputExist(year.ToString(), getFileNamePattern(item.Name)) == false)
                {

                    // parse & create output
                    List<Patent> patentListByWeekParsed = new List<Patent>();

                    if (item.Name.Contains("edit"))
                    {
                        string patentNumberException = string.Empty;
                        try
                        {
                            XmlReaderSettings settings = new XmlReaderSettings();
                            settings.DtdProcessing = DtdProcessing.Parse;

                            using (XmlReader reader = XmlReader.Create(item.FullName, settings))
                            {

                                while (reader.ReadToFollowing("PATDOC"))
                                {

                                    // Parsing Patent Number
                                    string patentNumber = string.Empty;
                                    reader.ReadToFollowing("B110");
                                    XmlReader b110Inner = reader.ReadSubtree();
                                    b110Inner.ReadToFollowing("PDAT");
                                    patentNumber = b110Inner.ReadElementContentAsString();

                                    foreach (TargetPatentNumber targetPatentNumber in Patent.getTargetPatentNumbers(year))
                                    {
                                        if (patentNumber.Contains(targetPatentNumber.targetPatentNumber))
                                        {

                                            // Create instance of patent
                                            Patent patentItem = new Patent();
                                            patentItem.patentNumber = patentNumber;
                                            patentItem.patentDate = targetPatentNumber.targetPatentDate;
                                            patentItem.patentClaimsCount = targetPatentNumber.targetPatentClaimsCount;

                                            // Used for exception log
                                            patentNumberException = patentItem.patentNumber;

                                            // Parsing Title
                                            string patentTitle = string.Empty;
                                            reader.ReadToFollowing("B540");
                                            XmlReader b540Inner = reader.ReadSubtree();
                                            b540Inner.ReadToFollowing("PDAT");
                                            patentTitle = b540Inner.ReadElementContentAsString();

                                            // Add to patent instance
                                            patentItem.patentTitle = StringPreprocessing.run(patentTitle);

                                            // Parsing Abstract SDOAB
                                            string patentAbstarct = string.Empty;
                                            reader.ReadToFollowing("SDOAB");
                                            XmlReader abstractInner = reader.ReadSubtree();
                                            while (abstractInner.Read())
                                            {
                                                if (abstractInner.HasValue)  
                                                {
                                                    if (!abstractInner.Value.Trim().Equals(string.Empty))
                                                    {
                                                        patentAbstarct = string.Concat(patentAbstarct, addWhiteSpace(abstractInner.Value));
                                                    }
                                                }
                                            }
                                            abstractInner.Close();

                                            // Add to patent instance
                                            patentItem.patentAbstract = StringPreprocessing.run(patentAbstarct);

                                            // Parsing Descriptions
                                            string patentDescription = string.Empty;
                                            reader.ReadToFollowing("SDODE"); 
                                            XmlReader descriptionInner = reader.ReadSubtree();
                                            while (descriptionInner.Read())
                                            {
                                                if (descriptionInner.HasValue)
                                                {
                                                    if (!descriptionInner.Value.Trim().Equals(string.Empty))
                                                    {
                                                        patentDescription = string.Concat(patentDescription, descriptionInner.Value);                                   
                                                    }
                                                }
                                            }
                                            descriptionInner.Close();
                                            patentDescription = RemoveLineBreaks(patentDescription);

                                            // Add to patent instance
                                            patentItem.patentDescription = StringPreprocessing.run(patentDescription);

                                            // Parsing Claims
                                            string patentClaims = string.Empty;
                                            reader.ReadToFollowing("SDOCL"); 
                                            XmlReader claimsInner = reader.ReadSubtree();
                                            while (claimsInner.Read())
                                            {
                                                if (claimsInner.HasValue)
                                                {
                                                    if (!claimsInner.Value.Trim().Equals(string.Empty))
                                                    {
                                                        patentClaims = string.Concat(patentClaims, claimsInner.Value);                                   
                                                    }
                                                }
                                            }
                                            claimsInner.Close();
                                            patentClaims = RemoveLineBreaks(patentClaims);

                                            // Add to patent instance
                                            patentItem.patentClaims = StringPreprocessing.run(patentClaims);

                                            // Add patent item to list
                                            patentListByWeekParsed.Add(patentItem);             
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            Console.WriteLine("Patent number: " + patentNumberException);
                        }
                    }

                    // Create output files
                    OutputByWeek.run(patentListByWeekParsed, year, getFileNamePattern(item.Name));

                }
            }
        }

        public static string getFileNamePattern(string fileName)
        {
            string year = fileName.Substring(2, 2);
            string month = fileName.Substring(4, 2);
            string day = fileName.Substring(6, 2);
            return string.Format("_y{0}_m{1}_d{2}", year, month, day);
        }

        public static string addWhiteSpace(string text)
        {
            if (!text.Substring(text.Length - 1).Equals(" "))
            {
                text = string.Format("{0} ", text);
            }
            return text;
        }

        public static string RemoveLineBreaks(string s)
        {
            return Regex.Replace(s, @"\t|\n|\r", string.Empty);
        }

    }
}