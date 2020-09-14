using System.Collections.Generic;
using System.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Analysis
{
    public class Analysis1
    {
        public string UniqueGene;
        public string Brain;
        public string Cerebellum;
        public string Heart;
        public string Liver;
        public string Kidney;
        public string Testis;
        public string OverallExpression;

        
        public static void run() {

            string brainFileName = Environment.CurrentDirectory + "/data/fused-kaessmann-brain.xml";
            string kidneyFileName = Environment.CurrentDirectory + "/data/fused-kaessmann-kidney.xml";     
            string liverFileName = Environment.CurrentDirectory + "/data/fused-kaessmann-liver.xml";
            string testisFileName = Environment.CurrentDirectory + "/data/fused-kaessmann-testis.xml";

            List<Analysis1> Analysis1List = new List<Analysis1>();

            foreach (Gene brainGene in Genes.getGenes(brainFileName))
            {
                Analysis1 analysis1 = new Analysis1();

                analysis1.UniqueGene = brainGene.ensemblId;
                analysis1.Brain = getExpression(brainGene.call);

                foreach (Gene kidneyGene in Genes.getGenes(kidneyFileName))
                {
                    if (kidneyGene.ensemblId.Equals(analysis1.UniqueGene))
                    {
                        analysis1.Kidney = getExpression(kidneyGene.call);
                    }
                }

                foreach (Gene liverGene in Genes.getGenes(liverFileName))
                {
                    if (liverGene.ensemblId.Equals(analysis1.UniqueGene))
                    {
                        analysis1.Liver = getExpression(liverGene.call);
                    }
                }

                foreach (Gene testisGene in Genes.getGenes(testisFileName))
                {
                    if (testisGene.ensemblId.Equals(analysis1.UniqueGene))
                    {
                        analysis1.Testis = getExpression(testisGene.call);
                    }
                }

                analysis1.OverallExpression = getOverallExpression(analysis1);

                Analysis1List.Add(analysis1);
            }

            writeToTable(Analysis1List);
        }

        public static void writeToTable(List<Analysis1> Analysis1List)
        {
            String outputDirectory = Environment.CurrentDirectory + "/data/output/analysis1";
            Directory.CreateDirectory(outputDirectory);

            var tsvFile = new StringBuilder();
            var delimiter = "\t";
            List<string> firstLineContent = new List<string>()
            {
                        "UniqueGene",
                        "Brain",
                        "Kidney",
                        "Liver",
                        "Testis"
            };
            var firstLine = string.Join(delimiter, firstLineContent);
            tsvFile.AppendLine(firstLine);

            foreach (Analysis1 analysis1 in Analysis1List)
            {
                List<string> itemContent = new List<string>()
                {
                    analysis1.UniqueGene,
                    analysis1.Brain,
                    analysis1.Kidney,
                    analysis1.Liver,
                    analysis1.Testis
                };
                var inputLine = string.Join(delimiter, itemContent);
                tsvFile.AppendLine(inputLine);             
            }

            String fileName = outputDirectory + "/analysis1.tsv";
            File.WriteAllText(fileName, tsvFile.ToString());
        }

        public static string getExpression(string input)
        {
            string returnValue = "N/A";
            if (input.Equals("Different"))
            {
                returnValue = "0";
            }
            else if (input.Equals("Same"))
            {
                returnValue = "1";
            }
            return returnValue;
        }

        public static string getOverallExpression(Analysis1 analysis1)
        {
            string returnValue = string.Empty;

            bool contains1 = false;
            bool contains0 = false;
            bool containsNA = false;

            List<string> organList = new List<string>();
            organList.Add(analysis1.Brain);
            organList.Add(analysis1.Kidney);
            organList.Add(analysis1.Liver);
            organList.Add(analysis1.Testis);

            foreach (string organ in organList)
            {
                if (organ == "0")
                {
                    contains0 = true;
                }
                else if (organ.Equals("1"))
                {
                    contains1 = true;
                }
                else if (organ.Equals("N/A"))
                {
                    containsNA = true;
                }
            }

            if (contains1 == true && contains0 == false && containsNA == false)
            {
                returnValue = "1";
            }

            if (contains1 == false && contains0 == true && containsNA == false)
            {
                returnValue = "0";
            }

            if (contains1 == false && contains0 == false && containsNA == true)
            {
                returnValue = "N/A";
            }

            if (contains1 == true && contains0 == true && containsNA == true)
            {
                returnValue = "N/A";
            }

            if (contains1 == true && contains0 == true && containsNA == false)
            {
                returnValue = "N/A";
            }

            if (contains1 == true && contains0 == true && containsNA == true)
            {
                returnValue = "0";
            }

            return returnValue;
        }
    }
}