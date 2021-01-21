using System;
using System.IO;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    class PublicationExDS
    {

        public string ncbiId;

        public string geneNames;

        public string pmId;

        public string ressource;


        public static void run()
        {

            HashSet<PublicationExDS> publicationHashSet = new HashSet<PublicationExDS>();

            HashSet<string> organDictionary = new HashSet<string>();

            using (StreamReader sr = new StreamReader(OrganDatasets.cardioFile.FullName))
            {

                sr.ReadLine();

                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] values = line.Split(',');

                    string pmid = values[7].Trim();

                    organDictionary.Add(pmid);

                }

            }

            using (var reader = new StreamReader(Environment.CurrentDirectory + "/data/input/gene2pubtatorcentral.tsv"))
            {

                reader.ReadLine();

                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();

                    String[] values = line.Split('\t');

                    if (values[1].Trim().Equals("Gene"))
                    {

                        string[] ncbiIdArray = values[2].Split(';');

                        foreach (String ncbiId in ncbiIdArray)
                        {

                            string pmId = values[0].Trim();

                            if (organDictionary.Contains(pmId))
                            {

                                string geneNames = values[3].Trim();

                                string ressource = values[4].Trim();


                                PublicationExDS pub = new PublicationExDS();

                                pub.geneNames = geneNames;

                                pub.pmId = pmId;

                                pub.ressource = ressource;

                                pub.ncbiId = ncbiId;


                                publicationHashSet.Add(pub);

                            }

                        }

                    }

                }

            }

            using (StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "/data/output/pub.tsv"))
            {

                List<string> firstLineContent = new List<string>(){
                    "PMID",
                    "GeneName",
                    "NCBIID"
                };

                sw.WriteLine(string.Join("\t", firstLineContent));

                foreach (var item in publicationHashSet)
                {

                    List<string> lineContent = new List<string>(){
                        item.pmId,
                        item.geneNames,
                        item.ncbiId
                    };

                    sw.WriteLine(string.Join("\t", lineContent));

                }

            }

        }

    }

}