using System;
using System.IO;

namespace DataFusion2
{
    class DI3Datasets
    {

        public static FileInfo KaessmannDiseaseAssociations = new FileInfo(Environment.CurrentDirectory + "/data/input/DI3/KaessmannDiseaseAssociations_dt.xml");

        public static FileInfo gene2pubtatorcentral(int i) 
        {
            return new FileInfo(Environment.CurrentDirectory + "/data/input/DI3/gene2pubtatorcentral_" + i + "_dt.tsv");
        }

    }

}