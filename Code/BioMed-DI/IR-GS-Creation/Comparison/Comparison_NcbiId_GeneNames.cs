using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;


namespace IR_GS_Creation
{

    class Comparison_NcbiId_GeneNames
    {

        public static (List<Goldstandard>, List<Goldstandard>, List<Goldstandard>, List<Goldstandard>) compare(FileInfo fileName1, FileInfo fileName2)
        {


            List<Goldstandard> gsListTrue = new List<Goldstandard>();

            List<Goldstandard> gsListTrueCornerCase = new List<Goldstandard>(); // very different records describe same entity

            List<Goldstandard> gsListFalse = new List<Goldstandard>();

            List<Goldstandard> gsListFalseCornerCase = new List<Goldstandard>(); // similiar records describe differents entities


            Random random = new Random();

            int gsFalseCornerSize = random.Next(3, 5);

            int gsTrueCornerSize = random.Next(1, 2);

            int gsFalseSize = 30 - gsFalseCornerSize;

            int gsTrueSize = 30 - gsTrueCornerSize;


            Dictionary<string, InputDataset> file1Dictionary = InputDataset.getDatasetDictionary(fileName1);

            Dictionary<string, InputDataset> file2Dictionary = InputDataset.getDatasetDictionary(fileName2);



            foreach (KeyValuePair<string, InputDataset> file1DictionaryItem in file1Dictionary)
            {

                foreach (KeyValuePair<string, InputDataset> file2DictionaryItem in file2Dictionary)
                {

                    if (check_gs_size(
                        gsListTrue: gsListTrue,
                        gsListTrueCornerCase: gsListTrueCornerCase,
                        gsListFalse: gsListFalse,
                        gsListFalseCornerCase: gsListFalseCornerCase,
                        gsTrueSize: gsTrueSize,
                        gsTrueCornerSize: gsTrueCornerSize,
                        gsFalseSize: gsFalseSize,
                        gsFalseCornerSize: gsFalseCornerSize
                    ))
                    {

                        string geneNameKey1 = getGeneNameBlockingKey(file1DictionaryItem.Value.geneNames);

                        string geneNameKey2 = getGeneNameBlockingKey(file2DictionaryItem.Value.geneNames);


                        string ncbiIdKey1 = getNcbiIdBlockingKey(file1DictionaryItem.Value.ncbiId);

                        string ncbiIdKey2 = getNcbiIdBlockingKey(file2DictionaryItem.Value.ncbiId);


                        if (geneNameKey1.Equals(geneNameKey2))
                        {

                            double geneNameSim = GeneNameSimilarity.getSimilarity(file1DictionaryItem.Value.geneNames,
                                file2DictionaryItem.Value.geneNames);


                            bool trueFile = false;

                            bool trueCornerFile = false;

                            bool falseFile = false;

                            bool falseCornerFile = false;


                            double gsThreshold = 0.9;


                            if (geneNameSim == 1)
                            {

                                trueFile = true;

                            }
                            else if (geneNameSim < gsThreshold)
                            {

                                falseFile = true;

                            }


                            if (!file1DictionaryItem.Value.ncbiId.Equals("NV") &
                                !file2DictionaryItem.Value.ncbiId.Equals("NV"))
                            {

                                if (ncbiIdKey1.Equals(ncbiIdKey2))
                                {

                                    if (file1DictionaryItem.Value.ncbiId.Equals(file2DictionaryItem.Value.ncbiId))
                                    {

                                        if (geneNameSim < gsThreshold)
                                        {

                                            trueCornerFile = true;

                                            trueFile = false;

                                            falseFile = false;

                                        }

                                    }
                                    else if (!file1DictionaryItem.Value.ncbiId.Equals(file2DictionaryItem.Value.ncbiId))
                                    {

                                        if (geneNameSim > gsThreshold)
                                        {

                                            falseCornerFile = true;

                                            trueFile = false;

                                            falseFile = false;

                                        }

                                    }

                                }

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
                            else if (trueCornerFile)
                            {

                                if (gsListTrueCornerCase.Count() < gsTrueCornerSize)
                                {

                                    if (!gsListTrueCornerCase.Exists(x => x.recordId2 == file2DictionaryItem.Key) &
                                        !gsListTrueCornerCase.Exists(x => x.recordId1 == file1DictionaryItem.Key))
                                    {

                                        Goldstandard goldstandardItem = new Goldstandard();

                                        goldstandardItem.recordId1 = file1DictionaryItem.Key;

                                        goldstandardItem.geneNames1 = file1DictionaryItem.Value.geneNames;

                                        goldstandardItem.ncbiId1 = file1DictionaryItem.Value.ncbiId;


                                        goldstandardItem.recordId2 = file2DictionaryItem.Key;

                                        goldstandardItem.geneNames2 = file2DictionaryItem.Value.geneNames;

                                        goldstandardItem.ncbiId2 = file2DictionaryItem.Value.ncbiId;


                                        goldstandardItem.boolValue = "TRUE";

                                        goldstandardItem.geneNamesSim = geneNameSim;


                                        goldstandardItem.geneNamesBlockingKey = geneNameKey1;

                                        goldstandardItem.ncbiIdBlockingKey = ncbiIdKey1;


                                        gsListTrueCornerCase.Add(goldstandardItem);


                                        Console.WriteLine("GS Corner Case True #" + (gsListTrueCornerCase.Count()).ToString() + " : GeneNames(" + file1DictionaryItem.Value.geneNames + " - " + file1DictionaryItem.Value.geneNames + " - Sim: " + geneNameSim + ") - NCBIIDs(" + file1DictionaryItem.Value.ncbiId + " - " + file2DictionaryItem.Value.ncbiId + " Sim: " + goldstandardItem.ncbiIdSim + ")");

                                    }

                                }

                            }
                            else if (falseCornerFile)
                            {

                                if (gsListFalseCornerCase.Count() < gsFalseCornerSize)
                                {

                                    if (!gsListFalseCornerCase.Exists(x => x.recordId2 == file2DictionaryItem.Key) &
                                        !gsListFalseCornerCase.Exists(x => x.recordId1 == file1DictionaryItem.Key))
                                    {

                                        Goldstandard goldstandardItem = new Goldstandard();


                                        goldstandardItem.recordId1 = file1DictionaryItem.Key;

                                        goldstandardItem.geneNames1 = file1DictionaryItem.Value.geneNames;

                                        goldstandardItem.ncbiId1 = file1DictionaryItem.Value.ncbiId;


                                        goldstandardItem.recordId2 = file2DictionaryItem.Key;

                                        goldstandardItem.geneNames2 = file2DictionaryItem.Value.geneNames;

                                        goldstandardItem.ncbiId2 = file2DictionaryItem.Value.ncbiId;


                                        goldstandardItem.boolValue = "FALSE";


                                        goldstandardItem.geneNamesSim = geneNameSim;


                                        goldstandardItem.geneNamesBlockingKey = geneNameKey1;

                                        goldstandardItem.ncbiIdBlockingKey = ncbiIdKey1;


                                        gsListFalseCornerCase.Add(goldstandardItem);


                                        Console.WriteLine("GS Corner Case False #" + (gsListFalseCornerCase.Count()).ToString() + " : GeneNames(" + goldstandardItem.geneNames1 + " - " + goldstandardItem.geneNames2 + " - Sim: " + geneNameSim + ") - NCBIIDs(" + goldstandardItem.ncbiId1 + " - " + goldstandardItem.ncbiId2 + " Sim: " + goldstandardItem.ncbiIdSim + ")");

                                    }

                                }

                            }

                            if (check_gs_sizeReturn(
                                gsListTrue: gsListTrue,
                                gsListTrueCornerCase: gsListTrueCornerCase,
                                gsListFalse: gsListFalse,
                                gsListFalseCornerCase: gsListFalseCornerCase,
                                gsTrueSize: gsTrueSize,
                                gsTrueCornerSize: gsTrueCornerSize,
                                gsFalseSize: gsFalseSize,
                                gsFalseCornerSize: gsFalseCornerSize
                            ))
                            {

                                return (gsListTrue, gsListTrueCornerCase, gsListFalse, gsListFalseCornerCase);
                                
                            }

                        }

                    }
                    else
                    {

                        return (gsListTrue, gsListTrueCornerCase, gsListFalse, gsListFalseCornerCase);

                    }

                }

            }

            return (gsListTrue, gsListTrueCornerCase, gsListFalse, gsListFalseCornerCase);

        }


        public static bool check_gs_size(
            List<Goldstandard> gsListTrue,
            List<Goldstandard> gsListTrueCornerCase,
            List<Goldstandard> gsListFalse,
            List<Goldstandard> gsListFalseCornerCase,
            int gsTrueSize,
            int gsTrueCornerSize,
            int gsFalseSize,
            int gsFalseCornerSize
        )
        {

            return gsListTrue.Count() <= gsTrueSize &
                gsListTrueCornerCase.Count() <= gsTrueCornerSize &
                gsListFalse.Count() <= gsFalseSize &
                gsListFalseCornerCase.Count() <= gsFalseCornerSize;

        }

        public static bool check_gs_sizeReturn(
            List<Goldstandard> gsListTrue,
            List<Goldstandard> gsListTrueCornerCase,
            List<Goldstandard> gsListFalse,
            List<Goldstandard> gsListFalseCornerCase,
            int gsTrueSize,
            int gsTrueCornerSize,
            int gsFalseSize,
            int gsFalseCornerSize
        )
        {

            return gsListTrue.Count() >= gsTrueSize &
                gsListTrueCornerCase.Count() >= gsTrueCornerSize &
                gsListFalse.Count() >= gsFalseSize &
                gsListFalseCornerCase.Count() >= gsFalseCornerSize;

        }


        public static String getNcbiIdBlockingKey(String ncbiId)
        {

            string key = "default";

            if (ncbiId.Length >= 2)
            {

                key = ncbiId.Substring(0, 1);

            }

            return key;

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