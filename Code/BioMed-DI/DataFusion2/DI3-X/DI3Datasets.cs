using System;
using System.IO;
using System.Collections.Generic;

namespace DataFusion2
{
    class DI3Datasets
    {


        public static List<FileInfo> datasets()
        {

            List<FileInfo> di3datasets = new List<FileInfo>();
        
            di3datasets.Add(KaessmannDiseaseAssociations);

            for (int i = 1; i <= 50; i++)
            {

                di3datasets.Add(gene2pubtatorcentral(i));

            }

            return di3datasets;

        }

        public static FileInfo KaessmannDiseaseAssociations = new FileInfo(Environment.CurrentDirectory + "/data/input/DI3/DI2_dt.xml");

        public static FileInfo gene2pubtatorcentral(int i) 
        {
            return new FileInfo(Environment.CurrentDirectory + "/data/input/DI3/gene2pubtatorcentral_" + i + "_dt.xml");
        }

    }

}