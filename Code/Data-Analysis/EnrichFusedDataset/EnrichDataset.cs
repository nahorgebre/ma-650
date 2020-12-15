using System;
using System.IO;
using System.Collections.Generic;


namespace EnrichFusedDataset
{
    class EnrichDataset
    {

        public static void run()
        {

            Console.WriteLine("Run!");

            List<Gene> geneList = Parser.getGeneList(new FileInfo(Environment.CurrentDirectory + "/data/input/DI3-fused.xml"));


            Console.WriteLine("Ex1");

            List<Gene> geneList1 = Ex1.run(geneList);

            Output.createXml(geneList1, new FileInfo(Environment.CurrentDirectory + "/data/output/analysis1.xml"));


            Console.WriteLine("Ex2");

            List<Gene> geneList2 = Ex2.run(geneList);

            Output.createXml(geneList2, new FileInfo(Environment.CurrentDirectory + "/data/output/analysis2.xml"));

        }

    }

}