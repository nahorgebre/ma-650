using System;
using System.IO;
using System.Collections.Generic;

namespace DataFusion2
{

    class DIDataFusion
    {

        public static void run()
        {

            Console.WriteLine("Load correspondences!");

            List<Tuple<string, string>> correspondences = Methods.getCorrespondenceList(DICorrespondences.getCorrespondencesFileInfoList());


            Console.WriteLine("Load key dictionary!");

            Dictionary<string, SortedSet<string>> mergedCorrespondences = Correspondences.getKeyDictionaryLeft(correspondences);

            
            Console.WriteLine("Load datasets!");

            HashSet<string> recordIdHashSet = Datasets.getRecordIdHashSet(mergedCorrespondences);

            Dictionary<string, Gene> datasets = Parser.getGeneListforFileList(DIDatasets.getDatasets(), recordIdHashSet);


            Console.WriteLine("Fuse datasets!");

            List<Gene> fusedRecords = DataFusionEngine.fuseRecords(mergedCorrespondences, datasets);

            Output.createXmlGene(fusedRecords, new FileInfo(string.Format("{0}/data/output/DI2/DI2-fused.xml", Environment.CurrentDirectory)));

        }

    }

}