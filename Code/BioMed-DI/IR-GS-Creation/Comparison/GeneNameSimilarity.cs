using System;
using System.Collections.Generic;
using F23.StringSimilarity;

namespace IR_GS_Creation
{

    class GeneNameSimilarity
    {

        public static double getSimilarity(String geneNameSr1, String geneNameSr2)
        {

            var jw = new JaroWinkler();

            List<String> geneNameListSr1 = getGeneNameList(geneNameSr1);

            List<String> geneNameListSr2 = getGeneNameList(geneNameSr2);

            SimComparison simComp = new SimComparison();

            foreach (string geneNameSr1Item in geneNameListSr1)
            {

                foreach (string geneNameSr2Item in geneNameListSr2)
                {

                    double sim = jw.Similarity(geneNameSr1Item.ToLower(), geneNameSr2Item.ToLower());

                    if (sim > simComp.similarity)
                    {

                        simComp.s1 = geneNameSr1Item;

                        simComp.s2 = geneNameSr2Item;

                        simComp.similarity = sim;

                    }

                }

            }

            return simComp.similarity;

        }

        public static List<String> getGeneNameList(string geneNames)
        {

            List<String> geneNameList = new List<String>();

            if (geneNames.Contains("|"))
            {

                String[] geneNameArray = geneNames.Split("|");

                foreach (String geneNameItem in geneNameArray)
                {

                    geneNameList.Add(geneNameItem.Trim());

                }

            }
            else
            {

                geneNameList.Add(geneNames);

            }

            return geneNameList;

        }

    }

}