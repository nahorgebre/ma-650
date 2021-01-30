using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    class PublicationAnalysis
    {

        public static FileInfo musMusculus_heart = new FileInfo(Environment.CurrentDirectory + "/data/output/PublicationNormalized/musMusculus_heart.tsv");

        public static FileInfo musMusculus_liver = new FileInfo(Environment.CurrentDirectory + "/data/output/PublicationNormalized/musMusculus_liver.tsv");

        public static FileInfo musMusculus_testis = new FileInfo(Environment.CurrentDirectory + "/data/output/PublicationNormalized/musMusculus_testis.tsv");

        public static FileInfo musMusculus_brain = new FileInfo(Environment.CurrentDirectory + "/data/output/PublicationNormalized/musMusculus_brain.tsv");

        public static FileInfo musMusculus_kidney = new FileInfo(Environment.CurrentDirectory + "/data/output/PublicationNormalized/musMusculus_kidney.tsv");


        public static FileInfo musMusculus_homoSapiens_heart = new FileInfo(Environment.CurrentDirectory + "/data/output/PublicationNormalized/musMusculus_homoSapiens_heart.tsv");

        public static FileInfo musMusculus_homoSapiens_liver = new FileInfo(Environment.CurrentDirectory + "/data/output/PublicationNormalized/musMusculus_homoSapiens_liver.tsv");

        public static FileInfo musMusculus_homoSapiens_testis = new FileInfo(Environment.CurrentDirectory + "/data/output/PublicationNormalized/musMusculus_homoSapiens_testis.tsv");

        public static FileInfo musMusculus_homoSapiens_brain = new FileInfo(Environment.CurrentDirectory + "/data/output/PublicationNormalized/musMusculus_homoSapiens_brain.tsv");

        public static FileInfo musMusculus_homoSapiens_kidney = new FileInfo(Environment.CurrentDirectory + "/data/output/PublicationNormalized/musMusculus_homoSapiens_kidney.tsv");


        public static FileInfo homoSapiens_heart = new FileInfo(Environment.CurrentDirectory + "/data/output/PublicationNormalized/homoSapiens_heart.tsv");

        public static FileInfo homoSapiens_liver = new FileInfo(Environment.CurrentDirectory + "/data/output/PublicationNormalized/homoSapiens_liver.tsv");

        public static FileInfo homoSapiens_testis = new FileInfo(Environment.CurrentDirectory + "/data/output/PublicationNormalized/homoSapiens_testis.tsv");

        public static FileInfo homoSapiens_brain = new FileInfo(Environment.CurrentDirectory + "/data/output/PublicationNormalized/homoSapiens_brain.tsv");

        public static FileInfo homoSapiens_kidney = new FileInfo(Environment.CurrentDirectory + "/data/output/PublicationNormalized/homoSapiens_kidney.tsv");


        public static void run()
        {

            List<Gene> geneList = Parser.getGeneList(EnrichDataset.enrichedFusedDS2);

            OrganCollection organCollection = new OrganCollection();

            TaxonomyCollection taxonomyCollection = new TaxonomyCollection();


            createOutput(
                outputFile: musMusculus_heart,
                geneList: geneList,
                taxonomyCollection: TaxonomyDatasets.getMusMusculus(),
                organCollection: OrganDatasets.getHeart()
            );

            createOutput(
                outputFile: musMusculus_homoSapiens_heart,
                geneList: geneList,
                taxonomyCollection: TaxonomyDatasets.getMusMusculusHomoSapiens(),
                organCollection: OrganDatasets.getHeart()
            );

        }

        public static void createOutput(FileInfo outputFile, List<Gene> geneList, HashSet<string> taxonomyCollection, HashSet<string> organCollection)
        {

            Dictionary<string, List<PublicationTableLine>> tableLineDictionary = new Dictionary<string, List<PublicationTableLine>>();

            tableLineDictionary.Add("1", new List<PublicationTableLine>());
            tableLineDictionary.Add("0", new List<PublicationTableLine>());

            foreach (var geneItem in geneList)
            {

                SortedDictionary<int, double> pubCountByYear = getYearCount(geneItem.publicationMentions, taxonomyCollection, organCollection);

                PublicationTableLine publicationTableLine = getPublicationTableLine(pubCountByYear);

                publicationTableLine.year = getFirstYear(geneItem.publicationMentions);

                publicationTableLine.gene = geneItem.ensemblId;

                publicationTableLine.expression = geneItem.overallCall;


                if (geneItem.overallCall.Equals("1"))
                {

                    List<PublicationTableLine> publicationTableLineList = tableLineDictionary["1"];

                    publicationTableLineList.Add(publicationTableLine);

                    tableLineDictionary["1"] = publicationTableLineList;

                }
                else if (geneItem.overallCall.Equals("0"))
                {

                    List<PublicationTableLine> publicationTableLineList = tableLineDictionary["0"];

                    publicationTableLineList.Add(publicationTableLine);

                    tableLineDictionary["0"] = publicationTableLineList;

                }

            }

            Console.WriteLine("Same Gene Entities: " + tableLineDictionary["1"].Count);
            Console.WriteLine("Different Gene Etities: " + tableLineDictionary["0"].Count);

            PublicationTableLine publicationTableLine1 = getPublicationTableLineAverage(tableLineDictionary["1"]);
            PublicationTableLine publicationTableLine0 = getPublicationTableLineAverage(tableLineDictionary["0"]);

            outputFile.Directory.Create();

            using (StreamWriter sw = new StreamWriter(outputFile.FullName))
            {

                sw.WriteLine(string.Join('\t', new List<string>() { "Y0", publicationTableLine1.y0.ToString(), publicationTableLine0.y0.ToString() }));

                sw.WriteLine(string.Join('\t', new List<string>() { "Y1", publicationTableLine1.y1.ToString(), publicationTableLine0.y1.ToString() }));

                sw.WriteLine(string.Join('\t', new List<string>() { "Y2", publicationTableLine1.y2.ToString(), publicationTableLine0.y2.ToString() }));

                sw.WriteLine(string.Join('\t', new List<string>() { "Y3", publicationTableLine1.y3.ToString(), publicationTableLine0.y3.ToString() }));

                sw.WriteLine(string.Join('\t', new List<string>() { "Y4", publicationTableLine1.y4.ToString(), publicationTableLine0.y4.ToString() }));

                sw.WriteLine(string.Join('\t', new List<string>() { "Y5", publicationTableLine1.y5.ToString(), publicationTableLine0.y5.ToString() }));

                sw.WriteLine(string.Join('\t', new List<string>() { "Y6", publicationTableLine1.y6.ToString(), publicationTableLine0.y6.ToString() }));

                sw.WriteLine(string.Join('\t', new List<string>() { "Y7", publicationTableLine1.y7.ToString(), publicationTableLine0.y7.ToString() }));

                sw.WriteLine(string.Join('\t', new List<string>() { "Y8", publicationTableLine1.y8.ToString(), publicationTableLine0.y8.ToString() }));

                sw.WriteLine(string.Join('\t', new List<string>() { "Y9", publicationTableLine1.y9.ToString(), publicationTableLine0.y9.ToString() }));

            }

        }

        public static SortedDictionary<int, double> getYearCount(List<GenePublicationMention> publicationList, HashSet<string> taxonomyCollection, HashSet<string> organCollection)
        {

            SortedDictionary<int, double> pubCountByYear = new SortedDictionary<int, double>();

            foreach (var item in publicationList)
            {

                if (!string.IsNullOrEmpty(item.year))
                {

                    try
                    {

                        int i = Int32.Parse(item.year);

                        if (taxonomyCollection.Contains(item.associatedNcbiId) & organCollection.Contains(item.pmId))
                        {

                            if (pubCountByYear.ContainsKey(i))
                            {

                                double count = pubCountByYear[i];

                                count++;

                                pubCountByYear[i] = count;

                            }
                            else
                            {

                                pubCountByYear.Add(i, 1);

                            }

                        }

                    }
                    catch (System.Exception)
                    {

                        Console.WriteLine("Year could not be converted into integer: " + item.year);
                        throw;

                    }

                }

            }

            return pubCountByYear;

        }

        public static string getFirstYear(List<GenePublicationMention> publicationList)
        {

            int year = 3000;

            foreach (var item in publicationList)
            {

                if (!string.IsNullOrEmpty(item.year))
                {

                    try
                    {

                        if (Int32.Parse(item.year) < year) year = Int32.Parse(item.year);

                    }
                    catch (System.Exception)
                    {

                        Console.WriteLine("Year could not be converted into intger: " + item.year);
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

        public static PublicationTableLine getPublicationTableLine(SortedDictionary<int, double> pubCountByYear)
        {

            List<double> pubCountByYearList = pubCountByYear.Values.ToList();

            List<int> pubCountByYearListKeys = pubCountByYear.Keys.ToList();


            int pubCountByYearListCount = pubCountByYearList.Count;

            for (int i = 0; i < 2; i++)
            {

                if (i == 0 & i < pubCountByYearListCount)
                {

                    Console.WriteLine("Year 1: " + pubCountByYearListKeys[i]);

                    Console.WriteLine("Value 1: " + pubCountByYearList[i]);

                }
                

                if (i == 1 & i < pubCountByYearListCount)
                {

                    Console.WriteLine("Year 2: " + pubCountByYearListKeys[i]);

                    Console.WriteLine("Value 2: " + pubCountByYearList[i]);

                }
                
            }

            PublicationTableLine publicationTableLine = new PublicationTableLine();

            publicationTableLine.y0 = 0;
            publicationTableLine.y1 = 0;
            publicationTableLine.y2 = 0;
            publicationTableLine.y3 = 0;
            publicationTableLine.y4 = 0;
            publicationTableLine.y5 = 0;
            publicationTableLine.y6 = 0;
            publicationTableLine.y7 = 0;
            publicationTableLine.y8 = 0;
            publicationTableLine.y9 = 0;

            for (int i = 0; i < 10; i++)
            {

                if (i == 0 & i < pubCountByYearListCount)
                {

                    publicationTableLine.y0 = pubCountByYearList[i];

                }
                else if (i == 1 & i < pubCountByYearListCount)
                {

                    publicationTableLine.y1 = pubCountByYearList[i];

                }
                else if (i == 2 & i < pubCountByYearListCount)
                {

                    publicationTableLine.y2 = pubCountByYearList[i];

                }
                else if (i == 3 & i < pubCountByYearListCount)
                {

                    publicationTableLine.y3 = pubCountByYearList[i];

                }
                else if (i == 4 & i < pubCountByYearListCount)
                {

                    publicationTableLine.y4 = pubCountByYearList[i];

                }
                else if (i == 5 & i < pubCountByYearListCount)
                {

                    publicationTableLine.y5 = pubCountByYearList[i];

                }
                else if (i == 6 & i < pubCountByYearListCount)
                {

                    publicationTableLine.y6 = pubCountByYearList[i];

                }
                else if (i == 7 & i < pubCountByYearListCount)
                {

                    publicationTableLine.y7 = pubCountByYearList[i];

                }
                else if (i == 8 & i < pubCountByYearListCount)
                {

                    publicationTableLine.y8 = pubCountByYearList[i];

                }
                else if (i == 9 & i < pubCountByYearListCount)
                {

                    publicationTableLine.y9 = pubCountByYearList[i];

                }

            }

            publicationTableLine.y =
            publicationTableLine.y0 +
            publicationTableLine.y1 +
            publicationTableLine.y2 +
            publicationTableLine.y3 +
            publicationTableLine.y4 +
            publicationTableLine.y5 +
            publicationTableLine.y6 +
            publicationTableLine.y7 +
            publicationTableLine.y8 +
            publicationTableLine.y9;

            if (publicationTableLine.y > 0)
            {

                publicationTableLine.y0 = publicationTableLine.y0 / publicationTableLine.y;

                publicationTableLine.y1 = publicationTableLine.y1 / publicationTableLine.y;

                publicationTableLine.y2 = publicationTableLine.y2 / publicationTableLine.y;

                publicationTableLine.y3 = publicationTableLine.y3 / publicationTableLine.y;

                publicationTableLine.y4 = publicationTableLine.y4 / publicationTableLine.y;

                publicationTableLine.y5 = publicationTableLine.y5 / publicationTableLine.y;

                publicationTableLine.y6 = publicationTableLine.y6 / publicationTableLine.y;

                publicationTableLine.y7 = publicationTableLine.y7 / publicationTableLine.y;

                publicationTableLine.y8 = publicationTableLine.y8 / publicationTableLine.y;

                publicationTableLine.y9 = publicationTableLine.y9 / publicationTableLine.y;

            }

            return publicationTableLine;

        }

        public static PublicationTableLine getPublicationTableLineAverage(List<PublicationTableLine> tableLineList)
        {

            PublicationTableLine tableLine = new PublicationTableLine();

            tableLine.y0 = 0;
            tableLine.y1 = 0;
            tableLine.y2 = 0;
            tableLine.y3 = 0;
            tableLine.y4 = 0;
            tableLine.y5 = 0;
            tableLine.y6 = 0;
            tableLine.y7 = 0;
            tableLine.y8 = 0;
            tableLine.y9 = 0;

            foreach (var item in tableLineList)
            {

                tableLine.y0 += item.y0;
                tableLine.y1 += item.y1;
                tableLine.y2 += item.y2;
                tableLine.y3 += item.y3;
                tableLine.y4 += item.y4;
                tableLine.y5 += item.y5;
                tableLine.y6 += item.y6;
                tableLine.y7 += item.y7;
                tableLine.y8 += item.y8;
                tableLine.y9 += item.y9;

            }

            if (tableLineList.Count > 0)
            {

                tableLine.y0 = tableLine.y0 / tableLineList.Count;
                tableLine.y1 = tableLine.y1 / tableLineList.Count;
                tableLine.y2 = tableLine.y2 / tableLineList.Count;
                tableLine.y3 = tableLine.y3 / tableLineList.Count;
                tableLine.y4 = tableLine.y4 / tableLineList.Count;
                tableLine.y5 = tableLine.y5 / tableLineList.Count;
                tableLine.y6 = tableLine.y6 / tableLineList.Count;
                tableLine.y7 = tableLine.y7 / tableLineList.Count;
                tableLine.y8 = tableLine.y8 / tableLineList.Count;
                tableLine.y9 = tableLine.y9 / tableLineList.Count;

            }

            return tableLine;

        }

    }

    class PublicationTableLine
    {

        public string gene;

        public string expression;

        public string year;

        public double y;

        public double y0;

        public double y1;

        public double y2;

        public double y3;

        public double y4;

        public double y5;

        public double y6;

        public double y7;

        public double y8;

        public double y9;

    }

}