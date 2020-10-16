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
            Publication.pubMedDate_dt();
        }

        public static string gene2PubtatorcentralInputDirectory = "data/input/Gene2Pubtatorcentral";
        public static string gene2PubtatorcentralOutputDirectory = "data/output/Gene2Pubtatorcentral";

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

        // 15 output files - (54.367.006 - 1) / 15 = 54.367.005 / 15 = 3.624.467
        public static void gene2pubtatorcentral_dt()
        {
            Genes genes = new Genes();

            int partitionSize = 3624467;

            List<Gene> gene_list_1 = new List<Gene>();
            List<Gene> gene_list_2 = new List<Gene>();
            List<Gene> gene_list_3 = new List<Gene>();
            List<Gene> gene_list_4 = new List<Gene>();
            List<Gene> gene_list_5 = new List<Gene>();
            List<Gene> gene_list_6 = new List<Gene>();
            List<Gene> gene_list_7 = new List<Gene>();
            List<Gene> gene_list_8 = new List<Gene>();
            List<Gene> gene_list_9 = new List<Gene>();
            List<Gene> gene_list_10 = new List<Gene>();
            List<Gene> gene_list_11 = new List<Gene>();
            List<Gene> gene_list_12 = new List<Gene>();
            List<Gene> gene_list_13 = new List<Gene>();
            List<Gene> gene_list_14 = new List<Gene>();
            List<Gene> gene_list_15 = new List<Gene>();

            using (var reader = new StreamReader(string.Format("{0}/{1}/{2}", Environment.CurrentDirectory, gene2PubtatorcentralInputDirectory, "gene2pubtatorcentral.tsv")))
            {
                reader.ReadLine();
                int counter = 1;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split('\t');

                    if (values[1].Trim().Equals("Gene"))
                    {
                        Gene gene = new Gene();
                        gene.ncbiId = values[2].Trim();

                        string[] geneNames = values[3].Split('|');
                        List<GeneName> geneNameList = new List<GeneName>();
                        foreach (string name in geneNames)
                        {
                            GeneName GeneName = new GeneName();
                            GeneName.name = name.Trim();
                            geneNameList.Add(GeneName);
                        }
                        gene.geneNames = geneNameList;

                        List<PublicationMention> publicationMentions_list = new List<PublicationMention>();
                        PublicationMention publicationMention = new PublicationMention();
                        publicationMention.pmId = values[0].Trim();
                        publicationMention.ressource = values[4].Trim();
                        publicationMentions_list.Add(publicationMention);
                        gene.publicationMentions = publicationMentions_list;

                        if (counter <= partitionSize)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 1.ToString(), counter);
                            gene_list_1.Add(gene);
                        }
                        else if (counter <= partitionSize * 2)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 2.ToString(), counter);
                            gene_list_2.Add(gene);
                        }
                        else if (counter <= partitionSize * 3)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 3.ToString(), counter);
                            gene_list_3.Add(gene);
                        }
                        else if (counter <= partitionSize * 4)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 4.ToString(), counter);
                            gene_list_4.Add(gene);
                        }
                        else if (counter <= partitionSize * 5)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 5.ToString(), counter);
                            gene_list_5.Add(gene);
                        }
                        else if (counter <= partitionSize * 6)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 6.ToString(), counter);
                            gene_list_6.Add(gene);
                        }
                        else if (counter <= partitionSize * 7)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 7.ToString(), counter);
                            gene_list_7.Add(gene);
                        }
                        else if (counter <= partitionSize * 8)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 8.ToString(), counter);
                            gene_list_8.Add(gene);
                        }
                        else if (counter <= partitionSize * 9)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 9.ToString(), counter);
                            gene_list_9.Add(gene);
                        }
                        else if (counter <= partitionSize * 10)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 10.ToString(), counter);
                            gene_list_10.Add(gene);
                        }
                        else if (counter <= partitionSize * 11)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 11.ToString(), counter);
                            gene_list_11.Add(gene);
                        }
                        else if (counter <= partitionSize * 12)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 12.ToString(), counter);
                            gene_list_12.Add(gene);
                        }
                        else if (counter <= partitionSize * 13)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 13.ToString(), counter);
                            gene_list_13.Add(gene);
                        }
                        else if (counter <= partitionSize * 14)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 14.ToString(), counter);
                            gene_list_14.Add(gene);
                        }
                        else if (counter > partitionSize * 14)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 15.ToString(), counter);
                            gene_list_15.Add(gene);
                        }

                        counter++;
                    }

                }
            }


            Methods.createXml(gene_list: gene_list_1, fileName: "gene2pubtatorcentral_1_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_1, fileName: "gene2pubtatorcentral_1_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_2, fileName: "gene2pubtatorcentral_2_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_2, fileName: "gene2pubtatorcentral_2_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_3, fileName: "gene2pubtatorcentral_3_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_3, fileName: "gene2pubtatorcentral_3_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_4, fileName: "gene2pubtatorcentral_4_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_4, fileName: "gene2pubtatorcentral_4_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_5, fileName: "gene2pubtatorcentral_5_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_5, fileName: "gene2pubtatorcentral_5_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_6, fileName: "gene2pubtatorcentral_6_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_6, fileName: "gene2pubtatorcentral_6_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_7, fileName: "gene2pubtatorcentral_7_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_7, fileName: "gene2pubtatorcentral_7_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_8, fileName: "gene2pubtatorcentral_8_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_8, fileName: "gene2pubtatorcentral_8_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_9, fileName: "gene2pubtatorcentral_9_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_9, fileName: "gene2pubtatorcentral_9_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_10, fileName: "gene2pubtatorcentral_10_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_10, fileName: "gene2pubtatorcentral_10_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_11, fileName: "gene2pubtatorcentral_11_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_11, fileName: "gene2pubtatorcentral_11_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_12, fileName: "gene2pubtatorcentral_12_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_12, fileName: "gene2pubtatorcentral_12_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_13, fileName: "gene2pubtatorcentral_13_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_13, fileName: "gene2pubtatorcentral_13_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_14, fileName: "gene2pubtatorcentral_14_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_14, fileName: "gene2pubtatorcentral_14_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_15, fileName: "gene2pubtatorcentral_15_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_15, fileName: "gene2pubtatorcentral_15_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

        }

        public static void gene2pubtatorcentral_dt2()
        {
            Genes genes = new Genes();
            List<Gene> gene_list = new List<Gene>();

            using (var reader = new StreamReader(string.Format("{0}/{1}/{2}", Environment.CurrentDirectory, gene2PubtatorcentralInputDirectory, "gene2pubtatorcentral.tsv")))
            {
                reader.ReadLine();
                int counter = 1;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split('\t');

                    if (values[1].Trim().Equals("Gene"))
                    {
                        Gene gene = new Gene();
                        gene.recordId = string.Format("gene2pubtatorcentral_{0}_rid", counter);
                        gene.ncbiId = values[2].Trim();

                        string[] geneNames = values[3].Split('|');
                        List<GeneName> geneNameList = new List<GeneName>();
                        foreach (string name in geneNames)
                        {
                            GeneName GeneName = new GeneName();
                            GeneName.name = name.Trim();
                            geneNameList.Add(GeneName);
                        }
                        gene.geneNames = geneNameList;

                        List<PublicationMention> publicationMentions_list = new List<PublicationMention>();
                        PublicationMention publicationMention = new PublicationMention();
                        publicationMention.pmId = values[0].Trim();
                        publicationMention.ressource = values[4].Trim();
                        publicationMentions_list.Add(publicationMention);
                        gene.publicationMentions = publicationMentions_list;

                        gene_list.Add(gene);

                        counter++;
                    }
                }
            }
            Methods.createXml(gene_list: gene_list, fileName: "gene2pubtatorcentral_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list, fileName: "gene2pubtatorcentral_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);
        }
    }
}