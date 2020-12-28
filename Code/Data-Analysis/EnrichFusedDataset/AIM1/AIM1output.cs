using System;
using System.IO;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    class AIM1output
    {

        public int pubAll = 0;


        // all species
        public int pubSame_speciesAll = 0;
        public int pubDiff_speciesAll = 0;

        // mus musculus & homo sapiens
        public int pubSame_speciesMusMusculusHomoSapiens = 0;
        public int pubDiff_speciesMusMusculusHomoSapiens = 0;

        // mus musculus
        public int pubSame_speciesMusMusculus = 0;
        public int pubDiff_speciesMusMusculus = 0;

        // homo sapiens
        public int pubSame_speciesHomoSapiens = 0;
        public int pubDiff_speciesHomoSapiens = 0;


        public static void run()
        {

            FileInfo aim1 = new FileInfo(Environment.CurrentDirectory + "/AIM1/aim1.tsv");

            if (aim1.Exists)
            {

                SortedDictionary<int, AIM1output> aim1Dictionary = getAim1SortedDictionary();

                using (StreamWriter sw = new StreamWriter(aim1.FullName))
                {

                    List<string> firstLine = new List<string>() { "year", "pubAll",
                    "pubSame_speciesAll", "pubDiff_speciesAll",
                    "pubSame_speciesMusMusculus", "pubDiff_speciesMusMusculus",
                    "pubSame_speciesHomoSapiens", "pubDiff_speciesHomoSapiens",
                    "pubSame_speciesMusMusculusHomoSapiens", "pubDiff_speciesMusMusculusHomoSapiens"
                };

                    // all species 1, 2, 3
                    // mus musculus 1, 4, 5
                    // homo sapiens 1, 6, 7
                    // mus musculus & homo sapiens 1, 8, 9

                    sw.WriteLine(string.Join('\t', firstLine));

                    foreach (var aim1Item in aim1Dictionary)
                    {

                        List<string> line = new List<string>() { aim1Item.Key.ToString(), aim1Item.Value.pubAll.ToString(),
                        aim1Item.Value.pubSame_speciesAll.ToString(), aim1Item.Value.pubDiff_speciesAll.ToString(),
                        aim1Item.Value.pubSame_speciesMusMusculus.ToString(), aim1Item.Value.pubDiff_speciesMusMusculus.ToString(),
                        aim1Item.Value.pubSame_speciesHomoSapiens.ToString(), aim1Item.Value.pubDiff_speciesHomoSapiens.ToString(),
                        aim1Item.Value.pubSame_speciesMusMusculusHomoSapiens.ToString(), aim1Item.Value.pubDiff_speciesMusMusculusHomoSapiens.ToString()
                    };

                        sw.WriteLine(string.Join('\t', line));

                    }

                }

            }

        }

        public static SortedDictionary<int, AIM1output> getNumberOfAllPublicationsByYear(SortedDictionary<int, AIM1output> aim1Dictionary)
        {

            using (StreamReader sr = new StreamReader(Environment.CurrentDirectory + "/data/input/PubMedDate.csv"))
            {

                sr.ReadLine();

                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] values = line.Split(',');

                    if (!string.IsNullOrEmpty(values[1]))
                    {

                        int year = Int16.Parse(values[1]);

                        if (aim1Dictionary.ContainsKey(year))
                        {

                            AIM1output output = aim1Dictionary[year];

                            output.pubAll += 1;

                        }
                        else if (!aim1Dictionary.ContainsKey(year))
                        {

                            aim1Dictionary.Add(year, new AIM1output { pubAll = 1 });

                        }

                    }

                }

            }

            return aim1Dictionary;

        }

        public static SortedDictionary<int, AIM1output> getAim1SortedDictionary()
        {

            // Read enriched and fused dataset
            List<Gene> geneList = Parser.getGeneList(EnrichDataset.enrichedFusedDS);


            // Retrieve taxonomy database
            HashSet<string> homoSapiensHashSet = TaxonomyDatasets.getHomoSapiens();

            HashSet<string> musMusculusHashSet = TaxonomyDatasets.getMusMusculus();

            HashSet<string> musMusculusHomoSapiensHashSet = TaxonomyDatasets.getMusMusculusHomoSapiens();

            Console.WriteLine("HashSet size: " + musMusculusHomoSapiensHashSet.Count);


            // Dictionary < publicationYear, AIM1output >
            SortedDictionary<int, AIM1output> aim1Dictionary = new SortedDictionary<int, AIM1output>();


            // retrieve # of publications for each species and each case
            foreach (Gene geneItem in geneList)
            {

                foreach (GenePublicationMention publicationItem in geneItem.publicationMentions)
                {

                    if (!string.IsNullOrEmpty(publicationItem.year))
                    {

                        int year = Int32.Parse(publicationItem.year);

                        if (!aim1Dictionary.ContainsKey(year))
                        {

                            aim1Dictionary.Add(year, new AIM1output());

                        }


                        AIM1output item = aim1Dictionary[year];

                        // homo sapiens
                        if (homoSapiensHashSet.Contains(publicationItem.associatedNcbiId))
                        {

                            if (geneItem.overallCall == "1")
                            {

                                item.pubSame_speciesHomoSapiens += 1;

                            }
                            else if (geneItem.overallCall == "0")
                            {

                                item.pubDiff_speciesHomoSapiens += 1;

                            }

                        }

                        // mus musculus
                        if (musMusculusHashSet.Contains(publicationItem.associatedNcbiId))
                        {

                            if (geneItem.overallCall == "1")
                            {

                                item.pubSame_speciesMusMusculus += 1;

                            }
                            else if (geneItem.overallCall == "0")
                            {

                                item.pubDiff_speciesMusMusculus += 1;

                            }

                        }

                        // mus musculus & homo sapiens
                        if (musMusculusHomoSapiensHashSet.Contains(publicationItem.associatedNcbiId))
                        {

                            if (geneItem.overallCall == "1")
                            {

                                item.pubSame_speciesMusMusculusHomoSapiens += 1;

                            }
                            else if (geneItem.overallCall == "0")
                            {

                                item.pubDiff_speciesMusMusculusHomoSapiens += 1;

                            }

                        }

                        // all
                        if (geneItem.overallCall == "1")
                        {

                            item.pubSame_speciesAll += 1;

                        }
                        else if (geneItem.overallCall == "0")
                        {

                            item.pubDiff_speciesAll += 1;

                        }

                        // return adjustments
                        aim1Dictionary[year] = item;

                    }

                }

            }


            // get overall # of publications by year
            aim1Dictionary = getNumberOfAllPublicationsByYear(aim1Dictionary);


            return aim1Dictionary;

        }

    }

}