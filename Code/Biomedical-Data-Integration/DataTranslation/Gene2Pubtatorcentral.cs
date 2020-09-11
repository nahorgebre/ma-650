using System;
using System.IO;
using System.Collections.Generic;

namespace DataTranslation
{
    public class Gene2Pubtatorcentral
    {
        public static string gene2PubtatorcentralInputDirectory = "data/input/Gene2Pubtatorcentral";
        public static string gene2PubtatorcentralOutputDirectory = "data/output/Gene2Pubtatorcentral";

        public static void gene2pubtatorcentral_dt()
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
                        List<geneName> geneNameList = new List<geneName>();
                        foreach (string name in geneNames)
                        {
                            geneName GeneName = new geneName();
                            GeneName.name = name.Trim();
                            geneNameList.Add(GeneName);
                        }
                        gene.geneNames = geneNameList;

                        List<PublicationMention> publicationMentions_list = new List<PublicationMention>();
                        PublicationMention publicationMention = new PublicationMention();
                        publicationMention.pmid = values[0].Trim();
                        publicationMention.ressource = values[4].Trim();
                        publicationMentions_list.Add(publicationMention);
                        gene.publicationMentions = publicationMentions_list;

                        gene_list.Add(gene);

                        counter++;
                    }
                }
            }
            Methods.createXml(gene_list: gene_list, fileName: "gene2pubtatorcentral_dt.xml", directory: gene2PubtatorcentralOutputDirectory);
        }
    }
}