using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace DataFusion2
{

    public class Correspondences2
    {

        public static Dictionary<string, SortedSet<string>> getKeyDictionary(List<Tuple<string, string>> di3correspondences)
        {

            Dictionary<string, SortedSet<string>> mergedCorrespondences = new Dictionary<string, SortedSet<string>>();

            foreach (Tuple<string, string> correspondenceItem in di3correspondences)
            {

                string recordId1 = correspondenceItem.Item1;

                string recordId2 = correspondenceItem.Item2;

                
                if (mergedCorrespondences.ContainsKey(recordId1))
                {

                    SortedSet<string> recordIdSortedSet = mergedCorrespondences[recordId1];

                    recordIdSortedSet.Add(recordId2);

                    mergedCorrespondences[recordId1] = recordIdSortedSet;
                    
                }
                else
                {

                    SortedSet<string> recordIdSortedSet = new SortedSet<string>();

                    recordIdSortedSet.Add(recordId2);

                    mergedCorrespondences.Add(recordId1, recordIdSortedSet);

                }

                
                if (mergedCorrespondences.ContainsKey(recordId2))
                {

                    SortedSet<string> recordIdSortedSet = mergedCorrespondences[recordId2];

                    recordIdSortedSet.Add(recordId1);

                    mergedCorrespondences[recordId2] = recordIdSortedSet;
                    
                }
                else
                {

                    SortedSet<string> recordIdSortedSet = new SortedSet<string>();

                    recordIdSortedSet.Add(recordId1);

                    mergedCorrespondences.Add(recordId2, recordIdSortedSet);

                }

            }

            return mergedCorrespondences;

        }

    
    }

}