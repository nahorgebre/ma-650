using System;

namespace GoldstandardCreation
{
    class DI3Datasets
    {        
        
        // // DI2
        // Publication
        public static string getGene2pubtatorcentral_path(int fileNumber) {
            String gene2pubtatorcentral_path = Environment.CurrentDirectory + "/data/input/DI2/" + Variables.pubTatorPartitionSize + "/gene2pubtatorcentral_" + fileNumber + "_dt.tsv";
            return gene2pubtatorcentral_path;
        }



    }

}