using System;
using System.IO;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    class Program
    {

        static void Main(string[] args)
        {

            EnrichDataset.run();

            AIM_TimeDependentOutput.run();

            AIM_PatentingActivity.run();

            //PatentTextMiningStatistics.run();

        }

        public static bool checkIfPatentsAreContainedInFusedDataset()
        {
            bool returnValue = false;

            FileInfo inputDataset = new FileInfo(Environment.CurrentDirectory + "/data/input/DI3-fused.xml");

            if (inputDataset.Exists)
            {

                List<Gene> geneList = Parser.getGeneList(inputDataset);

                int count = 0;

                foreach (var item in geneList)
                {

                    if (item.patentMentions.Count > 0)
                    {

                        count ++;
                        
                    }
                    
                }

                Console.WriteLine("Count: " + count);

                if (count > 0)
                {
                    
                    returnValue = true;
                    
                }
                
            }

            return returnValue;

        }

        public static bool checkIfPatentsAreContainedInEnrichedDataset()
        {
            bool returnValue = false;

            FileInfo inputDataset = new FileInfo(Environment.CurrentDirectory + "/data/output/enrichedFusedDS.xml");

            if (inputDataset.Exists)
            {

                List<Gene> geneList = Parser.getGeneList(inputDataset);

                int count = 0;

                foreach (var item in geneList)
                {

                    if (item.patentMentions.Count > 0)
                    {

                        count ++;
                        
                    }
                    
                }

                Console.WriteLine("Count: " + count);

                if (count > 0)
                {

                    returnValue = true;

                }
                
            }

            return returnValue;

        }

    }

}