using System;
using System.IO;
using System.Collections.Generic;

namespace DataFusion2
{

    class DI3DataFusion
    {

        public static void run()
        {

            Console.WriteLine("Load correspondences!");

            List<Tuple<string, string>> correspondences = Methods.getCorrespondenceList(DI3Correspondences.correspondences);


            Console.WriteLine("Load key dictionary!");

            Dictionary<string, SortedSet<string>> mergedCorrespondences = Correspondences.getKeyDictionaryLeft(correspondences);


            Console.WriteLine("Load datasets!");

            HashSet<string> recordIdHashSet = Datasets.getRecordIdHashSet(mergedCorrespondences);

            Dictionary<string, Gene> datasets = Parser.getGeneListforFileList(DI3Datasets.datasets(), recordIdHashSet);


            Console.WriteLine("Fuse datasets!");

            List<Gene> fusedRecords = DataFusionEngine.fuseRecords(mergedCorrespondences, datasets);

            Output.createXmlGene(fusedRecords, new FileInfo(string.Format("{0}/data/output/DI3/DI3-fused.xml", Environment.CurrentDirectory)));
            
        }

    }

}