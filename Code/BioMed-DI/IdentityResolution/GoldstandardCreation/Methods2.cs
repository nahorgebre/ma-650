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

        
        public static (List<Goldstandard>, List<Goldstandard>) compareFiles_NcbiId_GeneName(string fileName1, string fileName2)
        {

            // recordId - 0
            // ensemblId - 1
            // ncbiId - 2
            // geneName - 3

            // Corner cases
            // very different records describe same entity
            // similar records describe different entities

            int gsSize = 50;

            List<Goldstandard> gsListTrue = new List<Goldstandard>();
            List<Goldstandard> gsListTrueCornerCase = new List<Goldstandard>();
            
            List<Goldstandard> gsListFalse = new List<Goldstandard>();
            List<Goldstandard> gsListFalseCornerCase = new List<Goldstandard>();

            var delimiter = "\t";

            using (StreamReader sr1 = new StreamReader(fileName1))
            {

                sr1.ReadLine();

                while (!sr1.EndOfStream)
                {

                    var lineSr1 = sr1.ReadLine();

                    if (gsListTrue.Count() < gsSize)
                    {

                        String[] valuesSr1 = lineSr1.Split(delimiter);

                        string geneNameSr1 = valuesSr1[3].Trim();

                        string ncbiIdSr1 = valuesSr1[2].Trim();

                        string recordIdSr1 = valuesSr1[0];

                        using (StreamReader sr2 = new StreamReader(fileName2))
                        {

                            sr2.ReadLine();
                
                            while (!sr2.EndOfStream)
                            {
                                var lineSr2 = sr2.ReadLine();

                                String[] valuesSr2 = lineSr2.Split(delimiter);

                                string geneNameSr2 = valuesSr2[3].Trim();

                                string ncbiIdSr2 = valuesSr2[2].Trim();

                                string recordIdSr2 = valuesSr2[0];

                                string key1 = getGeneNameBlockingKey(geneNameSr1);

                                string key2 = getGeneNameBlockingKey(geneNameSr2);

                                if (key1.Equals(key2))
                                {

                                    double geneNameSim = getBestGeneNameSimilarity(geneNameSr1, geneNameSr2);

                                    var jw = new JaroWinkler();

                                    double ncbiIdSim = jw.Similarity(ncbiIdSr1, ncbiIdSr2);


                                    bool trueFile = false;

                                    bool falseFile = false;

                                    // 0.95
                                    if (geneNameSim == 1) trueFile = true;

                                    if (ncbiIdSim == 1) trueFile = true;

                                    // 0.95
                                    if (geneNameSim <= 0.9 & geneNameSim > 0.6) falseFile = true;


                                    if (trueFile)
                                    {

                                        if (!gsListTrue.Exists(x => x.recordId2 == recordIdSr2) & !gsListTrue.Exists(x => x.recordId1 == recordIdSr1))
                                        {

                                            Console.WriteLine("GS True #" + (gsListTrue.Count() + 1).ToString() + " : " + geneNameSr1 + " - " + geneNameSr2 + " - " + geneNameSim);

                                            Goldstandard goldstandardItem = new Goldstandard();
                                            goldstandardItem.recordId1 = recordIdSr1;
                                            goldstandardItem.value1 = geneNameSr1;
                                            goldstandardItem.recordId2 = recordIdSr2;
                                            goldstandardItem.value2 = geneNameSr2;
                                            goldstandardItem.boolValue = "TRUE";
                                            goldstandardItem.sim = geneNameSim;
                                            goldstandardItem.blockingKey = key1;

                                            gsListTrue.Add(goldstandardItem);

                                        }

                                    }
                                    else if (falseFile)
                                    {
                                    
                                        if (gsListFalse.Count() < gsSize)
                                        {
                                        
                                            if (!gsListFalse.Exists(x => x.recordId2 == recordIdSr2) & !gsListFalse.Exists(x => x.recordId1 == recordIdSr1))
                                            {
                               
                                                Console.WriteLine("GS False #" + (gsListFalse.Count() + 1).ToString() + " : " + geneNameSr1 + " - " + geneNameSr2 + " - " + geneNameSim);

                                                Goldstandard goldstandardItem = new Goldstandard();
                                                goldstandardItem.recordId1 = recordIdSr1;
                                                goldstandardItem.value1 = geneNameSr1;
                                                goldstandardItem.recordId2 = recordIdSr2;
                                                goldstandardItem.value2 = geneNameSr2;
                                                goldstandardItem.boolValue = "FALSE";
                                                goldstandardItem.sim = geneNameSim;
                                                goldstandardItem.blockingKey = key1;

                                                gsListFalse.Add(goldstandardItem);

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }
            
            }

            Console.WriteLine("GS-True-List Count: " + goldstandardListTrue.Count);
            Console.WriteLine("GS-False-List Count: " + gsListFalse.Count);
            
            return (goldstandardListTrue, gsListFalse);

        }



    }

}