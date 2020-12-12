using System;
using System.IO;
using System.Collections.Generic;

namespace DataFusion2
{
    class DI1Correspondences
    {

        public static List<FileInfo> correspondences = new List<FileInfo> {
            
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI1/Brain_2_Kidney/correspondences.csv"),

            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI1/Brain_2_Liver/correspondences.csv"),
            
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI1/Brain_2_Testis/correspondences.csv"),

            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI1/Brain_2_mart_export_brain/correspondences.csv"),
            
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI1/Cerebellum_2_Brain/correspondences.csv"),

            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI1/Cerebellum_2_Kidney/correspondences.csv"),

            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI1/Cerebellum_2_Liver/correspondences.csv"),

            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI1/Cerebellum_2_Testis/correspondences.csv"),

            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI1/Cerebellum_2_mart_export_cerebellum/correspondences.csv"),

            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI1/Heart_2_Brain/correspondences.csv"),

            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI1/Heart_2_Cerebellum/correspondences.csv"),

            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI1/Heart_2_Heart_Ensembl_NCBI_Crosswalk/correspondences.csv"),

            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI1/Heart_2_Kidney/correspondences.csv"),

            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI1/Heart_2_Liver/correspondences.csv"),

            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI1/Heart_2_Testis/correspondences.csv"),

            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI1/Kidney_2_Liver/correspondences.csv"),

            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI1/Kidney_2_Testis/correspondences.csv"),

            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI1/Kidney_2_mart_export_kidney/correspondences.csv"),

            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI1/Liver_2_mart_export_liver/correspondences.csv"),

            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI1/Testis_2_Liver/correspondences.csv"),

            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI1/Testis_2_mart_export_testis/correspondences.csv"),

            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI1/mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk/correspondences.csv")

        };

    }

}