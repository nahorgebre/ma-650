using System;
using System.Collections.Generic;
using System.Linq;

namespace DataFusion2
{

    class EnsemblIdFuser
    {

        public static string fuse(List<string> ensemblIdList)
        {

            string ensemblId = string.Join('|', ensemblIdList);

            string[] ensemblIdArray = ensemblId.Split('|').Distinct().ToArray();

            ensemblId = string.Join('|', ensemblIdArray);

            Console.WriteLine("Fuser - Ensembl Id: " + ensemblId);

            return ensemblId;

        }

    }

}