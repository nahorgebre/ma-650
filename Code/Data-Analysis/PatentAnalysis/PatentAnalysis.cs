using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    class PatentCount
    {

        public int samePatentCount;

        public int differentPatentCount;

    }

    class PatentAnalysis
    {

        public static void run()
        {
            /*
            get1DMatrix();

            getSameDifferentFrequencyInKaessmannDS();

            getTop10GenesInPatents();
            */

            //getSameDifferentFrequencyForPublications();

            getTimeDependentDS();

        }

        public static void get1DMatrix()
        {

            List<Gene> geneList = Parser.getGeneList(EnrichDataset.enrichedFusedDS3);


            int Call_Same = 0;

            int Call_Different = 0;


            foreach (Gene geneItem in geneList)
            {

                int patentCount = geneItem.patentMentions.Count;

                if (geneItem.overallCall.Equals("1"))
                {

                    Call_Same = Call_Same + patentCount;

                }
                else if (geneItem.overallCall.Equals("0"))
                {

                    Call_Different = Call_Different + patentCount;

                }

            }


            double Call_Sum = (double)Call_Same + (double)Call_Different;

            double Call_Same_Frequency = (double)Call_Same / Call_Sum;

            double Call_Different_Frequency = (double)Call_Different / Call_Sum;


            Console.WriteLine(Environment.NewLine + "1D-Matrix: Frequencies of Gene Expressions in Patents");

            Console.WriteLine("Patent Call-Same: " + Call_Same);

            Console.WriteLine("Patent Call-Same Frequency: " + Call_Same_Frequency);

            Console.WriteLine("Patent Call-Different: " + Call_Different);

            Console.WriteLine("Patent Call-Different Frequency: " + Call_Different_Frequency);

        }

        public static void getSameDifferentFrequencyInKaessmannDS()
        {

            List<Gene> geneList = Parser.getGeneList(EnrichDataset.enrichedFusedDS1);


            int Call_Same = 0;

            int Call_Different = 0;


            foreach (Gene geneItem in geneList)
            {

                if (geneItem.overallCall.Equals("1"))
                {

                    Call_Same++;

                }
                else if (geneItem.overallCall.Equals("0"))
                {

                    Call_Different++;

                }

            }

            double Call_Sum = (double)Call_Same + (double)Call_Different;

            double Call_Same_Frequency = (double)Call_Same / Call_Sum;

            double Call_Different_Frequency = (double)Call_Different / Call_Sum;


            Console.WriteLine(Environment.NewLine + "1D-Matrix: Frequencies of Gene Expressions in Kaessmann Data Source");

            Console.WriteLine("Call-Same: " + Call_Same);

            Console.WriteLine("Call-Same Frequency: " + Call_Same_Frequency);

            Console.WriteLine("Call-Different: " + Call_Different);

            Console.WriteLine("Call-Different Frequency: " + Call_Different_Frequency);

        }

        public static void getSameDifferentFrequencyForPublications()
        {

            List<Gene> geneList = Parser.getGeneList(EnrichDataset.enrichedFusedDS2);


            int Call_Same = 0;

            int Call_Different = 0;


            foreach (Gene geneItem in geneList)
            {

                int pubCount = geneItem.publicationMentions.Count;

                if (geneItem.overallCall.Equals("1"))
                {

                    Call_Same += pubCount;

                }
                else if (geneItem.overallCall.Equals("0"))
                {

                    Call_Different += pubCount;

                }

            }

            double Call_Sum = (double)Call_Same + (double)Call_Different;

            double Call_Same_Frequency = (double)Call_Same / Call_Sum;

            double Call_Different_Frequency = (double)Call_Different / Call_Sum;


            Console.WriteLine(Environment.NewLine + "1D-Matrix: Frequencies of Gene Expressions in Publications");

            Console.WriteLine("Call-Same: " + Call_Same);

            Console.WriteLine("Call-Same Frequency: " + Call_Same_Frequency);

            Console.WriteLine("Call-Different: " + Call_Different);

            Console.WriteLine("Call-Different Frequency: " + Call_Different_Frequency);

        }

        public static void getTop10GenesInPatents()
        {

            List<Gene> geneList = Parser.getGeneList(EnrichDataset.enrichedFusedDS3);

            Dictionary<string, int> geneFrequency = new Dictionary<string, int>();

            foreach (Gene geneItem in geneList)
            {

                if (geneItem.overallCall.Equals("1"))
                {

                    if (geneFrequency.ContainsKey(geneItem.ensemblId))
                    {

                        int i = geneFrequency[geneItem.ensemblId];

                        foreach (var item in geneItem.patentMentions)
                        {

                            i++;

                        }

                        geneFrequency[geneItem.ensemblId] = i;

                    }
                    else
                    {

                        int i = geneItem.patentMentions.Count;

                        geneFrequency.Add(geneItem.ensemblId, i);

                    }

                }

            }

            var sortedDict = from entry in geneFrequency orderby entry.Value descending select entry;

            Console.WriteLine(Environment.NewLine + "Top 10 genes with same call in patents");

            for (int i = 0; i < 10; i++)
            {

                Console.WriteLine("Gene-Entity: " + sortedDict.ToList()[i].Key + " - Count: " + sortedDict.ToList()[i].Value);

            }

        }

        public static void getTimeDependentDS()
        {

            List<Gene> geneList = Parser.getGeneList(EnrichDataset.enrichedFusedDS3);

            SortedDictionary<int, PatentCount> patentCountByYearSD = new SortedDictionary<int, PatentCount>();

            foreach (var geneItem in geneList)
            {

                foreach (var patentItem in geneItem.patentMentions)
                {

                    int patentyear = Int32.Parse(patentItem.patentDate.Substring(0, 4));

                    if (patentCountByYearSD.ContainsKey(patentyear))
                    {

                        PatentCount patentCount = patentCountByYearSD[patentyear];

                        if (geneItem.overallCall.Equals("1"))
                        {

                            patentCount.samePatentCount++;

                        }
                        else if (geneItem.overallCall.Equals("0"))
                        {

                            patentCount.differentPatentCount++;

                        }

                        patentCountByYearSD[patentyear] = patentCount;

                    }
                    else
                    {

                        PatentCount patentCount = new PatentCount() { samePatentCount = 0, differentPatentCount = 0 };

                        if (geneItem.overallCall.Equals("1"))
                        {

                            patentCount.samePatentCount++;

                        }
                        else if (geneItem.overallCall.Equals("0"))
                        {

                            patentCount.differentPatentCount++;

                        }

                        patentCountByYearSD.Add(patentyear, patentCount);

                    }

                }

            }

            FileInfo outputFile = new FileInfo(Environment.CurrentDirectory + "/PatentAnalysis/patentTimeDependetData.tsv");

            using (StreamWriter sw = new StreamWriter(outputFile.FullName))
            {

                foreach (var item in patentCountByYearSD)
                {

                    List<string> line = new List<string>()
                    {
                        item.Key.ToString(),
                        item.Value.samePatentCount.ToString(),
                        item.Value.differentPatentCount.ToString()
                    };

                    sw.WriteLine(string.Join('\t', line));

                }

            }

        }

    }

}