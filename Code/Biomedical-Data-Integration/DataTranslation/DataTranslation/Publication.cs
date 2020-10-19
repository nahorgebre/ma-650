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
        
        // 15 output files - (54.367.006 - 1) / 15 = 54.367.005 / 15 = 3.624.467
        // 30 output files - (54.367.006 - 1) / 30 = 54.367.005 / 35 = 1.553.343
        public static void gene2pubtatorcentral_dt()
        {
            Genes genes = new Genes();

            int partitionSize = 1553343;

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
            List<Gene> gene_list_16 = new List<Gene>();
            List<Gene> gene_list_17 = new List<Gene>();
            List<Gene> gene_list_18 = new List<Gene>();
            List<Gene> gene_list_19 = new List<Gene>();
            List<Gene> gene_list_20 = new List<Gene>();
            List<Gene> gene_list_21 = new List<Gene>();
            List<Gene> gene_list_22 = new List<Gene>();
            List<Gene> gene_list_23 = new List<Gene>();
            List<Gene> gene_list_24 = new List<Gene>();
            List<Gene> gene_list_25 = new List<Gene>();
            List<Gene> gene_list_26 = new List<Gene>();
            List<Gene> gene_list_27 = new List<Gene>();
            List<Gene> gene_list_28 = new List<Gene>();
            List<Gene> gene_list_29 = new List<Gene>();
            List<Gene> gene_list_30 = new List<Gene>();
            List<Gene> gene_list_31 = new List<Gene>();
            List<Gene> gene_list_32 = new List<Gene>();
            List<Gene> gene_list_33 = new List<Gene>();
            List<Gene> gene_list_34 = new List<Gene>();
            List<Gene> gene_list_35 = new List<Gene>();

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
                        else if (counter <= partitionSize * 15)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 15.ToString(), counter);
                            gene_list_15.Add(gene);
                        }
                        else if (counter <= partitionSize * 16)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 16.ToString(), counter);
                            gene_list_16.Add(gene);
                        }
                        else if (counter <= partitionSize * 17)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 17.ToString(), counter);
                            gene_list_17.Add(gene);
                        }
                        else if (counter <= partitionSize * 18)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 18.ToString(), counter);
                            gene_list_18.Add(gene);
                        }
                        else if (counter <= partitionSize * 19)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 19.ToString(), counter);
                            gene_list_19.Add(gene);
                        }
                        else if (counter <= partitionSize * 20)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 20.ToString(), counter);
                            gene_list_20.Add(gene);
                        }
                        else if (counter <= partitionSize * 21)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 21.ToString(), counter);
                            gene_list_21.Add(gene);
                        }
                        else if (counter <= partitionSize * 22)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 22.ToString(), counter);
                            gene_list_22.Add(gene);
                        }
                        else if (counter <= partitionSize * 23)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 23.ToString(), counter);
                            gene_list_23.Add(gene);
                        }
                        else if (counter <= partitionSize * 24)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 24.ToString(), counter);
                            gene_list_24.Add(gene);
                        }
                        else if (counter <= partitionSize * 25)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 25.ToString(), counter);
                            gene_list_25.Add(gene);
                        }
                        else if (counter <= partitionSize * 26)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 26.ToString(), counter);
                            gene_list_26.Add(gene);
                        }
                        else if (counter <= partitionSize * 27)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 27.ToString(), counter);
                            gene_list_27.Add(gene);
                        }
                        else if (counter <= partitionSize * 28)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 28.ToString(), counter);
                            gene_list_28.Add(gene);
                        }
                        else if (counter <= partitionSize * 29)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 29.ToString(), counter);
                            gene_list_29.Add(gene);
                        }
                        else if (counter <= partitionSize * 30)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 30.ToString(), counter);
                            gene_list_30.Add(gene);
                        }
                        else if (counter <= partitionSize * 31)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 31.ToString(), counter);
                            gene_list_31.Add(gene);
                        }
                        else if (counter <= partitionSize * 32)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 32.ToString(), counter);
                            gene_list_32.Add(gene);
                        }
                        else if (counter <= partitionSize * 33)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 33.ToString(), counter);
                            gene_list_33.Add(gene);
                        }
                        else if (counter <= partitionSize * 34)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 34.ToString(), counter);
                            gene_list_34.Add(gene);                        
                        }
                        else if (counter > partitionSize * 34)
                        {
                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_{1}_rid", 35.ToString(), counter);
                            gene_list_35.Add(gene);
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

            Methods.createXml(gene_list: gene_list_16, fileName: "gene2pubtatorcentral_16_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_16, fileName: "gene2pubtatorcentral_16_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_17, fileName: "gene2pubtatorcentral_17_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_17, fileName: "gene2pubtatorcentral_17_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_18, fileName: "gene2pubtatorcentral_18_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_18, fileName: "gene2pubtatorcentral_18_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_19, fileName: "gene2pubtatorcentral_19_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_19, fileName: "gene2pubtatorcentral_19_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_20, fileName: "gene2pubtatorcentral_20_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_20, fileName: "gene2pubtatorcentral_20_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_21, fileName: "gene2pubtatorcentral_21_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_21, fileName: "gene2pubtatorcentral_21_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_22, fileName: "gene2pubtatorcentral_22_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_22, fileName: "gene2pubtatorcentral_22_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_23, fileName: "gene2pubtatorcentral_23_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_23, fileName: "gene2pubtatorcentral_23_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_24, fileName: "gene2pubtatorcentral_24_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_24, fileName: "gene2pubtatorcentral_24_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_25, fileName: "gene2pubtatorcentral_25_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_25, fileName: "gene2pubtatorcentral_25_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_26, fileName: "gene2pubtatorcentral_26_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_26, fileName: "gene2pubtatorcentral_26_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_27, fileName: "gene2pubtatorcentral_27_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_27, fileName: "gene2pubtatorcentral_27_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_28, fileName: "gene2pubtatorcentral_28_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_28, fileName: "gene2pubtatorcentral_28_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_29, fileName: "gene2pubtatorcentral_29_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_29, fileName: "gene2pubtatorcentral_29_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_30, fileName: "gene2pubtatorcentral_30_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_30, fileName: "gene2pubtatorcentral_30_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

            Methods.createXml(gene_list: gene_list_31, fileName: "gene2pubtatorcentral_31_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_31, fileName: "gene2pubtatorcentral_31_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);
            
            Methods.createXml(gene_list: gene_list_32, fileName: "gene2pubtatorcentral_32_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_32, fileName: "gene2pubtatorcentral_32_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);
            
            Methods.createXml(gene_list: gene_list_33, fileName: "gene2pubtatorcentral_33_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_33, fileName: "gene2pubtatorcentral_33_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);
            
            Methods.createXml(gene_list: gene_list_34, fileName: "gene2pubtatorcentral_34_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_34, fileName: "gene2pubtatorcentral_34_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);
            
            Methods.createXml(gene_list: gene_list_35, fileName: "gene2pubtatorcentral_35_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
            Methods.createTsv(gene_list: gene_list_35, fileName: "gene2pubtatorcentral_35_dt.tsv", directory: gene2PubtatorcentralOutputDirectory);

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