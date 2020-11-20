using System;
using System.IO;
using System.Collections.Generic;

namespace CreateResultTable
{
    class Program
    {
        static void Main(string[] args)
        {
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
            Methods.createTsvFileResult1(result1List, result1File);

            FileInfo result2File = new FileInfo("");
            Methods.createTsvFileResult2(result2List, result2File);

        }
    }
}
