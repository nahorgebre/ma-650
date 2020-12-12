using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace DataFusion2
{

    class DI1DataFusion
    {

        public static void run()
        {

            Console.WriteLine("Load correspondences!");

            List<Tuple<string, string>> correspondences = Methods.getCorrespondenceList(DI1Correspondences.correspondences);


            Console.WriteLine("Load key dictionary!");

            Dictionary<string, SortedSet<string>> mergedCorrespondences = Correspondences.getKeyDictionary(correspondences);


            Console.WriteLine("Load datasets!");

            HashSet<string> recordIdHashSet = Datasets.getRecordIdHashSet(mergedCorrespondences);

            Dictionary<string, Gene> datasets = Parser.getGeneListforFileList(DI1Datasets.datasets, recordIdHashSet);


            Console.WriteLine("Fuse datasets!");

            List<Gene> fusedRecords = DataFusionEngine.fuseRecords(mergedCorrespondences, datasets);

            Output.createXmlGene(fusedRecords, new FileInfo(string.Format("{0}/data/output/DI1/DI1-fused.xml", Environment.CurrentDirectory)));

            
        }

    }

}