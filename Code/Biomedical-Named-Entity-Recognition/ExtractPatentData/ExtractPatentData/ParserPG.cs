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
                doc.LoadXml(xml);

                patent.patentNumber = doc.DocumentElement.SelectSingleNode("/PATDOC/SDOBI/B100/B110/DNUM/PDAT").InnerText;

                foreach (TargetPatentNumber targetPatentNumber in targetPatentNumberList)
                {
                    if (patent.patentNumber.Contains(targetPatentNumber.targetPatentNumber))
                    {
                        Console.WriteLine(string.Format("Parsing {0}.", patent.patentNumber));

                        patent.patentDate = targetPatentNumber.targetPatentDate;
                        patent.patentClaimsCount = targetPatentNumber.targetPatentClaimsCount;

                        patent.patentTitle = StringPreprocessing.run(doc.DocumentElement.SelectSingleNode("/PATDOC/SDOBI/B500/B540/STEXT/PDAT").InnerText);

                        patent.patentAbstract = StringPreprocessing.run(Parser.getXmlInnerText(xml, "/PATDOC/SDOAB//*/text()"));
                        patent.patentDescription = StringPreprocessing.run(Parser.getXmlInnerText(xml, "/PATDOC/SDODE//*/text()"));
                        patent.patentClaims = StringPreprocessing.run(Parser.getXmlInnerText(xml, "/PATDOC/SDOCL//*/text()"));

                        patentList.Add(patent);
                    }
                }
            }

            return patentList;
        }

    }
}