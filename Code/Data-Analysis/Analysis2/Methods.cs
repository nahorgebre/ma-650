using System;
using System.IO;
using System.Collections.Generic;

namespace Analysis2
{
    class Methods
    {

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

                    pubMedDateDictionary.Add(values[0], values[1]);
                    
                }
                
            }

            return pubMedDateDictionary;

        }

    }

}