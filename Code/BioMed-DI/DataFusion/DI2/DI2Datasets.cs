using System;
using System.IO;
using System.Collections.Generic;

namespace DataFusion
{
    class DI2Datasets
    {

        public static List<FileInfo> getDatasetFileInfoList()
        {

            List<FileInfo> datasetFileInfoList = new List<FileInfo>();

            datasetFileInfoList.Add(new FileInfo(Environment.CurrentDirectory + "/data/input/DI4/DI1_dt.xml"));

            //datasetFileInfoList.Add(new FileInfo(Environment.CurrentDirectory + "/data/input/DI4/patent_abstract_dt.xml"));

            for (int i = 1; i <= 7; i++)
            {

                datasetFileInfoList.Add(new FileInfo(Environment.CurrentDirectory + "/data/input/DI2/all_gene_disease_pmid_associations_" + i + "_dt.xml"));

            }

            for (int i = 1; i <= 50; i++)
            {

                datasetFileInfoList.Add(new FileInfo(Environment.CurrentDirectory + "/data/input/DI3/gene2pubtatorcentral_" + i + "_dt.xml"));

            }

            return datasetFileInfoList;

        }



    }

}