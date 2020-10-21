using System;
using System.Collections.Generic;
using System.IO;

namespace Analysis
{

    public class Analysis1_2
    {

        public static void run()
        {

            FileInfo outputFile = new FileInfo(string.Format("{0}/data/output/analysis1.tsv", Environment.CurrentDirectory));
            using (StreamWriter sw = new StreamWriter(outputFile.FullName))
            {
                var delimiter = "\t";
                List<string> firstLineContent = new List<string>()
                {
                    "UniqueGene",
                    "Brain",
                    "Cerebellum",
                    "Heart",
                    "Liver",
                    "Kidney",
                    "Testis",
                    "OverallExpression"
                };
                var firstLine = string.Join(delimiter, firstLineContent);
                sw.WriteLine(firstLine);

                FileInfo inputFile = new FileInfo(string.Format("{0}/data/input/kaessmann-fused.xml", Environment.CurrentDirectory));
                foreach (Gene geneItem in Genes.getGenes(inputFile.FullName))
                {
                    string UniqueGene = geneItem.ensemblId;

                    string Brain = "N/A";
                    string Cerebellum = "N/A";
                    string Heart = "N/A";
                    string Liver = "N/A";
                    string Kidney = "N/A";
                    string Testis = "N/A";
 
                    foreach (Organ organItem in geneItem.organs)
                    {
                        if (organItem.organName.Equals("brain"))
                        {
                            Brain = getExpression(organItem.call);
                        }
                        else if (organItem.organName.Equals("cerebellum"))
                        {
                            Cerebellum = getExpression(organItem.call);
                        }
                        else if (organItem.organName.Equals("heart"))
                        {
                            Heart = getExpression(organItem.call);
                        }
                        else if (organItem.organName.Equals("liver"))
                        {
                            Liver = getExpression(organItem.call);
                        }
                        else if (organItem.organName.Equals("kidney"))
                        {
                            Kidney = getExpression(organItem.call);
                        }
                        else if (organItem.organName.Equals("testis"))
                        {
                            Testis = getExpression(organItem.call);
                        }
                    }

                    List<string> expressionList = new List<string>();
                    expressionList.Add(Brain);
                    expressionList.Add(Cerebellum);
                    expressionList.Add(Heart);
                    expressionList.Add(Liver);
                    expressionList.Add(Kidney);
                    expressionList.Add(Testis);

                    string OverallExpression = getOverallExpression(expressionList);

                    List<string> lineContent = new List<string>()
                    {
                        UniqueGene,
                        Brain,
                        Cerebellum,
                        Heart,
                        Liver,
                        Kidney,
                        Testis,
                        OverallExpression
                    };
                    var line = string.Join(delimiter, lineContent);
                    sw.WriteLine(line);
                }

            }

        }

        public static string getOverallExpression(List<string> expressionList)
        {
            string returnValue = string.Empty;
            
            bool contains1 = false;
            bool contains0 = false;

            
            foreach (string expression in expressionList)
            {
                if (expression.Equals("0"))
                {
                    contains0 = true;
                }
                else if (expression.Equals("1"))
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

    }

}