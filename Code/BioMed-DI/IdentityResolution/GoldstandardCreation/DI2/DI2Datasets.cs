using System;

namespace GoldstandardCreation
{
    class DI2Datasets
    {

        public static string kaessmann_path = Environment.CurrentDirectory + "/data/input/DI2/Kaessmann_dt.tsv";

        public static string all_gene_disease_pmid_associations_path(int fileNumber) 
        {

            String path = Environment.CurrentDirectory + "/data/input/DI2/all_gene_disease_pmid_associations_" + fileNumber + "_dt.tsv";

            return path;

        }

    }

}