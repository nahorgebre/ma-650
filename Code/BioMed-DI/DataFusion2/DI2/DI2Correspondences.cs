using System;
using System.IO;

namespace DataFusion2
{
    class DI2Correspondences
    {

        public static FileInfo kaessmann_2_all_gene_disease_pmid_associations(int i) 
        {

            return new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI2/kaessmann_2_all_gene_disease_pmid_associations_" + i + "/correspondences.csv");

        }

    }

}