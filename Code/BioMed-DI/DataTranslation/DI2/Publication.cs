using System;
using System.IO;
using System.Collections.Generic;

namespace DataTranslation
{

    public class Publication
    {
        
        public static void runDataTranslation()
        {

            Directory.CreateDirectory(string.Format("{0}/{1}", Environment.CurrentDirectory, Publication.gene2PubtatorcentralOutputDirectory));
            Publication.gene2pubtatorcentral_dt();
            //Publication.pubMedDate_dt();

        }

        public static string gene2PubtatorcentralInputDirectory = "data/input/Gene2Pubtatorcentral";
        public static string gene2PubtatorcentralOutputDirectory = "data/output/DI2";


        public static void gene2pubtatorcentral_dt()
        {

            Console.WriteLine("Start gene2pubtatorcentral_dt()");


            for (int i = 1; i <= Variables.partitionNumbers; i++)
            {

                List<Gene> gene_list = new List<Gene>();

                using (var reader = new StreamReader(string.Format("{0}/{1}/{2}", Environment.CurrentDirectory, gene2PubtatorcentralInputDirectory, "gene2pubtatorcentral.tsv")))
                {

                    reader.ReadLine();
                    int conditionCounter = 1;
                    int recordIdCounter = 1;

                    while (!reader.EndOfStream)
                    {

                        var line = reader.ReadLine();
                        String[] values = line.Split('\t');

                        bool condition;

                        if (i == Variables.partitionNumbers)
                        {

                            condition = conditionCounter > Variables.partitionSize * (i - 1);

                        }
                        else
                        {

                            condition = (conditionCounter > Variables.partitionSize * (i - 1)) & (conditionCounter <= Variables.partitionSize * i);

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

                                    List<GeneName> geneNameList = new List<GeneName>();
                                    foreach (string name in geneNameHashSet)
                                    {
                                        GeneName GeneName = new GeneName();
                                        GeneName.name = name.Trim();
                                        geneNameList.Add(GeneName);
                                    }
                                    gene.geneNames = string.Join("|", geneNameList);

                                    List<PublicationMention> publicationMentions_list = new List<PublicationMention>();
                                    PublicationMention publicationMention = new PublicationMention();
                                    publicationMention.pmId = values[0].Trim();
                                    publicationMention.ressource = values[4].Trim();
                                    publicationMentions_list.Add(publicationMention);
                                    gene.publicationMentions = publicationMentions_list;

                                    gene_list.Add(gene);   

                                    recordIdCounter++;

                                }
                            
                            }
                            
                        }

                        conditionCounter++;

                    }

                }

                Console.WriteLine("Gene list length: " + gene_list.Count);
                    
                Methods.createXml(gene_list: gene_list, fileName: "gene2pubtatorcentral_" + i + "_dt.xml", directory: gene2PubtatorcentralOutputDirectory + "/" + Variables.partitionNumbers.ToString());
                Methods.createTsv(gene_list: gene_list, fileName: "gene2pubtatorcentral_" + i + "_dt.tsv", directory: gene2PubtatorcentralOutputDirectory + "/" + Variables.partitionNumbers.ToString());
 
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

        // gespiegelte partitionierung
        public static void pubMedDate_dt()
        {

            Genes genes = new Genes();
            List<Gene> gene_list = new List<Gene>();

            using (var reader = new StreamReader(string.Format("{0}/{1}/{2}", Environment.CurrentDirectory, gene2PubtatorcentralInputDirectory, "PubMedDate.csv")))
            {

                reader.ReadLine();
                int counter = 1;
                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();
                    String[] values = line.Split(",");

                    Gene gene = new Gene();
                    gene.recordId = string.Format("pubMedDate_{0}_rid", counter);

                    List<PublicationMention> publicationMentions_list = new List<PublicationMention>();
                    PublicationMention publicationMention = new PublicationMention();
                    publicationMention.pmId = values[0].Trim();
                    publicationMention.year = values[1].Trim();
                    publicationMentions_list.Add(publicationMention);
                    gene.publicationMentions = publicationMentions_list;

                    gene_list.Add(gene);

                    counter++;

                }

            }

            Methods.createXml(gene_list: gene_list, fileName: "PubMedDate_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list, fileName: "PubMedDate_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

        }

    }

}