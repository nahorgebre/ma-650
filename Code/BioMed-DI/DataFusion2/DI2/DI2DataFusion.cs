using System;
using System.IO;
using System.Collections.Generic;

namespace DataFusion2
{

    class DI2DataFusion
    {

        public static void run()
        {

            Console.WriteLine("Load correspondences!");

            List<Tuple<string, string>> correspondences = Methods.getCorrespondenceList(DI2Correspondences.kaessmann_2_all_gene_disease_pmid_associations());


            Console.WriteLine("Load key dictionary!");

            Dictionary<string, SortedSet<string>> mergedCorrespondences = Correspondences.getKeyDictionaryLeft(correspondences);


            Console.WriteLine("Load datasets!");

            Dictionary<string, Gene> datasets = Parser.getGeneListforFileList(DI2Datasets.datasets(), mergedCorrespondences);


            Console.WriteLine("Fuse datasets!");

            List<Gene> fusedRecords = DataFusionEngine.fuseRecords(mergedCorrespondences, datasets);

            Output.createXmlGene(fusedRecords, new FileInfo(string.Format("{0}/data/output/DI2/DI2-fused.xml", Environment.CurrentDirectory)));
            
        }

    }

}