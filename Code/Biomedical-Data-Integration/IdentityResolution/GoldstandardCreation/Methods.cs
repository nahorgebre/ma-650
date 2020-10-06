using System;
using System.Collections.Generic;
using System.IO;

namespace GoldstandardCreation
{
    class Methods
    {

        public static List<Goldstandard> compareGeneNameLargeFiles(String fileName1, String fileName2) {

            List<Goldstandard> goldstandardList = new List<Goldstandard>();

            try
            {
                var delimiter = "\t";

                using (StreamReader sr1 = new StreamReader(fileName1))
                {
                    while (!sr1.EndOfStream)
                    {
                        var lineSr1 = sr1.ReadLine();

                        String[] valuesSr1 = lineSr1.Split(delimiter);
                        string geneNameSr1 = valuesSr1[3].Trim();
                        string recordIdSr1 = valuesSr1[0];

                        using (StreamReader sr2 = new StreamReader(fileName2))
                        {
                            for (int i = 0; i < 100000; i++)
                            {
                                var lineSr2 = sr2.ReadLine();

                                if (!lineSr2.Equals(string.Empty))
                                {
                                    String[] valuesSr2 = lineSr2.Split(delimiter);
                                    string geneNameSr2 = valuesSr2[3].Trim();
                                    string recordIdSr2 = valuesSr2[0];

                                    if (geneNameSr1.Equals(geneNameSr2))
                                    {
                                        Goldstandard goldstandardItem = new Goldstandard();
                                        goldstandardItem.recordId1 = recordIdSr1;
                                        goldstandardItem.recordId2 = recordIdSr2;
                                        goldstandardItem.value = "TRUE";

                                        goldstandardList.Add(goldstandardItem);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
            }

            return goldstandardList;
        }

        public static void compareGeneName() {

        }
    }
}