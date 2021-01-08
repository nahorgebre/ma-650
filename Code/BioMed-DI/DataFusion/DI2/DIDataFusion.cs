using System;
using System.IO;
using System.Collections.Generic;

namespace DataFusion
{

    class DIDataFusion
    {

        public static void run()
        {

            Console.WriteLine("Load correspondences!");

            List<Tuple<string, string>> correspondences = DICorrespondences.getCorrespondenceList(DICorrespondences.getCorrespondencesFileInfoList());


            Console.WriteLine("Load key dictionary!");

            Dictionary<string, SortedSet<string>> mergedCorrespondences = Correspondences.getKeyDictionaryLeft(correspondences);

            
            Console.WriteLine("Load datasets!");

            HashSet<string> recordIdHashSet = DIDatasets.getRecordIdHashSet(mergedCorrespondences);

            Dictionary<string, Gene> datasets = Parser.getGeneListforFileList(DIDatasets.getDatasetFileInfoList(), recordIdHashSet);


            Console.WriteLine("Fuse datasets!");

            List<Gene> fusedRecords = DataFusionEngine.fuseRecords(mergedCorrespondences, datasets);

            FileInfo fusedDataset = new FileInfo(string.Format("{0}/data/output/DI2/DI2-fused.xml", Environment.CurrentDirectory));

            Output.createXmlGene(fusedRecords, fusedDataset);

            checkIfPatentsAreContainedInFusedDataset(fusedDataset);

        }

        public static void checkIfPatentsAreContainedInFusedDataset(FileInfo fusedDataset)
        {

            Console.WriteLine("Check fused dataset!");

            FileInfo dataset = new FileInfo(Environment.CurrentDirectory + "/data/output/DI2/DI2-fused.xml");

            if (dataset.Exists)
            {

                List<Gene> geneList = Parser.getGeneList(dataset);

                int count = 0;

                foreach (var item in geneList)
                {

                    if (item.patentMentions.Count > 0)
                    {

                        count ++;
                        
                    }
                    
                }

                Console.WriteLine("# of patents in fused dataset: " + count);
                
            }

        }

    }

}