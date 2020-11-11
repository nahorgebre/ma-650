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

        public static (List<Goldstandard>, List<Goldstandard>) compareFiles(string fileName1, string fileName2, int index, string blocking)
        {
            // ensemblId -> 1
            // geneName -> 3
            // pmId -> 4

            int gsSize = 200;

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
                    if (goldstandardListTrue.Count() < gsSize)
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
                                else if (blocking.Equals(EnsemblId))
                                {

                                    key1 = getEnsemblIdBlockingKey(compareValueSr1);
                                    key2 = getEnsemblIdBlockingKey(compareValueSr2);
                                    
                                }

                                if (key1.Equals(key2))
                                {

                                    var jw = new JaroWinkler();
                                    double sim = jw.Similarity(compareValueSr1, compareValueSr2);

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
                                        if (sim >= 0.95) trueFile = true;
                                        if (sim < 0.95 & sim > 0.7) falseFile = true;

                                    }

                                    if (trueFile)
                                    {

                                        if (!goldstandardListTrue.Exists(x => x.recordId2 == recordIdSr2) & !goldstandardListTrue.Exists(x => x.recordId1 == recordIdSr1))
                                        {

                                            Console.WriteLine("GS True #" + (goldstandardListTrue.Count() + 1).ToString() + " : " + compareValueSr1 + " - " + compareValueSr2 + " - " + sim);

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
                                    
                                        if (goldstandardListFalse.Count() < gsSize)
                                        {
                                        
                                            if (!goldstandardListFalse.Exists(x => x.recordId2 == recordIdSr2) & !goldstandardListFalse.Exists(x => x.recordId1 == recordIdSr1))
                                            {
                               
                                                Console.WriteLine("GS False #" + (goldstandardListFalse.Count() + 1).ToString() + " : " + compareValueSr1 + " - " + compareValueSr2 + " - " + sim);

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
                        item.sim.ToString(),
                        item.blockingKey
                    };
                    var line = string.Join(delimiter, lineContent);
                    sw.WriteLine(line);

                }

            }

        }

        public static (List<Goldstandard>, List<Goldstandard>, List<Goldstandard>, List<Goldstandard>) compareFilesEnsemblIdBlockingComparator(string fileName1, string fileName2)
        {

            int gsSizeTrueClose = 35;

            int gsSizeTrueFar = 15;

            int gsSizeFalseClose = 49;

            int gsSizeFalseFar = 1;


            List<Goldstandard> goldstandardListTrueClose = new List<Goldstandard>();

            List<Goldstandard> goldstandardListTrueFar = new List<Goldstandard>();


            List<Goldstandard> goldstandardListFalseClose = new List<Goldstandard>();

            List<Goldstandard> goldstandardListFalseFar = new List<Goldstandard>();


            var delimiter = "\t";


            using (StreamReader sr1 = new StreamReader(fileName1))
            {

                sr1.ReadLine();

                while (!sr1.EndOfStream)
                {

                    var lineSr1 = sr1.ReadLine();

                    using (StreamReader sr2 = new StreamReader(fileName2))
                    {

                        sr2.ReadLine();
           
                        while (!sr2.EndOfStream)
                        {
                                
                            var lineSr2 = sr2.ReadLine();

                            if (goldstandardListTrueClose.Count() < gsSizeTrueClose |
                                goldstandardListTrueFar.Count() < gsSizeTrueFar |
                                goldstandardListFalseClose.Count() < gsSizeFalseClose |
                                goldstandardListFalseFar.Count() < gsSizeFalseFar)
                            {

                                String[] valuesSr1 = lineSr1.Split(delimiter);

                                string compareValueSr1 = valuesSr1[1].Trim();

                                string recordIdSr1 = valuesSr1[0];


                                String[] valuesSr2 = lineSr2.Split(delimiter);

                                string compareValueSr2 = valuesSr2[1].Trim();

                                string recordIdSr2 = valuesSr2[0];


                                string key1 = getEnsemblIdBlockingKey(compareValueSr1);

                                string key2 = getEnsemblIdBlockingKey(compareValueSr2);


                                if (key1.Equals(key2))
                                {

                                    var jw = new JaroWinkler();

                                    double sim = jw.Similarity(compareValueSr1, compareValueSr2);


                                    bool trueFileClose = false;

                                    bool trueFileFar = false;

                                    bool falseFileClose = false;

                                    bool falseFileFar = false;


                                    if (sim == 1) trueFileClose = true;

                                    if (sim >= 0.98 & sim < 1) trueFileFar = true;

                                    if (sim < 0.98) falseFileClose = true;

                                    if (sim == 1) falseFileFar = true;


                                    if (trueFileClose)
                                    {

                                        if (goldstandardListTrueClose.Count() < gsSizeTrueClose)
                                        {
                                        
                                            if (!goldstandardListTrueClose.Exists(x => x.recordId2 == recordIdSr2) & !goldstandardListTrueClose.Exists(x => x.recordId1 == recordIdSr1))
                                            {
                                  
                                                Console.WriteLine("Goldstandard True Close #" + goldstandardListTrueClose.Count() + " : " + compareValueSr1 + " - " + compareValueSr2 + " - " + sim);

                                                Goldstandard goldstandardItem = new Goldstandard();

                                                goldstandardItem.recordId1 = recordIdSr1;

                                                goldstandardItem.value1 = compareValueSr1;

                                                goldstandardItem.recordId2 = recordIdSr2;

                                                goldstandardItem.value2 = compareValueSr2;

                                                goldstandardItem.boolValue = "TRUE";

                                                goldstandardItem.sim = sim;

                                                goldstandardItem.blockingKey = key1;

                                                goldstandardListTrueClose.Add(goldstandardItem);

                                            }

                                        }
                                       
                                    }
                                    else if (trueFileFar)
                                    {

                                        if (goldstandardListTrueFar.Count() < gsSizeTrueFar)
                                        {
                                        
                                            if (!goldstandardListTrueFar.Exists(x => x.recordId2 == recordIdSr2) & !goldstandardListTrueFar.Exists(x => x.recordId1 == recordIdSr1))
                                            {
                                  
                                                Console.WriteLine("Goldstandard True Far #" + goldstandardListTrueFar.Count() + " : " + compareValueSr1 + " - " + compareValueSr2 + " - " + sim);

                                                Goldstandard goldstandardItem = new Goldstandard();

                                                goldstandardItem.recordId1 = recordIdSr1;

                                                goldstandardItem.value1 = compareValueSr1;

                                                goldstandardItem.recordId2 = recordIdSr2;

                                                goldstandardItem.value2 = compareValueSr2;

                                                goldstandardItem.boolValue = "TRUE";

                                                goldstandardItem.sim = sim;

                                                goldstandardItem.blockingKey = key1;

                                                goldstandardListTrueFar.Add(goldstandardItem);

                                            }

                                        }

                                    }
                                    else if (falseFileClose)
                                    {

                                        if (goldstandardListFalseClose.Count() < gsSizeFalseClose)
                                        {
                                        
                                            if (!goldstandardListFalseClose.Exists(x => x.recordId2 == recordIdSr2) & !goldstandardListFalseClose.Exists(x => x.recordId1 == recordIdSr1))
                                            {
                                  
                                                Console.WriteLine("Goldstandard False Close #" + goldstandardListFalseClose.Count() + " : " + compareValueSr1 + " - " + compareValueSr2 + " - " + sim);

                                                Goldstandard goldstandardItem = new Goldstandard();

                                                goldstandardItem.recordId1 = recordIdSr1;

                                                goldstandardItem.value1 = compareValueSr1;

                                                goldstandardItem.recordId2 = recordIdSr2;

                                                goldstandardItem.value2 = compareValueSr2;

                                                goldstandardItem.boolValue = "FALSE";

                                                goldstandardItem.sim = sim;

                                                goldstandardItem.blockingKey = key1;

                                                goldstandardListFalseClose.Add(goldstandardItem);

                                            }

                                        }

                                    }
                                    else if (falseFileFar)
                                    {

                                        if (goldstandardListFalseFar.Count() < gsSizeFalseFar)
                                        {
                                        
                                            if (!goldstandardListFalseFar.Exists(x => x.recordId2 == recordIdSr2) & !goldstandardListFalseFar.Exists(x => x.recordId1 == recordIdSr1))
                                            {
                                  
                                                Console.WriteLine("Goldstandard False Far #" + goldstandardListFalseFar.Count() + " : " + compareValueSr1 + " - " + compareValueSr2 + " - " + sim);

                                                Goldstandard goldstandardItem = new Goldstandard();

                                                goldstandardItem.recordId1 = recordIdSr1;

                                                goldstandardItem.value1 = compareValueSr1;

                                                goldstandardItem.recordId2 = recordIdSr2;

                                                goldstandardItem.value2 = compareValueSr2;

                                                goldstandardItem.boolValue = "FALSE";

                                                goldstandardItem.sim = sim;

                                                goldstandardItem.blockingKey = key1;

                                                goldstandardListFalseFar.Add(goldstandardItem);

                                            }

                                        }

                                    }

                                }
                                
                            }

                        }
                        
                    }
                
                }

            }

            Console.WriteLine("True Close: " + gsSizeTrueClose + " - " + goldstandardListTrueClose.Count());
            Console.WriteLine("True Far: " + gsSizeTrueFar + " - " + goldstandardListTrueFar.Count());
            Console.WriteLine("False Close: " + gsSizeFalseClose + " - " +  goldstandardListFalseClose.Count());
            Console.WriteLine("False Far: " + gsSizeFalseFar + " - " + goldstandardListFalseFar.Count());
     
            return (goldstandardListTrueClose, goldstandardListTrueFar, goldstandardListFalseClose, goldstandardListFalseFar);

        }


        /*
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
        */

                   /*
            using (StreamReader sr1 = new StreamReader(fileName1))
            {

                sr1.ReadLine();

                while (!sr1.EndOfStream)
                {

                    var lineSr1 = sr1.ReadLine();

                    if (goldstandardListTrue.Count() < gsSizeTrue)
                    {

                        String[] valuesSr1 = lineSr1.Split(delimiter);

                        string compareValueSr1 = valuesSr1[4].Trim();

                        string recordIdSr1 = valuesSr1[0];

                        using (StreamReader sr2 = new StreamReader(fileName2))
                        {

                            sr2.ReadLine();
           
                            while (!sr2.EndOfStream)
                            {
                                var lineSr2 = sr2.ReadLine();

                                String[] valuesSr2 = lineSr2.Split(delimiter);

                                string compareValueSr2 = valuesSr2[4].Trim();

                                string recordIdSr2 = valuesSr2[0];

                                string key1 = getPmIdBlockingKey(compareValueSr1);

                                string key2 = getPmIdBlockingKey(compareValueSr2);
                                
                                if (key1.Equals(key2))
                                {

                                    var jw = new JaroWinkler();

                                    double sim = jw.Similarity(compareValueSr1, compareValueSr2);

                                    bool trueFile = false;

                                    bool falseFileClose = false;

                                    bool falseFileFar = false;

                                    if (sim >= 0.97) trueFile = true;

                                    if (sim < 0.97 & sim > 0.1) falseFileClose = true;

                                    if (sim == 0) falseFileFar = true;

                                    if (trueFile)
                                    {

                                        if (!goldstandardListTrue.Exists(x => x.recordId2 == recordIdSr2) & !goldstandardListTrue.Exists(x => x.recordId1 == recordIdSr1))
                                        {

                                            Console.WriteLine("Goldstandard True - " + goldstandardListTrue.Count() +" : " + compareValueSr1 + " - " + compareValueSr2 + " - " + sim);

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
                                    else if (falseFileClose)
                                    {
                                    
                                        if (goldstandardListFalseClose.Count() < gsSizeFalseClose)
                                        {
                                        
                                            if (!goldstandardListFalseClose.Exists(x => x.recordId2 == recordIdSr2) & !goldstandardListFalseClose.Exists(x => x.recordId1 == recordIdSr1))
                                            {
                                  
                                                Console.WriteLine("Goldstandard False Close - " + goldstandardListFalseClose.Count() + " : " + compareValueSr1 + " - " + compareValueSr2 + " - " + sim);

                                                Goldstandard goldstandardItem = new Goldstandard();

                                                goldstandardItem.recordId1 = recordIdSr1;

                                                goldstandardItem.value1 = compareValueSr1;

                                                goldstandardItem.recordId2 = recordIdSr2;

                                                goldstandardItem.value2 = compareValueSr2;

                                                goldstandardItem.boolValue = "FALSE";

                                                goldstandardItem.sim = sim;

                                                goldstandardItem.blockingKey = key1;

                                                goldstandardListFalseClose.Add(goldstandardItem);

                                            }

                                        }

                                    }
                                    else if (falseFileFar)
                                    {

                                        if (goldstandardListFalseFar.Count() < gsSizeFalseFar)
                                        {

                                            if (!goldstandardListFalseFar.Exists(x => x.recordId2 == recordIdSr2) & !goldstandardListFalseFar.Exists(x => x.recordId1 == recordIdSr1))
                                            {

                                                Console.WriteLine("Goldstandard False Far - " + goldstandardListFalseFar.Count() + " : " + compareValueSr1 + " - " + compareValueSr2 + " - " + sim);

                                                Goldstandard goldstandardItem = new Goldstandard();

                                                goldstandardItem.recordId1 = recordIdSr1;

                                                goldstandardItem.value1 = compareValueSr1;

                                                goldstandardItem.recordId2 = recordIdSr2;

                                                goldstandardItem.value2 = compareValueSr2;

                                                goldstandardItem.boolValue = "FALSE";

                                                goldstandardItem.sim = sim;

                                                goldstandardItem.blockingKey = key1;

                                                goldstandardListFalseFar.Add(goldstandardItem);

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }
            
            }
            */

                /*
        public static String getPmIdBlockingKey(String pmId)
        {

            String key = "default";

            int pmIdLength = pmId.Count();

            if (pmIdLength >= 5)
            {

                key = pmId.Substring(0, 4).Trim();

            }

            return key;

        }
        */

    }

}