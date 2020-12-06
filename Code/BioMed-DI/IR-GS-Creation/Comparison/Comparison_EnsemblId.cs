using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using F23.StringSimilarity;


namespace IR_GS_Creation
{

    class Comparison_EnsemblId
    {

        public static bool check_gs_size(
            List<Goldstandard> goldstandardListTrueClose,
            List<Goldstandard> goldstandardListTrueFar,
            List<Goldstandard> goldstandardListFalseClose,
            List<Goldstandard> goldstandardListFalseFar,
            int gsSizeTrueClose,
            int gsSizeTrueFar,
            int gsSizeFalseClose,
            int gsSizeFalseFar
        )
        {

            return goldstandardListTrueClose.Count() <= gsSizeTrueClose &
                goldstandardListTrueFar.Count() <= gsSizeTrueFar &
                goldstandardListFalseClose.Count() <= gsSizeFalseClose &
                goldstandardListFalseFar.Count() <= gsSizeFalseFar;

        }

        public static bool check_gs_sizeReturn(
            List<Goldstandard> goldstandardListTrueClose,
            List<Goldstandard> goldstandardListTrueFar,
            List<Goldstandard> goldstandardListFalseClose,
            List<Goldstandard> goldstandardListFalseFar,
            int gsSizeTrueClose,
            int gsSizeTrueFar,
            int gsSizeFalseClose,
            int gsSizeFalseFar
        )
        {

            return goldstandardListTrueClose.Count() >= gsSizeTrueClose &
                goldstandardListTrueFar.Count() >= gsSizeTrueFar &
                goldstandardListFalseClose.Count() >= gsSizeFalseClose &
                goldstandardListFalseFar.Count() >= gsSizeFalseFar;

        }

        public static String getEnsemblIdBlockingKey(String ensemblId)
        {

            String key = "default";

            int beginIndex = ensemblId.Count() - 2;

            int endIndex = ensemblId.Count() - 1;

            int length = endIndex - beginIndex;

            key = ensemblId.Substring(beginIndex, length);

            return key;

        }

