using System;
using System.IO;
using System.Collections.Generic;

namespace DataFusion
{
    class DI3Correspondences
    {

        public static List<FileInfo> getCorrespondencesFileInfoList()
        {

            List<FileInfo> correspondencesFileInfoList = new List<FileInfo>();

            correspondencesFileInfoList.Add(new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI4/kaessmann_2_patentAbstract/correspondences.csv"));

            //correspondencesFileInfoList.Add(new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI4/kaessmann_2_patentTitle/correspondences.csv"));

            return correspondencesFileInfoList;

        }

    }

}