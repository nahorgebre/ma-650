using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using F23.StringSimilarity;

namespace GoldstandardCreation
{

    class Methods
    {


        public static String EnsemblId = "EnsemblId";

        public static String GeneName = "GeneName";

        public static String PmId = "PmId";


        public static (List<Goldstandard>, List<Goldstandard>) compareFiles(string fileName1, string fileName2, int index, string blocking)
        {
            // ensemblId -> 1
            // geneName -> 3
            // pmId -> 4

            List<Goldstandard> goldstandardListTrue = new List<Goldstandard>();
            List<Goldstandard> goldstandardListFalse = new List<Goldstandard>();

            var delimiter = "\t";

            HashSet<String> blockingKeys = new HashSet<string>();

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

                                string key1 = "default";
                                string key2 = "default";



                                if (blocking.Equals(GeneName))
                                {

                                    key1 = getGeneNameBlockingKey(compareValueSr1);
                                    key2 = getGeneNameBlockingKey(compareValueSr2);
                                    
                                }
                                else if (blocking.Equals(PmId))
                                {

                                    key1 = getPmIdBlockingKey(compareValueSr1);
                                    key2 = getPmIdBlockingKey(compareValueSr2);
                                    
                                }
                                else if (blocking.Equals(EnsemblId))
                                {

                                    key1 = getEnsemblIdBlockingKey(compareValueSr1);
                                    key2 = getEnsemblIdBlockingKey(compareValueSr2);
                                    
                                }

                                blockingKeys.Add(key1);
                                blockingKeys.Add(key2);

                                if (key1.Equals(key2))
                                {

                                    // calculate similarity
                                    var jw = new JaroWinkler();
                                    double sim = jw.Similarity(compareValueSr1, compareValueSr2);

                                    //Console.WriteLine(compareValueSr1 + " - " + compareValueSr2 + " - " + sim);

                                    bool trueFile = false;
                                    bool falseFile = false;

                                    if (index == 3)
                                    {

                                        // GeneName
                                        if (sim > 0.95) trueFile = true;
                                        if (sim <= 0.95 & sim > 0.7) falseFile = true;

                                    }
                                    else if (index == 1)
                                    {
                                        // Ensembl Id
                                        if (sim >= 0.98) trueFile = true;
                                        if (sim < 0.98 & sim > 0.7) 
                                        {
                                            //Console.WriteLine(compareValueSr1 + " - " + compareValueSr2 + " - " + sim);
                                            falseFile = true;
                                        }

                                    }
                                    else if (index == 4)
                                    {
                                        // PmId
                                        if (sim >= 0.98) trueFile = true;
                                        if (sim < 0.98 & sim > 0.7) 
                                        {
                                            //Console.WriteLine(compareValueSr1 + " - " + compareValueSr2 + " - " + sim);
                                            falseFile = true;
                                        }
                                    }

                                    if (trueFile)
                                    {

                                        if (!goldstandardListTrue.Exists(x => x.recordId2 == recordIdSr2) & !goldstandardListTrue.Exists(x => x.recordId1 == recordIdSr1))
                                        {

                                            Goldstandard goldstandardItem = new Goldstandard();
                                            goldstandardItem.recordId1 = recordIdSr1;
                                            goldstandardItem.value1 = compareValueSr1;
                                            goldstandardItem.recordId2 = recordIdSr2;
                                            goldstandardItem.value2 = compareValueSr2;
                                            goldstandardItem.boolValue = "TRUE";
                                            goldstandardItem.sim = sim;
                                            goldstandardItem.blockingKey = key1;

                                            goldstandardListTrue.Add(goldstandardItem);

                                        }

                                    }
                                    else if (falseFile)
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
            
            }

            Console.WriteLine("GS-True-List Count: " + goldstandardListTrue.Count);
            Console.WriteLine("GS-False-List Count: " + goldstandardListFalse.Count);
            
            return (goldstandardListTrue, goldstandardListFalse);

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

            if (nameLength >= 2)
            {

                key = geneName.Substring(0,2).Trim();

            }

            /*
            if (nameLength >= 4) {

                int keyIndex = geneName.Count() / 2;
                key = geneName.Substring(0, keyIndex);

            } else if (nameLength == 1) {

                key = geneName;

            } else if (nameLength == 2) {

                key = geneName;

            } else if (nameLength == 3) {
            
                key = geneName;

            }
            */

            return key;

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

        public static String getPmIdBlockingKey(String pmId)
        {

            String key = "default";

            int pmIdLength = pmId.Count();

            if (pmIdLength >= 4)
            {

                key = pmId.Substring(0,4).Trim();

            }

            return key;

        }

        public static void createBlockingKeyOutput(HashSet<String> blockingKeys) {

            string fileName = string.Format("{0}/data/output/test.csv", Environment.CurrentDirectory);

            using (StreamWriter sw = new StreamWriter(fileName))
            {

                foreach (var key in blockingKeys)
                {

                    sw.WriteLine(key);
                    
                }
            }
        }

        public static void createOuput(string fileName, List<Goldstandard> goldstandardList)
        {

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (Goldstandard item in goldstandardList)
                {

                    //Console.WriteLine("Sim: " + item.sim);

                    var delimiter = "\t";
                    List<string> lineContent = new List<string>()
                    {
                        item.recordId1,
                        item.value1,
                        item.recordId2,
                        item.value2,
                        item.boolValue,
                        item.sim.ToString(),
                        item.blockingKey
                    };
                    var line = string.Join(delimiter, lineContent);
                    sw.WriteLine(line);

                }

            }

        }

    }

}