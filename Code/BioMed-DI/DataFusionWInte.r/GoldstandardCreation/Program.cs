using System;
using System.IO;

namespace GoldstandardCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

        }

        public static void compare(FileInfo file1, FileInfo file2) {

            using(StreamReader sr1 = new StreamReader(file1.FullName)) {
                while (!sr1.EndOfStream)
                {
                    var lineSr1 = sr1.ReadLine();
                    
                    using (StreamReader sr2 = new StreamReader(file2.FullName))
                    {
                        while (!sr2.EndOfStream)
                        {
                            var lineSr2 = sr1.ReadLine();
                        }
                    }
                }
            }

        }
    }
}
