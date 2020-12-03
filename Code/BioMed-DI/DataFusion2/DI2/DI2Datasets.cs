using System;
using System.IO;
using System.Collections.Generic;

namespace DataFusion2
{
    class DI2Datasets
    {

        public static List<FileInfo> datasets()
        {

            List<FileInfo> di2datasets = new List<FileInfo>();

            di2datasets.Add(Kaessmann);

            for (int i = 1; i <= 7; i++)
            {

                di2datasets.Add(all_gene_disease_pmid_associations(i));
                
            }

            return di2datasets;

        }

        public static FileInfo Kaessmann = new FileInfo(Environment.CurrentDirectory + "/data/input/DI2/Kaessmann_dt.xml");

        public static FileInfo all_gene_disease_pmid_associations(int i) 
        {
            return new FileInfo(Environment.CurrentDirectory + "/data/input/DI2/all_gene_disease_pmid_associations_" + i + "_dt.tsv");
        }

    }

}