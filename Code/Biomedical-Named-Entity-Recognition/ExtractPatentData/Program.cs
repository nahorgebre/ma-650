using System;
using System.IO;

namespace ExtractPatentData
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            FileStream stream;
            StreamWriter writer;
            TextWriter consoleOut = Console.Out;

            try
            {
                Directory.CreateDirectory("./logs");
                string fileName = "./logs/ExtractPatentData.log";
                File.Delete(fileName);
                stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(stream);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot open ExtractPatentData.log for writing");
                Console.WriteLine(ex.Message);
                return; 
            }

            Console.SetOut(writer);
            */

            Patent.getPatentNumbersByYear();
            //ParserPFTAPS.run();
            ParserPG2.run();
            ParserIPG2.run();
            //Output.run();
            //AWSupload.run();

            /*
            Console.SetOut(consoleOut);
            writer.Close();
            stream.Close();
            */   
        }
    }
}