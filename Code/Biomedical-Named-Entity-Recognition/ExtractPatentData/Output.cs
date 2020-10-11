using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace ExtractPatentData
{
    class Output
    {
        public static void run() {
            DirectoryInfo outputDirectory = new DirectoryInfo(string.Format("{0}/data/output", Environment.CurrentDirectory));
            DirectoryInfo outputByYearDirectory = new DirectoryInfo(string.Format("{0}/data/outputByYear", Environment.CurrentDirectory));
            
            titleOutput(outputDirectory, outputByYearDirectory);
            abstractOutput(outputDirectory, outputByYearDirectory);
            descriptionOutput(outputDirectory, outputByYearDirectory);
            claimsOutput(outputDirectory, outputByYearDirectory);
        }

        public static void titleOutput(DirectoryInfo outputDirectory, DirectoryInfo outputByYearDirectory) {
            FileInfo titleOutput = new FileInfo(string.Format("{0}/title.tsv", outputDirectory.FullName));

            using (StreamWriter sw = new StreamWriter(titleOutput.FullName))
            {
                var delimiter = "\t";
                List<string> firstLineContent = new List<string>()
                {
                    "patentNumber",
                    "patentDate",
                    "patentTitle"
                };
                var firstLine = string.Join(delimiter, firstLineContent);
                sw.WriteLine(firstLine);
            }
        }

        public static void abstractOutput(DirectoryInfo outputDirectory, DirectoryInfo outputByYearDirectory) {
            FileInfo abstractOutput = new FileInfo(string.Format("{0}/abstract.tsv", outputDirectory.FullName));

            using (StreamWriter sw = new StreamWriter(abstractOutput.FullName))
            {
                var delimiter = "\t";
                List<string> firstLineContent = new List<string>()
                {
                    "patentNumber",
                    "patentDate",
                    "patentAbstract"
                };
                var firstLine = string.Join(delimiter, firstLineContent);
                sw.WriteLine(firstLine);
            }
        }

        public static void descriptionOutput(DirectoryInfo outputDirectory, DirectoryInfo outputByYearDirectory) {
            FileInfo descriptionOutput = new FileInfo(string.Format("{0}/description.tsv", outputDirectory.FullName));

            using (StreamWriter sw = new StreamWriter(descriptionOutput.FullName))
            {
                var delimiter = "\t";
                List<string> firstLineContent = new List<string>()
                {
                    "patentNumber",
                    "patentDate",
                    "patentDescription"
                };
                var firstLine = string.Join(delimiter, firstLineContent);
                sw.WriteLine(firstLine);
            }
        }

        public static void claimsOutput(DirectoryInfo outputDirectory, DirectoryInfo outputByYearDirectory) {
            FileInfo claimsOutput = new FileInfo(string.Format("{0}/claims.tsv", outputDirectory.FullName));

            using (StreamWriter sw = new StreamWriter(claimsOutput.FullName))
            {
                var delimiter = "\t";
                List<string> firstLineContent = new List<string>()
                {
                    "patentNumber",
                    "patentDate",
                    "patentClaimsCount",
                    "patentClaims"
                };
                var firstLine = string.Join(delimiter, firstLineContent);
                sw.WriteLine(firstLine);

                

            }
        }
    }
}