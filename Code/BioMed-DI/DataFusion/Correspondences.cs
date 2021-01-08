using System;
using System.IO;
using System.Collections.Generic;

namespace DataFusion
{

    public class Correspondences
    {

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

        public static Dictionary<string, SortedSet<string>> getKeyDictionaryLeft(List<Tuple<string, string>> di3correspondences)
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

                    recordIdSortedSet.Add(recordId1);

                    recordIdSortedSet.Add(recordId2);

                    mergedCorrespondences.Add(recordId1, recordIdSortedSet);

                }

            }

            //Intermediate correspondences output

            FileInfo intermediateCorrespondences = new FileInfo(Environment.CurrentDirectory + "/data/correspondences/correspodences.csv");

            intermediateCorrespondences.Directory.Create();

            using (StreamWriter sw = new StreamWriter(intermediateCorrespondences.FullName))
            {

                foreach (KeyValuePair<string, SortedSet<string>> item in mergedCorrespondences)
                {

                    sw.WriteLine(item.Key + "," + String.Join("|", item.Value));
                
                }
                
            }

            return mergedCorrespondences;
            
        }

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