using System;
using System.IO;
using System.Collections.Generic;

namespace DataTranslation
{

    public class gene2pubtatorcentral_dt
    {

        public static void runDataTranslation()
        {

            Directory.CreateDirectory(string.Format("{0}/{1}", Environment.CurrentDirectory, DI2.outputDirectory));

            Console.WriteLine("Start gene2pubtatorcentral_dt()");


            for (int i = 1; i <= Variables.gene2pubtatorcentral_partitionNumbers; i++)
            {

                List<Publication> publication_list = new List<Publication>();

                using (var reader = new StreamReader(string.Format("{0}/{1}/{2}", Environment.CurrentDirectory, DI2.inputDirectory, "gene2pubtatorcentral.tsv")))
                {

                    reader.ReadLine();

                    int conditionCounter = 1;

                    int recordIdCounter = 1;

                    while (!reader.EndOfStream)
                    {

                        var line = reader.ReadLine();

                        String[] values = line.Split('\t');

                        bool condition;

                        if (i == Variables.gene2pubtatorcentral_partitionNumbers)
                        {

                            condition = conditionCounter > Variables.gene2pubtatorcentral_partitionSize * (i - 1);

                        }
                        else
                        {

                            condition = (conditionCounter > Variables.gene2pubtatorcentral_partitionSize * (i - 1)) & (conditionCounter <= Variables.gene2pubtatorcentral_partitionSize * i);

                        }

                        
                        if (condition)
                        {

                            if (values[1].Trim().Equals("Gene"))
                            {

                                string[] ncbiIdArray = values[2].Split(';');

                                foreach (String ncbiId in ncbiIdArray)
                                {

                                    Publication publication = new Publication(); 

                                    publication.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", i.ToString(), recordIdCounter);

                                    publication.pmId = values[0].Trim();

                                    publication.ressource = values[4].Trim();

                                    publication.ncbiId = ncbiId;

                                    HashSet<string> geneNameHashSet = getGeneNameHashSet(values[3]);

                                    List<String> geneNameList = new List<string>();

                                    /*

                                    foreach (string name in geneNameHashSet)
                                    {

                                        GeneName GeneName = new GeneName();

                                        GeneName.name = name.Trim();

                                        geneNameList.Add(name);

                                    }

                                    */

                                    publication.geneNames = string.Join("|", geneNameList);

                                    publication_list.Add(publication);

                                    recordIdCounter++;

                                }
                            
                            }
                            
                        }

                        conditionCounter++;

                    }

                }

                Console.WriteLine("Gene list length: " + publication_list.Count);
                    
                Methods.createXmlPublication(publication_list: publication_list, fileName: "gene2pubtatorcentral_" + i + "_dt.xml", directory: DI2.outputDirectory + "/" + Variables.gene2pubtatorcentral_partitionNumbers.ToString());

                Methods.createTsvPublication(publication_list: publication_list, fileName: "gene2pubtatorcentral_" + i + "_dt.tsv", directory: DI2.outputDirectory + "/" + Variables.gene2pubtatorcentral_partitionNumbers.ToString());
 
            }

        }


        public static HashSet<string> getGeneNameHashSet(string geneNameValues)
        {

            HashSet<string> geneNameHashSet = new HashSet<string>();

            geneNameValues = geneNameValues.Replace("and", ",");

            string[] geneNameSplitArray = geneNameValues.Split(new Char [] { '|' , ',' });

            foreach (string geneNameSplit in geneNameSplitArray)
            {

                geneNameHashSet.Add(geneNameSplit.Trim());
            
            }

            return geneNameHashSet;

        }

    }

}