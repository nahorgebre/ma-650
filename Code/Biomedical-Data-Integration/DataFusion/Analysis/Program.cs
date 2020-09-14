using System;
using System.Collections.Generic;
using System.IO;

namespace Analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            analysis1();
        }

        public static void analysis1()
        {

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
            

            foreach (string fileName in fileNameList)
            {
                List<Gene> geneList = Genes.getGenes(fileName);

                List<Analysis1> Analysis1List = new List<Analysis1>();

                foreach (Gene gene in geneList)
                {
                    Analysis1 analysis1 = new Analysis1();

                    analysis1.UniqueGene = gene.ensemblId;
                    

                    Analysis1List.Add(analysis1);        
                }

            }
            
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
            string returnValue = "N/A";
            
        }
    }
}
