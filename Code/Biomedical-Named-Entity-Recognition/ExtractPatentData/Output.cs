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
            DirectoryInfo outputByYearDirectory = new DirectoryInfo(string.Format("{0}/data/output/outputByYear", Environment.CurrentDirectory));
            
            titleOutput(outputDirectory, outputByYearDirectory);
            abstractOutput(outputDirectory, outputByYearDirectory);
            descriptionOutput(outputDirectory, outputByYearDirectory);
            claimsOutput(outputDirectory, outputByYearDirectory);
        }

        public static void titleOutput(DirectoryInfo outputDirectory, DirectoryInfo outputByYearDirectory) {
            FileInfo titleOutput = new FileInfo(string.Format("{0}/title.tsv", outputDirectory.FullName));

            Console.WriteLine("1");

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

                Console.WriteLine("2");

                foreach (FileInfo file in outputByYearDirectory.GetFiles("*title*"))
                {

                    Console.WriteLine("3");

                    using (StreamReader sr = new StreamReader(file.FullName))
                    {

                        Console.WriteLine("4");

                        sr.ReadLine();
                        while (!sr.EndOfStream)
                        {

                            Console.WriteLine("5");

                            var line = sr.ReadLine();
                            if (!line.Equals(string.Empty))
                            {

                                Console.WriteLine("6");

                                String[] values = line.Split(delimiter);
                                List<string> itemContent = new List<string>()
                                {
                                    values[0].Trim(),
                                    values[1].Trim(),
                                    values[2].Trim()
                                };
                                var inpuLine = string.Join(delimiter, itemContent);
                                sw.WriteLine(inpuLine);     
                            }

                        }
                    }
                }

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

                foreach (FileInfo file in outputByYearDirectory.GetFiles("*abstract*"))
                {
                    using (StreamReader sr = new StreamReader(file.FullName))
                    {
                        sr.ReadLine();
                        while (!sr.EndOfStream)
                        {

                            var line = sr.ReadLine();
                            if (!line.Equals(string.Empty))
                            {
                                String[] values = line.Split(delimiter);
                                List<string> itemContent = new List<string>()
                                {
                                    values[0].Trim(),
                                    values[1].Trim(),
                                    values[2].Trim()
                                };
                                var inpuLine = string.Join(delimiter, itemContent);
                                sw.WriteLine(inpuLine);     
                            }

                        }
                    }
                }

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

                foreach (FileInfo file in outputByYearDirectory.GetFiles("*description*"))
                {
                    using (StreamReader sr = new StreamReader(file.FullName))
                    {
                        sr.ReadLine();
                        while (!sr.EndOfStream)
                        {

                            var line = sr.ReadLine();
                            if (!line.Equals(string.Empty))
                            {
                                String[] values = line.Split(delimiter);
                                List<string> itemContent = new List<string>()
                                {
                                    values[0].Trim(),
                                    values[1].Trim(),
                                    values[2].Trim()
                                };
                                var inpuLine = string.Join(delimiter, itemContent);
                                sw.WriteLine(inpuLine);     
                            }

                        }
                    }
                }

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

                foreach (FileInfo file in outputByYearDirectory.GetFiles("*claims*"))
                {
                    using (StreamReader sr = new StreamReader(file.FullName))
                    {
                        sr.ReadLine();
                        while (!sr.EndOfStream)
                        {

                            var line = sr.ReadLine();
                            if (!line.Equals(string.Empty))
                            {
                                String[] values = line.Split(delimiter);
                                List<string> itemContent = new List<string>()
                                {
                                    values[0].Trim(),
                                    values[1].Trim(),
                                    values[2].Trim(),
                                    values[3].Trim(),
                                };
                                var inpuLine = string.Join(delimiter, itemContent);
                                sw.WriteLine(inpuLine);     
                            }

                        }
                    }
                }

            }
        }
    }
}