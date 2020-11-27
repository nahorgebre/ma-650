using System;
using System.Linq;
using System.Collections.Generic;

namespace DataFusion2
{
    
    class GeneNamesFuser
    {

        public static string fuse(List<string> geneNameList)
        {

            string geneNames = string.Join('|', geneNameList);

            string[] geneNameArray = geneNames.Split('|').Distinct().ToArray();

            geneNames = string.Join('|', geneNameArray);

            Console.WriteLine("Fuser - Gene Names: " + geneNames);

            return geneNames;

        }

    }

}