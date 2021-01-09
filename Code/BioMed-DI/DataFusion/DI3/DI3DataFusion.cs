using System;
using System.IO;
using System.Collections.Generic;

namespace DataFusion
{

    class DI3DataFusion
    {

        public static void run()
        {

            Console.WriteLine("Load correspondences!");

            List<Tuple<string, string>> correspondences = Correspondences.getCorrespondenceList(DI3Correspondences.getCorrespondencesFileInfoList());


            Console.WriteLine("Load key dictionary!");

            Dictionary<string, SortedSet<string>> mergedCorrespondences = Correspondences.getKeyDictionaryLeft(correspondences);


            Console.WriteLine("Load datasets!");

            HashSet<string> recordIdHashSet = Datasets.getRecordIdHashSet(mergedCorrespondences);

            Dictionary<string, Gene> datasets = Parser.getGeneListforFileList(DI3Datasets.getDatasetFileInfoList(), recordIdHashSet);


            Console.WriteLine("Fuse datasets!");

            List<Gene> fusedRecords = DataFusionEngine.fuseRecords(mergedCorrespondences, datasets);

            checkIfFusedRecordsContainPatents(fusedRecords);


            FileInfo fusedDataset = new FileInfo(string.Format("{0}/data/output/DI3/DI3-fused.xml", Environment.CurrentDirectory));

            Output.createXmlGene(fusedRecords, fusedDataset);

            checkIfPatentsAreContainedInFusedDataset(fusedDataset);

        }

        public static void checkIfFusedRecordsContainPatents(List<Gene> fusedRecords)
        {

            int countGene = 0;

            int countPatent = 0;

            foreach (Gene item in fusedRecords)
            {

                if (item.patentMentions.Count > 0)
                {

                    countGene++;

                    countPatent = countPatent + item.patentMentions.Count;

                }

            }

            Console.WriteLine("# of genes with patents in fused records: " + countGene);

            Console.WriteLine("# of patents in fused records: " + countPatent);

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

                        countGene++;

                        countPatent = countPatent + item.patentMentions.Count;

                    }

                }

                Console.WriteLine("# of genes with patents in fused dataset: " + countGene);

                Console.WriteLine("# of patents in fused dataset: " + countPatent);

            }

        }

    }

}