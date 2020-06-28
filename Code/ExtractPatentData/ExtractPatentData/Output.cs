using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExtractPatentData
{
    class Output
    {
        public static void writePatentTitleCsvByYear(List<Patent> patentList, string year)
        {
            string directory = Environment.CurrentDirectory + @"\data\output\title\";
            string fileName = directory + year + "title.csv";
            if (!File.Exists(fileName))
            {
                Directory.CreateDirectory(directory);
                var csvFile = new StringBuilder();
                csvFile.AppendLine("patentNumber,patentYear,patentTitle");
                foreach (Patent patent in patentList)
                {
                    csvFile.AppendLine(string.Format("{0},{1},\"{2}\"", patent.patentNumber, patent.patentYear, patent.patentTitle));         
                }
                File.WriteAllText(fileName, csvFile.ToString());
            }
        }

        public static void writePatentAbstractCsvByYear(List<Patent> patentList, string year)
        {
            string directory = Environment.CurrentDirectory + @"\data\output\abstract\";
            string fileName = directory + year + "abstract.csv";
            if (!File.Exists(fileName))
            {
                Directory.CreateDirectory(directory);
                var csvFile = new StringBuilder();
                csvFile.AppendLine("patentNumber,patentYear,patentAbstract");
                foreach (Patent patent in patentList)
                {
                    csvFile.AppendLine(string.Format("{0},{1},\"{2}\"", patent.patentNumber, patent.patentYear, patent.patentAbstract));         
                }
                File.WriteAllText(fileName, csvFile.ToString());
            }
        }

        public static void writePatentDescriptionCsvByYear(List<Patent> patentList, string year)
        {
            string directory = Environment.CurrentDirectory + @"\data\output\description\";
            string fileName = directory + year + "description.csv";
            if (!File.Exists(fileName))
            {
                Directory.CreateDirectory(directory);
                var csvFile = new StringBuilder();
                csvFile.AppendLine("patentNumber,patentYear,patentDescription");
                foreach (Patent patent in patentList)
                {
                    csvFile.AppendLine(string.Format("{0},{1},\"{2}\"", patent.patentNumber, patent.patentYear, patent.patentDescription));         
                }
                File.WriteAllText(fileName, csvFile.ToString());
            }
        }

        public static void writePatentClaimsCsvByYear(List<Patent> patentList, string year)
        {
            string directory = Environment.CurrentDirectory + @"\data\output\claims\";
            string fileName = directory + year + "claims.csv";
            if (!File.Exists(fileName))
            {
                Directory.CreateDirectory(directory);
                var csvFile = new StringBuilder();
                csvFile.AppendLine("patentNumber,patentYear,patentClaims");
                foreach (Patent patent in patentList)
                {
                    csvFile.AppendLine(string.Format("{0},{1},\"{2}\"", patent.patentNumber, patent.patentYear, patent.patentClaims));         
                }
                File.WriteAllText(fileName, csvFile.ToString());
            }
        }

        public static bool checkIfOutputByYearExist(string fileName)
        { 
            bool returnValue = false;
            foreach (string directory in Directory.GetDirectories(Environment.CurrentDirectory + @"\data\output\"))
            {
                foreach (var fileNameInDirectory in Directory.GetFiles(directory))
                {
                    if (fileNameInDirectory.Equals(fileName))
                    {
                        returnValue = true;
                    }
                }
            }
            return returnValue;
        }

        public static void combineToSingleOutput()
        {
            List<string> directoryList = new List<string>()
            {
                Environment.CurrentDirectory + @"\data\output\title\",
                Environment.CurrentDirectory + @"\data\output\abstract\",
                Environment.CurrentDirectory + @"\data\output\description\",
                Environment.CurrentDirectory + @"\data\output\claims\"
            };

            foreach (string directory in directoryList)
            {
                if (Directory.Exists(directory))
                {
                    foreach (var fileNameInDirectory in Directory.GetFiles(directory))
                    {

                    }
                }
            }
        }
    }
}