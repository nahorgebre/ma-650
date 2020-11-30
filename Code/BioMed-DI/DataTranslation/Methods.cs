using System.Collections.Generic;

namespace DataTranslation
{

    public class Methods
    {

        public static List<Gene> adjustRecordId(List<Gene> geneList, string recordIdPattern)
        {

            List<Gene> adjustedGeneList = new List<Gene>();

            int counter = 1;

            foreach (Gene item in geneList)
            {
                
                item.recordId = string.Format(recordIdPattern, counter);

                adjustedGeneList.Add(item);

                counter ++;

            }

            return adjustedGeneList;

        }

    }

}