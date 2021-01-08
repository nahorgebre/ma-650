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

            FileInfo fusedDataset = new FileInfo(string.Format("{0}/data/output/DI3/DI3-fused.xml", Environment.CurrentDirectory));

            Output.createXmlGene(fusedRecords, fusedDataset);

            Datasets.checkIfPatentsAreContainedInFusedDataset(fusedDataset);

        }

    }

}