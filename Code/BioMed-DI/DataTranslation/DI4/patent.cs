using System;
using System.IO;
using System.Collections.Generic;

namespace DataTranslation
{

    public class patent
    {

        public static void runDataTranslationSingleOutput()
        {

            List<Gene> abstract_gene_list = getPatentGeneList(new FileInfo(DI4.inputDirectory + "/scispaCyAbstractGene.csv"), "abstract");

            Output.createXml(gene_list: abstract_gene_list, file: new FileInfo(DI4.outputDirectory + "/patent_abstract_dt.xml"));

            Output.createTsv(gene_list: abstract_gene_list, file: new FileInfo(DI4.outputDirectory + "/patent_abstract_dt.tsv"));

        }

        public static List<Gene> getPatentGeneList(FileInfo inputFile, string chapter)
        {

            List<Gene> gene_list = new List<Gene>();

            using (StreamReader sr = new StreamReader(inputFile.FullName))
            {
                
                sr.ReadLine();

                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] lineValues = line.Split('\t');

                    if (!string.IsNullOrEmpty(lineValues[2]))
                    {

                        if (lineValues[2].Contains('|'))
                        {

                            foreach (string geneName in lineValues[2].Split('|'))
                            {

                                Gene gene = new Gene();

                                gene.geneNames = geneName;


                                List<GenePatentMention> patentMentionList = new List<GenePatentMention>();

                                GenePatentMention patentMention = new GenePatentMention();

                                patentMention.patentId = lineValues[0];

                                patentMention.patentDate = lineValues[1];

                                patentMentionList.Add(patentMention);


                                gene.patentMentions = patentMentionList;


                                gene_list.Add(gene);
                                
                            }
                            
                        }
                        
                    }
                    
                }

            }

            return gene_list;

        }

    }

}