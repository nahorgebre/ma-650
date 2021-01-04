using System;
using System.IO;
using System.Collections.Generic;

namespace DataFusion2
{
    class DIDatasets
    {

        public static List<FileInfo> getDatasets()
        {

            List<FileInfo> datasets = new List<FileInfo>();

            datasets.Add(Kaessmann);

            for (int i = 1; i <= 7; i++)
            {

                datasets.Add(all_gene_disease_pmid_associations(i));
                
            }

            for (int i = 1; i <= 50; i++)
            {

                datasets.Add(gene2pubtatorcentral(i));
                
            }

            datasets.Add(patent_abstract);

            return datasets;

        }

        public static FileInfo Kaessmann = new FileInfo(Environment.CurrentDirectory + "/data/input/DI2/DI1_dt.xml");

        public static FileInfo all_gene_disease_pmid_associations(int i) 
        {

            return new FileInfo(Environment.CurrentDirectory + "/data/input/DI2/all_gene_disease_pmid_associations_" + i + "_dt.xml");

        }

        public static FileInfo gene2pubtatorcentral(int i) 
        {

            return new FileInfo(Environment.CurrentDirectory + "/data/input/DI3/gene2pubtatorcentral_" + i + "_dt.xml");

        }

        public static FileInfo patent_abstract = new FileInfo(Environment.CurrentDirectory + "/data/input/DI4/patent_abstract_dt.xml");

    }

}