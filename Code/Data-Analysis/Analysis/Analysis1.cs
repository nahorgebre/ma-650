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
        /*
        public string UniqueGene;
        public string Brain = "N/A";
        //public string Cerebellum = "N/A";
        //public string Heart = "N/A";
        public string Liver = "N/A";
        public string Kidney = "N/A";
        public string Testis = "N/A";
        public string OverallExpression;

        public static void run() {
            
            string brainInput = Environment.CurrentDirectory + "/data/fused-kaessmann-brain.xml";
            string cerebellumInput = Environment.CurrentDirectory + "/data/fused-kaessmann-cerebellum.xml";
            string heartInput = Environment.CurrentDirectory + "/data/fused-kaessmann-heart.xml";          
            string liverInput = Environment.CurrentDirectory + "/data/fused-kaessmann-liver.xml";
            string kidneyInput = Environment.CurrentDirectory + "/data/fused-kaessmann-kidney.xml";
            string testisInput = Environment.CurrentDirectory + "/data/fused-kaessmann-testis.xml";

            String outputDirectory = Environment.CurrentDirectory + "/data/output";
            Directory.CreateDirectory(outputDirectory);

            string fileName = outputDirectory + "/analysis1.tsv";
            using (StreamWriter sw = new StreamWriter(fileName)) 
            {
                var delimiter = "\t";
                List<string> firstLineContent = new List<string>()
                {
                    "UniqueGene",
                    "Brain",
                    //"Cerebellum",
                    //"Heart",
                    "Liver",
                    "Kidney",
                    "Testis",
                    "OverallExpression"
                };
                var firstLine = string.Join(delimiter, firstLineContent);
                sw.WriteLine(firstLine);

                foreach (Gene brainGene in Genes.getGenes(brainInput))
                {
                    Analysis1 analysis1 = new Analysis1();

                    analysis1.UniqueGene = brainGene.ensemblId;
                    analysis1.Brain = getExpression(brainGene.call);

                    foreach (Gene kidneyGene in Genes.getGenes(kidneyInput))
                    {
                        if (kidneyGene.ensemblId.Equals(analysis1.UniqueGene))
                        {
                            analysis1.Kidney = getExpression(kidneyGene.call);
                        }
                    }

                    foreach (Gene liverGene in Genes.getGenes(liverInput))
                    {
                        if (liverGene.ensemblId.Equals(analysis1.UniqueGene))
                        {
                            analysis1.Liver = getExpression(liverGene.call);
                        }
                    }

                    foreach (Gene testisGene in Genes.getGenes(testisInput))
                    {
                        if (testisGene.ensemblId.Equals(analysis1.UniqueGene))
                        {
                            analysis1.Testis = getExpression(testisGene.call);
                        }
                    }

                    analysis1.OverallExpression = getOverallExpression(analysis1);

                    List<string> itemContent = new List<string>()
                    {
                        analysis1.UniqueGene,
                        analysis1.Brain,
                        analysis1.Liver,
                        analysis1.Kidney,
                        analysis1.Testis,
                        analysis1.OverallExpression
                    };
                    
                    var inputLine = string.Join(delimiter, itemContent);
                    sw.WriteLine(inputLine);

                    Console.WriteLine(inputLine);
                    
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
            string returnValue = string.Empty;
            
            bool contains1 = false;
            bool contains0 = false;

            List<string> organList = new List<string>();
            organList.Add(analysis1.Brain.ToString());          
            organList.Add(analysis1.Liver.ToString());
            organList.Add(analysis1.Kidney.ToString());
            organList.Add(analysis1.Testis.ToString());

            foreach (string organ in organList)
            {
                if (organ.Equals("0"))
                {
                    contains0 = true;
                }
                else if (organ.Equals("1"))
                {
                    contains1 = true;
                }
            }

            if (contains0 == true)
            {
                if (contains1 == true)
                {
                    returnValue = "N/A";
                }            
            }

            if (contains0 == true)
            {
                if (contains1 == false)
                {
                    returnValue = "0";
                }         
            }

            if (contains0 == false)
            {
                if (contains1 == true)
                {
                   returnValue = "1"; 
                }            
            }

            return returnValue;
        }
        */
    }
}