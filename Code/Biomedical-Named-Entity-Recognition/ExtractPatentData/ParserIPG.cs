using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Text;

namespace ExtractPatentData
{
    class ParserIPG
    {

        public static string xPathInventionTitle = "/us-patent-grant/us-bibliographic-data-grant/invention-title";
        public static string xPathAbstract = "/us-patent-grant/abstract";
        public static string xPathAbstractText = "/us-patent-grant/abstract//*/text()";
        public static string xPathDescription = "/us-patent-grant/description";
        public static string xPathDescriptionText = "/us-patent-grant/description//*/text()";
        public static string xPathClaims = "/us-patent-grant/claims";
        public static string xPathClaimsText = "/us-patent-grant/claims//*/text()";

        public static void run()
        {
            // 2006
            for (int year = 2011; year <= 2016; year++)
            {
                foreach (var zipFile in Directory.GetFiles(string.Format("./data/input/PatentGrantFullTextData/{0}", year.ToString())))
                {
                    string fileNamePattern = Parser.getFileNamePattern(zipFile, "pg", year.ToString());
                    Console.WriteLine(string.Format("{0}File Name: ...{1}.tsv", Environment.NewLine, fileNamePattern));

                    if (OutputByWeek.checkIfOutputExist(year.ToString(), fileNamePattern) == false)
                    {              
                        string fileName = FileArchiver.extractSingleFile(zipFile);
                            
                        string[] patentListByWeek = Parser.getXmlPerPatent(fileName);
                        List<Patent> patentListByWeekParsed = parseXML(patentListByWeek, year.ToString());
                        OutputByWeek.run(patentListByWeekParsed, year.ToString(), fileNamePattern);

                        FileArchiver.deleteExtractedFile(fileName);
                    }
                }
                OutputByYear.run(year.ToString());
            }
        }

        public static List<Patent> parseXML(string[] patentListByWeek, string year)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<Patent> patentList = new List<Patent>();
            List<TargetPatentNumber> targetPatentNumberList = Patent.getTargetPatentNumbers(year);

            foreach (string patent in patentListByWeek)
            {
                string patentText = patent.Trim();
                string patNum = getPatNum(patentText);

                foreach (TargetPatentNumber targetPatentNumber in targetPatentNumberList)
                {
                    if (patNum.Contains(targetPatentNumber.targetPatentNumber))
                    {
                        Patent patentItem = new Patent();

                        patentItem.patentNumber = patNum;
                        patentItem.patentDate = targetPatentNumber.targetPatentDate;
                        patentItem.patentClaimsCount = targetPatentNumber.targetPatentClaimsCount;

                        string patentTextAdjusted = Parser.removeSpecialCharacters(patentText);

                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(patentTextAdjusted);

                        patentItem.patentTitle = Parser.getXmlInnerTextFromSingleNode(
                            doc: doc, 
                            xPath: xPathInventionTitle);

                        patentItem.patentAbstract = Parser.getXmlInnerTextFromMultipleNodes(
                            doc: doc, 
                            xPath: xPathAbstract, 
                            xml: patentTextAdjusted, 
                            xPathText: xPathAbstractText);

                        patentItem.patentDescription = Parser.getXmlInnerTextFromMultipleNodes(
                            doc: doc, 
                            xPath: xPathDescription, 
                            xml: patentTextAdjusted, 
                            xPathText: xPathDescriptionText);

                        patentItem.patentClaims = Parser.getXmlInnerTextFromMultipleNodes(
                            doc: doc, 
                            xPath: xPathClaims, 
                            xml: patentTextAdjusted, 
                            xPathText: xPathClaimsText);

                        patentList.Add(patentItem);
                    }
                }
            }

            watch.Stop();
            Console.WriteLine("ParserIPG.parseXML() - Elapsed Time: {0} Milliseconds", watch.ElapsedMilliseconds);

            return patentList;
        }

        public static string getPatNum(string xml)
        {
            string patternB = "<doc-number>";
            string patternE = "</doc-number>";

            int startInd = xml.IndexOf(patternB) + patternB.Length;
            int length = xml.IndexOf(patternE) - startInd;

            string patNum = xml.Substring(startInd, length);

            return patNum;
        }

    }
}