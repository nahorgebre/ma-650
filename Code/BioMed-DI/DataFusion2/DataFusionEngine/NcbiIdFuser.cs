using System;
using System.Collections.Generic;
using System.Linq;

namespace DataFusion2
{

    class NcbiIdFuser
    {

        public static string fuse(List<string> ncbiIdList)
        {

            string ncbiId = string.Join('|', ncbiIdList);

            string[] ncbiIdArray = ncbiId.Split('|').Distinct().ToArray();

            ncbiId = string.Join('|', ncbiIdArray);

            Console.WriteLine("Fuser - NCBI ID: " + ncbiId);

            return ncbiId;

        }

    }

}