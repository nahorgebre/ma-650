using System;
using System.IO;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    class AIM2output
    {

        public int pubAll = 0;

        // all species
        public int pubStrongD_speciesAll = 0;
        public int pubWeakD_speciesAll = 0;

        // mus musculus & homo sapiens
        public int pubStrongD_speciesMusMusculusHomoSapiens = 0;
        public int pubWeakD_speciesMusMusculusHomoSapiens = 0;

        // mus musculus
        public int pubStrongD_speciesMusMusculus = 0;
        public int pubWeakD_speciesMusMusculus = 0;

        // homo sapiens
        public int pubStrongD_speciesHomoSapiens = 0;
        public int pubWeakD_speciesHomoSapiens = 0;


        public static void run()
        {

            SortedDictionary<int, AIM2output> aim2Dictionary = getAim2SortedDictionary();

            FileInfo aim2 = new FileInfo(Environment.CurrentDirectory + "/AIM2/aim2.tsv");

            using (StreamWriter sw = new StreamWriter(aim2.FullName))
            {

                List<string> firstLine = new List<string>() { "year", "pubAll",
                    "pubStrongD_speciesAll", "pubWeakD_speciesAll",
                    "pubStrongD_speciesMusMusculus", "pubWeakD_speciesMusMusculus",
                    "pubStrongD_speciesHomoSapiens", "pubWeakD_speciesHomoSapiens",
                    "pubStrongD_speciesMusMusculusHomoSapiens", "pubWeakD_speciesMusMusculusHomoSapiens"
                };

                // all species 1, 2, 3
                // mus musculus 1, 4, 5
                // homo sapiens 1, 6, 7
                // mus musculus & homo sapiens 1, 8, 9

                sw.WriteLine(string.Join('\t', firstLine));

                foreach (var aim1Item in aim2Dictionary)
                {

                    List<string> line = new List<string>() { aim1Item.Key.ToString(), aim1Item.Value.pubAll.ToString(),
                        aim1Item.Value.pubStrongD_speciesAll.ToString(), aim1Item.Value.pubWeakD_speciesAll.ToString(),
                        aim1Item.Value.pubStrongD_speciesMusMusculus.ToString(), aim1Item.Value.pubWeakD_speciesMusMusculus.ToString(),
                        aim1Item.Value.pubStrongD_speciesHomoSapiens.ToString(), aim1Item.Value.pubWeakD_speciesHomoSapiens.ToString(),
                        aim1Item.Value.pubStrongD_speciesMusMusculusHomoSapiens.ToString(), aim1Item.Value.pubWeakD_speciesMusMusculusHomoSapiens.ToString()
                    };

                    sw.WriteLine(string.Join('\t', line));

                }

            }

        }

        public static SortedDictionary<int, AIM2output> getNumberOfAllPublicationsByYear(SortedDictionary<int, AIM2output> aim2Dictionary)
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

                        if (aim2Dictionary.ContainsKey(year))
                        {

                            AIM2output output = aim2Dictionary[year];

                            output.pubAll += 1;

                        }
                        else if (!aim2Dictionary.ContainsKey(year))
                        {

                            aim2Dictionary.Add(year, new AIM2output { pubAll = 1 });

                        }

                    }

                }

            }

            return aim2Dictionary;

        }

        public static SortedDictionary<int, AIM2output> getAim2SortedDictionary()
        {

            // Read enriched and fused dataset
            List<Gene> geneList = Parser.getGeneList(EnrichDataset.enrichedFusedDS);


            // Retrieve taxonomy database
            HashSet<string> homoSapiensHashSet = TaxonomyDatasets.getHomoSapiens();

            HashSet<string> musMusculusHashSet = TaxonomyDatasets.getMusMusculus();

            HashSet<string> musMusculusHomoSapiensHashSet = TaxonomyDatasets.getMusMusculusHomoSapiens();


            // Dictionary < publicationYear, AIM1output >
            SortedDictionary<int, AIM2output> aim2Dictionary = new SortedDictionary<int, AIM2output>();


            // retrieve # of publications for each species and each case
            foreach (Gene geneItem in geneList)
            {

                double diseaseAssociation = double.Parse(geneItem.overallDiseaseAssociation);

                foreach (GenePublicationMention publicationItem in geneItem.publicationMentions)
                {

                    int year = Int32.Parse(publicationItem.year);

                    if (!aim2Dictionary.ContainsKey(year))
                    {

                        aim2Dictionary.Add(year, new AIM2output());

                    }


                    AIM2output item = aim2Dictionary[year];

                    // homo sapiens
                    if (homoSapiensHashSet.Contains(publicationItem.associatedNcbiId))
                    {

                        if (diseaseAssociation >= 0.8)
                        {

                            item.pubStrongD_speciesHomoSapiens += 1;

                        }
                        else
                        {

                            item.pubWeakD_speciesHomoSapiens += 1;

                        }

                    }

                    // mus musculus
                    if (musMusculusHashSet.Contains(publicationItem.associatedNcbiId))
                    {

                        if (diseaseAssociation >= 0.8)
                        {

                            item.pubStrongD_speciesMusMusculus += 1;

                        }
                        else
                        {

                            item.pubWeakD_speciesMusMusculus += 1;

                        }

                    }

                    // mus musculus & homo sapiens
                    if (musMusculusHomoSapiensHashSet.Contains(publicationItem.associatedNcbiId))
                    {

                        if (diseaseAssociation >= 0.8)
                        {

                            item.pubStrongD_speciesMusMusculusHomoSapiens += 1;

                        }
                        else
                        {

                            item.pubWeakD_speciesMusMusculusHomoSapiens += 1;

                        }

                    }

                    // all species
                    if (diseaseAssociation >= 0.8)
                    {

                        item.pubStrongD_speciesAll += 1;

                    }
                    else
                    {

                        item.pubWeakD_speciesAll += 1;

                    }

                    // return adjustments
                    aim2Dictionary[year] = item;

                }

            }


            // get overall # of publications by year
            aim2Dictionary = getNumberOfAllPublicationsByYear(aim2Dictionary);


            return aim2Dictionary;

        }

    }

}