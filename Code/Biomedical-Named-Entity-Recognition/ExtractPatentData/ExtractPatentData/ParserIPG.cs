using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace ExtractPatentData
{
    class ParserIPG
    {

        public static void parseXML()
        {
            for (int year = 2005; year <= 2016; year++)
            {
                foreach (var zipFile in Directory.GetFiles(Environment.CurrentDirectory + @"\data\input\PatentGrantFullTextData\" + year.ToString()))
                {
                    string fileNamePattern = Parser.getFileNamePattern(zipFile, "pg", year.ToString());
                    
                    if (OutputByWeek.checkIfOutputExist(year.ToString(), fileNamePattern) == false)
                    {
                        string fileName = FileArchiver.extractSingleFile(zipFile);

                        List<string> patentListByWeek = Parser.getXmlPerPatent(fileName);
                        List<Patent> patentListByWeekParsed = extractXML(patentListByWeek, year.ToString());
                        OutputByWeek.run(patentListByWeekParsed, year.ToString(), fileNamePattern);
                        
                        FileArchiver.deleteExtractedFile(fileName);
                    }
                }
                OutputByYear.run(year.ToString());
            }
        }

        public static List<Patent> extractXML(List<string> patentListByWeek, string year)
        {
            List<Patent> patentList = new List<Patent>();
            List<TargetPatentNumber> targetPatentNumberList = Patent.getTargetPatentNumbers(year);

            foreach (string patentItem in patentListByWeek)
            {
                Patent patent = new Patent();

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(patentItem);

                patent.patentNumber = doc.DocumentElement.SelectSingleNode("/us-patent-grant/us-bibliographic-data-grant/publication-reference/document-id/doc-number").InnerText;

                foreach (TargetPatentNumber targetPatentNumber in targetPatentNumberList)
                {
                    if (patent.patentNumber.Contains(targetPatentNumber.targetPatentNumber))
                    {
                        patent.patentDate = Parser.checkIfStringIsEmpty(targetPatentNumber.targetPatentDate);
                        patent.patentClaimsCount = Parser.checkIfStringIsEmpty(targetPatentNumber.targetPatentClaimsCount);

                        patent.patentTitle = Parser.checkIfStringIsEmpty(doc.DocumentElement.SelectSingleNode("/us-patent-grant/us-bibliographic-data-grant/invention-title").InnerText);
                        patent.patentAbstract = Parser.checkIfStringIsEmpty(Parser.getXmlInnerText(patentItem, "/us-patent-grant/abstract//*/text()"));
                        patent.patentDescription = Parser.checkIfStringIsEmpty(Parser.getXmlInnerText(patentItem, "/us-patent-grant/description//*/text()"));
                        patent.patentClaims = Parser.checkIfStringIsEmpty(string.Join(" ", new string[] 
                        {
                            doc.DocumentElement.SelectSingleNode("/us-patent-grant/us-claim-statement").InnerText,
                            Parser.getXmlInnerText(patentItem, "/us-patent-grant/claims//*/text()")
                        }));

                        patentList.Add(patent);
                    }
                }
            }

            return patentList;
        }

    }
}