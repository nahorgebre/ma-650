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

            correspondencesFileInfoList.Add(new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI4/kaessmann_2_patentAbstract/correspondences.csv"));

            
            for (int i = 1; i <= 7; i++)
            {

                correspondencesFileInfoList.Add(new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI2/kaessmann_2_all_gene_disease_pmid_associations_" + i + "/correspondences.csv"));
                
            }
                  
            for (int i = 1; i <= 50; i++)
            {

                correspondencesFileInfoList.Add(new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmann_2_gene2pubtatorcentral_" + i + "/correspondences.csv"));

            }
            

            return correspondencesFileInfoList;

        }

        public static List<Tuple<string, string>> getCorrespondenceList(List<FileInfo> fileList)
        {

            List<Tuple<string, string>> correspondenceList = new List<Tuple<string, string>>();

            foreach (FileInfo file in fileList)
            {

                using (StreamReader sr = new StreamReader(file.FullName))
                {

                    while (!sr.EndOfStream)
                    {

                        var line = sr.ReadLine();

                        string[] values = line.Split(",");

                        string recordId1 = values[0].Replace("\"", string.Empty);

                        string recordId2 = values[1].Replace("\"", string.Empty);

                        correspondenceList.Add(new Tuple<string, string>(recordId1, recordId2));

                    }

                }

            }

            return correspondenceList;

        }

    }

}