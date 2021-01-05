using System;
using System.IO;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    class AIM_PatentingActivity
    {

        public static void run()
        {

            Console.WriteLine("AIM 3!");

            // Read enriched and fused dataset
            List<Gene> geneList = Parser.getGeneList(EnrichDataset.enrichedFusedDS);

            FileInfo patentActivity = new FileInfo(Environment.CurrentDirectory + "/AIM/patentingActivity.tsv");


            int DiseaseAssociation_Strong_Call_Same = 0;

            int DiseaseAssociation_Strong_Call_Different = 0;

            int DiseaseAssociation_Weak_Call_Same = 0;

            int DiseaseAssociation_Weak_Call_Different = 0;


            foreach (Gene geneItem in geneList)
            {

                if (!geneItem.overallDiseaseAssociation.Equals(string.Empty))
                {

                    double diseaseAssociation = double.Parse(geneItem.overallDiseaseAssociation);

                    int patentCount = geneItem.patentMentions.Count;

                    Console.WriteLine("Patent Count: " + patentCount);

                    Console.WriteLine("1 Disease association: " + diseaseAssociation);


                    if (geneItem.overallCall.Equals("1"))
                    {

                        Console.WriteLine("2 Disease association: " + diseaseAssociation);

                        if (diseaseAssociation >= double.Parse("0,1"))
                        {

                            Console.WriteLine("3 Disease association: " + diseaseAssociation);

                            DiseaseAssociation_Strong_Call_Same = DiseaseAssociation_Strong_Call_Same + patentCount;

                        }
                        else if (diseaseAssociation < double.Parse("0,1"))
                        {

                            Console.WriteLine("3 Disease association: " + diseaseAssociation);

                            DiseaseAssociation_Weak_Call_Same = DiseaseAssociation_Weak_Call_Same + patentCount;

                        }

                    }
                    else if (geneItem.overallCall.Equals("0"))
                    {

                        Console.WriteLine("2 Disease association: " + diseaseAssociation);

                        if (diseaseAssociation >= double.Parse("0,1"))
                        {

                            Console.WriteLine("3 Disease association: " + diseaseAssociation);

                            DiseaseAssociation_Strong_Call_Different = DiseaseAssociation_Strong_Call_Different + patentCount;

                        }
                        else if (diseaseAssociation < double.Parse("0,1"))
                        {

                            Console.WriteLine("3 Disease association: " + diseaseAssociation);

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

        }

    }

}