using System;
using System.IO;
using System.Collections.Generic;

namespace DataFusion
{
    class Datasets
    {

        public static HashSet<string> getRecordIdHashSet(Dictionary<string, SortedSet<string>> mergedCorrespondences)
        {

            HashSet<string> recordIdHashSet = new HashSet<string>();

            foreach (KeyValuePair<string, SortedSet<string>> correspondenceItem in mergedCorrespondences)
            {

                recordIdHashSet.Add(correspondenceItem.Key);

                foreach (string sortedSetItem in correspondenceItem.Value)
                {

                    recordIdHashSet.Add(sortedSetItem);

                }

            }

            return recordIdHashSet;

        }

        public static void checkIfPatentsAreContainedInFusedDataset(FileInfo fusedDataset)
        {

            Console.WriteLine("Check fused dataset!");

            FileInfo dataset = new FileInfo(Environment.CurrentDirectory + "/data/output/DI2/DI2-fused.xml");

            if (dataset.Exists)
            {

                List<Gene> geneList = Parser.getGeneList(dataset);

                int countGene = 0;

                int countPatent = 0;

                foreach (var item in geneList)
                {

                    if (item.patentMentions.Count > 0)
                    {

                        countGene ++;

                        countPatent = countPatent + item.patentMentions.Count;
                        
                    }
                    
                }

                Console.WriteLine("# of genes with patents in fused dataset: " + countGene);

                Console.WriteLine("# of patents in fused dataset: " + countPatent);
                
            }

        }

    }

}