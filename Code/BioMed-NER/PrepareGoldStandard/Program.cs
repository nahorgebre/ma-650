using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace PrepareGoldStandard
{

    class Program
    {

        public static List<int> getStartIndexList(string text, string pattern)
        {

            List<int> startIndexList = new List<int>();

            int index = 0;

            while ((index = text.IndexOf(pattern, index)) != -1)
            {

                startIndexList.Add(index);

                index++;

            }

            return startIndexList;

        }

        public static List<int> getItemWithinParameter(List<int> startIndexList, int lowerBound, int upperBound)
        {

            List<int> adjustedStartIndexList = new List<int>();

            foreach (int startIndexItem in startIndexList)
            {

                if ((startIndexItem >= lowerBound) & (startIndexItem <= upperBound))
                {

                    adjustedStartIndexList.Add(startIndexItem);

                }

            }

            return adjustedStartIndexList;

        }

        public static string addBIOannotations2(string text, List<GeneMention> geneMentionList)
        {

            Console.WriteLine("Text: " + text);

            string outsideTag = @"|O";

            string beginTag = @"|B-GENE";

            string insideTag = @"|I-GENE";

            int indexAdjustment = 0;

            foreach (GeneMention item in geneMentionList)
            {

                int startIndex = Int16.Parse(item.startIndex) + indexAdjustment;

                int endIndex = Int16.Parse(item.endIndex) + indexAdjustment;

                int entityCount = item.geneName.Split(null).Count();

                // -----------------------

                if (entityCount > 1)
                {

                    string[] entityTokenArray = item.geneName.Split(null);

                    for (int entityTokenArrayIndex = 0; entityTokenArrayIndex < entityTokenArray.Count(); entityTokenArrayIndex++)
                    {

                        Console.WriteLine("-----------------------------------Entity token: " + entityTokenArray[entityTokenArrayIndex]);


                        if (entityTokenArrayIndex == 0)
                        {

                            string entityToken = entityTokenArray[entityTokenArrayIndex];

                            int entityTokenLength = entityToken.Length;

                            int entityTokenEndIndex = startIndex + entityTokenArray[entityTokenArrayIndex].Length;

                            text = text.Insert(entityTokenEndIndex, beginTag);

                            indexAdjustment = indexAdjustment + beginTag.Count();

                        }



                        if (entityTokenArrayIndex >= 1)
                        {

                            string entityToken = entityTokenArray[entityTokenArrayIndex];

                            int entityTokenLength = entityToken.Length;


                            List<int> startIndexList = getStartIndexList(text, entityToken);

                            foreach (var item1 in startIndexList)
                            {

                                Console.WriteLine("1-" + item1);

                                Console.WriteLine("1-substring: " + text.Substring(item1, 10));

                            }

                            Console.WriteLine("Index adjustment: " + indexAdjustment);

                            Console.WriteLine("Start: " + startIndex);

                            Console.WriteLine("Start substring: " + text.Substring(startIndex, 10));

                            Console.WriteLine("End: " + endIndex);


                            //Console.WriteLine("Text: " + text);


                            List<int> adjustedStartIndexList = getItemWithinParameter(startIndexList, startIndex, endIndex);

                            foreach (var item2 in adjustedStartIndexList)
                            {

                                Console.WriteLine("2-" + item2);

                            }


                            int adjustedEndIndex = adjustedStartIndexList[0] + entityTokenLength;

                            text = text.Insert(adjustedEndIndex, insideTag);


                            indexAdjustment = indexAdjustment + insideTag.Count();

                        }


                    }

                }

                // -----------------------------------

                if (entityCount == 1)
                {

                    text = text.Insert(endIndex, beginTag);

                    indexAdjustment = indexAdjustment + beginTag.Count();

                }

            }


            text = FlairDataPreparation.removeWhiteSpaces(text);

            string[] textArray = text.Split(null);


            StringBuilder annotatedText = new StringBuilder();


            foreach (string textArrayItem in textArray)
            {

                if (textArrayItem.Contains(@"|"))
                {

                    annotatedText.AppendLine(textArrayItem.Replace('|', '\t'));

                }
                else
                {

                    annotatedText.AppendLine(textArrayItem + '\t'.ToString() + outsideTag.Replace('|'.ToString(), string.Empty));

                }

            }

            return annotatedText.ToString();
        }

        public static List<GeneMention> getSortedGeneMentionList(List<GeneMention> geneMentions)
        {

            SortedDictionary<int, GeneMention> sortedDictionary = new SortedDictionary<int, GeneMention>();

            foreach (var item in geneMentions)
            {

                sortedDictionary.Add(Int16.Parse(item.startIndex), item);

            }

            return sortedDictionary.Values.ToList();

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

            List<string> textList = text.Split(null).ToList();

            //List<string> punctuationList = new List<string>() { ".", ",", "!", "?", ":", ";"};

            //List<string> punctuationList = new List<string>() {  "!", "#", "$", "%", "&", "(", ")", "/", "*", ".", ":", ";", "<", "=", ">", "?", "@", "[", "\\", "]", "_", "`", "{", "}", "~", "'" };

            Char[] charArray = new Char[] { '!', '#', '$', '%', '&', '(', ')', '/', '*', '.', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '_', '`', '{', '}', '~', '\'' };

            for (int i = 0; i < textList.Count; i++)
            {

                

                if (charArray.Any(s => textList[i].IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0))
                {

                    if (!geneHashSet.ContainsKey(textList[i]))
                    {

                        Console.WriteLine("Original Token: " + textList[i]);

                        string pattern = "([!#$%&()/*.:;<=>?@[\\]_`{}~'])";

                        string[] tokenArray = Regex.Split(textList[i], pattern);

                        tokenArray = tokenArray.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                        foreach (var token in tokenArray)
                        {

                            Console.WriteLine("Token: " + token);
                            
                        }
                        
                    }

                }

                if (geneHashSet.ContainsKey(textList[i]))
                {

                    if (geneHashSet[textList[i]] == 0)
                    {

                        annotatedText.AppendLine(textList[i] + '\t'.ToString() + beginTag);

                    }
                    else if (geneHashSet[textList[i]] == 1)
                    {

                        if (geneHashSet.ContainsKey(textList[i+1]))
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

                        if (geneHashSet.ContainsKey(textList[i-1]))
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




        static void Main(string[] args)
        {

            string text = "A compound comprising a target cell-specific portion and human NAD(P)H:quinone reductase 2 )NQO2) or a variant or fragment or fusion or derivative thereof which has substantially the same activity as NQO2 towards a given prodrug, or a polynucleotide encoding said NQO2 or said variant or fragment or fusion or derivative. A recombinant polynucleotide comprising a target cell-specific promoter operably linked to a polynucleotide encoding human NAD(P)H:quinone reductase 2 (NQO2) or a variant or fragment or fusion or derivative thereof which has substantially the same activity as NQO2 towards a given prodrug. The compounds and polynucleotides are useful in a method of treating a patient in conjunction with a suitable prodrug. A method of treating a human patient with a target cell to be destroyed wherein the target cell expresses NQO2 the method comprising administering to the patient a prodrug which is converted to a substantially cytotoxic drug by the action of NQO2 and nicotinamide riboside (reduced) (NRH) or an analogue thereof which can pass reducing equivalents to NQO2.";



            List<GeneMention> geneMentionList = new List<GeneMention>();

            GeneMention g1 = new GeneMention() { geneName = "NQO2", startIndex = "92", endIndex = "96" };
            geneMentionList.Add(g1);

            GeneMention g2 = new GeneMention() { geneName = "NQO2", startIndex = "200", endIndex = "204" };
            geneMentionList.Add(g2);

            GeneMention g3 = new GeneMention() { geneName = "human NAD(P)H:quinone reductase 2", startIndex = "57", endIndex = "90" };
            geneMentionList.Add(g3);

            GeneMention g4 = new GeneMention() { geneName = "human NAD(P)H:quinone reductase 2", startIndex = "439", endIndex = "472" };
            geneMentionList.Add(g4);


            Console.WriteLine(addBIOannotations(text, geneMentionList));


            // ----


            //geneMentionList = getSortedGeneMentionList(geneMentionList);

            //Console.WriteLine(addBIOannotations(text, geneMentionList));


            // ----


            /*
            List<int> startIndexList = getStartIndexList(text, "NAD(P)H:quinone");

            foreach (var item in startIndexList)
            {

                Console.WriteLine("1-" + item);

            }

           


            List<int> adjustedStartIndexList = getItemWithinParameter(startIndexList, 57, 90);

            foreach (var item in adjustedStartIndexList)
            {

                Console.WriteLine("2-" + item);
                
            }


            text = FlairDataPreparation.removeWhiteSpaces(text);
            */
            /*
                        US6867231	A	1082	1086	NQO2	ABBREVIATION	P16083
            US6867231	A	200	204	NQO2	ABBREVIATION	P16083
            US6867231	A	264	268	NQO2	ABBREVIATION	P16083
            US6867231	A	439	472	human NAD(P)H:quinone reductase 2	FULL_NAME	P16083
            US6867231	A	474	478	NQO2	ABBREVIATION	P16083
            US6867231	A	57	90	human NAD(P)H:quinone reductase 2	FULL_NAME	P16083
            US6867231	A	582	586	NQO2	ABBREVIATION	P16083
            US6867231	A	837	841	NQO2	ABBREVIATION	P16083
            US6867231	A	92	96	NQO2	ABBREVIATION	P16083
            US6867231	A	973	977	NQO2	ABBREVIATION	P16083
            */


            //DataPreparation.run();

            //AWSupload.run();

        }

    }

}