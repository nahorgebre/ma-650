using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using F23.StringSimilarity;

namespace GoldstandardCreation
{

    class Methods2
    {


        public static (List<Goldstandard>, List<Goldstandard>) compareFiles_EnsemblId(string fileName1, string fileName2)
        {

            // recordId - 0 // ensemblId - 1

            int gsSize = 50;

            List<Goldstandard> goldstandardListTrue = new List<Goldstandard>();
            List<Goldstandard> goldstandardListFalse = new List<Goldstandard>();

            var delimiter = "\t";

            using (StreamReader sr1 = new StreamReader(fileName1))
            {

                sr1.ReadLine();

                while (!sr1.EndOfStream)
                {

                    var lineSr1 = sr1.ReadLine();

                    String[] valuesSr1 = lineSr1.Split(delimiter);

                    string ensemblIdSr1 = valuesSr1[1].Trim();

                    string recordIdSr1 = valuesSr1[0];

                    using (StreamReader sr2 = new StreamReader(fileName2))
                    {

                        sr2.ReadLine();

                        while (!sr2.EndOfStream)
                        {
                            var lineSr2 = sr2.ReadLine();

                            String[] valuesSr2 = lineSr2.Split(delimiter);

                            string ensemblIdSr2 = valuesSr2[2].Trim();

                            string recordIdSr2 = valuesSr2[0];

                            string key1 = getEnsemblIdBlockingKey(ensemblIdSr1);

                            string key2 = getEnsemblIdBlockingKey(ensemblIdSr2);

                            if (key1.Equals(key2))
                            {

                                var jw = new JaroWinkler();

                                double ensemblIdSim = jw.Similarity(ensemblIdSr1, ensemblIdSr2);


                                bool trueFile = false;

                                bool falseFile = false;


                                if (ensemblIdSim == 1) trueFile = true;

                                if (ensemblIdSim < 1) falseFile = true;


                                if (trueFile)
                                {

                                    if (!goldstandardListTrue.Exists(x => x.recordId2 == recordIdSr2) & !goldstandardListTrue.Exists(x => x.recordId1 == recordIdSr1))
                                    {

                                        Console.WriteLine("GS True #" + (goldstandardListTrue.Count() + 1).ToString() + " : " + ensemblIdSr1 + " - " + ensemblIdSr2 + " - " + ensemblIdSim);

                                        Goldstandard goldstandardItem = new Goldstandard();
                                        goldstandardItem.recordId1 = recordIdSr1;
                                        goldstandardItem.value1 = ensemblIdSr1;
                                        goldstandardItem.recordId2 = recordIdSr2;
                                        goldstandardItem.value2 = ensemblIdSr2;
                                        goldstandardItem.boolValue = "TRUE";
                                        goldstandardItem.sim = ensemblIdSim;
                                        goldstandardItem.blockingKey = key1;

                                        goldstandardListTrue.Add(goldstandardItem);

                                    }

                                }
                                else if (falseFile)
                                {

                                    if (goldstandardListFalse.Count() < gsSize)
                                    {

                                        if (!goldstandardListFalse.Exists(x => x.recordId2 == recordIdSr2) & !goldstandardListFalse.Exists(x => x.recordId1 == recordIdSr1))
                                        {

                                            Console.WriteLine("GS False #" + (goldstandardListFalse.Count() + 1).ToString() + " : " + ensemblIdSr1 + " - " + ensemblIdSr2 + " - " + ensemblIdSim);

                                            Goldstandard goldstandardItem = new Goldstandard();
                                            goldstandardItem.recordId1 = recordIdSr1;
                                            goldstandardItem.value1 = ensemblIdSr1;
                                            goldstandardItem.recordId2 = recordIdSr2;
                                            goldstandardItem.value2 = ensemblIdSr2;
                                            goldstandardItem.boolValue = "FALSE";
                                            goldstandardItem.sim = ensemblIdSim;
                                            goldstandardItem.blockingKey = key1;

                                            goldstandardListFalse.Add(goldstandardItem);

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }

            Console.WriteLine("GS-True-List Count: " + goldstandardListTrue.Count);
            Console.WriteLine("GS-False-List Count: " + goldstandardListFalse.Count);

            return (goldstandardListTrue, goldstandardListFalse);

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


        public static (List<Goldstandard>, List<Goldstandard>, List<Goldstandard>, List<Goldstandard>) compareFiles_NcbiId_GeneName(string fileName1, string fileName2)
        {


            // recordId - 0 // ncbiId - 2 // geneName - 3


            int gsSize = 5;

            int gsCornerSize = 1;


            List<Goldstandard> gsListTrue = new List<Goldstandard>();

            List<Goldstandard> gsListTrueCornerCase = new List<Goldstandard>(); // very different records describe same entity

            List<Goldstandard> gsListFalse = new List<Goldstandard>();

            List<Goldstandard> gsListFalseCornerCase = new List<Goldstandard>(); // similiar records describe differents entities


            bool iterationCheck = gsListTrue.Count() < gsSize | 
                gsListTrueCornerCase.Count() < gsCornerSize |
                gsListFalse.Count() < gsSize |
                gsListFalseCornerCase.Count() < gsCornerSize;


            var delimiter = "\t";

            using (StreamReader sr1 = new StreamReader(fileName1))
            {

                sr1.ReadLine();

                while (!sr1.EndOfStream)
                {

                    using (StreamReader sr2 = new StreamReader(fileName2))
                    {

                        sr2.ReadLine();

                        while (!sr2.EndOfStream)
                        {                            


                            if (iterationCheck)
                            {


                                var lineSr1 = sr1.ReadLine();

                                String[] valuesSr1 = lineSr1.Split(delimiter);

                                string geneNameSr1 = valuesSr1[3].Trim();

                                string ncbiIdSr1 = valuesSr1[2].Trim();

                                string recordIdSr1 = valuesSr1[0];




                                var lineSr2 = sr2.ReadLine();

                                String[] valuesSr2 = lineSr2.Split(delimiter);

                                string geneNameSr2 = valuesSr2[3].Trim();

                                string ncbiIdSr2 = valuesSr2[2].Trim();

                                string recordIdSr2 = valuesSr2[0];




                                string geneNameKey1 = getGeneNameBlockingKey(geneNameSr1);

                                string geneNameKey2 = getGeneNameBlockingKey(geneNameSr2);


                                string ncbiIdKey1 = getNcbiIdBlockingKey(ncbiIdSr1);

                                string ncbiIdKey2 = getNcbiIdBlockingKey(ncbiIdSr2);


                                if (geneNameKey1.Equals(geneNameKey2))
                                {

                                    double geneNameSim = getBestGeneNameSimilarity(geneNameSr1, geneNameSr2);

                                    double ncbiIdSim = 0;


                                    bool trueFile = false;

                                    bool trueCornerFile = false;

                                    bool falseFile = false;

                                    bool falseCornerFile = false;


                                    double gsThreshold = 0.9;



                                    if (ncbiIdSr1.Equals("NaN") | ncbiIdSr2.Equals("NaN"))
                                    {


                                        if (geneNameSim == 1)
                                        {

                                            trueFile = true;


                                        }

                                        if (geneNameSim < gsThreshold)
                                        {


                                            falseFile = true;

                                        }

                                    }



                                    if (!ncbiIdSr1.Equals("NaN") & !ncbiIdSr2.Equals("NaN"))
                                    {


                                        var jw = new JaroWinkler();

                                        ncbiIdSim = jw.Similarity(ncbiIdSr1, ncbiIdSr2);

                                        if (ncbiIdKey1.Equals(ncbiIdKey2))
                                        {


                                            if (ncbiIdSim == 1)
                                            {

                                                trueCornerFile = true;

                                            }

                                        }

                                        if (ncbiIdSim >= 0.85)
                                        {


                                            trueCornerFile = true;

                                        }

                                        if (geneNameSim >= gsThreshold & geneNameSim < 1 & ncbiIdSim < 1)
                                        {

                                            falseCornerFile = true;

                                        }

                                    }

                                    if (trueFile)
                                    {

                                        if (gsListTrue.Count() < gsSize)
                                        {

                                            if (!gsListTrue.Exists(x => x.recordId2 == recordIdSr2) & !gsListTrue.Exists(x => x.recordId1 == recordIdSr1))
                                            {

                                                Console.WriteLine("GS True #" + (gsListTrue.Count() + 1).ToString() + " : GeneNames(" + geneNameSr1 + " - " + geneNameSr2 + " - Sim: " + geneNameSim + ") - NCBIIDs(" + ncbiIdSr1 + " - " + ncbiIdSr2 + " Sim: " + ncbiIdSim + ")");

                                                Goldstandard goldstandardItem = new Goldstandard();
                                                goldstandardItem.recordId1 = recordIdSr1;
                                                goldstandardItem.value1 = geneNameSr1;
                                                goldstandardItem.recordId2 = recordIdSr2;
                                                goldstandardItem.value2 = geneNameSr2;
                                                goldstandardItem.boolValue = "TRUE";
                                                goldstandardItem.sim = geneNameSim;
                                                goldstandardItem.blockingKey = geneNameKey1;

                                                gsListTrue.Add(goldstandardItem);


                                            }

                                        }

                                    }
                                    else if (trueCornerFile)
                                    {


                                        if (gsListTrueCornerCase.Count() < gsCornerSize)
                                        {


                                            if (!gsListTrueCornerCase.Exists(x => x.recordId2 == recordIdSr2) & !gsListTrueCornerCase.Exists(x => x.recordId1 == recordIdSr1))
                                            {


                                                Console.WriteLine("GS Corner Case True #" + (gsListTrueCornerCase.Count() + 1).ToString() + " : GeneNames(" + geneNameSr1 + " - " + geneNameSr2 + " - Sim: " + geneNameSim + ") - NCBIIDs(" + ncbiIdSr1 + " - " + ncbiIdSr2 + " Sim: " + ncbiIdSim + ")");

                                                Goldstandard goldstandardItem = new Goldstandard();
                                                goldstandardItem.recordId1 = recordIdSr1;
                                                goldstandardItem.value1 = geneNameSr1;
                                                goldstandardItem.recordId2 = recordIdSr2;
                                                goldstandardItem.value2 = geneNameSr2;
                                                goldstandardItem.boolValue = "TRUE";
                                                goldstandardItem.sim = geneNameSim;
                                                goldstandardItem.blockingKey = geneNameKey1;

                                                gsListTrueCornerCase.Add(goldstandardItem);

                                            }

                                        }

                                    }
                                    else if (falseFile)
                                    {



                                        if (gsListFalse.Count() < gsSize)
                                        {


                                            if (!gsListFalse.Exists(x => x.recordId2 == recordIdSr2) & !gsListFalse.Exists(x => x.recordId1 == recordIdSr1))
                                            {


                                                Console.WriteLine("GS False #" + (gsListFalse.Count() + 1).ToString() + " : GeneNames(" + geneNameSr1 + " - " + geneNameSr2 + " - Sim: " + geneNameSim + ") - NCBIIDs(" + ncbiIdSr1 + " - " + ncbiIdSr2 + " Sim: " + ncbiIdSim + ")");

                                                Goldstandard goldstandardItem = new Goldstandard();
                                                goldstandardItem.recordId1 = recordIdSr1;
                                                goldstandardItem.value1 = geneNameSr1;
                                                goldstandardItem.recordId2 = recordIdSr2;
                                                goldstandardItem.value2 = geneNameSr2;
                                                goldstandardItem.boolValue = "FALSE";
                                                goldstandardItem.sim = geneNameSim;
                                                goldstandardItem.blockingKey = geneNameKey1;

                                                gsListFalse.Add(goldstandardItem);

                                            }

                                        }

                                    }
                                    else if (falseCornerFile)
                                    {



                                        if (gsListFalseCornerCase.Count() < gsCornerSize)
                                        {



                                            if (!gsListFalseCornerCase.Exists(x => x.recordId2 == recordIdSr2) & !gsListFalseCornerCase.Exists(x => x.recordId1 == recordIdSr1))
                                            {


                                                Console.WriteLine("GS Corner Case False #" + (gsListFalseCornerCase.Count() + 1).ToString() + " : GeneNames(" + geneNameSr1 + " - " + geneNameSr2 + " - Sim: " + geneNameSim + ") - NCBIIDs(" + ncbiIdSr1 + " - " + ncbiIdSr2 + " Sim: " + ncbiIdSim + ")");

                                                Goldstandard goldstandardItem = new Goldstandard();
                                                goldstandardItem.recordId1 = recordIdSr1;
                                                goldstandardItem.value1 = geneNameSr1;
                                                goldstandardItem.recordId2 = recordIdSr2;
                                                goldstandardItem.value2 = geneNameSr2;
                                                goldstandardItem.boolValue = "FALSE";
                                                goldstandardItem.sim = geneNameSim;
                                                goldstandardItem.blockingKey = geneNameKey1;

                                                gsListFalseCornerCase.Add(goldstandardItem);

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


            Console.WriteLine("GS True Count: " + gsListTrue.Count);

            Console.WriteLine("GS Corner Case True Count: " + gsListTrue.Count);

            Console.WriteLine("GS False Count: " + gsListFalse.Count);

            Console.WriteLine("GS False Count: " + gsListFalse.Count);


            return (gsListTrue, gsListTrueCornerCase, gsListFalse, gsListFalseCornerCase);

        }


        public static double getBestGeneNameSimilarity(String geneNameSr1, String geneNameSr2)
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