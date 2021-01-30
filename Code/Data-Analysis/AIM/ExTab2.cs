using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace EnrichFusedDataset
{
/*
    class ExTab2
    {

        public FileInfo musMusculus_heart = new FileInfo(Environment.CurrentDirectory + "/data/output/musMusculus_heart.tsv");

        public FileInfo musMusculus_liver = new FileInfo(Environment.CurrentDirectory + "/data/output/musMusculus_liver.tsv");

        public FileInfo musMusculus_testis = new FileInfo(Environment.CurrentDirectory + "/data/output/musMusculus_testis.tsv");

        public FileInfo musMusculus_brain = new FileInfo(Environment.CurrentDirectory + "/data/output/musMusculus_brain.tsv");

        public FileInfo musMusculus_kidney = new FileInfo(Environment.CurrentDirectory + "/data/output/musMusculus_kidney.tsv");


        public FileInfo musMusculus_homoSapiens_heart = new FileInfo(Environment.CurrentDirectory + "/data/output/musMusculus_homoSapiens_heart.tsv");

        public FileInfo musMusculus_homoSapiens_liver = new FileInfo(Environment.CurrentDirectory + "/data/output/musMusculus_homoSapiens_liver.tsv");

        public FileInfo musMusculus_homoSapiens_testis = new FileInfo(Environment.CurrentDirectory + "/data/output/musMusculus_homoSapiens_testis.tsv");

        public FileInfo musMusculus_homoSapiens_brain = new FileInfo(Environment.CurrentDirectory + "/data/output/musMusculus_homoSapiens_brain.tsv");

        public FileInfo musMusculus_homoSapiens_kidney = new FileInfo(Environment.CurrentDirectory + "/data/output/musMusculus_homoSapiens_kidney.tsv");


        public FileInfo homoSapiens_heart = new FileInfo(Environment.CurrentDirectory + "/data/output/homoSapiens_heart.tsv");

        public FileInfo homoSapiens_liver = new FileInfo(Environment.CurrentDirectory + "/data/output/homoSapiens_liver.tsv");

        public FileInfo homoSapiens_testis = new FileInfo(Environment.CurrentDirectory + "/data/output/homoSapiens_testis.tsv");

        public FileInfo homoSapiens_brain = new FileInfo(Environment.CurrentDirectory + "/data/output/homoSapiens_brain.tsv");

        public FileInfo homoSapiens_kidney = new FileInfo(Environment.CurrentDirectory + "/data/output/homoSapiens_kidney.tsv");



        public static void run()
        {

            List<Gene> geneList = Parser.getGeneList(EnrichDataset.enrichedFusedDS2);





            OrganCollection organCollection = new OrganCollection();


            createOutput();


        }

        public static void createOutput(FileInfo outputFile, string Organism, string Organ, List<Gene> geneList)
        {

            List<Ex2TableLine> tabContent = new List<Ex2TableLine>();

            int windowSize = 10;





            foreach (var item in geneList)
            {

                string ncbi

                Ex2TableLine tabContentItem = new Ex2TableLine();

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

                    counter++;

                }

                tabContentItem.y = line2.ToString();
                Console.WriteLine(tabContentItem.y);

                tabContent.Add(tabContentItem);

            }

            createOutput2(tabContent, windowSize);

        }

        public static void createOutput2(List<Ex2TableLine> tabContent, int windowSize)
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

    class Ex2TableLine
    {

        public string gene;

        public string expression;

        public string year;

        public string y;

        public string y0;

        public string y1;

        public string y2;

        public string y3;

        public string y4;

        public string y5;

        public string y6;

        public string y7;

        public string y8;

        public string y9;

    }

*/

}