using System;
using System.IO;
using System.Collections.Generic;

namespace DataFusion2
{
    class DI2Correspondences
    {

        public static List<FileInfo> kaessmann_2_all_gene_disease_pmid_associations()
        {

            List<FileInfo> kaessmann_2_all_gene_disease_pmid_associations = new List<FileInfo>();

            for (int i = 1; i <= 7; i++)
            {

                kaessmann_2_all_gene_disease_pmid_associations.Add(new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI2/kaessmann_2_all_gene_disease_pmid_associations_" + i + "/correspondences.csv"));
                
            }

            return kaessmann_2_all_gene_disease_pmid_associations;

        }

    }

}