using System;
using System.IO;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    class DiseaseAssociationStatistics
    {

        public static void run()
        {

            // Read enriched and fused dataset
            List<Gene> geneList = Parser.getGeneList(EnrichDataset.enrichedFusedDS);

            int range09 = 0;

            int range08 = 0;

            int range07 = 0;

            int range06 = 0;

            int range05 = 0;

            int range04 = 0;

            int range03 = 0;

            int range02 = 0;

            int range01 = 0;

            int range0 = 0;

            foreach (var item in geneList)
            {

                if (!string.IsNullOrEmpty(item.overallDiseaseAssociation))
                {

                    double da = double.Parse(item.overallDiseaseAssociation);

                    if (da >= 0.9)
                    {

                        range09++;

                    }
                    else if (da >= 0.8 & da < 0.9)
                    {

                        range08++;

                    }
                    else if (da >= 0.7 & da < 0.8)
                    {

                        range07++;

                    }
                    else if (da >= 0.6 & da < 0.7)
                    {

                        range06++;

                    }
                    else if (da >= 0.5 & da < 0.6)
                    {

                        range05++;

                    }
                    else if (da >= 0.4 & da < 0.5)
                    {

                        range04++;

                    }
                    else if (da >= 0.3 & da < 0.4)
                    {

                        range03++;

                    }
                    else if (da >= 0.2 & da < 0.3)
                    {

                        range02++;

                    }
                    else if (da >= 0.1 & da < 0.2)
                    {

                        range01++;

                    }
                    else if (da >= 0 & da < 0.1)
                    {

                        range0++;

                    }

                }

            }


            FileInfo daFile = new FileInfo(Environment.CurrentDirectory + "/Statistics/daFile.txt");

            using (StreamWriter sw = new StreamWriter(daFile.FullName))
            {

                sw.WriteLine("0.9 - 1: " + range09);

                sw.WriteLine("0.8 - 0.9: " + range08);

                sw.WriteLine("0.7 - 0.8: " + range07);

                sw.WriteLine("0.6 - 0.7: " + range06);

                sw.WriteLine("0.5 - 0.6: " + range05);

                sw.WriteLine("0.4 - 0.5: " + range04);

                sw.WriteLine("0.3 - 0.4: " + range03);

                sw.WriteLine("0.2 - 0.3: " + range02);

                sw.WriteLine("0.1 - 0.2: " + range01);

                sw.WriteLine("0 - 0.1: " + range0);

            }

        }

    }

}