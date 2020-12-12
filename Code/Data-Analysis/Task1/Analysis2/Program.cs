using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Analysis2
{

    class Program
    {

        static void Main(string[] args)
        {

            /*

            List<int> yearList = PubMedYear.getSortedYearList();

            var delimiter = "\t";

            for (int i = yearList.Count() - 2; i > yearList.Count() - 100; i--)
            {

                //Console.WriteLine("");

                //Console.WriteLine("                     " + "\"" + yearList[i] + "\",");

                //Console.WriteLine("        public int year" + yearList[i] + " = 0;");

                //Console.WriteLine("                        output.year" + yearList[i] + ".ToString(),");

                Console.WriteLine("                        else if (publicationMentionItem.year.Equals(\"" + yearList[i] + "\"))");
                Console.WriteLine("                        {");
                Console.WriteLine();
                Console.WriteLine("                            output.year" + yearList[i] + " = output.year" + yearList[i] + " + 1;");
                Console.WriteLine();
                Console.WriteLine("                        }");


            }

            */

            Console.WriteLine("Load datasets!");

            FileInfo xmlFile = new FileInfo(Environment.CurrentDirectory + "/data/input/DI3-fused.xml");

            List<Gene> geneList = Parser.getGeneList(xmlFile);


            Console.WriteLine("Add publication years!");

            List<Gene> adjustedGeneList = PubMedYear.addYear(geneList);


            Console.WriteLine("Create output!");

            Output.createXml(gene_list: adjustedGeneList, fileName: "analysis-2.xml", directory: "data/output");

            Output.createTsv(adjustedGeneList, new FileInfo(Environment.CurrentDirectory + "/data/output/analysis-2.tsv"));

        }

    }

}