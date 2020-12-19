using System;
using System.IO;
using System.Collections.Generic;

namespace PrepareGoldStandard
{

    class PatNum
    {

        public static HashSet<string> getPatNumHashSet()
        {

            HashSet<string> patNumHashSet = new HashSet<string>();

            using (StreamReader sr = new StreamReader(Datasets.patNum.FullName))
            {

                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    
                    var line = sr.ReadLine();

                    string[] values = line.Split(",");

                    string patNum = values[0].Replace("\"", string.Empty);

                    patNumHashSet.Add(patNum);

                }
                
            }

            return patNumHashSet;

        } 

    }

}