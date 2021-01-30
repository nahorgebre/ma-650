using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    class Exercise2
    {

        public static int windowSize = 20;

        public static void run()
        {

            List<Gene> geneList = Parser.getGeneList(EnrichDataset.enrichedFusedDS2);

            OrganCollection organCollection = new OrganCollection();

            TaxonomyCollection taxonomyCollection = new TaxonomyCollection();


            // musMusculus

            createOutput(
                outputFileName: "musMusculus",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.MusMusculusNcbiIdHashSet,
                organCollection: new HashSet<string>()
            );

            createOutput(
                outputFileName: "musMusculus_heart",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.MusMusculusNcbiIdHashSet,
                organCollection: organCollection.heart
            );

            createOutput(
                outputFileName: "musMusculus_liver",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.MusMusculusNcbiIdHashSet,
                organCollection: organCollection.liver
            );

            createOutput(
                outputFileName: "musMusculus_testis",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.MusMusculusNcbiIdHashSet,
                organCollection: organCollection.testis
            );

            createOutput(
                outputFileName: "musMusculus_brain",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.MusMusculusNcbiIdHashSet,
                organCollection: organCollection.barin
            );

            createOutput(
                outputFileName: "musMusculus_kidney",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.MusMusculusNcbiIdHashSet,
                organCollection: organCollection.kidney
            );


            // musMusculus_homoSapiens

            createOutput(
                outputFileName: "musMusculus_homoSapiens",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.MusMusculusHomoSapiensNcbiIdHashSet,
                organCollection: new HashSet<string>()
            );

            createOutput(
                outputFileName: "musMusculus_homoSapiens_heart",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.MusMusculusHomoSapiensNcbiIdHashSet,
                organCollection: organCollection.heart
            );

            createOutput(
                outputFileName: "musMusculus_homoSapiens_liver",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.MusMusculusHomoSapiensNcbiIdHashSet,
                organCollection: organCollection.liver
            );

            createOutput(
                outputFileName: "musMusculus_homoSapiens_testis",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.MusMusculusHomoSapiensNcbiIdHashSet,
                organCollection: organCollection.testis
            );

            createOutput(
                outputFileName: "musMusculus_homoSapiens_brain",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.MusMusculusHomoSapiensNcbiIdHashSet,
                organCollection: organCollection.barin
            );

            createOutput(
                outputFileName: "musMusculus_homoSapiens_kidney",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.MusMusculusHomoSapiensNcbiIdHashSet,
                organCollection: organCollection.kidney
            );


            // homoSapiens

            createOutput(
                outputFileName: "homoSapiens",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.HomoSapiensNcbiIdHashSet,
                organCollection: new HashSet<string>()
            );

            createOutput(
                outputFileName: "homoSapiens_heart",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.HomoSapiensNcbiIdHashSet,
                organCollection: organCollection.heart
            );

            createOutput(
                outputFileName: "homoSapiens_liver",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.HomoSapiensNcbiIdHashSet,
                organCollection: organCollection.liver
            );

            createOutput(
                outputFileName: "homoSapiens_testis",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.HomoSapiensNcbiIdHashSet,
                organCollection: organCollection.testis
            );

            createOutput(
                outputFileName: "homoSapiens_brain",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.HomoSapiensNcbiIdHashSet,
                organCollection: organCollection.barin
            );

            createOutput(
                outputFileName: "homoSapiens_kidney",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.HomoSapiensNcbiIdHashSet,
                organCollection: organCollection.kidney
            );


            // drosophilaMelanogaster

            createOutput(
                outputFileName: "drosophilaMelanogaster",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.DrosophilaMelanogasterNcbiIdHashSet,
                organCollection: new HashSet<string>()
            );

            createOutput(
                outputFileName: "drosophilaMelanogaster_heart",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.DrosophilaMelanogasterNcbiIdHashSet,
                organCollection: organCollection.heart
            );

            createOutput(
                outputFileName: "drosophilaMelanogaster_liver",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.DrosophilaMelanogasterNcbiIdHashSet,
                organCollection: organCollection.liver
            );

            createOutput(
                outputFileName: "drosophilaMelanogaster_testis",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.DrosophilaMelanogasterNcbiIdHashSet,
                organCollection: organCollection.testis
            );

            createOutput(
                outputFileName: "drosophilaMelanogaster_brain",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.DrosophilaMelanogasterNcbiIdHashSet,
                organCollection: organCollection.barin
            );

            createOutput(
                outputFileName: "drosophilaMelanogaster_kidney",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.DrosophilaMelanogasterNcbiIdHashSet,
                organCollection: organCollection.kidney
            );


            // macacaMulatta

            createOutput(
                outputFileName: "macacaMulatta",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.MacacaMulattaNcbiIdHashSet,
                organCollection: new HashSet<string>()
            );

            createOutput(
                outputFileName: "macacaMulatta_heart",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.MacacaMulattaNcbiIdHashSet,
                organCollection: organCollection.heart
            );

            createOutput(
                outputFileName: "macacaMulatta_liver",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.MacacaMulattaNcbiIdHashSet,
                organCollection: organCollection.liver
            );

            createOutput(
                outputFileName: "macacaMulatta_testis",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.MacacaMulattaNcbiIdHashSet,
                organCollection: organCollection.testis
            );

            createOutput(
                outputFileName: "macacaMulatta_brain",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.MacacaMulattaNcbiIdHashSet,
                organCollection: organCollection.barin
            );

            createOutput(
                outputFileName: "macacaMulatta_kidney",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.MacacaMulattaNcbiIdHashSet,
                organCollection: organCollection.kidney
            );


            // saccharomycesCerevisiae

            createOutput(
                outputFileName: "saccharomycesCerevisiae",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.SaccharomycesCerevisiaeNcbiIdHashSet,
                organCollection: new HashSet<string>()
            );

            createOutput(
                outputFileName: "saccharomycesCerevisiae_heart",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.SaccharomycesCerevisiaeNcbiIdHashSet,
                organCollection: organCollection.heart
            );

            createOutput(
                outputFileName: "saccharomycesCerevisiae_liver",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.SaccharomycesCerevisiaeNcbiIdHashSet,
                organCollection: organCollection.liver
            );

            createOutput(
                outputFileName: "saccharomycesCerevisiae_testis",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.SaccharomycesCerevisiaeNcbiIdHashSet,
                organCollection: organCollection.testis
            );

            createOutput(
                outputFileName: "saccharomycesCerevisiae_brain",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.SaccharomycesCerevisiaeNcbiIdHashSet,
                organCollection: organCollection.barin
            );

            createOutput(
                outputFileName: "saccharomycesCerevisiae_kidney",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.SaccharomycesCerevisiaeNcbiIdHashSet,
                organCollection: organCollection.kidney
            );


            // susScrofa

            createOutput(
                outputFileName: "susScrofa",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.SusScrofaNcbiIdHashSet,
                organCollection: new HashSet<string>()
            );

            createOutput(
                outputFileName: "susScrofa_heart",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.SusScrofaNcbiIdHashSet,
                organCollection: organCollection.heart
            );

            createOutput(
                outputFileName: "susScrofa_liver",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.SusScrofaNcbiIdHashSet,
                organCollection: organCollection.liver
            );

            createOutput(
                outputFileName: "susScrofa_testis",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.SusScrofaNcbiIdHashSet,
                organCollection: organCollection.testis
            );

            createOutput(
                outputFileName: "susScrofa_brain",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.SusScrofaNcbiIdHashSet,
                organCollection: organCollection.barin
            );

            createOutput(
                outputFileName: "susScrofa_kidney",
                geneList: geneList,
                taxonomyCollection: taxonomyCollection.SusScrofaNcbiIdHashSet,
                organCollection: organCollection.kidney
            );

        }

        public static void createOutput(string outputFileName, List<Gene> geneList, HashSet<string> taxonomyCollection, HashSet<string> organCollection)
        {

            FileInfo outputFile = new FileInfo(Environment.CurrentDirectory + "/data/output/Publication/" + outputFileName + "_" + windowSize + ".tsv");

            outputFile.Directory.Create();



            FileInfo outputFileAggregated = new FileInfo(Environment.CurrentDirectory + "/data/output/Publication/" + outputFileName + "_Aggregated_" + windowSize + ".tsv");

            outputFileAggregated.Directory.Create();


            FileInfo outputFileNormalized = new FileInfo(Environment.CurrentDirectory + "/data/output/Publication/" + outputFileName + "_AggregatedNormalized_" + windowSize + ".tsv");

            outputFileNormalized.Directory.Create();


            FileInfo outputFileCumulated = new FileInfo(Environment.CurrentDirectory + "/data/output/Publication/" + outputFileName + "_AggregatedNormalizedCumulated_" + windowSize + ".tsv");

            outputFileCumulated.Directory.Create();


            List<Exercise2TableLine> TableLineContentList = new List<Exercise2TableLine>();


            foreach (var item in geneList)
            {

                if (checkTaxonomyOrganCollection(item.publicationMentions, taxonomyCollection, organCollection))
                {

                    Exercise2TableLine TableLineContentItem = new Exercise2TableLine();

                    TableLineContentItem.gene = item.ensemblId;

                    TableLineContentItem.expression = item.overallCall;

                    TableLineContentItem.year = getFirstPubYear(item.publicationMentions, taxonomyCollection);


                    SortedDictionary<int, int> pubCount = getPubCountByYear(item.publicationMentions, taxonomyCollection, organCollection);

                    StringBuilder pubCountByYearLine = new StringBuilder();

                    int counter = 0;

                    foreach (var pubitem in pubCount)
                    {

                        if (counter < windowSize)
                        {

                            pubCountByYearLine.Append("|" + pubitem.Value);

                        }

                        counter++;

                    }

                    TableLineContentItem.y = adjustLineContent(pubCountByYearLine.ToString());

                    TableLineContentList.Add(TableLineContentItem);

                }

            }

            createCsv(TableLineContentList, windowSize, outputFile);


            // aggregated

            List<double> TableLineAggregatedList_Same = new List<double>();

            double TableLineAggregatedCount_Same = 0;

            List<double> TableLineAggregatedList_Different = new List<double>();

            double TableLineAggregatedCount_Different = 0;

            for (int i = 0; i < windowSize; i++)
            {

                TableLineAggregatedList_Same.Add(0);

                TableLineAggregatedList_Different.Add(0);

            }

            foreach (var TableLineContentItem in TableLineContentList)
            {

                string tableLineContent = TableLineContentItem.y;

                string[] tableLineArray = tableLineContent.Split("|").Skip(1).ToArray();

                if (TableLineContentItem.expression.Equals("1"))
                {

                    for (int i = 0; i < windowSize; i++)
                    {

                        if (!tableLineArray[i].Equals(string.Empty))
                        {

                            string stringItem = tableLineArray[i];

                            double doubleItem = double.Parse(stringItem);

                            double aggregated = TableLineAggregatedList_Same[i];

                            aggregated += doubleItem;

                            TableLineAggregatedList_Same[i] = aggregated;

                        }

                    }

                    TableLineAggregatedCount_Same++;

                }
                else if (TableLineContentItem.expression.Equals("0"))
                {

                    for (int i = 0; i < windowSize; i++)
                    {

                        if (!tableLineArray[i].Equals(string.Empty))
                        {

                            string stringItem = tableLineArray[i];

                            double doubleItem = double.Parse(stringItem);

                            double aggregated = TableLineAggregatedList_Different[i];

                            aggregated += doubleItem;

                            TableLineAggregatedList_Different[i] = aggregated;

                        }

                    }

                    TableLineAggregatedCount_Different++;

                }

            }

            for (int i = 0; i < windowSize; i++)
            {

                TableLineAggregatedList_Same[i] = adjustValue(TableLineAggregatedList_Same[i] / TableLineAggregatedCount_Same);

                TableLineAggregatedList_Different[i] = adjustValue(TableLineAggregatedList_Different[i] / TableLineAggregatedCount_Different);

            }

            createCsv2(outputFileAggregated, TableLineAggregatedList_Same, TableLineAggregatedList_Different);



            // normalized

            List<double> TableLineNormalizedList_Same = new List<double>();

            double same_sum = 0;

            List<double> TableLineNormalizedList_Different = new List<double>();

            double different_sum = 0;

            for (int i = 0; i < windowSize; i++)
            {

                same_sum += TableLineAggregatedList_Same[i];

                different_sum += TableLineAggregatedList_Different[i];

            }

            for (int i = 0; i < windowSize; i++)
            {

                TableLineNormalizedList_Same.Add(adjustValue(TableLineAggregatedList_Same[i] / same_sum));

                TableLineNormalizedList_Different.Add(adjustValue(TableLineAggregatedList_Different[i] / different_sum));

            }

            createCsv2(outputFileNormalized, TableLineNormalizedList_Same, TableLineNormalizedList_Different);



            // cumulated

            List<double> TableLineCumulatedList_Same = new List<double>();

            List<double> TableLineCumulatedList_Different = new List<double>();

            for (int i = 0; i < windowSize; i++)
            {

                if (i > 0 & i < (windowSize-1))
                {

                    TableLineCumulatedList_Same.Add(adjustValue(TableLineCumulatedList_Same[i - 1] + TableLineNormalizedList_Same[i]));

                    TableLineCumulatedList_Different.Add(adjustValue(TableLineCumulatedList_Different[i - 1] + TableLineNormalizedList_Different[i]));

                }
                else if (i == 0)
                {

                    TableLineCumulatedList_Same.Add(adjustValue(TableLineNormalizedList_Same[i]));

                    TableLineCumulatedList_Different.Add(adjustValue(TableLineNormalizedList_Different[i]));

                }
                else if (i == (windowSize-1))
                {

                    TableLineCumulatedList_Same.Add(1.0);

                    TableLineCumulatedList_Different.Add(1.0);

                }

            }

            createCsv2(outputFileCumulated, TableLineCumulatedList_Same, TableLineCumulatedList_Different);


        }

        public static double adjustValue(double value)
        {

            return Math.Round(value, 4);

        }

        public static string replaceCommaByPoint(double value)
        {

            return value.ToString().Replace(',', '.');

        }

        public static void createCsv2(FileInfo outputFile, List<double> TableLineList_Same, List<double> TableLineList_Different)
        {

            using (StreamWriter sw = new StreamWriter(outputFile.FullName))
            {

                List<string> firstLineList = new List<string>(){
                    "Y", "Same", "Different"
                };

                var firstLine = string.Join('|', firstLineList);

                sw.WriteLine(firstLine);

                for (int i = 0; i < windowSize; i++)
                {

                    List<string> lineList = new List<string>(){
                        ("Y" + i).ToString(),
                        replaceCommaByPoint(TableLineList_Same[i]),
                        replaceCommaByPoint(TableLineList_Different[i])
                    };

                    var line = string.Join('|', lineList);

                    sw.WriteLine(line);

                }

            }

        }

        public static void createCsv(List<Exercise2TableLine> TableLineContentList, int windowSize, FileInfo outputFile)
        {

            string firstLinePart1 = "gene|expression|year";

            StringBuilder firstLinePart2 = new StringBuilder();

            for (int i = 0; i < windowSize; i++)
            {

                firstLinePart2.Append("|Y" + i);

            }

            string firstLine = firstLinePart1 + firstLinePart2;

            using (StreamWriter sw = new StreamWriter(outputFile.FullName))
            {

                sw.WriteLine(firstLine);

                foreach (var item in TableLineContentList)
                {

                    string line = item.gene + "|" + item.expression + "|" + item.year + item.y;

                    sw.WriteLine(line);

                }

            }

        }

        public static bool checkTaxonomyOrganCollection(List<GenePublicationMention> publicationList, HashSet<string> taxonomyCollection, HashSet<string> organCollection)
        {

            bool returnValue = false;

            foreach (var item in publicationList)
            {

                if (taxonomyCollection.Contains(item.associatedNcbiId))
                {

                    if (organCollection.Count() != 0)
                    {

                        if (organCollection.Contains(item.pmId))
                        {

                            returnValue = true;

                        }

                    }
                    else if (organCollection.Count() == 0)
                    {

                        returnValue = true;

                    }

                }

            }

            return returnValue;

        }


        public static string adjustLineContent(string tableLineContent)
        {

            int lineCount = tableLineContent.Split('|').Count();

            int difference = (1 + windowSize) - lineCount;

            for (int i = 0; i < difference; i++)
            {

                tableLineContent += "|0";

            }

            return tableLineContent;

        }


        public static SortedDictionary<int, int> getPubCountByYear(List<GenePublicationMention> publicationList, HashSet<string> taxonomyCollection, HashSet<string> organCollection)
        {

            // year, pubCount
            SortedDictionary<int, int> pubCount = new SortedDictionary<int, int>();

            foreach (var item in publicationList)
            {

                if (!string.IsNullOrEmpty(item.year))
                {

                    try
                    {

                        int i = Int32.Parse(item.year);

                        if (taxonomyCollection.Contains(item.associatedNcbiId))
                        {

                            if (organCollection.Count() != 0)
                            {

                                if (organCollection.Contains(item.pmId))
                                {

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

                            }
                            else if (organCollection.Count() == 0)
                            {

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

                        }

                    }
                    catch (System.Exception)
                    {

                        Console.WriteLine("Could not convert string to integer: " + item.year);

                        throw;

                    }

                }

            }

            return pubCount;

        }

        public static string getFirstPubYear(List<GenePublicationMention> publicationList, HashSet<string> taxonomyCollection)
        {

            int year = 3000;

            foreach (var item in publicationList)
            {

                if (taxonomyCollection.Contains(item.associatedNcbiId))
                {

                    if (!string.IsNullOrEmpty(item.year))
                    {

                        try
                        {

                            if (Int32.Parse(item.year) < year) year = Int32.Parse(item.year);

                        }
                        catch (System.Exception)
                        {

                            Console.WriteLine("Could not convert string to integer: " + item.year);

                            throw;

                        }

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

    class Exercise2TableLine
    {

        public string gene;

        public string expression;

        public string year;

        public string y;

    }

}