using System;
using System.Collections.Generic;

namespace Goldstandard
{
    public class Datasets
    {
        public static string all_gene_disease_pmid_associations_Path = Environment.CurrentDirectory + "/data/input/all_gene_disease_pmid_associations_dt.xml";        
        public static string gene2pubtatorcentral_Path = Environment.CurrentDirectory + "/data/input/gene2pubtatorcentral_dt.xml";
        
        // Brain
        public static string Brain_Path = Environment.CurrentDirectory + "/data/input/Brain/Brain_dt.xml";
        public static string mart_export_brain_Path = Environment.CurrentDirectory + "/data/input/Brain/mart_export_brain_dt.xml";
       
        // Cerebellum
        public static string Cerebellum_Path = Environment.CurrentDirectory + "/data/input/Cerebellum/Cerebellum_dt.xml";
        public static string mart_export_cerebellum_Path = Environment.CurrentDirectory + "/data/input/Cerebellum/mart_export_cerebellum_dt.xml";

        // Heart
        public static string Heart_Path = Environment.CurrentDirectory + "/data/input/Heart/Heart_dt.xml";
        public static string Heart_Ensembl_NCBI_Crosswalk_Path = Environment.CurrentDirectory + "/data/input/Heart/Heart_Ensembl_NCBI_Crosswalk_dt.xml";
        public static string mart_export_heart_Path = Environment.CurrentDirectory + "/data/input/Heart/mart_export_heart_dt.xml";

        // Kidney
        public static string Kidney_Path = Environment.CurrentDirectory + "/data/input/Kidney/Kidney_dt.xml";
        public static string mart_export_kidney_Path = Environment.CurrentDirectory + "/data/input/Kidney/mart_export_kidney_dt.xml";

        // Liver
        public static string Liver_Path = Environment.CurrentDirectory + "/data/input/Liver/Liver_dt.xml";
        public static string mart_export_liver_Path = Environment.CurrentDirectory + "/data/input/Liver/mart_export_liver_dt.xml";
        
        // Testis
        public static string mart_export_testis_Path = Environment.CurrentDirectory + "/data/input/Testis/mart_export_testis_dt.xml";
        public static string Testis_Path = Environment.CurrentDirectory + "/data/input/Testis/Testis_dt.xml";
    }
}