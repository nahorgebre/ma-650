using System;
using System.IO;
using System.Text;
using Amazon.S3.Model;
using System.Collections.Generic;

namespace IR_ResultTables
{
    class Program
    {
        static void Main(string[] args)
        {

            AWSlistingContents.getS3ObjectList("DI1");

            AWSlistingContents.getS3ObjectList("DI2");


            /*
            for (int i = 1; i <= 50; i++)
            {

                AWSlistingContents.getS3ObjectList("DI3/kaessmann_2_gene2pubtatorcentral_" + i);

            }
            */



            List<string> wgetList = new List<string>();

            foreach (FileInfo fileItem in new DirectoryInfo(Environment.CurrentDirectory + "/Get-DI3").GetFiles())
            {

                using (StreamReader sr = new StreamReader(fileItem.FullName))
                {

                    while (!sr.EndOfStream)
                    {

                        var line = sr.ReadLine();

                        if (!line.Contains(Environment.NewLine))
                        {

                            wgetList.Add(line);

                        }
                        else if (line.Contains(Environment.NewLine))
                        {

                            foreach (var item in line.Split(Environment.NewLine))
                            {

                                wgetList.Add(item);

                            }

                        }

                    }



                }

            }




            using (StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "/Get-DI3.sh"))
            {

                foreach (var item in wgetList)
                {
                    //Console.WriteLine("----" + sw);

                    sw.WriteLine(item);

                }

            }



            AWSlistingContents.getS3ObjectList("DI4");


            foreach (String parameter in args)
            {

                if (parameter.Equals("DI1"))
                {

                    (List<Result1> list1, List<Result2> list2) = InformationRetrievalFromLog.retrieveFromResultLogs(parameter);

                    Output.createTsvFileResult1(list1, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result1.tsv"));

                    Output.createTeXFileResult1_2(list1, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result1.tex"));

                    Output.createTsvFileResult2(list2, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result2.tsv"));

                    Output.createTeXFileResult2_1(list2, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result2.tex"));

                }
                else if (parameter.Equals("DI2"))
                {

                    (List<Result1> list1, List<Result2> list2) = InformationRetrievalFromLog.retrieveFromResultLogs(parameter);

                    Output.createTsvFileResult1(list1, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result1.tsv"));

                    Output.createTeXFileResult1_2(list1, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result1.tex"));

                    Output.createTsvFileResult2(list2, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result2.tsv"));

                    Output.createTeXFileResult2_1(list2, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result2.tex"));

                }
                else if (parameter.Equals("DI3"))
                {

                    (List<Result1> list1, List<Result2> list2) = InformationRetrievalFromLog.retrieveFromResultLogs2(parameter);

                    Output.createTsvFileResult1(list1, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result1.tsv"));

                    Output.createTeXFileResult1_2(list1, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result1.tex"));

                    Output.createTsvFileResult2(list2, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result2.tsv"));

                    Output.createTeXFileResult2_1(list2, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result2.tex"));

                }
                else if (parameter.Equals("DI4"))
                {

                    (List<Result1> list1, List<Result2> list2) = InformationRetrievalFromLog.retrieveFromResultLogs(parameter);

                    Output.createTsvFileResult1(list1, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result1.tsv"));

                    Output.createTeXFileResult1_2(list1, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result1.tex"));

                    Output.createTsvFileResult2(list2, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result2.tsv"));

                    Output.createTeXFileResult2_1(list2, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result2.tex"));

                }

            }

        }

    }

}