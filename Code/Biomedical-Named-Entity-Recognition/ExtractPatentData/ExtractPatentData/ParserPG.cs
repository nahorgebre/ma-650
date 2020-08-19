using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ExtractPatentData
{
    class ParserPG
    {

        public static void run()
        {
            try
            {
                for (int year = 2002; year <= 2004; year++)
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
                            patentItem.patentTitle = StringPreprocessing.run(doc.DocumentElement.SelectSingleNode("/PATDOC/SDOBI/B500/B540/STEXT/PDAT").InnerText);

                            patentItem.patentAbstract = StringPreprocessing.run(Parser.getXmlInnerText(patentTextAdjusted, "/PATDOC/SDOAB//*/text()"));
                            patentItem.patentDescription = StringPreprocessing.run(Parser.getXmlInnerText(patentTextAdjusted, "/PATDOC/SDODE//*/text()"));
                            patentItem.patentClaims = StringPreprocessing.run(Parser.getXmlInnerText(patentTextAdjusted, "/PATDOC/SDOCL//*/text()"));

                            patentList.Add(patentItem);
                        }
                        catch (System.Exception)
                        {
                            Console.WriteLine("Exception: {0}", patentText);
                        }

                    }
                }
            }

            watch.Stop();
            Console.WriteLine("ParserPG.parseXML() - Elapsed Time: {0} Milliseconds", watch.ElapsedMilliseconds);

            return patentList;
        }

        public static string getPatNum(string xml)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            string patternB = "<B110><DNUM><PDAT>";
            string patternE = "</PDAT></DNUM></B110>";

            int startInd = xml.IndexOf(patternB) + patternB.Length;
            int length = xml.IndexOf(patternE) - startInd;

            string patNum = xml.Substring(startInd, length);

            watch.Stop();
            if (watch.ElapsedMilliseconds > 1)
            {
                //Console.WriteLine("ParserPG.getPatNum() - Elapsed Time: {0} Milliseconds", watch.ElapsedMilliseconds);
            }
            
            return patNum;
        }

    }
}