using System;
using System.Collections.Generic;

namespace DataPreparation
{
    class Program
    {
        static void Main(string[] args)
        {





            HashSet<String> Heart_Ensembl_NCBI_Crosswalk_dt = new HashSet<String>();
            List<(int, String)> Heart_Ensembl_NCBI_Crosswalk_dt_recordIds = new List<(int, String)>
            {
                (2, Correspondences.gene2pubtatorcentral_2_PubMedDate),
            };

            HashSet<String> Heart_dt = new HashSet<String>();
            List<(int, String)> Heart_dt_recordIds = new List<(int, String)>
            {
                (2, Correspondences.gene2pubtatorcentral_2_PubMedDate),
            };

            HashSet<String> mart_export_heart_dt = new HashSet<String>();
            List<(int, String)> mart_export_heart_dt_recordIds = new List<(int, String)>
            {
                (2, Correspondences.gene2pubtatorcentral_2_PubMedDate),
            };

            HashSet<String> Kidney_dt = new HashSet<String>();
            List<(int, String)> Kidney_dt_recordIds = new List<(int, String)>
            {
                (2, Correspondences.gene2pubtatorcentral_2_PubMedDate),
            };

            HashSet<String> mart_export_kidney_dt = new HashSet<String>();
            List<(int, String)> mart_export_kidney_dt_recordIds = new List<(int, String)>
            {
                (2, Correspondences.gene2pubtatorcentral_2_PubMedDate),
            };

            HashSet<String> Liver_dt = new HashSet<String>();
            List<(int, String)> Liver_dt_recordIds = new List<(int, String)>
            {
                (2, Correspondences.gene2pubtatorcentral_2_PubMedDate),
            };

            HashSet<String> mart_export_liver_dt = new HashSet<String>();
            List<(int, String)> mart_export_liver_dt_recordIds = new List<(int, String)>
            {
                (2, Correspondences.gene2pubtatorcentral_2_PubMedDate),
            };

            HashSet<String> mart_export_testis_dt = new HashSet<String>();
            List<(int, String)> mart_export_testis_dt_recordIds = new List<(int, String)>
            {
                (2, Correspondences.gene2pubtatorcentral_2_PubMedDate),
            };

            HashSet<String> Testis_dt = new HashSet<String>();
            List<(int, String)> Testis_dt_recordIds = new List<(int, String)>
            {
                (2, Correspondences.gene2pubtatorcentral_1_2_PubMedDate),
                (2, Correspondences.gene2pubtatorcentral_2_2_PubMedDate),
                (2, Correspondences.gene2pubtatorcentral_3_2_PubMedDate),
                (2,Correspondences.gene2pubtatorcentral_4_2_PubMedDate),
                (2, Correspondences.gene2pubtatorcentral_5_2_PubMedDate),
                (2, Correspondences.gene2pubtatorcentral_6_2_PubMedDate),
                (2, Correspondences.gene2pubtatorcentral_7_2_PubMedDate),
                (2, Correspondences.gene2pubtatorcentral_8_2_PubMedDate),
                (2, Correspondences.gene2pubtatorcentral_9_2_PubMedDate),
                (2, Correspondences.gene2pubtatorcentral_10_2_PubMedDate),
                (2, Correspondences.gene2pubtatorcentral_11_2_PubMedDate),
                (2, Correspondences.gene2pubtatorcentral_12_2_PubMedDate),
                (2, Correspondences.gene2pubtatorcentral_13_2_PubMedDate),
                (2, Correspondences.gene2pubtatorcentral_14_2_PubMedDate),
                (2, Correspondences.gene2pubtatorcentral_15_2_PubMedDate)
            };
        }
    }
}
