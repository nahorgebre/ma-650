using System;
using System.IO;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    class EnrichDataset
    {

        public static FileInfo inputDataset = new FileInfo(Environment.CurrentDirectory + "/data/input/DI3-fused.xml");

        public static FileInfo enrichedFusedDS = new FileInfo(Environment.CurrentDirectory + "/data/output/enrichedFusedDS.xml");


        public static void run()
        {

            Console.WriteLine("Enrich fused dataset!");

            if (!enrichedFusedDS.Exists)
            {

                List<Gene> geneList = Parser.getGeneList(inputDataset);

                // get overall call
                geneList = Ex1.run(geneList);

                // get publication year
                geneList = Ex2.run(geneList);

                // get overall diseases association
                geneList = Ex3.run(geneList);

                Output.createXml(geneList, enrichedFusedDS);

            }

        }

    }

}