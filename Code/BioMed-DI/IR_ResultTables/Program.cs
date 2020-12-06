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

            AWSlistingContents.getS3ObjectList("DI3");

            AWSlistingContents.getS3ObjectList("DI4");


            foreach (String parameter in args)
            {
                
                if (parameter.Equals("DI1"))
                {

                    (List<Result1> list1, List<Result2> list2) = InformationRetrievalFromLog.retrieveFromResultLogs(parameter);

                    Output.createTsvFileResult1(list1, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result1.tsv"));

                    Output.createTeXFileResult1(list1, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result1.tex"));

                    Output.createTsvFileResult2(list2, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result2.tsv"));  

                    Output.createTeXFileResult2(list2, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result2.tex"));   

                }
                else if (parameter.Equals("DI2"))
                {

                    (List<Result1> list1, List<Result2> list2) = InformationRetrievalFromLog.retrieveFromResultLogs(parameter); 

                    Output.createTsvFileResult1(list1, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result1.tsv"));

                    Output.createTeXFileResult1(list1, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result1.tex"));

                    Output.createTsvFileResult2(list2, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result2.tsv"));  

                    Output.createTeXFileResult2(list2, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result2.tex"));   

                }
                else if (parameter.Equals("DI3"))
                {

                    (List<Result1> list1, List<Result2> list2) = InformationRetrievalFromLog.retrieveFromResultLogs(parameter);

                    Output.createTsvFileResult1(list1, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result1.tsv"));

                    Output.createTeXFileResult1(list1, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result1.tex"));

                    Output.createTsvFileResult2(list2, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result2.tsv"));   

                    Output.createTeXFileResult2(list2, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result2.tex"));  

                }
                else if (parameter.Equals("DI4"))
                {

                    (List<Result1> list1, List<Result2> list2) = InformationRetrievalFromLog.retrieveFromResultLogs(parameter); 

                    Output.createTsvFileResult1(list1, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result1.tsv"));

                    Output.createTeXFileResult1(list1, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result1.tex"));

                    Output.createTsvFileResult2(list2, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result2.tsv"));

                    Output.createTeXFileResult2(list2, new FileInfo(Environment.CurrentDirectory + "/data/output/" + parameter + "/result2.tex"));

                }

            }

        }

    }

}