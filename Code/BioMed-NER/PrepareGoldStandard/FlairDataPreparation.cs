using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PrepareGoldStandard
{

    class FlairDataPreparation
    {

        // Abstract test
        public static FileInfo inputAbstractTestText = new FileInfo(Environment.CurrentDirectory + "/data/output/test_abstract.txt");
        public static FileInfo inputAbstractTestEntity = new FileInfo(Environment.CurrentDirectory + "/data/output/test_entity_abstract.tsv");

        // Abstract train
        public static FileInfo inputAbstractTrainText = new FileInfo(Environment.CurrentDirectory + "/data/output/train_abstract.txt");
        public static FileInfo inputAbstractTrainEntity = new FileInfo(Environment.CurrentDirectory + "/data/output/train_entity_abstract.tsv");

        // Title test
        public static FileInfo inputTitleTestText = new FileInfo(Environment.CurrentDirectory + "/data/output/test_title.txt");
        public static FileInfo inputTitleTestEntity = new FileInfo(Environment.CurrentDirectory + "/data/output/test_entity_title.tsv");

        // Title train
        public static FileInfo inputTitleTrainText = new FileInfo(Environment.CurrentDirectory + "/data/output/train_title.txt");
        public static FileInfo inputTitleTrainEntity = new FileInfo(Environment.CurrentDirectory + "/data/output/train_entity_title.tsv");

        // Output
        public static FileInfo outputTitleTrainFlair = new FileInfo(Environment.CurrentDirectory + "/data/outputFlair/trainFlairTitle.tsv");
        public static FileInfo outputAbstractTrainFlair = new FileInfo(Environment.CurrentDirectory + "/data/outputFlair/trainFlairTitle.tsv");


        public static void run()
        {

            // Abstract
            List<string> annotatedTextList = getAnnotatedTextList(inputAbstractTrainText, inputAbstractTrainEntity);
            outputAnnotations(outputAbstractTrainFlair, annotatedTextList);

        }

        public static void outputAnnotations(FileInfo outputFile, List<string> annotatedTextList)
        {

            outputFile.Directory.Create();

            using (StreamWriter sw = new StreamWriter(outputFile.FullName))
            {
                
                foreach (string annotatedText in annotatedTextList)
                {

                    sw.WriteLine(annotatedText);

                    sw.WriteLine(string.Empty);
                    
                }

            }

        }

        public static List<string> getAnnotatedTextList(FileInfo textFile, FileInfo entityFile)
        {

            List<string> annotatedTextList = new List<string>();

            Dictionary<string, List<GeneMention>> geneMentionDictionary = getGeneMentionDictionary(entityFile);

            using (StreamReader sr = new StreamReader(textFile.FullName))
            {

                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] values = line.Split('\t');

                    if (geneMentionDictionary.ContainsKey(values[0].Trim()))
                    {

                        string annotatedText = addBIOannotations(values[1], geneMentionDictionary[values[0].Trim()]);

                        annotatedTextList.Add(annotatedText);
                        
                    }
                    
                }
                
            }

            return annotatedTextList;

        }

        public static Dictionary<string, List<GeneMention>> getGeneMentionDictionary(FileInfo entityFile)
        {

            Dictionary<string, List<GeneMention>> geneMentionDictionary = new Dictionary<string, List<GeneMention>>();

            using (StreamReader sr = new StreamReader(entityFile.FullName))
            {
                
                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] values = line.Split('\t');

                    if (geneMentionDictionary.ContainsKey(values[0]))
                    {

                        List<GeneMention> geneMentionList = geneMentionDictionary[values[0]];

                        geneMentionList.Add( new GeneMention() { geneName = values[4], startIndex = values[2], endIndex = values[3] } );

                        geneMentionDictionary[values[0]] = geneMentionList;
                        
                    }
                    else if (!geneMentionDictionary.ContainsKey(values[0]))
                    {

                        geneMentionDictionary.Add(values[0], new List<GeneMention>(){ new GeneMention() { geneName = values[4], startIndex = values[2], endIndex = values[3] } } );

                    }
                    
                }

            }

            return geneMentionDictionary;

        }

        public static string addBIOannotations(string text, List<GeneMention> geneMentionList)
        {

            string outsideTag = "O";

            string beginTag = "B-GENE";

            string insideTag = "I-GENE";

            Dictionary<string, int> geneHashSet = new Dictionary<string, int>();

            foreach (var item in geneMentionList)
            {

                if (item.geneName.Split(null).Count() == 1)
                {

                    if (!geneHashSet.ContainsKey(item.geneName)) geneHashSet.Add(item.geneName, 0);

                }
                else if (item.geneName.Split(null).Count() > 1)
                {

                    string[] geneNameArray = item.geneName.Split(null);

                    for (int i = 0; i < geneNameArray.Count(); i++)
                    {

                        if (!geneHashSet.ContainsKey(geneNameArray[i]))
                        {

                            if (i == 0)
                            {

                                geneHashSet.Add(geneNameArray[i], 1);

                            }
                            else
                            {

                                geneHashSet.Add(geneNameArray[i], 2);

                            }

                        }

                    }

                }

            }

            StringBuilder annotatedText = new StringBuilder();

            List<string> textList = tokenizeText(text, geneHashSet);

            for (int i = 0; i < textList.Count; i++)
            {

                if (geneHashSet.ContainsKey(textList[i]))
                {

                    if (geneHashSet[textList[i]] == 0)
                    {

                        annotatedText.AppendLine(textList[i] + '\t'.ToString() + beginTag);

                    }
                    else if (geneHashSet[textList[i]] == 1)
                    {

                        if (geneHashSet.ContainsKey(textList[i + 1]))
                        {

                            annotatedText.AppendLine(textList[i] + '\t'.ToString() + beginTag);

                        }
                        else
                        {

                            annotatedText.AppendLine(textList[i] + '\t'.ToString() + outsideTag);

                        }

                    }
                    else if (geneHashSet[textList[i]] == 2)
                    {

                        if (geneHashSet.ContainsKey(textList[i - 1]))
                        {

                            annotatedText.AppendLine(textList[i] + '\t'.ToString() + insideTag);

                        }
                        else
                        {

                            annotatedText.AppendLine(textList[i] + '\t'.ToString() + outsideTag);

                        }

                    }

                }
                else
                {

                    annotatedText.AppendLine(textList[i] + '\t'.ToString() + outsideTag);

                }

            }

            return annotatedText.ToString();

        }

        public static List<string> tokenizeText(string text, Dictionary<string, int> geneHashSet)
        {

            Char[] charArray = new Char[] { '!', '#', '$', '%', '&', '(', ')', '/', '*', '.', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '_', '`', '{', '}', '~', '\'' };

            List<string> tokenList = new List<string>();

            foreach (string textItem in text.Split(null))
            {

                if (charArray.Any(s => textItem.IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0))
                {

                    if (!geneHashSet.ContainsKey(textItem))
                    {

                        string pattern = "([!#$%&()/*.:;<=>?@[\\]_`{}~'])";

                        string[] tokenArray = Regex.Split(textItem, pattern);

                        tokenArray = tokenArray.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                        foreach (var token in tokenArray)
                        {

                            tokenList.Add(token);

                        }

                    }
                    else if (geneHashSet.ContainsKey(textItem))
                    {

                        tokenList.Add(textItem);

                    }

                }
                else
                {

                    tokenList.Add(textItem);

                }

            }

            return tokenList;

        }

    }

    class GeneMention
    {

        public string geneName;

        public string startIndex;

        public string endIndex;

    }

}