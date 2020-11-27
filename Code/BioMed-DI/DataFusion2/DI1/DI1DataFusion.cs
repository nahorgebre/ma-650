using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace DataFusion2
{

    class DI1DataFusion
    {

        public static void run()
        {



            Console.WriteLine("Load datasets!");

            Dictionary<string, Gene> di1datasets = Parser.getGeneList(DI1Datasets.di1datasets);

            

            List<Gene> geneList = new List<Gene>();

            foreach (KeyValuePair<string, Gene> item in di1datasets)
            {

                geneList.Add(item.Value);

            }

            Output.createXmlGene(geneList, new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/di1datasets.xml"));
           


            Console.WriteLine("Load correspondences!");

            List<Tuple<string, string>> di1correspondences = Methods.getCorrespondenceList(DI1Correspondences.di1correspondences);



            Console.WriteLine("Fuse datasets!");

            Dictionary<string, string> keyDictionary = DataFusionEngine.getKeyDictionary(di1correspondences);

            Dictionary<string, HashSet<Gene>> unfusedRecords = DataFusionEngine.getUnfusedRecords(di1datasets, keyDictionary);

            List<Gene> fusedRecords = DataFusionEngine.fuseRecords(unfusedRecords);

            Output.createXmlGene(fusedRecords, new FileInfo(string.Format("{0}/data/output/DI1/kaessmann-fused.xml", Environment.CurrentDirectory)));
            

        }

    }

}