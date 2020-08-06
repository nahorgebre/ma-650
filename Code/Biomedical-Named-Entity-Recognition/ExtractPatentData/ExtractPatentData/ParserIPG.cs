using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Text;

namespace ExtractPatentData
{
    class ParserIPG
    {

        public static void run()
        {
            try
            {
                for (int year = 2005; year <= 2016; year++)
                {
                    foreach (var zipFile in Directory.GetFiles(string.Format(@"{0}\data\input\PatentGrantFullTextData\{1}", Environment.CurrentDirectory, year.ToString())))
                    {
                        string fileNamePattern = Parser.getFileNamePattern(zipFile, "pg", year.ToString());
                        Console.WriteLine(string.Format("{0}File Name: ...{1}.tsv", Environment.NewLine, fileNamePattern));

                        if (OutputByWeek.checkIfOutputExist(year.ToString(), fileNamePattern) == false)
                        {              
                            string fileName = FileArchiver.extractSingleFile(zipFile);
                            List<string> patentListByWeek = Parser.getXmlPerPatent(fileName);

                            List<Patent> patentListByWeekParsed = parseXML(patentListByWeek, year.ToString());
                            OutputByWeek.run(patentListByWeekParsed, year.ToString(), fileNamePattern);

                            FileArchiver.deleteExtractedFile(fileName);
                        }
                    }
                    OutputByYear.run(year.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static List<Patent> parseXML(List<string> patentListByWeek, string year)
        {
            List<Patent> patentList = new List<Patent>();
            List<TargetPatentNumber> targetPatentNumberList = Patent.getTargetPatentNumbers(year);

            foreach (string patentItem in patentListByWeek)
            {
                Patent patent = new Patent();

                XmlDocument doc = new XmlDocument();
                string xml = File.ReadAllText(patentItem, Encoding.UTF8);
                doc.Load(xml);

                patent.patentNumber = doc.DocumentElement.SelectSingleNode("/us-patent-grant/us-bibliographic-data-grant/publication-reference/document-id/doc-number").InnerText;

                foreach (TargetPatentNumber targetPatentNumber in targetPatentNumberList)
                {
                    if (patent.patentNumber.Contains(targetPatentNumber.targetPatentNumber))
                    {
                        Console.WriteLine(string.Format("Parsing {0}.", patent.patentNumber));

                        patent.patentDate = targetPatentNumber.targetPatentDate;
                        patent.patentClaimsCount = targetPatentNumber.targetPatentClaimsCount;

                        patent.patentTitle = StringPreprocessing.run(doc.DocumentElement.SelectSingleNode("/us-patent-grant/us-bibliographic-data-grant/invention-title").InnerText);
                        patent.patentAbstract = StringPreprocessing.run(Parser.getXmlInnerText(xml, "/us-patent-grant/abstract//*/text()"));
                        patent.patentDescription = StringPreprocessing.run(Parser.getXmlInnerText(xml, "/us-patent-grant/description//*/text()"));
                        patent.patentClaims = StringPreprocessing.run(string.Join(" ", new string[] 
                        {
                            doc.DocumentElement.SelectSingleNode("/us-patent-grant/us-claim-statement").InnerText,
                            Parser.getXmlInnerText(xml, "/us-patent-grant/claims//*/text()")
                        }));

                        patentList.Add(patent);
                    }
                }
            }

            return patentList;
        }

    }
}