using System;
using System.IO;
using System.Collections.Generic;

namespace DataFusion2
{
    class DICorrespondences
    {

        public static List<FileInfo> getCorrespondencesFileInfoList()
        {

            List<FileInfo> correspondencesFileInfoList = new List<FileInfo>();

            for (int i = 1; i <= 7; i++)
            {

                correspondencesFileInfoList.Add(new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI2/kaessmann_2_all_gene_disease_pmid_associations_" + i + "/correspondences.csv"));
                
            }

            for (int i = 1; i <= 50; i++)
            {

                correspondencesFileInfoList.Add(new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmann_2_gene2pubtatorcentral_" + i + "/correspondences.csv"));

            }

            correspondencesFileInfoList.Add(new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI4/kaessmann_2_patentAbstract/correspondences.csv"));

            return correspondencesFileInfoList;

        }

    }

}