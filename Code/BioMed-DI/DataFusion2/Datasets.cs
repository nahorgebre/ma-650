using System;
using System.Collections.Generic;

namespace DataFusion2
{

    public class Datasets
    {

        public static HashSet<string> getRecordIdHashSet(Dictionary<string, SortedSet<string>> mergedCorrespondences)
        {

            HashSet<string> recordIdHashSet = new HashSet<string>();

            foreach (KeyValuePair<string, SortedSet<string>> correspondenceItem in mergedCorrespondences)
            {

                recordIdHashSet.Add(correspondenceItem.Key);

                foreach (string sortedSetItem in correspondenceItem.Value)
                {

                    recordIdHashSet.Add(sortedSetItem);
                    
                }
                
            }

            return recordIdHashSet;

        }

    }

}