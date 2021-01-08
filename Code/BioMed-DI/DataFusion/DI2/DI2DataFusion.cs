using System;
using System.IO;
using System.Collections.Generic;

namespace DataFusion
{

    class DI2DataFusion
    {

        public static void run()
        {

            Console.WriteLine("Load correspondences!");

            List<Tuple<string, string>> correspondences = Correspondences.getCorrespondenceList(DI2Correspondences.getCorrespondencesFileInfoList());


            Console.WriteLine("Load key dictionary!");

            Dictionary<string, SortedSet<string>> mergedCorrespondences = Correspondences.getKeyDictionaryLeft(correspondences);

            
            Console.WriteLine("Load datasets!");

            HashSet<string> recordIdHashSet = Datasets.getRecordIdHashSet(mergedCorrespondences);

            Dictionary<string, Gene> datasets = Parser.getGeneListforFileList(DI2Datasets.getDatasetFileInfoList(), recordIdHashSet);


            Console.WriteLine("Fuse datasets!");

            List<Gene> fusedRecords = DataFusionEngine.fuseRecords(mergedCorrespondences, datasets);

            FileInfo fusedDataset = new FileInfo(string.Format("{0}/data/output/DI2/DI2-fused.xml", Environment.CurrentDirectory));

            Output.createXmlGene(fusedRecords, fusedDataset);

            Datasets.checkIfPatentsAreContainedInFusedDataset(fusedDataset);

        }

    }

}