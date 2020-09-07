using System;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;

namespace Goldstandard
{
    class Kidney
    {
        public static void kidneyGoldStandard()
        {
            Kidney_2_mart_export_kidney();
            mart_export_kidney_2_all_gene_disease_pmid_associations();
            mart_export_kidney_2_gene2pubtatorcentral();
        }

        public static void mart_export_kidney_2_gene2pubtatorcentral()
        {
            List<Gene> mart_export_kidney_dt = Methods.readXmlFile(Datasets.mart_export_kidney_Path);
            List<Gene> gene2pubtatorcentral_dt = Methods.readXmlFile(Datasets.gene2pubtatorcentral_Path);

            (List<Goldstandard> mart_export_kidney_2_gene2pubtatorcentral_TRUE, List<Goldstandard> mart_export_kidney_2_gene2pubtatorcentral_FALSE) = Methods.compareUsingGeneName(mart_export_kidney_dt, gene2pubtatorcentral_dt, 200);
            Methods.createGoldStandard(mart_export_kidney_2_gene2pubtatorcentral_TRUE, mart_export_kidney_2_gene2pubtatorcentral_FALSE, "mart_export_kidney_2_gene2pubtatorcentral");
        }

        public static void Kidney_2_mart_export_kidney()
        {
            List<Gene> Kidney_dt = Methods.readXmlFile(Datasets.Kidney_Path);
            List<Gene> mart_export_kidney_dt = Methods.readXmlFile(Datasets.mart_export_kidney_Path);

            (List<Goldstandard> Kidney_2_mart_export_kidney_TRUE, List<Goldstandard> Kidney_2_mart_export_kidney_FALSE) = Methods.compareUsingGeneId(Kidney_dt, mart_export_kidney_dt, 200);
            Methods.createGoldStandard(Kidney_2_mart_export_kidney_TRUE, Kidney_2_mart_export_kidney_FALSE, "Kidney_2_mart_export_kidney");
        }

        public static void mart_export_kidney_2_all_gene_disease_pmid_associations()
        {
            List<Gene> mart_export_kidney_dt = Methods.readXmlFile(Datasets.mart_export_kidney_Path);
            List<Gene> all_gene_disease_pmid_associations_dt = Methods.readXmlFile(Datasets.all_gene_disease_pmid_associations_Path);

            (List<Goldstandard> mart_export_kidney_2_all_gene_disease_pmid_associations_TRUE, List<Goldstandard> mart_export_kidney_2_all_gene_disease_pmid_associations_FALSE) = Methods.compareUsingGeneName(mart_export_kidney_dt, all_gene_disease_pmid_associations_dt, 200);
            Methods.createGoldStandard(mart_export_kidney_2_all_gene_disease_pmid_associations_TRUE, mart_export_kidney_2_all_gene_disease_pmid_associations_FALSE, "mart_export_kidney_2_all_gene_disease_pmid_associations");
        }
    }
}