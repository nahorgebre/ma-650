using System;
using System.IO;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    class EnrichDataset
    {

        public static FileInfo inputDataset = new FileInfo(Environment.CurrentDirectory + "/data/input/DI3-fused.xml");

        public static FileInfo analysis1Output = new FileInfo(Environment.CurrentDirectory + "/data/output/analysis1.xml");

        public static FileInfo analysis2Output = new FileInfo(Environment.CurrentDirectory + "/data/output/analysis2.xml");

        public static void run()
        {

            Console.WriteLine("Run!");

            List<Gene> geneList = Parser.getGeneList(inputDataset);


            if (!analysis1Output.Exists)
            {

                Console.WriteLine("Ex1");

                List<Gene> geneList1 = Ex1.run(geneList);

                Output.createXml(geneList1, analysis1Output);

            }


            if (!analysis2Output.Exists)
            {

                Console.WriteLine("Ex2");

                List<Gene> geneList2 = Ex2.run(geneList);

                Output.createXml(geneList2, analysis2Output);

            }

        }

    }

}