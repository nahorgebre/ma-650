using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;


namespace IR_GS_Creation
{

    class Comparison_NcbiId_GeneNames2
    {

        public static (List<Goldstandard>, List<Goldstandard>, List<Goldstandard>, List<Goldstandard>) compare(FileInfo fileName1, FileInfo fileName2)
        {


            List<Goldstandard> gsListTrue = new List<Goldstandard>();

            List<Goldstandard> gsListTrueCornerCase = new List<Goldstandard>(); // very different records describe same entity

            List<Goldstandard> gsListFalse = new List<Goldstandard>();

            List<Goldstandard> gsListFalseCornerCase = new List<Goldstandard>(); // similiar records describe differents entities


            Random random = new Random();

            int gsFalseCornerSize = random.Next(15, 20);

            int gsTrueCornerSize = random.Next(5, 10);

            int gsFalseSize = 70 - gsFalseCornerSize;

            int gsTrueSize = 70 - gsTrueCornerSize;


            Dictionary<string, InputDataset> file1Dictionary = InputDataset.getDatasetDictionary(fileName1);

            Dictionary<string, InputDataset> file2Dictionary = InputDataset.getDatasetDictionary(fileName2);


            Console.WriteLine("test0");


            // True Cases
            foreach (KeyValuePair<string, InputDataset> file1DictionaryItem in file1Dictionary)
            {

                Console.WriteLine("test1");

                if (check_gs_True_size(gsListTrue: gsListTrue, gsListTrueCornerCase: gsListTrueCornerCase, gsTrueSize: gsTrueSize, gsTrueCornerSize: gsTrueCornerSize))
                {

                    Console.WriteLine("test2");

                    if (file2Dictionary.ContainsKey(file1DictionaryItem.Key))
                    {

                        InputDataset file2RecordItem = file2Dictionary[file1DictionaryItem.Key];

                        double geneNameSim = GeneNameSimilarity.getSimilarity(file1DictionaryItem.Value.geneNames, file2RecordItem.geneNames);

                        double gsThreshold = 0.9;

                        // True Corner
                        if (geneNameSim < gsThreshold)
                        {

                            Goldstandard goldstandardItem = new Goldstandard();

                            goldstandardItem.recordId1 = file1DictionaryItem.Key;

                            goldstandardItem.geneNames1 = file1DictionaryItem.Value.geneNames;


                            goldstandardItem.recordId2 = file2RecordItem.recordId;

                            goldstandardItem.geneNames2 = file2RecordItem.geneNames;


                            goldstandardItem.boolValue = "TRUE";

                            goldstandardItem.geneNamesSim = geneNameSim;


                            gsListTrueCornerCase.Add(goldstandardItem);

                            Console.WriteLine("True Corner: Name Sim = " + geneNameSim);

                            file1Dictionary.Remove(file1DictionaryItem.Key);

                            file2Dictionary.Remove(file1DictionaryItem.Key);

                        }

                        // True
                        if (geneNameSim == 1)
                        {

                            Goldstandard goldstandardItem = new Goldstandard();


                            goldstandardItem.recordId1 = file1DictionaryItem.Key;

                            goldstandardItem.geneNames1 = file1DictionaryItem.Value.geneNames;


                            goldstandardItem.recordId2 = file2RecordItem.recordId;

                            goldstandardItem.geneNames2 = file2RecordItem.geneNames;


                            goldstandardItem.boolValue = "TRUE";

                            goldstandardItem.geneNamesSim = geneNameSim;


                            gsListTrue.Add(goldstandardItem);

                            Console.WriteLine("True: Name Sim = " + geneNameSim);

                            file1Dictionary.Remove(file1DictionaryItem.Key);

                            file2Dictionary.Remove(file1DictionaryItem.Key);

                        }


                    }

                }

            }

            // False Cases
            foreach (KeyValuePair<string, InputDataset> file1DictionaryItem in file1Dictionary)
            {

                foreach (KeyValuePair<string, InputDataset> file2DictionaryItem in file2Dictionary)
                {

                    if (check_gs_size(gsListTrue: gsListTrue, gsListTrueCornerCase: gsListTrueCornerCase, gsListFalse: gsListFalse, gsListFalseCornerCase: gsListFalseCornerCase, gsTrueSize: gsTrueSize, gsTrueCornerSize: gsTrueCornerSize, gsFalseSize: gsFalseSize, gsFalseCornerSize: gsFalseCornerSize))
                    {

                        if (!file1DictionaryItem.Value.ncbiId.Equals(file2DictionaryItem.Value.ncbiId))
                        {

                            double gsThreshold = 0.9;

                            double geneNameSim = GeneNameSimilarity.getSimilarity(file1DictionaryItem.Value.geneNames, file2DictionaryItem.Value.geneNames);

                            // False Corner
                            if (geneNameSim > gsThreshold)
                            {

                                Goldstandard goldstandardItem = new Goldstandard();


                                goldstandardItem.recordId1 = file1DictionaryItem.Key;

                                goldstandardItem.geneNames1 = file1DictionaryItem.Value.geneNames;


                                goldstandardItem.recordId2 = file2DictionaryItem.Key;

                                goldstandardItem.geneNames2 = file2DictionaryItem.Value.geneNames;


                                goldstandardItem.boolValue = "FALSE";

                                goldstandardItem.geneNamesSim = geneNameSim;


                                gsListFalseCornerCase.Add(goldstandardItem);

                                Console.WriteLine("False Corner: Name Sim = " + geneNameSim);

                            }

                            // False
                            if (geneNameSim < gsThreshold)
                            {

                                Goldstandard goldstandardItem = new Goldstandard();


                                goldstandardItem.recordId1 = file1DictionaryItem.Key;

                                goldstandardItem.geneNames1 = file1DictionaryItem.Value.geneNames;


                                goldstandardItem.recordId2 = file2DictionaryItem.Key;

                                goldstandardItem.geneNames2 = file2DictionaryItem.Value.geneNames;


                                goldstandardItem.boolValue = "FALSE";

                                goldstandardItem.geneNamesSim = geneNameSim;


                                gsListFalse.Add(goldstandardItem);

                                Console.WriteLine("False: Name Sim = " + geneNameSim);

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

        public static bool check_gs_True_size(
            List<Goldstandard> gsListTrue,
            List<Goldstandard> gsListTrueCornerCase,
            int gsTrueSize,
            int gsTrueCornerSize
        )
        {

            return gsListTrue.Count() <= gsTrueSize &
                gsListTrueCornerCase.Count() <= gsTrueCornerSize;

        }

    }

}