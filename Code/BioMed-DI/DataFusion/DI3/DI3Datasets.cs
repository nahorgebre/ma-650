using System;
using System.IO;
using System.Collections.Generic;

namespace DataFusion
{
    class DI3Datasets
    {

        public static List<FileInfo> getDatasetFileInfoList()
        {

            List<FileInfo> datasetFileInfoList = new List<FileInfo>();

            datasetFileInfoList.Add(new FileInfo(Environment.CurrentDirectory + "/data/input/DI4/DI3_dt.xml"));

            datasetFileInfoList.Add(new FileInfo(Environment.CurrentDirectory + "/data/input/DI4/patent_abstract_dt.xml"));

            //datasetFileInfoList.Add(new FileInfo(Environment.CurrentDirectory + "/data/input/DI4/patent_title_dt.xml"));

            return datasetFileInfoList;

        }

    }

}