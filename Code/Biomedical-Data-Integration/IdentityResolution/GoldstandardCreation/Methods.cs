using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GoldstandardCreation
{
    class Methods
    {

        public static List<Goldstandard> compareGeneNameLargeFiles(String fileName1, String fileName2) {

            List<Goldstandard> goldstandardListTrue = new List<Goldstandard>();
            List<Goldstandard> goldstandardListFalse = new List<Goldstandard>();

            try
            {
                var delimiter = "\t";

                using (StreamReader sr1 = new StreamReader(fileName1))
                {
                    while (!sr1.EndOfStream)
                    {
                        var lineSr1 = sr1.ReadLine();
                        if (!lineSr1.Equals(string.Empty))
                        {
                            if (goldstandardListTrue.Count < 200)
                            {
                                
                            }
                            String[] valuesSr1 = lineSr1.Split(delimiter);
                            string geneNameSr1 = valuesSr1[3].Trim();
                            string recordIdSr1 = valuesSr1[0];

                            using (StreamReader sr2 = new StreamReader(fileName2))
                            {
                                for (int j = 0; j < 100000; j++)
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

                                            goldstandardListTrue.Add(goldstandardItem);
                                        }
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

            return goldstandardListTrue;
        }

        public static (List<Goldstandard>, List<Goldstandard>) compareEnsemblId(string fileName1, string fileName2) {

            List<Goldstandard> goldstandardListTrue = new List<Goldstandard>();
            List<Goldstandard> goldstandardListFalse = new List<Goldstandard>();

            try
            {
                var delimiter = "\t";

                using (StreamReader sr1 = new StreamReader(fileName1))
                {
                    sr1.ReadLine();
                    while (!sr1.EndOfStream)
                    {
                        var lineSr1 = sr1.ReadLine();
                        if (!lineSr1.Equals(string.Empty))
                        {

                            if (goldstandardListTrue.Count() < 200)
                            {
                                String[] valuesSr1 = lineSr1.Split(delimiter);
                                string ensemblIdSr1 = valuesSr1[1].Trim();
                                string recordIdSr1 = valuesSr1[0];

                                using (StreamReader sr2 = new StreamReader(fileName2))
                                {
                                    while (!sr2.EndOfStream)
                                    {
                                        var lineSr2 = sr2.ReadLine();

                                        if (!lineSr2.Equals(string.Empty))
                                        {
                                            String[] valuesSr2 = lineSr2.Split(delimiter);
                                            string ensemblIdSr2 = valuesSr2[1].Trim();
                                            string recordIdSr2 = valuesSr2[0];

                                            if (ensemblIdSr1.Equals(ensemblIdSr2))
                                            {
                                                Goldstandard goldstandardItem = new Goldstandard();
                                                goldstandardItem.recordId1 = recordIdSr1;
                                                goldstandardItem.recordId2 = recordIdSr2;
                                                goldstandardItem.value = "TRUE";

                                                goldstandardListTrue.Add(goldstandardItem);
                                            }
                                            else
                                            {
                                                if (goldstandardListFalse.Count() < 200)
                                                {
                                                    Goldstandard goldstandardItem = new Goldstandard();
                                                    goldstandardItem.recordId1 = recordIdSr1;
                                                    goldstandardItem.recordId2 = recordIdSr2;
                                                    goldstandardItem.value = "FALSE";

                                                    goldstandardListFalse.Add(goldstandardItem);                     
                                                }
                                            }
                                        }
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

            return (goldstandardListTrue, goldstandardListFalse);
        }

        public static (List<Goldstandard>, List<Goldstandard>) comparePmId(string fileName1, string fileName2)
        {
            List<Goldstandard> goldstandardListTrue = new List<Goldstandard>();
            List<Goldstandard> goldstandardListFalse = new List<Goldstandard>();

            try
            {
                var delimiter = "\t";

                using (StreamReader sr1 = new StreamReader(fileName1))
                {
                    sr1.ReadLine();

                    // make comparisons as long as matches are not found
                    if (goldstandardListTrue.Count() < 200)
                    {


                        
                    }

                        while (!sr1.EndOfStream)
                        {
                            var lineSr1 = sr1.ReadLine();
                            if (!lineSr1.Equals(string.Empty))
                            {
                                String[] valuesSr1 = lineSr1.Split(delimiter);
                                string pmIdSr1 = valuesSr1[4].Trim();
                                string recordIdSr1 = valuesSr1[0];

                                using (StreamReader sr2 = new StreamReader(fileName2))
                                {
                                    // Reducing number of comparisons -- while (!sr2.EndOfStream)
                                    for (int j = 0; j < 100000; j++)                        
                                    {
                                        var lineSr2 = sr2.ReadLine();

                                        if (!lineSr2.Equals(string.Empty))
                                        {
                                            String[] valuesSr2 = lineSr2.Split(delimiter);
                                            string pmIdSr2 = valuesSr2[4].Trim();
                                            string recordIdSr2 = valuesSr2[0];

                                            if (pmIdSr1.Equals(pmIdSr2))
                                            {
                                                Goldstandard goldstandardItem = new Goldstandard();
                                                goldstandardItem.recordId1 = recordIdSr1;
                                                goldstandardItem.recordId2 = recordIdSr2;
                                                goldstandardItem.value = "TRUE";

                                                goldstandardListTrue.Add(goldstandardItem);

                                                Console.WriteLine("True Count: " + goldstandardListTrue.Count());
                                            }
                                            else
                                            {
                                                if (goldstandardListFalse.Count() < 200)
                                                {
                                                    Goldstandard goldstandardItem = new Goldstandard();
                                                    goldstandardItem.recordId1 = recordIdSr1;
                                                    goldstandardItem.recordId2 = recordIdSr2;
                                                    goldstandardItem.value = "FALSE";

                                                    goldstandardListFalse.Add(goldstandardItem);                     
                                                }
                                            }
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

            return (goldstandardListTrue, goldstandardListFalse);
        }

        public static void createOuput(string folderName, string fileName, List<Goldstandard> goldstandardList) {

            string directoryName = Environment.CurrentDirectory + "/data/output/" + folderName;
            Directory.CreateDirectory(directoryName);

            File.Delete(directoryName + "/" + fileName);
            using (StreamWriter sw = new StreamWriter(directoryName + "/" + fileName))
            {
                foreach (Goldstandard item in goldstandardList)
                {
                    var delimiter = "\t";
                    List<string> lineContent = new List<string>()
                    {
                        item.recordId1,
                        item.recordId2,
                        item.value
                    };
                    var line = string.Join(delimiter, lineContent);
                    sw.WriteLine(line);
                }

            }
        }

        public static void createTestTrainOutput() {
            
        }
    }
}