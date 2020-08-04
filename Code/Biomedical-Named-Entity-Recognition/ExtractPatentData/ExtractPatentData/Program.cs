namespace ExtractPatentData
{
    class Program
    {
        static void Main(string[] args)
        {
            BulkDownloader.downloadBulkFiles();
            ParserPFTAPS.run();
            ParserPG.run();
            ParserIPG.run();
            Output.run();
        }
    }
}