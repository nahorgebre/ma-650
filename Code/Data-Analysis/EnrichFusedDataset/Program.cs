using System;
using System.IO;
using System.Collections.Generic;


namespace EnrichFusedDataset
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Run!");

            List<Gene> geneList = Parser.getGeneList(new FinleInfo(Environment.CurrentDirectory + "/data/input/DI3-fused.xml"));


            List<Gene> geneList1 = Ex1.run(geneList);

            Output.createXml(geneList1, new FileInfo(Environment.CurrentDirectory + "/data/output/analysis1.xml"));


            List<Gene> geneList2 = Ex2.run(geneList);

            Output.createXml(geneList2, new FileInfo(Environment.CurrentDirectory + "/data/output/analysis2.xml"));
        }
    }
}
