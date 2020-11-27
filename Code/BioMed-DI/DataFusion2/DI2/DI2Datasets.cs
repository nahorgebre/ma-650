using System;
using System.IO;

namespace DataFusion2
{
    class DI2Datasets
    {

        public static FileInfo KaessmannDiseaseAssociations = new FileInfo(Environment.CurrentDirectory + "/data/input/DI2/Kaessmann_dt.xml");

        public static FileInfo all_gene_disease_pmid_associations(int i) 
        {
            return new FileInfo(Environment.CurrentDirectory + "/data/input/DI2/all_gene_disease_pmid_associations_" + i + "_dt.tsv");
        }

    }

}