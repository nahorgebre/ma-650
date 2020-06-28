namespace ExtractPatentData
{
    class Program
    {
        static void Main(string[] args)
        {
            BulkDownloader.downloadBulkFiles();
            ParserPFTAPS.parseAPS();
            ParserPG.parseXML();
            ParserIPG.parseXML();
            //Output.combineToSingleOutput();
        }
    }
}
