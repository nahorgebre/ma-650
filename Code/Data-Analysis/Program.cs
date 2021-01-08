using System;
using System.IO;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    class Program
    {

        static void Main(string[] args)
        {

            /*
            double x = double.Parse("0.10".Replace('.', ','));

            Console.WriteLine(x.ToString());
            */

            if (checkIfPatentsAreContainedInFusedDataset())
            {

                Console.WriteLine("Fused Dataset does contain Patents!");

                EnrichDataset.run();

            }
            else
            {

                Console.WriteLine("Fused Dataset does not contain Patents!");

            }

            if (checkIfPatentsAreContainedInEnrichedDataset())
            {

                Console.WriteLine("Enriched Dataset does contain Patents!");

                AIM_TimeDependentOutput.run();

                AIM_PatentingActivity.run();

            }
            else
            {

                Console.WriteLine("Enriched Dataset does not contain Patents!");

            }

        }

        public static bool checkIfPatentsAreContainedInFusedDataset()
        {
            bool returnValue = false;

            FileInfo inputDataset = new FileInfo(Environment.CurrentDirectory + "/data/input/DI2-fused.xml");

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