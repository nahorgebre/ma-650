using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace IR_GS_Creation
{

    class DI4
    {

        //patent_abstract_dt.tsv

        public static void run()
        {

            (List<Goldstandard> trueList, List<Goldstandard> falseList) = getGoldStandardList(DI4Datasets.DI1_dt, DI4Datasets.patent_abstract_dt);

            (List<Goldstandard> trueList_train, List<Goldstandard> trueList_test) = divideIntoTrainTest(trueList);

            (List<Goldstandard> falseList_train, List<Goldstandard> falseList_test) = divideIntoTrainTest(falseList);

            List<Goldstandard> train = trueList_train.Concat(falseList_train).ToList();

            List<Goldstandard> test = trueList_test.Concat(falseList_test).ToList();

            createOutput(train, new FileInfo(Environment.CurrentDirectory + "/data/output/DI4/kaessmann_2_patentAbstract/train.csv"));

            createOutput(test, new FileInfo(Environment.CurrentDirectory + "/data/output/DI4/kaessmann_2_patentAbstract/test.csv"));

        }

        public static void createOutput(List<Goldstandard> list, FileInfo file)
        {

            file.Directory.Create();

            using (StreamWriter sw = new StreamWriter(file.FullName))
            {

                foreach (var item in list)
                {

                    sw.WriteLine(item.recordId1 + "," + item.recordId2 + "," + item.boolValue);
                    
                }
                
            }

        }

        public static (List<Goldstandard>, List<Goldstandard>) divideIntoTrainTest(List<Goldstandard> List)
        {

            int threshold = List.Count / 2;

            List<Goldstandard> list1 = new List<Goldstandard>();

            List<Goldstandard> list2 = new List<Goldstandard>();

            int counter = 0;

            foreach (var listItem in List)
            {

                if (counter < threshold)
                {

                    list1.Add(listItem);
                    
                }
                else
                {

                    list2.Add(listItem);

                }

                counter ++;
                
            }

            return (list1, list2);

        }

        public static (List<Goldstandard>, List<Goldstandard>) getGoldStandardList(FileInfo file1, FileInfo file2)
        {

            List<Goldstandard> gsListTrue = new List<Goldstandard>();

            List<Goldstandard> gsListFalse = new List<Goldstandard>();


            int gsFalseSize = 70;

            int gsTrueSize = 70;


            Dictionary<string, InputDataset> file1Dictionary = InputDataset.getDatasetDictionary(DI4Datasets.DI1_dt);

            Console.WriteLine("Dictionary size 1: " + file1Dictionary.Count());

            Dictionary<string, InputDataset> file2Dictionary = InputDataset.getDatasetDictionary(DI4Datasets.patent_abstract_dt);

            Console.WriteLine("Dictionary size 2:", file2Dictionary.Count());

            foreach (KeyValuePair<string, InputDataset> file1DictionaryItem in file1Dictionary)
            {

                foreach (KeyValuePair<string, InputDataset> file2DictionaryItem in file2Dictionary)
                {

                    if (check_gs_size(
                        gsListTrue: gsListTrue,
                        gsListFalse: gsListFalse,
                        gsTrueSize: gsTrueSize,
                        gsFalseSize: gsFalseSize
                    ))
                    {

                        string geneNameKey1 = getGeneNameBlockingKey(file1DictionaryItem.Value.geneNames);

                        string geneNameKey2 = getGeneNameBlockingKey(file2DictionaryItem.Value.geneNames);


                        if (geneNameKey1.Equals(geneNameKey2))
                        {

                            double geneNameSim = GeneNameSimilarity.getSimilarity(file1DictionaryItem.Value.geneNames, file2DictionaryItem.Value.geneNames);

                            bool trueFile = false;

                            bool falseFile = false;

                            double gsThreshold = 0.9;

                            if (geneNameSim == 1)
                            {

                                trueFile = true;

                            }
                            else if (geneNameSim < gsThreshold)
                            {

                                falseFile = true;

                            }

                            if (trueFile)
                            {

                                if (gsListTrue.Count() < gsTrueSize)
                                {

                                    if (!gsListTrue.Exists(x => x.recordId2 == file2DictionaryItem.Key) &
                                        !gsListTrue.Exists(x => x.recordId1 == file1DictionaryItem.Key))
                                    {



                                        Goldstandard goldstandardItem = new Goldstandard();

                                        goldstandardItem.recordId1 = file1DictionaryItem.Key;

                                        goldstandardItem.geneNames1 = file1DictionaryItem.Value.geneNames;

                                        goldstandardItem.recordId2 = file2DictionaryItem.Key;

                                        goldstandardItem.geneNames2 = file2DictionaryItem.Value.geneNames;

                                        goldstandardItem.boolValue = "TRUE";

                                        goldstandardItem.geneNamesSim = geneNameSim;

                                        goldstandardItem.geneNamesBlockingKey = geneNameKey1;

                                        gsListTrue.Add(goldstandardItem);

                                        Console.WriteLine("GS True #" + (gsListTrue.Count()).ToString() + " : GeneNames(" + goldstandardItem.geneNames1 + " - " + goldstandardItem.geneNames2 + " - Sim: " + geneNameSim + ")");

                                    }

                                }

                            }
                            else if (falseFile)
                            {

                                if (gsListFalse.Count() < gsFalseSize)
                                {

                                    if (!gsListFalse.Exists(x => x.recordId2 == file2DictionaryItem.Key) &
                                        !gsListFalse.Exists(x => x.recordId1 == file1DictionaryItem.Key))
                                    {

                                        Goldstandard goldstandardItem = new Goldstandard();

                                        goldstandardItem.recordId1 = file1DictionaryItem.Key;

                                        goldstandardItem.geneNames1 = file1DictionaryItem.Value.geneNames;

                                        goldstandardItem.recordId2 = file2DictionaryItem.Key;

                                        goldstandardItem.geneNames2 = file2DictionaryItem.Value.geneNames;

                                        goldstandardItem.boolValue = "FALSE";

                                        goldstandardItem.geneNamesSim = geneNameSim;

                                        goldstandardItem.geneNamesBlockingKey = geneNameKey1;

                                        gsListFalse.Add(goldstandardItem);

                                        Console.WriteLine("GS False #" + (gsListFalse.Count()).ToString() + " : GeneNames(" + goldstandardItem.geneNames1 + " - " + goldstandardItem.geneNames2 + " - Sim: " + goldstandardItem.geneNamesSim + ")");

                                    }

                                }

                            }

                            if (check_gs_sizeReturn(
                                gsListTrue: gsListTrue,
                                gsListFalse: gsListFalse,
                                gsTrueSize: gsTrueSize,
                                gsFalseSize: gsFalseSize
                            ))
                            {

                                return (gsListTrue, gsListFalse);

                            }

                        }

                    }
                    else
                    {

                        return (gsListTrue, gsListFalse);

                    }

                }

            }

            return (gsListTrue, gsListFalse);

        }

        public static bool check_gs_size(
            List<Goldstandard> gsListTrue,
            List<Goldstandard> gsListFalse,
            int gsTrueSize,
            int gsFalseSize
        )
        {

            return gsListTrue.Count() <= gsTrueSize &
                gsListFalse.Count() <= gsFalseSize;

        }

        public static bool check_gs_sizeReturn(
            List<Goldstandard> gsListTrue,
            List<Goldstandard> gsListFalse,
            int gsTrueSize,
            int gsFalseSize
        )
        {

            return gsListTrue.Count() >= gsTrueSize &
                gsListFalse.Count() >= gsFalseSize;

        }

        public static String getGeneNameBlockingKey(String geneNames)
        {

            string key = "default";

            String geneName = geneNames;

            if (geneNames.Contains("|"))
            {

                String[] geneNameArray = geneNames.Split("|");

                geneName = geneNameArray[0].ToLower();

                foreach (String geneNameItem in geneNameArray)
                {

                    if (geneNameItem.Count() < geneName.Count())
                    {

                        if (!geneNameItem.Trim().Equals(string.Empty))
                        {

                            geneName = geneNameItem.ToLower();

                        }

                    }

                }

            }

            geneName = Regex.Replace(geneName, @"\s+", String.Empty);

            int nameLength = geneName.Count();

            if (nameLength >= 3)
            {

                key = geneName.Substring(0, 2).Trim();

            }

            return key.ToLower();

        }

    }

}