using System;
using System.IO;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    class EnrichDataset
    {

        public static FileInfo inputDataset1 = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1-fused.xml");

        public static FileInfo inputDataset2 = new FileInfo(Environment.CurrentDirectory + "/data/input/DI2-fused.xml");

        public static FileInfo inputDataset3 = new FileInfo(Environment.CurrentDirectory + "/data/input/DI3-fused.xml");

        public static FileInfo enrichedFusedDS1 = new FileInfo(Environment.CurrentDirectory + "/data/output/enrichedFusedDS1.xml");

        public static FileInfo enrichedFusedDS2 = new FileInfo(Environment.CurrentDirectory + "/data/output/enrichedFusedDS2.xml");

        public static FileInfo enrichedFusedDS3 = new FileInfo(Environment.CurrentDirectory + "/data/output/enrichedFusedDS3.xml");


        public static void run()
        {

            createEnrichedDS(inputDataset1, enrichedFusedDS1);

            createEnrichedDS(inputDataset2, enrichedFusedDS2);

            createEnrichedDS(inputDataset3, enrichedFusedDS3);

        }

        public static void createEnrichedDS(FileInfo input, FileInfo output)
        {

            Console.WriteLine("Enrich fused dataset!");

            if (!enrichedFusedDS3.Exists)
            {

                List<Gene> geneList = Parser.getGeneList(input);

                // get overall call
                geneList = Ex1.run(geneList);

                // get publication year
                geneList = Ex2.run(geneList);

                // get overall diseases association
                geneList = Ex3.run(geneList);

                Output.createXml(geneList, output);

                //Output.createDaTsv2(geneList, new FileInfo(Environment.CurrentDirectory + "/data/output/enrichedFusedDS.tsv"));

            }

        }
        

    }

}