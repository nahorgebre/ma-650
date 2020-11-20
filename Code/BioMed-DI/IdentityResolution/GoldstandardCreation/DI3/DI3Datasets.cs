using System;

namespace GoldstandardCreation
{
    class DI3Datasets
    {

        public static string kaessmannDiseaseAssociations_path = Environment.CurrentDirectory + "/data/input/DI2/KaessmannDiseaseAssociations_dt.tsv";        
        
        public static string getGene2pubtatorcentral_path(int fileNumber) {
            String gene2pubtatorcentral_path = Environment.CurrentDirectory + "/data/input/DI2/gene2pubtatorcentral_" + fileNumber + "_dt.tsv";
            return gene2pubtatorcentral_path;
        }

    }

}