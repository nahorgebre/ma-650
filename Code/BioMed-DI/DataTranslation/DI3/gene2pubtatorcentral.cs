using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DataTranslation
{

    public class gene2pubtatorcentral
    {

        public static void runDataTranslation()
        {

            Directory.CreateDirectory(string.Format("{0}/{1}", Environment.CurrentDirectory, DI3.outputDirectory));

            Console.WriteLine("Start gene2pubtatorcentral_dt()");

            for (int i = 1; i <= Variables.gene2pubtatorcentral_partitionNumbers; i++)
            {

                List<Gene> gene_list = new List<Gene>();

                using (var reader = new StreamReader(string.Format("{0}/{1}/{2}", Environment.CurrentDirectory, DI3.inputDirectory, "gene2pubtatorcentral.tsv")))
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

                                    Gene gene = new Gene();

                                    gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", i.ToString(), recordIdCounter);

                                    gene.ncbiId = ncbiId;

                                    HashSet<string> geneNameHashSet = getGeneNameHashSet(values[3]);

                                    gene.geneNames = string.Join("|", geneNameHashSet);


                                    List<GenePublicationMention> publicationList = new List<GenePublicationMention>();

                                    GenePublicationMention publication = new GenePublicationMention();

                                    publication.pmId = values[0].Trim();

                                    publication.ressource = values[4].Trim();

                                    publicationList.Add(publication);


                                    gene.publicationMentions = publicationList;


                                    gene_list.Add(gene);


                                    recordIdCounter++;

                                }

                            }

                        }

                        conditionCounter++;

                    }

                }

                Methods.createXmlGene(gene_list: gene_list, fileName: "gene2pubtatorcentral_" + i + "_dt.xml", directory: DI3.outputDirectory);

                Methods.createTsv(gene_list: gene_list, fileName: "gene2pubtatorcentral_" + i + "_dt.tsv", directory: DI3.outputDirectory);
            
            }

        }

        public static HashSet<string> getGeneNameHashSet(string geneNameValues)
        {

            HashSet<string> geneNameHashSet = new HashSet<string>();

            //geneNameValues = geneNameValues.Replace("and", "|");

            //geneNameValues = geneNameValues.Replace("or", "|");

            //geneNameValues = geneNameValues.Replace(",", "|");

            string[] geneNameSplitArray = geneNameValues.Split('|');

            foreach (string geneNameSplit in geneNameSplitArray)
            {

                string geneNameItem = geneNameSplit.Trim();

                if (!geneNameItem.Equals(string.Empty))
                {

                    geneNameItem = removeWhiteSpaces(geneNameItem);

                    geneNameHashSet.Add(geneNameItem);
                    
                }
       
            }

            return geneNameHashSet;

        }

        public static string removeWhiteSpaces(string text)
        {

            RegexOptions options = RegexOptions.None;

            Regex regex = new Regex("[ ]{2,}", options);

            return regex.Replace(text, " ");

        }

    }

}