using System;
using System.IO;

namespace IR_GS_Creation
{
    class DI3Datasets
    {

        public static FileInfo kaessmannDiseaseAssociations_path = new FileInfo(Environment.CurrentDirectory + "/data/input/DI3/KaessmannDiseaseAssociations_dt.tsv");        
        
        public static FileInfo getGene2pubtatorcentral_path(int fileNumber) {
            
            FileInfo gene2pubtatorcentral_path = new FileInfo(Environment.CurrentDirectory + "/data/input/DI3/gene2pubtatorcentral_" + fileNumber + "_dt.tsv");
            
            return gene2pubtatorcentral_path;

        }

    }

}