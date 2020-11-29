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


            Console.WriteLine("Load datasets!");

            Dictionary<string, Gene> di1datasets = Parser.getGeneListforFileList(DI1Datasets.di1datasets);

            
            Console.WriteLine("Load correspondences!");

            List<Tuple<string, string>> di1correspondences = Methods.getCorrespondenceList(DI1Correspondences.di1correspondences);


            Console.WriteLine("Load key dictionary!");

            FileInfo di1KeyDictionary = new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI1/keyDictionary.csv");

            Dictionary<string, HashSet<string>> keyDictionary = Correspondences.getKeyDictionary(di1KeyDictionary, di1correspondences);


            Console.WriteLine("Fuse datasets!");

            List<Gene> fusedRecords = DataFusionEngine.fuseRecords(keyDictionary, di1datasets);

            Output.createXmlGene(fusedRecords, new FileInfo(string.Format("{0}/data/output/DI1/kaessmann-fused.xml", Environment.CurrentDirectory)));
            
        }

    }

}