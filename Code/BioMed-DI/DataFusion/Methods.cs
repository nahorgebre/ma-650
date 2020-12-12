using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace DataFusion2
{

    public class Methods
    {

        public static List<Tuple<string, string>> getCorrespondenceList(List<FileInfo> fileList)
        {

            List<Tuple<string, string>> correspondenceList = new List<Tuple<string, string>>();

            foreach (FileInfo file in fileList)
            {

                using (StreamReader sr = new StreamReader(file.FullName))
                {

                    while (!sr.EndOfStream)
                    {

                        var line = sr.ReadLine();

                        string[] values = line.Split(",");

                        string recordId1 = values[0].Replace("\"", string.Empty);

                        string recordId2 = values[1].Replace("\"", string.Empty);

                        correspondenceList.Add(new Tuple<string, string>(recordId1, recordId2));

                    }

                }

            }

            return correspondenceList;

        }

    }

}