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

            // put KaessmannDiseaseAssociations into center

            Console.WriteLine("Load correspondences!");

            List<Tuple<string, string>> di3correspondences = Methods.getCorrespondenceList(DI3Correspondences.di3correspondences);


            Console.WriteLine("Load key dictionary!");

            Dictionary<string, SortedSet<string>> mergedCorrespondences = Correspondences.getKeyDictionaryLeft(di3correspondences);


            Console.WriteLine("Load datasets!");

            Dictionary<string, Gene> di3datasets = Parser.getGeneListforFileList(DI3Datasets.di3datasets(), mergedCorrespondences);


            Console.WriteLine("Fuse datasets!");

            List<Gene> fusedRecords = DataFusionEngine.fuseRecords(mergedCorrespondences, di3datasets);

            Output.createXmlGene(fusedRecords, new FileInfo(string.Format("{0}/data/output/DI3/DI3-fused.xml", Environment.CurrentDirectory)));
            
        }

    }

}