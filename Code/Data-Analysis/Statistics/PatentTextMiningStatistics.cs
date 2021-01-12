using System;
using System.IO;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    class PatentTextMiningStatistics
    {

        public static FileInfo abstractText = new FileInfo(Environment.CurrentDirectory + "/data/input/patent/abstract.tsv");

        public static FileInfo titleText = new FileInfo(Environment.CurrentDirectory + "/data/input/patent/title.tsv");

        public static FileInfo abstractEntities = new FileInfo(Environment.CurrentDirectory + "/data/input/patent/scispaCyAbstractGene.csv");

        public static FileInfo titleEntities = new FileInfo(Environment.CurrentDirectory + "/data/input/patent/scispaCyTitleGene.csv");

        public static FileInfo origPatents = new FileInfo(Environment.CurrentDirectory + "/data/input/patent/US_Patents_1985_2016_313392.csv");


        public static void run()
        {

            int countGeneNames = 0;

            HashSet<string> distinctGeneHashSet = new HashSet<string>();

            foreach (var fileInfoItem in new List<FileInfo>() { abstractEntities, titleEntities })
            {

                using (StreamReader sr = new StreamReader(fileInfoItem.FullName))
                {

                    sr.ReadLine();

                    while (!sr.EndOfStream)
                    {

                        var line = sr.ReadLine();

                        if (line.Contains('|'))
                        {

                            string[] values = line.Split('|');

                            foreach (var item in line.Split('|'))
                            {

                                distinctGeneHashSet.Add(item);

                                countGeneNames ++;

                            }

                        }
                        else
                        {

                            distinctGeneHashSet.Add(line);

                            countGeneNames ++;

                        }

                    }

                }

            }

            Console.WriteLine("overall # of genes in patents: " + countGeneNames);

            Console.WriteLine("# of distinct genes in patents: " + distinctGeneHashSet.Count);

        }

    }

}