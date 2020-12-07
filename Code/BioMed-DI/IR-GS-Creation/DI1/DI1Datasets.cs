using System;
using System.IO;

namespace IR_GS_Creation
{
    
    class DI1Datasets
    {

        public static FileInfo Brain_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/Brain_dt.tsv");
        
        public static FileInfo Cerebellum_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/Cerebellum_dt.tsv");

        public static FileInfo Heart_Ensembl_NCBI_Crosswalk_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/Heart_Ensembl_NCBI_Crosswalk_dt.tsv");

        public static FileInfo Heart_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/Heart_dt.tsv");

        public static FileInfo Kidney_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/Kidney_dt.tsv");

        public static FileInfo Liver_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/Liver_dt.tsv");

        public static FileInfo Testis_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/Testis_dt.tsv");
    
        public static FileInfo mart_export_brain_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/mart_export_brain_dt.tsv");
          
        public static FileInfo mart_export_cerebellum_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/mart_export_cerebellum_dt.tsv");

        public static FileInfo mart_export_heart_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/mart_export_heart_dt.tsv");

        public static FileInfo mart_export_kidney_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/mart_export_kidney_dt.tsv");
        
        public static FileInfo mart_export_liver_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/mart_export_liver_dt.tsv");
         
        public static FileInfo mart_export_testis_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/mart_export_testis_dt.tsv");

    }

}