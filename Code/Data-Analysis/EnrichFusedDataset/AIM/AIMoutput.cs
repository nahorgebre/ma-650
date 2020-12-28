using System;
using System.IO;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    class AIMoutput
    {

        public int pubAll = 0;


        // all species
        public int pubStrongD_speciesAll = 0;
        public int pubWeakD_speciesAll = 0;
        public int pubSame_speciesAll = 0;
        public int pubDiff_speciesAll = 0;


        // mus musculus & homo sapiens
        public int pubStrongD_speciesMusMusculusHomoSapiens = 0;
        public int pubWeakD_speciesMusMusculusHomoSapiens = 0;
        public int pubSame_speciesMusMusculusHomoSapiens = 0;
        public int pubDiff_speciesMusMusculusHomoSapiens = 0;


        // mus musculus
        public int pubStrongD_speciesMusMusculus = 0;
        public int pubWeakD_speciesMusMusculus = 0;
        public int pubSame_speciesMusMusculus = 0;
        public int pubDiff_speciesMusMusculus = 0;


        // homo sapiens
        public int pubStrongD_speciesHomoSapiens = 0;
        public int pubWeakD_speciesHomoSapiens = 0;
        public int pubSame_speciesHomoSapiens = 0;
        public int pubDiff_speciesHomoSapiens = 0;


        public static void run()
        {



            FileInfo aimFile = new FileInfo(Environment.CurrentDirectory + "/AIM/aim.tsv");

            if (!aimFile.Exists)
            {

                SortedDictionary<int, AIMoutput> aimDictionary = getAimSortedDictionary();

                using (StreamWriter sw = new StreamWriter(aimFile.FullName))
                {

                    List<string> firstLine = new List<string>() { "year", "pubAll",
                    "pubStrongD_speciesAll", "pubWeakD_speciesAll",
                    "pubStrongD_speciesMusMusculus", "pubWeakD_speciesMusMusculus",
                    "pubStrongD_speciesHomoSapiens", "pubWeakD_speciesHomoSapiens",
                    "pubStrongD_speciesMusMusculusHomoSapiens", "pubWeakD_speciesMusMusculusHomoSapiens",
                    "pubSame_speciesAll", "pubDiff_speciesAll",
                    "pubSame_speciesMusMusculus", "pubDiff_speciesMusMusculus",
                    "pubSame_speciesHomoSapiens", "pubDiff_speciesHomoSapiens",
                    "pubSame_speciesMusMusculusHomoSapiens", "pubDiff_speciesMusMusculusHomoSapiens"
                    };

                    // Disease associations - All species 1, 2, 3
                    // Disease associations - Mus musculus 1, 4, 5
                    // Disease associations - Homo sapiens 1, 6, 7
                    // Disease associations - Mus musculus & homo sapiens 1, 8, 9

                    // Overall call - All species 1, 10, 11
                    // Overall call - Mus musculus 1, 12, 13
                    // Overall call - Homo sapiens 1, 14, 15
                    // Overall call - Mus musculus & homo sapiens 1, 16, 17

                    sw.WriteLine(string.Join('\t', firstLine));

                    foreach (var aimItem in aimDictionary)
                    {

                        List<string> line = new List<string>() { aimItem.Key.ToString(), aimItem.Value.pubAll.ToString(),
                        aimItem.Value.pubStrongD_speciesAll.ToString(), aimItem.Value.pubWeakD_speciesAll.ToString(),
                        aimItem.Value.pubStrongD_speciesMusMusculus.ToString(), aimItem.Value.pubWeakD_speciesMusMusculus.ToString(),
                        aimItem.Value.pubStrongD_speciesHomoSapiens.ToString(), aimItem.Value.pubWeakD_speciesHomoSapiens.ToString(),
                        aimItem.Value.pubStrongD_speciesMusMusculusHomoSapiens.ToString(), aimItem.Value.pubWeakD_speciesMusMusculusHomoSapiens.ToString(),
                        aimItem.Value.pubSame_speciesAll.ToString(), aimItem.Value.pubDiff_speciesAll.ToString(),
                        aimItem.Value.pubSame_speciesMusMusculus.ToString(), aimItem.Value.pubDiff_speciesMusMusculus.ToString(),
                        aimItem.Value.pubSame_speciesHomoSapiens.ToString(), aimItem.Value.pubDiff_speciesHomoSapiens.ToString(),
                        aimItem.Value.pubSame_speciesMusMusculusHomoSapiens.ToString(), aimItem.Value.pubDiff_speciesMusMusculusHomoSapiens.ToString()
                        };

                        sw.WriteLine(string.Join('\t', line));

                    }

                }

            }

        }

        public static SortedDictionary<int, AIMoutput> getNumberOfAllPublicationsByYear(SortedDictionary<int, AIMoutput> aimDictionary)
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

                        if (aimDictionary.ContainsKey(year))
                        {

                            AIMoutput output = aimDictionary[year];

                            output.pubAll += 1;

                        }
                        else if (!aimDictionary.ContainsKey(year))
                        {

                            aimDictionary.Add(year, new AIMoutput { pubAll = 1 });

                        }

                    }

                }

            }

            return aimDictionary;

        }

        public static SortedDictionary<int, AIMoutput> getAimSortedDictionary()
        {

            // Read enriched and fused dataset
            List<Gene> geneList = Parser.getGeneList(EnrichDataset.enrichedFusedDS);


            // Retrieve taxonomy database
            HashSet<string> homoSapiensHashSet = TaxonomyDatasets.getHomoSapiens();

            HashSet<string> musMusculusHashSet = TaxonomyDatasets.getMusMusculus();

            HashSet<string> musMusculusHomoSapiensHashSet = TaxonomyDatasets.getMusMusculusHomoSapiens();


            // Dictionary < publicationYear, AIM1output >
            SortedDictionary<int, AIMoutput> aimDictionary = new SortedDictionary<int, AIMoutput>();


            // retrieve # of publications for each species and each case
            foreach (Gene geneItem in geneList)
            {

                double diseaseAssociation = double.Parse(geneItem.overallDiseaseAssociation);

                foreach (GenePublicationMention publicationItem in geneItem.publicationMentions)
                {

                    if (!string.IsNullOrEmpty(publicationItem.year))
                    {

                        int year = Int32.Parse(publicationItem.year);

                        if (!aimDictionary.ContainsKey(year))
                        {

                            aimDictionary.Add(year, new AIMoutput());

                        }


                        AIMoutput item = aimDictionary[year];

                        // homo sapiens
                        if (homoSapiensHashSet.Contains(publicationItem.associatedNcbiId))
                        {

                            if (diseaseAssociation >= 0.8)
                            {

                                item.pubStrongD_speciesHomoSapiens += 1;

                            }
                            else if (diseaseAssociation < 0.8)
                            {

                                item.pubWeakD_speciesHomoSapiens += 1;

                            }

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

                            if (diseaseAssociation >= 0.8)
                            {

                                item.pubStrongD_speciesMusMusculus += 1;

                            }
                            else if (diseaseAssociation < 0.8)
                            {

                                item.pubWeakD_speciesMusMusculus += 1;

                            }

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

                            if (diseaseAssociation >= 0.8)
                            {

                                item.pubStrongD_speciesMusMusculusHomoSapiens += 1;

                            }
                            else if (diseaseAssociation < 0.8)
                            {

                                item.pubWeakD_speciesMusMusculusHomoSapiens += 1;

                            }

                            if (geneItem.overallCall == "1")
                            {

                                item.pubSame_speciesMusMusculusHomoSapiens += 1;

                            }
                            else if (geneItem.overallCall == "0")
                            {

                                item.pubDiff_speciesMusMusculusHomoSapiens += 1;

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

                        // all species
                        if (geneItem.overallCall == "1")
                        {

                            item.pubSame_speciesAll += 1;

                        }
                        else if (geneItem.overallCall == "0")
                        {

                            item.pubDiff_speciesAll += 1;

                        }

                        // return adjustments
                        aimDictionary[year] = item;

                    }

                }

            }


            // get overall # of publications by year
            aimDictionary = getNumberOfAllPublicationsByYear(aimDictionary);


            return aimDictionary;

        }

    }

}