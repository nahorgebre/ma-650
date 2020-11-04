using System;
using System.IO;

namespace ExtractPatentData
{
    class Program
    {
        static void Main(string[] args)
        {

            Patent.getPatentNumbersByYear();
            
            ParserPFTAPS.run();
            ParserPG2.run();
            ParserIPG2.run();

            Output.run();

            AWSupload.run();

        }
    }
}