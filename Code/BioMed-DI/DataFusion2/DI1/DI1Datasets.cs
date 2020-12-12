using System;
using System.IO;
using System.Collections.Generic;

namespace DataFusion2
{
    class DI1Datasets
    {
        
        public static List<FileInfo> datasets = new List<FileInfo> {

            new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/Brain_dt.xml"),

            new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/Cerebellum_dt.xml"),

            new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/Heart_Ensembl_NCBI_Crosswalk_dt.xml"),

            new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/Heart_dt.xml"),

            new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/Kidney_dt.xml"),

            new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/Liver_dt.xml"),

            new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/Testis_dt.xml"),

            new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/mart_export_brain_dt.xml"),

            new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/mart_export_cerebellum_dt.xml"),

            new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/mart_export_heart_dt.xml"),

            new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/mart_export_kidney_dt.xml"),

            new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/mart_export_liver_dt.xml"),

            new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/mart_export_testis_dt.xml")

        };

    }

}