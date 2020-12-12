using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace Analysis
{

    public class Methods
    {

        public static void createXmlGene(List<Gene> gene_list)
        {

            FileInfo file = new FileInfo(string.Format("{0}/data/output/analysis1.xml", Environment.CurrentDirectory));

            Console.WriteLine("Create Xml: " + file.Name);

            Console.WriteLine("Count: " + gene_list.Count);

            file.Directory.Create();

            XmlSerializer serializer = new XmlSerializer(typeof(Genes));

            TextWriter writer = new StreamWriter(file.FullName);

            Genes genes = new Genes();

            genes.gene = gene_list;

            serializer.Serialize(writer, genes);

            writer.Close();

            Console.WriteLine(file.FullName);

        }

                
        public static void createTsvFile(List<Gene> geneList)
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

                foreach (Gene geneItem in geneList)
                {
                    string UniqueGene = geneItem.ensemblId;

                    string Brain = string.Empty;
                    string Cerebellum = string.Empty;
                    string Heart = string.Empty;
                    string Liver = string.Empty;
                    string Kidney = string.Empty;
                    string Testis = string.Empty;
                    string OverallExpression = string.Empty;
 
                    foreach (Organ organItem in geneItem.organs)
                    {
                        if (organItem.organName.Equals("brain"))
                        {
                            Brain = organItem.call;
                        }
                        else if (organItem.organName.Equals("cerebellum"))
                        {
                            Cerebellum = organItem.call;
                        }
                        else if (organItem.organName.Equals("heart"))
                        {
                            Heart = organItem.call;
                        }
                        else if (organItem.organName.Equals("liver"))
                        {
                            Liver = organItem.call;
                        }
                        else if (organItem.organName.Equals("kidney"))
                        {
                            Kidney = organItem.call;
                        }
                        else if (organItem.organName.Equals("testis"))
                        {
                            Testis = organItem.call;
                        }
                        else if (organItem.organName.Equals("overallExpression"))
                        {
                            OverallExpression = organItem.call;
                        }
                    }

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