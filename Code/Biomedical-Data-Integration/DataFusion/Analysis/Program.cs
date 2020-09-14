using System;
using System.Collections.Generic;
using System.IO;

namespace Analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static void CreateAnalysis1ResultFile()
        {
            List<string> fileNameList = new List<string>();

            foreach (string fileName in Directory.GetFiles(Environment.CurrentDirectory + "/data/"))
            {
                fileNameList.Add(fileName);
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
    }
}
