using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace DataFusion2
{

    public class Correspondences
    {

        public static HashSet<string> getRecordIdHashSet(Dictionary<string, HashSet<string>> keyDictionary)
        {

            HashSet<string> recordIdDictionary = new HashSet<string>();

            foreach (KeyValuePair<string, HashSet<string>> keyDictionaryItem in keyDictionary)
            {

                foreach (string hashSetItem in keyDictionaryItem.Value)
                {

                    recordIdDictionary.Add(hashSetItem);
                    
                }
                
            }

            return recordIdDictionary;

        }

        public static Dictionary<string, HashSet<string>> getKeyDictionary(FileInfo di1KeyDictionary, List<Tuple<string, string>> di1correspondences)
        {

            Dictionary<string, HashSet<string>> keyDictionary = new Dictionary<string, HashSet<string>>();

            if (!di1KeyDictionary.Exists)
            {

                keyDictionary = createKeyDictionary2(di1correspondences);

                using (StreamWriter sw = new StreamWriter(di1KeyDictionary.FullName))
                {

                    foreach (KeyValuePair<string, HashSet<string>> item in keyDictionary)
                    {

                        sw.WriteLine(item.Key + "," + string.Join('|', item.Value));

                    }

                }

            }
            else
            {

                using (StreamReader sr = new StreamReader(di1KeyDictionary.FullName))
                {

                    while (!sr.EndOfStream)
                    {

                        var line = sr.ReadLine();

                        string[] values = line.Split(',');

                        keyDictionary.Add(values[0], values[1].Split('|').ToHashSet());

                    }

                }

            }

            Console.WriteLine("Key dictionary size: " + keyDictionary.Count);

            return keyDictionary;

        }

        
        public static Dictionary<string, HashSet<string>> createKeyDictionary2(List<Tuple<string, string>> di1correspondences) {

            Dictionary<string, SortedSet<string>> mergedCorrespondences = new Dictionary<string, SortedSet<string>>();

            foreach (Tuple<string, string> correspondenceItem in di1correspondences)
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


            HashSet<string> mergedRecordIdHashSet = new HashSet<string>();

            foreach (KeyValuePair<string, SortedSet<string>> mergedCorrespondencesItem in mergedCorrespondences)
            {
                  
                mergedRecordIdHashSet.Add(string.Join('+', mergedCorrespondencesItem.Value));

            }


            Dictionary<string, HashSet<string>> keyDictionaryString = new Dictionary<string, HashSet<string>>();

            foreach (string mergedRecordId in mergedRecordIdHashSet)
            {

                HashSet<string> newMergedRecordIdHashSet = mergedRecordId.Split('+').ToHashSet();

                keyDictionaryString.Add(mergedRecordId, newMergedRecordIdHashSet);
                
            }

            return keyDictionaryString;

        }

        public static Dictionary<string, HashSet<string>> createKeyDictionary(List<Tuple<string, string>> correspondences)
        {

            List<HashSet<string>> mergedCorrespondences = new List<HashSet<string>>();

            foreach (Tuple<string, string> correspondenceItem in correspondences)
            {

                string recordId1 = correspondenceItem.Item1;

                (bool record1status, int record1position) = checkCorrespondence(recordId1, mergedCorrespondences);

                string recordId2 = correspondenceItem.Item2;

                (bool record2status, int record2position) = checkCorrespondence(recordId2, mergedCorrespondences);

                if (record1status == false & record2status == false)
                {

                    mergedCorrespondences.Add(new HashSet<string> { recordId1, recordId2 });

                }

                if (record1status == true & record2status == false)
                {

                    HashSet<string> correspondenceList = mergedCorrespondences[record1position];

                    correspondenceList.Add(recordId2);

                    mergedCorrespondences[record1position] = correspondenceList;

                }

                if (record1status == false & record2status == true)
                {

                    HashSet<string> correspondenceList = mergedCorrespondences[record2position];

                    correspondenceList.Add(recordId1);

                    mergedCorrespondences[record2position] = correspondenceList;

                }

            }

            Dictionary<string, HashSet<string>> keyDictionaryString = new Dictionary<string, HashSet<string>>();

            foreach (HashSet<string> correspondenceList in mergedCorrespondences)
            {

                string newRecordId = string.Join('+', correspondenceList);

                keyDictionaryString.Add(newRecordId, correspondenceList);

            }

            return keyDictionaryString;

        }

        public static (bool status, int value) checkCorrespondence(string recordId, List<HashSet<string>> mergedCorrespondences)
        {

            for (int i = 0; i < mergedCorrespondences.Count; i++)
            {

                HashSet<string> correspondenceList = mergedCorrespondences[i];

                foreach (string correspondence in correspondenceList)
                {

                    if (correspondence.Equals(recordId))
                    {

                        return (true, i);

                    }

                }

            }

            return (false, 0);

        }


    }

}