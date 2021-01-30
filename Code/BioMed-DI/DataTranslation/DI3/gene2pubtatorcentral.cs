using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DataTranslation
{

    public class gene2pubtatorcentral
    {

        public static void runDataTranslationSingleOutput()
        {

            List<Gene> gene_list = new List<Gene>();

            Console.WriteLine("Run Data Translation!");

            using (var reader = new StreamReader(DI3.inputDirectory + "/gene2pubtatorcentral.tsv"))
            {

                reader.ReadLine();

                int recordIdCounter = 1;

                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();

                    String[] values = line.Split('\t');

                    if (values[1].Trim().Equals("Gene"))
                    {

                        string[] ncbiIdArray = values[2].Split(';');

                        foreach (String ncbiId in ncbiIdArray)
                        {

                            Gene gene = new Gene();

                            gene.recordId = string.Format("gene2pubtatorcentral_{0}_rid", recordIdCounter);

                            gene.ncbiId = ncbiId;

                            HashSet<string> geneNameHashSet = getGeneNameHashSet(values[3]);

                            gene.geneNames = string.Join("|", geneNameHashSet);


                            List<GenePublicationMention> publicationList = new List<GenePublicationMention>();

                            GenePublicationMention publication = new GenePublicationMention();

                            publication.pmId = values[0].Trim();

                            publication.ressource = values[4].Trim();

                            publication.associatedNcbiId = ncbiId;

                            publicationList.Add(publication);


                            gene.publicationMentions = publicationList;


                            gene_list.Add(gene);


                            recordIdCounter++;

                        }

                    }

                }

            }

            Output.createXml(gene_list: gene_list, file: new FileInfo(DI3.outputDirectory + "/gene2pubtatorcentral_dt.xml"));

            Output.createTsv(gene_list: gene_list, file: new FileInfo(DI3.outputDirectory + "/gene2pubtatorcentral_dt.tsv"));

        }

        public static void runDataTranslationMultipleOutputs()
        {

            Console.WriteLine("Run Data Translation!");

            for (int i = 1; i <= gene2pubtatorcentralPartitioningVariables.partitionNumbers; i++)
            {

                List<Gene> gene_list = new List<Gene>();

                using (var reader = new StreamReader(DI3.inputDirectory + "/gene2pubtatorcentral.tsv"))
                {

                    reader.ReadLine();

                    int conditionCounter = 1;

                    int recordIdCounter = 1;

                    while (!reader.EndOfStream)
                    {

                        var line = reader.ReadLine();

                        String[] values = line.Split('\t');

                        bool condition;

                        if (i == gene2pubtatorcentralPartitioningVariables.partitionNumbers)
                        {

                            condition = conditionCounter > gene2pubtatorcentralPartitioningVariables.partitionSize * (i - 1);

                        }
                        else
                        {

                            condition = (conditionCounter > gene2pubtatorcentralPartitioningVariables.partitionSize * (i - 1)) & (conditionCounter <= gene2pubtatorcentralPartitioningVariables.partitionSize * i);

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

                                    publication.associatedNcbiId = ncbiId;

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

                Output.createXml(gene_list: gene_list, file: new FileInfo(DI3.outputDirectory + "/gene2pubtatorcentral_" + i + "_dt.xml"));

                Output.createTsv(gene_list: gene_list, file: new FileInfo(DI3.outputDirectory + "/gene2pubtatorcentral_" + i + "_dt.tsv"));

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