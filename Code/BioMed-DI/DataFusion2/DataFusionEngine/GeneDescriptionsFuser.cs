using System;
using System.Linq;
using System.Collections.Generic;

namespace DataFusion2
{
    class GeneDescriptionsFuser
    {

        public static string fuse(List<string> geneDescriptionsList)
        {

            string geneDescriptions = string.Join('|', geneDescriptionsList);

            string[] geneDescriptionsArray = geneDescriptions.Split('|').Distinct().ToArray();

            geneDescriptions = string.Join('|', geneDescriptionsArray);

            Console.WriteLine("Fuser - Gene Descriptions: " + geneDescriptions);

            return geneDescriptions;

        }

    }

}