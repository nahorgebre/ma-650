using System;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;

namespace Goldstandard
{
    class Cerebellum
    {
        public static void cerebellumGoldStandard()
        {
            Cerebellum_2_mart_export_cerebellum();
            //mart_export_cerebellum_2_all_gene_disease_pmid_associations();
            //mart_export_cerebellum_2_gene2pubtatorcentral();
        }

        public static void mart_export_cerebellum_2_gene2pubtatorcentral()
        {
            List<Gene> mart_export_cerebellum_dt = Methods.readXmlFile(Datasets.mart_export_cerebellum_Path);
            List<Gene> gene2pubtatorcentral_dt = Methods.readXmlFile(Datasets.gene2pubtatorcentral_Path);

            (List<Goldstandard> mart_export_cerebellum_2_gene2pubtatorcentral_TRUE, List<Goldstandard> mart_export_cerebellum_2_gene2pubtatorcentral_FALSE) = Methods.compareUsingGeneName(mart_export_cerebellum_dt, gene2pubtatorcentral_dt, 200);
            Methods.createGoldStandard(mart_export_cerebellum_2_gene2pubtatorcentral_TRUE, mart_export_cerebellum_2_gene2pubtatorcentral_FALSE, "mart_export_cerebellum_2_gene2pubtatorcentral");
        }

        public static void Cerebellum_2_mart_export_cerebellum()
        {
            List<Gene> Cerebellum_dt = Methods.readXmlFile(Datasets.Cerebellum_Path);
            List<Gene> mart_export_cerebellum_dt = Methods.readXmlFile(Datasets.mart_export_cerebellum_Path);

            (List<Goldstandard> Cerebellum_2_mart_export_cerebellum_TRUE, List<Goldstandard> Cerebellum_2_mart_export_cerebellum_FALSE) = Methods.compareUsingGeneId(Cerebellum_dt, mart_export_cerebellum_dt, 200);
            Methods.createGoldStandard(Cerebellum_2_mart_export_cerebellum_TRUE, Cerebellum_2_mart_export_cerebellum_FALSE, "Cerebellum_2_mart_export_cerebellum");
        }

        public static void mart_export_cerebellum_2_all_gene_disease_pmid_associations()
        {
            List<Gene> mart_export_cerebellum_dt = Methods.readXmlFile(Datasets.mart_export_cerebellum_Path);
            List<Gene> all_gene_disease_pmid_associations_dt = Methods.readXmlFile(Datasets.all_gene_disease_pmid_associations_Path);

            (List<Goldstandard> mart_export_cerebellum_2_all_gene_disease_pmid_associations_TRUE, List<Goldstandard> mart_export_cerebellum_2_all_gene_disease_pmid_associations_FALSE) = Methods.compareUsingGeneName(mart_export_cerebellum_dt, all_gene_disease_pmid_associations_dt, 200);
            Methods.createGoldStandard(mart_export_cerebellum_2_all_gene_disease_pmid_associations_TRUE, mart_export_cerebellum_2_all_gene_disease_pmid_associations_FALSE, "mart_export_cerebellum_2_all_gene_disease_pmid_associations");
        }
    }
}