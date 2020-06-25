namespace ExtractPatentData
{
    class Program
    {
        static void Main(string[] args)
        {
            BulkDownloader.downloadBulkFiles();
            Parser.parseAPS();
            Parser.parseXML2();
            Parser.parseXML4();
            Output.combineToSingleOutput();
        }
    }
}
