using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Analysis2
{
    class PubMedYear
    {

        public static List<int> getSortedYearList()
        {

            SortedSet<int> yearSet = new SortedSet<int>();

            using (StreamReader sr = new StreamReader(Environment.CurrentDirectory + "/data/input/PubMedDate.csv"))
            {
                sr.ReadLine();

                while (!sr.EndOfStream)
                {

                    string year = sr.ReadLine().Split(',')[1];

                    int patentYear = Int32.Parse(year);

                    yearSet.Add(patentYear);

                }

            }

            return yearSet.ToList();

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

        public static List<Gene> addYear(List<Gene> geneList)
        {

            Dictionary<string, string> pubMedDateDictionary = PubMedYear.getPubMedDateDisctionary();

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

    }

}