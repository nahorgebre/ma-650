using System;
using System.IO;

namespace IR_GS_Creation
{
    class DI2Datasets
    {

        public static FileInfo DI1_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI2/DI1_dt.tsv");

        public static FileInfo all_gene_disease_pmid_associations_dt(int fileNumber) 
        {

            return new FileInfo(Environment.CurrentDirectory + "/data/input/DI2/all_gene_disease_pmid_associations_" + fileNumber + "_dt.tsv");

        }

    }

}