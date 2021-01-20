using System;
using System.IO;
using System.Collections.Generic;

namespace EnrichFusedDataset
{
    class Ex3
    {

        // Add overall disease association
        public static List<Gene> run(List<Gene> geneList)
        {

            foreach (Gene geneItem in geneList)
            {
                
                if (geneItem.diseaseAssociations.Count > 258)
                {

                    geneItem.overallDiseaseAssociation = "1";
                    
                }
                else
                {

                    geneItem.overallDiseaseAssociation = "0";

                }
                //geneItem.overallDiseaseAssociation = getMaxValue(geneItem.diseaseAssociations).ToString();

                //geneItem.overallDiseaseAssociation = getAverage(geneItem.diseaseAssociations).ToString();

            }

            return geneList;

        }

        public static double getAverage(List<GeneDiseaseAssociation> daList)
        {

            double da = 0;

            int daCount = 0;

            double average = new double();

            if (daList.Count > 0)
            {

                foreach (GeneDiseaseAssociation diseaseAssociationItem in daList)
                {

                    da += double.Parse(diseaseAssociationItem.associationScore.Replace('.', ','));

                    daCount += 1;

                }

                average = da / daCount;

            }

            return average;

        }

        public static double getMaxValue(List<GeneDiseaseAssociation> daList)
        {

            double max = new double();

            if (daList.Count > 0)
            {

                foreach (GeneDiseaseAssociation diseaseAssociationItem in daList)
                {

                    double score = double.Parse(diseaseAssociationItem.associationScore.Replace('.', ','));

                    if (max == new double())
                    {

                        max = score;

                    }
                    else if (max < score)
                    {

                        max = score;

                    }

                }

            }

            return max;

        }

    }

}