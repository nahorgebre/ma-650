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

            foreach (String parameter in args)
            {
                
                if (parameter.Equals("DI1"))
                {

                    Dictionary<string, List<string>> resultFileDictionary = AWSlistingContents.getS3ObjectList(parameter);

            


                }
                else if (parameter.Equals("DI2"))
                {

                    Dictionary<string, List<string>> resultFileDictionary = AWSlistingContents.getS3ObjectList(parameter);

                }
                else if (parameter.Equals("DI3"))
                {

                    Dictionary<string, List<string>> resultFileDictionary = AWSlistingContents.getS3ObjectList(parameter);

                }
                else if (parameter.Equals("DI4"))
                {

                    Dictionary<string, List<string>> resultFileDictionary = AWSlistingContents.getS3ObjectList(parameter);

                }

            }

            /*

            List<Result1> result1List = new List<Result1>();

            List<Result2> result2List = new List<Result2>();

            Result1 result1 = new Result1();

            Result2 result2 = new Result2();

            FileInfo Blocker = new FileInfo("");

            FileInfo Correspondences = new FileInfo("");

            FileInfo Evaluation = new FileInfo("");

            result1List.Add(result1);

            result2List.Add(result2);

    	    FileInfo result1File = new FileInfo("");
            Output.createTsvFileResult1(result1List, result1File);

            FileInfo result2File = new FileInfo("");
            Output.createTsvFileResult2(result2List, result2File);

            */

        }

    }

}