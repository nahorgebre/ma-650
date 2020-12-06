using System;
using System.IO;

namespace IR_GS_Creation
{
    
    class DI1Datasets
    {

        public static FileInfo Brain_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/Brain_dt.xml");
        
        public static FileInfo Cerebellum_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/Cerebellum_dt.xml");

        public static FileInfo Heart_Ensembl_NCBI_Crosswalk_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/Heart_Ensembl_NCBI_Crosswalk_dt.xml");

        public static FileInfo Heart_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/Heart_dt.xml");

        public static FileInfo Kidney_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/Kidney_dt.xml");

        public static FileInfo Liver_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/Liver_dt.xml");

        public static FileInfo Testis_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/Testis_dt.xml");
    
        public static FileInfo mart_export_brain_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/mart_export_brain_dt.xml");
          
        public static FileInfo mart_export_cerebellum_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/mart_export_cerebellum_dt.xml");

        public static FileInfo mart_export_heart_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/mart_export_heart_dt.xml");

        public static FileInfo mart_export_kidney_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/mart_export_kidney_dt.xml");
        
        public static FileInfo mart_export_liver_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/mart_export_liver_dt.xml");
         
        public static FileInfo mart_export_testis_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI1/mart_export_testis_dt.xml");

    }

}