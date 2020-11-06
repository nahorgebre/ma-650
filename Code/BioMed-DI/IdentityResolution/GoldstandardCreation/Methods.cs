using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using F23.StringSimilarity;

namespace GoldstandardCreation
{

    class Methods
    {

        public static (List<Goldstandard>, List<Goldstandard>) compareFiles(string fileName1, string fileName2, int index)
        {
            // ensemblId -> 1
            // geneName -> 3
            // pmId -> 4

            List<Goldstandard> goldstandardListTrue = new List<Goldstandard>();
            List<Goldstandard> goldstandardListFalse = new List<Goldstandard>();

            var delimiter = "\t";

            using (StreamReader sr1 = new StreamReader(fileName1))
            {

                sr1.ReadLine();
                while (!sr1.EndOfStream)
                {

                    // go through all lines
                    var lineSr1 = sr1.ReadLine();
                    if (goldstandardListTrue.Count() < 200)
                    {

                        String[] valuesSr1 = lineSr1.Split(delimiter);
                        string compareValueSr1 = valuesSr1[index].Trim();
                        string recordIdSr1 = valuesSr1[0];

                        using (StreamReader sr2 = new StreamReader(fileName2))
                        {

                            sr2.ReadLine();
                            // Reducing number of comparisons -- while (!sr2.EndOfStream) -- for (int j = 0; j < 100000; j++)              
                            while (!sr2.EndOfStream)
                            {
                                var lineSr2 = sr2.ReadLine();

                                String[] valuesSr2 = lineSr2.Split(delimiter);
                                string compareValueSr2 = valuesSr2[index].Trim();
                                string recordIdSr2 = valuesSr2[0];

                                // calculate similarity
                                var jw = new JaroWinkler();
                                double sim = jw.Similarity(compareValueSr1, compareValueSr2);

                                if (sim > 0.95)
                                {

                                    Goldstandard goldstandardItem = new Goldstandard();
                                    goldstandardItem.recordId1 = recordIdSr1;
                                    goldstandardItem.value1 = compareValueSr1;
                                    goldstandardItem.recordId2 = recordIdSr2;
                                    goldstandardItem.value2 = compareValueSr2;
                                    goldstandardItem.boolValue = "TRUE";
                                    goldstandardItem.sim = sim;

                                    goldstandardListTrue.Add(goldstandardItem);

                                }
                                else if (sim <= 0.95 & sim > 0.7)
                                {
                                    
                                    if (goldstandardListFalse.Count() < 200)
                                    {
                                        
                                        if (!goldstandardListFalse.Exists(x => x.recordId2 == recordIdSr2) & !goldstandardListFalse.Exists(x => x.recordId1 == recordIdSr1))
                                        {

                                            Goldstandard goldstandardItem = new Goldstandard();
                                            goldstandardItem.recordId1 = recordIdSr1;
                                            goldstandardItem.value1 = compareValueSr1;
                                            goldstandardItem.recordId2 = recordIdSr2;
                                            goldstandardItem.value2 = compareValueSr2;
                                            goldstandardItem.boolValue = "FALSE";
                                            goldstandardItem.sim = sim;

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

        public static void createOuput(string fileName, List<Goldstandard> goldstandardList)
        {

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (Goldstandard item in goldstandardList)
                {

                    var delimiter = "\t";
                    List<string> lineContent = new List<string>()
                    {
                        item.recordId1,
                        item.value1,
                        item.recordId2,
                        item.value2,
                        item.boolValue,
                        item.sim.ToString()
                    };
                    var line = string.Join(delimiter, lineContent);
                    sw.WriteLine(line);

                }

            }

        }

    }

}