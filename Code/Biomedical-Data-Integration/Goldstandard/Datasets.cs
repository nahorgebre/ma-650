using System;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;

namespace Goldstandard
{
    public class Datasets
    {
        public static List<Gene> all_gene_disease_pmid_associations_dt = Methods.readXmlFile("./data/input/all_gene_disease_pmid_associations_dt.xml");
        public static List<Gene> gene2pubtatorcentral_dt = Methods.readXmlFile("./data/input/gene2pubtatorcentral_dt.xml");
        
        // Brain
        public static List<Gene> Brain_dt = Methods.readXmlFile("./data/input/Brain/Brain_dt.xml");
        public static List<Gene> mart_export_brain_dt = Methods.readXmlFile("./data/input/Brain/mart_export_brain_dt.xml");

        // Cerebellum
        public static List<Gene> Cerebellum_dt = Methods.readXmlFile("./data/input/Cerebellum/Cerebellum_dt.xml");
        public static List<Gene> mart_export_cerebellum_dt = Methods.readXmlFile("./data/input/Cerebellum/mart_export_cerebellum_dt.xml");

        // Heart
        public static List<Gene> Heart_dt = Methods.readXmlFile("./data/input/Heart/Heart_dt.xml");
        public static List<Gene> Heart_Ensembl_NCBI_Crosswalk_dt = Methods.readXmlFile("./data/input/Heart/Heart_Ensembl_NCBI_Crosswalk_dt.xml");
        public static List<Gene> mart_export_heart_dt = Methods.readXmlFile("./data/input/Heart/mart_export_heart_dt.xml");

        // Kidney
        public static List<Gene> Kidney_dt = Methods.readXmlFile("./data/input/Kidney/Kidney_dt.xml");
        public static List<Gene> mart_export_kidney_dt = Methods.readXmlFile("./data/input/Kidney/mart_export_kidney_dt.xml");

        // Liver
        public static List<Gene> Liver_dt = Methods.readXmlFile("./data/input/Liver/Liver_dt.xml");
        public static List<Gene> mart_export_liver_dt = Methods.readXmlFile("./data/input/Liver/mart_export_liver_dt.xml");

        // Testis
        public static List<Gene> mart_export_testis_dt = Methods.readXmlFile("./data/input/Testis/mart_export_testis_dt.xml");
        public static List<Gene> Testis_dt = Methods.readXmlFile("./data/input/Testis/Testis_dt.xml");
    }
}