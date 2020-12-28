using System;
using System.IO;
using System.Collections.Generic;

namespace EnrichFusedDataset
{
    class Ex3
    {

        // Add overall disease association
        public static List<Gene> run (List<Gene> geneList)
        {
            
            foreach (Gene geneItem in geneList)
            {

                double da = 0;

                int daCount = 0;

                foreach (GeneDiseaseAssociation diseaseAssociationItem in geneItem.diseaseAssociations)
                {

                    da += double.Parse(diseaseAssociationItem.associationScore);

                    daCount += 1;
                    
                }

                double averageDa = da / daCount;

                geneItem.overallDiseaseAssociation = averageDa.ToString();

            }

            return geneList;

        }

    }

}