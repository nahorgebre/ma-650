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
                            
                            string[] patentListByWeek = Parser.getXmlPerPatent(fileName);
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
                        try
                        {
                        Patent patentItem = new Patent();

                        patentItem.patentNumber = patNum;
                        patentItem.patentDate = targetPatentNumber.targetPatentDate;
                        patentItem.patentClaimsCount = targetPatentNumber.targetPatentClaimsCount;

                        string patentTextAdjusted = Parser.removeSpecialCharacters(patentText);

                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(patentTextAdjusted);
                        patentItem.patentTitle = StringPreprocessing.run(doc.DocumentElement.SelectSingleNode("/us-patent-grant/us-bibliographic-data-grant/invention-title").InnerText);
                        
                        patentItem.patentAbstract = StringPreprocessing.run(Parser.getXmlInnerText(patentTextAdjusted, "/us-patent-grant/abstract//*/text()"));
                        patentItem.patentDescription = StringPreprocessing.run(Parser.getXmlInnerText(patentTextAdjusted, "/us-patent-grant/description//*/text()"));
                        patentItem.patentClaims = StringPreprocessing.run(Parser.getXmlInnerText(patentTextAdjusted, "/us-patent-grant/claims//*/text()"));

                        patentList.Add(patentItem);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Exception: {0}", ex);
                            Console.WriteLine(patNum);
                            File.WriteAllText(Environment.CurrentDirectory + @"\text.xml", patentText);

                            string patentTextAdjusted = Parser.removeSpecialCharacters(patentText);
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(patentTextAdjusted);
                            doc.DocumentElement.HasAttribute()
                            string test = doc.DocumentElement.SelectSingleNode("/us-patent-grant/us-bibliographic-data-grant/invention-title").InnerText;
                            File.WriteAllText(Environment.CurrentDirectory + @"\test.txt", test);
                        }

                    }
                }
            }

            watch.Stop();
            Console.WriteLine("ParserIPG.parseXML() - Elapsed Time: {0} Milliseconds", watch.ElapsedMilliseconds);

            return patentList;
        }

        public static string getPatNum(string xml)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            string patternB = "<doc-number>";
            string patternE = "</doc-number>";

            int startInd = xml.IndexOf(patternB) + patternB.Length;
            int length = xml.IndexOf(patternE) - startInd;

            string patNum = xml.Substring(startInd, length);

            watch.Stop();
            //Console.WriteLine("ParserPG.getPatNum() - Elapsed Time: {0} Milliseconds", watch.ElapsedMilliseconds);

            return patNum;
        }

    }
}