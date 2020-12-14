using System;
using System.IO;
using System.Collections.Generic;

namespace EnrichFusedDataset
{
    class Ex2
    {

        public static List<Gene> run (List<Gene> geneList)
        {

            Dictionary<string, string> pubMedDateDictionary = getPubMedDateDisctionary();

            foreach (Gene geneItem in geneList)
            {

                foreach (GenePublicationMention publicationItem in geneItem.publicationMentions)
                {

                    if (pubMedDateDictionary.ContainsKey(publicationItem.pmId))
                    {

                        publicationItem.year = pubMedDateDictionary[publicationItem.pmId];

                    }
             
                }
                
            }

            return geneList;

        }

        public static Dictionary<string, string> getPubMedDateDisctionary()
        {

            Dictionary<string, string> pubMedDateDictionary = new Dictionary<string, string>();

            FileInfo pubMedDate = new FileInfo(Environment.CurrentDirectory + "/data/input/PubMedDate.csv");

            using (StreamReader sr = new StreamReader(pubMedDate.FullName))
            {
                sr.ReadLine();

                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string delimiter = ",";
                            
                    String[] values = line.Split(delimiter);

                    if (!pubMedDateDictionary.ContainsKey(values[0]))
                    {
                        
                        pubMedDateDictionary.Add(values[0], values[1]);

                    }
     
                }
                
            }

            return pubMedDateDictionary;

        }

    }

}