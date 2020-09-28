using System;
using System.IO;
using System.Xml;
using System.Text;
using System.IO.Compression;
using System.Collections.Generic;

namespace ExtractPatentData
{
    class ParserIPG2
    {

        public static void run()
        {

            for (int year = 2005; year <= 2016; year++)
            {                              
                DirectoryInfo directorySelected = new DirectoryInfo(string.Format("{0}/data/input/PatentGrantFullTextData/{1}", Environment.CurrentDirectory, year));

                // 1 - Decompress all files
                Parser.DecompressAllXmlFiles(directorySelected);

                // 2 - Merge XML files
                MergeXmlFiles(directorySelected, year);

                // 3 - Parse XML files
                ParseXML(directorySelected, year.ToString());

                year++;
            }
        }

        public static void MergeXmlFiles(DirectoryInfo directorySelected, int year)
        {
            foreach (FileInfo item in directorySelected.GetFiles("*.xml"))
            {
                if (!item.Name.Contains("edit"))
                {
                    string fileName = string.Format("{0}/{1}edit.xml", directorySelected.FullName, item.Name.Substring(0, item.Name.LastIndexOf(".")));
                    File.Delete(fileName);

                    if (!File.Exists(fileName))
                    {
                        string text = File.ReadAllText(item.FullName, Encoding.UTF8);
                        string xmlVersionEncoding = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";

                        text = text.Replace(xmlVersionEncoding, "PATENT-TEXT-START" );
                        string[] tokens = text.Split(new[] { "PATENT-TEXT-START" }, StringSplitOptions.None);
                        //tokens = tokens.Skip(1).ToArray();

                        using (StreamWriter file = new StreamWriter(fileName))
                        {
                            file.WriteLine(xmlVersionEncoding);

                            string documentTypeDeclaration = Parser.getMergedDocumentTypeDeclaration(tokens, year);
                            file.Write(documentTypeDeclaration + Environment.NewLine);

                            string rootBegin = "<root>";
                            file.WriteLine(rootBegin);

                            foreach (var token in tokens)
                            {
                                file.Write(Parser.removeDocumentTypeDeclaration(token));
                            }

                            string rootEnd = "</root>";
                            file.WriteLine(rootEnd);
                        }   
                    }           
                }
            }
        }

        public static void ParseXML(DirectoryInfo directorySelected, string year) 
        {
            foreach (FileInfo item in directorySelected.GetFiles("*.xml"))
            {
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
                            while (reader.ReadToFollowing("us-patent-grant"))
                            {

                                // Parsing Patent Number
                                string patentNumber = string.Empty;
                                reader.ReadToFollowing("publication-reference");
                                XmlReader publicationReferenceInner = reader.ReadSubtree();
                                publicationReferenceInner.ReadToFollowing("doc-number");
                                patentNumber = publicationReferenceInner.ReadElementContentAsString();

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
                                        reader.ReadToFollowing("invention-title");
                                        patentTitle = reader.ReadElementContentAsString();

                                        // Add to patent instance
                                        patentItem.patentTitle = StringPreprocessing.run(patentTitle);

                                        // Parsing Abstract
                                        string patentAbstarct = string.Empty;
                                        reader.ReadToFollowing("abstract");
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

                                        string patentDescriptionBRFSUM = string.Empty;
                                        bool BRFSUM = false;
                                        int BRFSUMcounter = 0;

                                        string patentDescriptionDETDESC = string.Empty;
                                        bool DETDESC = false;
                                        int DETDESCcounter = 0;
                                
                                        reader.ReadToFollowing("description");
                                        XmlReader descriptionInner = reader.ReadSubtree();
                                        while (descriptionInner.Read())
                                        {

                                            // Brief Summary
                                            if (descriptionInner.Name.Equals("BRFSUM") &&
                                            descriptionInner.Depth.Equals(1) &&
                                            descriptionInner.Value.Equals("description=\"Brief Summary\" end=\"lead\""))
                                            {
                                                BRFSUM = true;                
                                            }

                                            if (descriptionInner.Name.Equals("BRFSUM") &&
                                            descriptionInner.Depth.Equals(1) &&
                                            descriptionInner.Value.Equals("description=\"Brief Summary\" end=\"tail\""))
                                            {
                                                BRFSUM = false;                
                                            }

                                            if (BRFSUM.Equals(true))
                                            {
                                                if (descriptionInner.HasValue)  
                                                {
                                                    if (!descriptionInner.Value.Trim().Equals(string.Empty))
                                                    {
                                                        if (BRFSUMcounter >= 1)
                                                        {
                                                            patentDescriptionBRFSUM = string.Concat(patentDescriptionBRFSUM, addWhiteSpace(descriptionInner.Value));   
                                                        }
                                                        BRFSUMcounter++;                              
                                                    }
                                                }
                                            }

                                            // Detailed Description
                                            if (descriptionInner.Name.Equals("DETDESC") &&
                                            descriptionInner.Depth.Equals(1) &&
                                            descriptionInner.Value.Equals("description=\"Detailed Description\" end=\"lead\""))
                                            {
                                                DETDESC = true;                
                                            }

                                            if (descriptionInner.Name.Equals("DETDESC") &&
                                            descriptionInner.Depth.Equals(1) &&
                                            descriptionInner.Value.Equals("description=\"Detailed Description\" end=\"tail\""))
                                            {
                                                DETDESC = false;                
                                            }

                                            if (DETDESC.Equals(true))
                                            {
                                                if (descriptionInner.HasValue)
                                                {
                                                    if (!descriptionInner.Value.Trim().Equals(string.Empty))
                                                    {
                                                        if (DETDESCcounter >= 1)
                                                        {
                                                            patentDescriptionDETDESC = string.Concat(patentDescriptionDETDESC, addWhiteSpace(descriptionInner.Value));                            
                                                        }
                                                        DETDESCcounter++;                                               
                                                    }
                                                }
                                            }

                                        }
                                        descriptionInner.Close();

                                        patentDescription = String.Concat(patentDescriptionBRFSUM, patentDescriptionDETDESC);

                                        // Add to patent instance
                                        patentItem.patentDescription = StringPreprocessing.run(patentDescription);

                                        // Parsing Claims
                                        string patentClaims = string.Empty;
                                        reader.ReadToFollowing("claims"); 
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
                OutputByWeek.run(patentListByWeekParsed: patentListByWeekParsed, 
                    year: year, 
                    fileNamePattern: getFileNamePattern(item.Name));
            }
        }

        public static string getFileNamePattern(string fileName)
        {
            string year = fileName.Substring(3, 2);
            string month = fileName.Substring(5, 2);
            string day = fileName.Substring(7, 2);
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

    }
}