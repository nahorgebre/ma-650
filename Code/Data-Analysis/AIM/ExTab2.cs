using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    class ExTab2
    {

        public static void run()
        {

            List<ExTabLine> tabContent = new List<ExTabLine>();

            int windowSize = 30;


            List<Gene> geneList = Parser.getGeneList(EnrichDataset.enrichedFusedDS2);

            Console.WriteLine("Size: " + geneList.Count);

            foreach (var item in geneList)
            {

                ExTabLine tabContentItem = new ExTabLine();

                tabContentItem.gene = item.ensemblId;

                tabContentItem.expression = item.overallCall;

                tabContentItem.year = getFirstYear(item.publicationMentions);

                SortedDictionary<int, int> pubCount = getYearCount(item.publicationMentions);

                

                StringBuilder line2 = new StringBuilder();

                int counter = 0;

                foreach (var pubitem in pubCount)
                {
                    if (counter < windowSize)
                    {
                        line2.Append("," + pubitem.Value);
                        //Console.WriteLine(pubitem.Value);
                    }
                    counter ++;
                }

                tabContentItem.y = line2.ToString();
                Console.WriteLine(tabContentItem.y);

                tabContent.Add(tabContentItem);

            }

            createOutput(tabContent, windowSize);

        }

        public static void createOutput(List<ExTabLine> tabContent, int windowSize)
        {

            string firstLine1 = "gene,expression,year";

            StringBuilder firstLine2 = new StringBuilder();

            for (int i = 0; i < windowSize; i++)
            {
                firstLine2.Append(",Y" + i);
            }

            string firstLine = firstLine1 + firstLine2;

            using (StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "/data/output/exc2.csv"))
            {

                sw.WriteLine(firstLine);

                foreach (var item in tabContent)
                {

                    string line = item.gene + "," + item.expression + "," + item.year + item.y;

                    sw.WriteLine(line);

                }

            }

        }

        public static SortedDictionary<int, int> getYearCount(List<GenePublicationMention> pubML)
        {

            // year, count>
            SortedDictionary<int, int> pubCount = new SortedDictionary<int, int>();

            foreach (var item in pubML)
            {

                if (!string.IsNullOrEmpty(item.year))
                {

                    try
                    {

                        int i = Int32.Parse(item.year);

                        if (pubCount.ContainsKey(i))
                        {

                            int count = pubCount[i];

                            count++;

                            pubCount[i] = count;

                        }
                        else
                        {

                            pubCount.Add(i, 1);

                        }

                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("2: " + item.year);
                        throw;
                    }

                }

            }

            return pubCount;

        }

        public static string getFirstYear(List<GenePublicationMention> pubML)
        {

            int year = 3000;

            foreach (var item in pubML)
            {

                if (!string.IsNullOrEmpty(item.year))
                {

                    try
                    {
                        if (Int32.Parse(item.year) < year) year = Int32.Parse(item.year);
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("1: " + item.year);
                        throw;
                    }

                }

            }

            if (year == 3000)
            {
                return string.Empty;
            }
            else
            {
                return year.ToString();
            }

            
        }

    }

    class ExTabLine
    {
        public string gene;

        public string expression;

        public string year;

        public string y;

    }

}