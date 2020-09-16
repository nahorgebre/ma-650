using System;
using System.IO;

namespace ExtractPatentData
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream stream;
            StreamWriter writer;
            TextWriter consoleOut = Console.Out;

            try
            {
                Directory.CreateDirectory("./logs");
                stream = new FileStream("./logs/ExtractPatentData.log", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(stream);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot open ExtractPatentData.log for writing");
                Console.WriteLine(ex.Message);
                return; 
            }

            Console.SetOut(writer);

            Patent.getPatentNumbersByYear();
            //ParserPFTAPS.run();
            //ParserPG.run();
            ParserIPG.run();
            Output.run();
            AWSupload.run();

            Console.SetOut(consoleOut);
            writer.Close();
            stream.Close();        
        }
    }
}