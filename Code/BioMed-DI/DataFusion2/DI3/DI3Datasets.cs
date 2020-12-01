using System;
using System.IO;
using System.Collections.Generic;

namespace DataFusion2
{
    class DI3Datasets
    {



        public static List<FileInfo> di3datasets()
        {

            List<FileInfo> di1datasets = new List<FileInfo>();
        
            di1datasets.Add(KaessmannDiseaseAssociations);

            for (int i = 1; i <= 50; i++)
            {

                di1datasets.Add(gene2pubtatorcentral(i));

            }

            return di1datasets;

        }

        public static FileInfo KaessmannDiseaseAssociations = new FileInfo(Environment.CurrentDirectory + "/data/input/DI3/KaessmannDiseaseAssociations_dt.xml");

        public static FileInfo gene2pubtatorcentral(int i) 
        {
            return new FileInfo(Environment.CurrentDirectory + "/data/input/DI3/gene2pubtatorcentral_" + i + "_dt.xml");
        }

    }

}