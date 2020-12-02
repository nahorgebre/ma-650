using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace DataFusion2
{

    class DI3DataFusion
    {

        public static void run()
        {

            /*

            Console.WriteLine("Load correspondences!");

            List<Tuple<string, string>> di3correspondences = Methods.getCorrespondenceList(DI3Correspondences.di3correspondences);


            Console.WriteLine("Load key dictionary!");

            FileInfo di3KeyDictionary = new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/keyDictionary.csv");

            Dictionary<string, HashSet<string>> keyDictionary = Correspondences.getKeyDictionary(di3KeyDictionary, di3correspondences);


            Console.WriteLine("Create record ID HashSet!");

            HashSet<string> recordIdHashSet = Correspondences.getRecordIdHashSet(keyDictionary);


            Console.WriteLine("Load datasets!");

            Dictionary<string, Gene> di3datasets = Parser.getGeneListforFileList(DI3Datasets.di3datasets(), recordIdHashSet);


            Console.WriteLine("Fuse datasets!");

            List<Gene> fusedRecords = DataFusionEngine.fuseRecords(keyDictionary, di3datasets);

            Output.createXmlGene(fusedRecords, new FileInfo(string.Format("{0}/data/output/DI3/DI3-fused.xml", Environment.CurrentDirectory)));

            */
            
        }

    }

}