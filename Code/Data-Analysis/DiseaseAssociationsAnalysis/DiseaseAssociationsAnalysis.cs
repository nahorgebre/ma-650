using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    class PublicationCount
    {

        public int strongPublicationCount;

        public int weakPublicationCount;

    }

    class DiseaseAssociationsAnalysis
    {

        public static void run()
        {

            //getTimeDependentDS();

            runDiseaseAssociationsAnalysis();

        }

        public static void getTimeDependentDS()
        {

            // year, pubCount
            SortedDictionary<int, PublicationCount> pubCountByYear = new SortedDictionary<int, PublicationCount>();

            List<Gene> geneList = Parser.getGeneList(EnrichDataset.enrichedFusedDS2);

            foreach (var geneItem in geneList)
            {

                foreach (var pubItem in geneItem.publicationMentions)
                {

                    if (!string.IsNullOrEmpty(pubItem.year))
                    {

                        int year = Int32.Parse(pubItem.year);

                        if (pubCountByYear.ContainsKey(year))
                        {

                            PublicationCount pubCount = pubCountByYear[year];

                            if (geneItem.diseaseAssociations.Count > 258)
                            {

                                pubCount.strongPublicationCount++;

                            }
                            else
                            {

                                pubCount.weakPublicationCount++;

                            }

                            pubCountByYear[year] = pubCount;

                        }
                        else
                        {

                            PublicationCount pubCount = new PublicationCount();

                            pubCount.weakPublicationCount = 0;

                            pubCount.strongPublicationCount = 0;

                            if (geneItem.diseaseAssociations.Count > 258)
                            {

                                pubCount.strongPublicationCount++;

                            }
                            else
                            {

                                pubCount.weakPublicationCount++;

                            }

                            pubCountByYear.Add(year, pubCount);

                        }

                    }

                }

            }

            using (StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "/DiseaseAssociationsAnalysis/tdds.tsv"))
            {

                foreach (var pubCount in pubCountByYear)
                {

                    List<string> line = new List<string>() { pubCount.Key.ToString(), pubCount.Value.strongPublicationCount.ToString(), pubCount.Value.weakPublicationCount.ToString() };

                    sw.WriteLine(string.Join('\t', line));

                }

            }

        }

        public static void runDiseaseAssociationsAnalysis()
        {

            Console.WriteLine("EFDS2");

            getDiseaseAssociationsMedian(EnrichDataset.enrichedFusedDS2);

            /*
            Console.WriteLine("EFDS3");

            getDiseaseAssociationsMedian(EnrichDataset.enrichedFusedDS3);
            */

        }

        public static void getDiseaseAssociationsMedian(FileInfo file)
        {

            // median -> 258

            SortedDictionary<int, int> countFrequency = new SortedDictionary<int, int>();

            List<Gene> geneList = Parser.getGeneList(file);

            Console.WriteLine("# of gene entities: " + geneList.Count);

            foreach (var geneItem in geneList)
            {

                int daCount = geneItem.diseaseAssociations.Count;

                if (countFrequency.ContainsKey(daCount))
                {

                    int i = countFrequency[daCount];

                    i++;

                    countFrequency[daCount] = i;

                }
                else
                {

                    countFrequency.Add(daCount, 1);

                }

            }

            GetMedian(countFrequency.Keys.ToArray());

        }

        public static void GetMedian(int[] array)
        {
            int[] tempArray = array;
            int count = tempArray.Length;

            Array.Sort(tempArray);

            decimal medianValue = 0;

            if (count % 2 == 0)
            {
                // count is even, need to get the middle two elements, add them together, then divide by 2
                int middleElement1 = tempArray[(count / 2) - 1];
                int middleElement2 = tempArray[(count / 2)];
                medianValue = (middleElement1 + middleElement2) / 2;
            }
            else
            {
                // count is odd, simply get the middle element.
                medianValue = tempArray[(count / 2)];
            }

            Console.WriteLine("Median: " + medianValue);

        }

    }

}