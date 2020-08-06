namespace ExtractPatentData
{
    class Program
    {
        static void Main(string[] args)
        {
            BulkDownloader.run();
            ParserPFTAPS.run();
            ParserPG.run();
            ParserIPG.run();
            Output.run();
        }
    }
}