        public static (List<Goldstandard>, List<Goldstandard>, List<Goldstandard>, List<Goldstandard>) compare(FileInfo file1, FileInfo file2)
        {

            Random random = new Random();

            int gsSizeTrueFar = random.Next(2,5);

            int gsSizeFalseFar = random.Next(2,5);

            int gsSizeTrueClose = 50 - gsSizeTrueFar;

            int gsSizeFalseClose = 50 - gsSizeFalseFar;

            
            List<Goldstandard> goldstandardListTrueClose = new List<Goldstandard>();

            List<Goldstandard> goldstandardListTrueFar = new List<Goldstandard>();


            List<Goldstandard> goldstandardListFalseClose = new List<Goldstandard>();

            List<Goldstandard> goldstandardListFalseFar = new List<Goldstandard>();


            Dictionary<string, InputDataset> file1Dictionary = InputDataset.getDatasetDictionary(file1);

            Dictionary<string, InputDataset> file2Dictionary = InputDataset.getDatasetDictionary(file2);


            foreach (KeyValuePair<string, InputDataset> file1DictionaryItem in file1Dictionary)
            {

                foreach (KeyValuePair<string, InputDataset> file2DictionaryItem in file2Dictionary)
                {

                    if (check_gs_size(
                        goldstandardListTrueClose: goldstandardListTrueClose,
                        goldstandardListTrueFar: goldstandardListTrueFar,
                        goldstandardListFalseClose: goldstandardListFalseClose,
                        goldstandardListFalseFar,
                        gsSizeTrueClose: gsSizeTrueClose,
                        gsSizeTrueFar: gsSizeTrueFar,
                        gsSizeFalseClose: gsSizeFalseClose,
                        gsSizeFalseFar: gsSizeFalseFar
                    ))
                    {

                        string key1 = getEnsemblIdBlockingKey(file1DictionaryItem.Value.ensemblId);

                        string key2 = getEnsemblIdBlockingKey(file2DictionaryItem.Value.ensemblId);


                        if (key1.Equals(key2))
                        {

                            var jw = new JaroWinkler();

                            double sim = jw.Similarity(file1DictionaryItem.Value.ensemblId, file2DictionaryItem.Value.ensemblId);


                            bool trueFileClose = false;

                            bool trueFileFar = false;

                            bool falseFileClose = false;

                            bool falseFileFar = false;


                            if (sim == 1) trueFileClose = true;

                            if (sim >= 0.99 & sim < 1) trueFileFar = true;

                            if (sim < 0.99) falseFileClose = true;

                            if (sim == 0) falseFileFar = true;


                            if (trueFileClose)
                            {

                                if (goldstandardListTrueClose.Count() < gsSizeTrueClose)
                                {

                                    if (!goldstandardListTrueClose.Exists(x => x.recordId2 == file2DictionaryItem.Key) & !goldstandardListTrueClose.Exists(x => x.recordId1 == file1DictionaryItem.Key))
                                    {

                                        Goldstandard goldstandardItem = new Goldstandard();

                                        goldstandardItem.recordId1 = file1DictionaryItem.Key;

                                        goldstandardItem.ensemblId1 = file1DictionaryItem.Value.ensemblId;

                                        goldstandardItem.recordId2 = file2DictionaryItem.Key;

                                        goldstandardItem.ensemblId2 = file2DictionaryItem.Value.ensemblId;

                                        goldstandardItem.boolValue = "TRUE";

                                        goldstandardItem.ensemblIdSim = sim;

                                        goldstandardItem.ensemblIdBlockingKey = key1;

                                        goldstandardListTrueClose.Add(goldstandardItem);

                                        Console.WriteLine("Goldstandard True Close #" + goldstandardListTrueClose.Count() + " : " + goldstandardItem.ensemblId1 + " - " + goldstandardItem.ensemblId2 + " - " + sim);

                                    }

                                }

                            }
                            else if (trueFileFar)
                            {

                                if (goldstandardListTrueFar.Count() < gsSizeTrueFar)
                                {

                                    if (!goldstandardListTrueFar.Exists(x => x.recordId2 == file2DictionaryItem.Key) & !goldstandardListTrueFar.Exists(x => x.recordId1 == file1DictionaryItem.Key))
                                    {

                                        Goldstandard goldstandardItem = new Goldstandard();

                                        goldstandardItem.recordId1 = file1DictionaryItem.Key;

                                        goldstandardItem.ensemblId1 = file1DictionaryItem.Value.ensemblId;

                                        goldstandardItem.recordId2 = file2DictionaryItem.Key;

                                        goldstandardItem.ensemblId2 = file2DictionaryItem.Value.ensemblId;

                                        goldstandardItem.boolValue = "TRUE";

                                        goldstandardItem.ensemblIdSim = sim;

                                        goldstandardItem.ensemblIdBlockingKey = key1;

                                        goldstandardListTrueFar.Add(goldstandardItem);

                                        Console.WriteLine("Goldstandard True Far #" + goldstandardListTrueFar.Count() + " : " + goldstandardItem.ensemblId1 + " - " + goldstandardItem.ensemblId2 + " - " + sim);

                                    }

                                }

                            }
                            else if (falseFileClose)
                            {

                                if (goldstandardListFalseClose.Count() < gsSizeFalseClose)
                                {

                                    if (!goldstandardListFalseClose.Exists(x => x.recordId2 == file2DictionaryItem.Key) & !goldstandardListFalseClose.Exists(x => x.recordId1 == file1DictionaryItem.Key))
                                    {


                                        Goldstandard goldstandardItem = new Goldstandard();

                                        goldstandardItem.recordId1 = file1DictionaryItem.Key;

                                        goldstandardItem.ensemblId1 = file1DictionaryItem.Value.ensemblId;

                                        goldstandardItem.recordId2 = file2DictionaryItem.Key;

                                        goldstandardItem.ensemblId2 = file2DictionaryItem.Value.ensemblId;

                                        goldstandardItem.boolValue = "FALSE";

                                        goldstandardItem.ensemblIdSim = sim;

                                        goldstandardItem.ensemblIdBlockingKey = key1;

                                        goldstandardListFalseClose.Add(goldstandardItem);

                                        Console.WriteLine("Goldstandard False Close #" + goldstandardListFalseClose.Count() + " : " + goldstandardItem.ensemblId1 + " - " + goldstandardItem.recordId2 + " - " + sim);

                                    }

                                }

                            }
                            else if (falseFileFar)
                            {

                                if (goldstandardListFalseFar.Count() < gsSizeFalseFar)
                                {

                                    if (!goldstandardListFalseFar.Exists(x => x.recordId2 == file2DictionaryItem.Key) & !goldstandardListFalseFar.Exists(x => x.recordId1 == file1DictionaryItem.Key))
                                    {

                                        Goldstandard goldstandardItem = new Goldstandard();

                                        goldstandardItem.recordId1 = file1DictionaryItem.Key;

                                        goldstandardItem.ensemblId1 = file1DictionaryItem.Value.ensemblId;

                                        goldstandardItem.recordId2 = file2DictionaryItem.Key;

                                        goldstandardItem.ensemblId2 = file2DictionaryItem.Value.ensemblId;

                                        goldstandardItem.boolValue = "FALSE";

                                        goldstandardItem.ensemblIdSim = sim;

                                        goldstandardItem.ensemblIdBlockingKey = key1;

                                        goldstandardListFalseFar.Add(goldstandardItem);

                                        Console.WriteLine("Goldstandard False Far #" + goldstandardListFalseFar.Count() + " : " + goldstandardItem.ensemblId1 + " - " + goldstandardItem.ensemblId2 + " - " + sim);

                                    }

                                }

                            }


                            if (check_gs_sizeReturn(
                                goldstandardListTrueClose: goldstandardListTrueClose,
                                goldstandardListTrueFar: goldstandardListTrueFar,
                                goldstandardListFalseClose: goldstandardListFalseClose,
                                goldstandardListFalseFar,
                                gsSizeTrueClose: gsSizeTrueClose,
                                gsSizeTrueFar: gsSizeTrueFar,
                                gsSizeFalseClose: gsSizeFalseClose,
                                gsSizeFalseFar: gsSizeFalseFar
                            ))
                            {

                                return (goldstandardListTrueClose, goldstandardListTrueFar, goldstandardListFalseClose, goldstandardListFalseFar);
                                
                            }

                        }

                    }
                    else
                    {

                        return (goldstandardListTrueClose, goldstandardListTrueFar, goldstandardListFalseClose, goldstandardListFalseFar);

                    }

                }

            }

            return (goldstandardListTrueClose, goldstandardListTrueFar, goldstandardListFalseClose, goldstandardListFalseFar);

        }

    }

}