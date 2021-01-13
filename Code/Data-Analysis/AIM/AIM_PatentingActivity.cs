using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    class AIM_PatentingActivity
    {

        public static void run()
        {

            Console.WriteLine("AIM 3!");

            // Read enriched and fused dataset
            List<Gene> geneList = Parser.getGeneList(EnrichDataset.enrichedFusedDS3);

            FileInfo patentActivity = new FileInfo(Environment.CurrentDirectory + "/AIM/patentingActivity.tsv");


            int DiseaseAssociation_Strong_Call_Same = 0;

            int DiseaseAssociation_Strong_Call_Different = 0;

            int DiseaseAssociation_Weak_Call_Same = 0;

            int DiseaseAssociation_Weak_Call_Different = 0;


            Dictionary<string, int> geneFrequency = new Dictionary<string, int>();


            foreach (Gene geneItem in geneList)
            {

                if (!geneItem.overallDiseaseAssociation.Equals(string.Empty))
                {

                    double diseaseAssociation = double.Parse(geneItem.overallDiseaseAssociation);

                    int patentCount = geneItem.patentMentions.Count;

                    

                    if (geneItem.overallCall.Equals("1"))
                    {

                        if (diseaseAssociation >= 0.5)
                        {

                            DiseaseAssociation_Strong_Call_Same = DiseaseAssociation_Strong_Call_Same + patentCount;

                            if (geneFrequency.ContainsKey(geneItem.ensemblId))
                            {

                                int i = geneFrequency[geneItem.ensemblId];

                                i = i++;

                                geneFrequency[geneItem.ensemblId] = i;
                                
                            }
                            else
                            {

                                geneFrequency.Add(geneItem.ensemblId, 1);

                            }

                        }
                        else if (diseaseAssociation < 0.5)
                        {

                            //Console.WriteLine("3 Disease association: " + diseaseAssociation);

                            DiseaseAssociation_Weak_Call_Same = DiseaseAssociation_Weak_Call_Same + patentCount;

                        }

                    }
                    else if (geneItem.overallCall.Equals("0"))
                    {

                        //Console.WriteLine("2 Disease association: " + diseaseAssociation);

                        if (diseaseAssociation >= 0.5)
                        {

                            //Console.WriteLine("3 Disease association: " + diseaseAssociation);

                            DiseaseAssociation_Strong_Call_Different = DiseaseAssociation_Strong_Call_Different + patentCount;

                        }
                        else if (diseaseAssociation < 0.5)
                        {

                            //Console.WriteLine("3 Disease association: " + diseaseAssociation);

                            DiseaseAssociation_Weak_Call_Different = DiseaseAssociation_Weak_Call_Different + patentCount;

                        }

                    }

                }

            }


            using (StreamWriter sw = new StreamWriter(patentActivity.FullName))
            {

                sw.WriteLine("DiseaseAssociation_Strong_Call_Same: " + DiseaseAssociation_Strong_Call_Same);

                sw.WriteLine("DiseaseAssociation_Strong_Call_Different: " + DiseaseAssociation_Strong_Call_Different);

                sw.WriteLine("DiseaseAssociation_Weak_Call_Same: " + DiseaseAssociation_Weak_Call_Same);

                sw.WriteLine("DiseaseAssociation_Weak_Call_Different: " + DiseaseAssociation_Weak_Call_Different);

            }


            var sortedGeneFreqDict = from entry in geneFrequency orderby entry.Value ascending select entry;

            List<KeyValuePair<string, int>> sortedList = sortedGeneFreqDict.ToList();

            for (int i = sortedList.Count - 1; i > sortedList.Count - 10; i--)
            {

                Console.WriteLine(sortedList.Count);

                Console.WriteLine("Top 10 genes from strong-same cell: " + sortedList[i].Key + " - " + sortedList[i].Value);
                
            }

        }

    }

}