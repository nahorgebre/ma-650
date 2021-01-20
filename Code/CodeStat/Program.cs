using System;
using System.IO;
using System.Collections.Generic;

namespace CodeStat
{
    class Program
    {
        static void Main(string[] args)
        {

            DirectoryInfo directory = new DirectoryInfo(@"C:\Users\nahor\GitHub\ma-650-master-thesis\Code");

            int lineCount = 0;


            List<FileInfo> fileInfoList = new List<FileInfo>();

            fileInfoList.AddRange(directory.GetFiles("*.java", SearchOption.AllDirectories));

            fileInfoList.AddRange(directory.GetFiles("*.cs", SearchOption.AllDirectories));

            fileInfoList.AddRange(directory.GetFiles("*.py", SearchOption.AllDirectories));

            foreach (var item in fileInfoList)
            {

                lineCount += File.ReadAllLines(item.FullName).Length;

            }


            Console.WriteLine(lineCount);

        }

    }

}
