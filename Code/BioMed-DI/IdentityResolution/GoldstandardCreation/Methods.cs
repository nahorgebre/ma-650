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


        public static (List<Goldstandard>, List<Goldstandard>) compareFiles_NcbiId_GeneName(string fileName1, string fileName2)
        {

            // recordId - 0
            // ensemblId - 1
            // ncbiId - 2
            // geneName - 3

            int gsSize = 100;

            List<Goldstandard> goldstandardListTrue = new List<Goldstandard>();
            List<Goldstandard> goldstandardListFalse = new List<Goldstandard>();

            var delimiter = "\t";

            using (StreamReader sr1 = new StreamReader(fileName1))
            {

                sr1.ReadLine();
                while (!sr1.EndOfStream)
                {

                    var lineSr1 = sr1.ReadLine();

                    if (goldstandardListTrue.Count() < gsSize)
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

                                //Console.WriteLine("Key 1: " + key1 + " - Key 2: " + key2);

                                if (key1.Equals(key2))
                                {

                                    //Console.WriteLine("Key: " + key1);

                                    double geneNameSim = getBestGeneNameSimilarity(geneNameSr1, geneNameSr2);

                                    var jw = new JaroWinkler();

                                    double ncbiIdSim = jw.Similarity(ncbiIdSr1, ncbiIdSr2);


                                    bool trueFile = false;

                                    bool falseFile = false;


                                    if (geneNameSim > 0.95) trueFile = true;

                                    if (ncbiIdSim == 1 ) trueFile = true;

                                    // geneNameSim <= 0.95 & geneNameSim > 0.6
                                    if (geneNameSim <= 0.95) falseFile = true;


                                    if (trueFile)
                                    {

                                        if (!goldstandardListTrue.Exists(x => x.recordId2 == recordIdSr2) & !goldstandardListTrue.Exists(x => x.recordId1 == recordIdSr1))
                                        {

                                            Console.WriteLine("GS True #" + (goldstandardListTrue.Count() + 1).ToString() + " : " + geneNameSr1 + " - " + geneNameSr2 + " - " + ncbiIdSim);

                                            Goldstandard goldstandardItem = new Goldstandard();
                                            goldstandardItem.recordId1 = recordIdSr1;
                                            goldstandardItem.value1 = geneNameSr1;
                                            goldstandardItem.recordId2 = recordIdSr2;
                                            goldstandardItem.value2 = geneNameSr2;
                                            goldstandardItem.boolValue = "TRUE";
                                            goldstandardItem.sim = ncbiIdSim;
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
                               
                                                Console.WriteLine("GS False #" + (goldstandardListFalse.Count() + 1).ToString() + " : " + geneNameSr1 + " - " + geneNameSr2 + " - " + ncbiIdSim);

                                                Goldstandard goldstandardItem = new Goldstandard();
                                                goldstandardItem.recordId1 = recordIdSr1;
                                                goldstandardItem.value1 = geneNameSr1;
                                                goldstandardItem.recordId2 = recordIdSr2;
                                                goldstandardItem.value2 = geneNameSr2;
                                                goldstandardItem.boolValue = "FALSE";
                                                goldstandardItem.sim = ncbiIdSim;
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

            return key.ToLower();

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

            int gsSizeTrueClose = 48;

            int gsSizeTrueFar = 2;

            int gsSizeFalseClose = 50;

            int gsSizeFalseFar = 0;


            List<Goldstandard> goldstandardListTrueClose = new List<Goldstandard>();

            List<Goldstandard> goldstandardListTrueFar = new List<Goldstandard>();


            List<Goldstandard> goldstandardListFalseClose = new List<Goldstandard>();

            List<Goldstandard> goldstandardListFalseFar = new List<Goldstandard>();


            var delimiter = "\t";

            string log_path = Environment.CurrentDirectory + "/data/output/DI1/Brain_2_mart_export_brain/log.tsv";

            using (StreamWriter sw = new StreamWriter(log_path)) 
            {

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

                                        if (sim >= 0.99 & sim < 1) trueFileFar = true;

                                        if (sim < 0.99) falseFileClose = true;

                                        if (sim == 0) falseFileFar = true;


                                        string logLine = "Item #" + (goldstandardListTrueClose.Count() + 1) + " : " + compareValueSr1 + " - " + compareValueSr2 + " - " + sim;

                                        sw.WriteLine(logLine);


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

            }

            Console.WriteLine("True Close: " + gsSizeTrueClose + " - " + goldstandardListTrueClose.Count());
            Console.WriteLine("True Far: " + gsSizeTrueFar + " - " + goldstandardListTrueFar.Count());
            Console.WriteLine("False Close: " + gsSizeFalseClose + " - " +  goldstandardListFalseClose.Count());
            Console.WriteLine("False Far: " + gsSizeFalseFar + " - " + goldstandardListFalseFar.Count());
     
            return (goldstandardListTrueClose, goldstandardListTrueFar, goldstandardListFalseClose, goldstandardListFalseFar);

        }

    }

}