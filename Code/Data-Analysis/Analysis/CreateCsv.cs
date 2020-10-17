using System;
using System.Collections.Generic;
using System.IO;

namespace Analysis
{
    class CreateCsv
    {
        public static void run() {

            List<string> inputFileNameList = new List<string>()
            {
                Environment.CurrentDirectory + "/data/input/fused-brain.xml",
                Environment.CurrentDirectory + "/data/input/fused-cerebellum.xml",
                Environment.CurrentDirectory + "/data/input/fused-heart.xml",
                Environment.CurrentDirectory + "/data/input/fused-liver.xml",
                Environment.CurrentDirectory + "/data/input/fused-kidney.xml",
                Environment.CurrentDirectory + "/data/input/fused-testis.xml"
            };

            String outputDirectory = Environment.CurrentDirectory + "/data/output";
            Directory.CreateDirectory(outputDirectory);

            foreach (var inputFileName in inputFileNameList)
            {
                String outputFileName = string.Format("{0}/{1}.tsv",
                    outputDirectory,
                    inputFileName.Substring(inputFileName.LastIndexOf("/") + 1, inputFileName.LastIndexOf(".") - 1)
                );

                using (StreamWriter sw = new StreamWriter(outputFileName)) 
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

                    foreach (Gene brainGene in Genes.getGenes(inputFileName))
                    {
                    }
                }
            }
        }
    }
}