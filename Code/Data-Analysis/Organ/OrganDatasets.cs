using System;
using System.IO;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    public class OrganState
    {

        public bool testis = false;

        public bool liver = false;

        public bool kidney = false;

        public bool heart = false;

        public bool cerebellum = false;

        public bool cardio = false;

        public bool brain = false;

    }

    public class OrganDatasets
    {

        public static FileInfo testisFile = new FileInfo(Environment.CurrentDirectory + "/data/input/organ/4 article_abstract_testis.csv");

        public static FileInfo liverFile = new FileInfo(Environment.CurrentDirectory + "/data/input/organ/4 article_abstract_liver.csv");

        public static FileInfo kidneyFile = new FileInfo(Environment.CurrentDirectory + "/data/input/organ/4 article_abstract_kidney.csv");

        //public static FileInfo heartFile = new FileInfo( Environment.CurrentDirectory + "/data/input/organ/" );

        public static FileInfo cerebellumFile = new FileInfo(Environment.CurrentDirectory + "/data/input/organ/4 article_abstract_cerebellum.csv");

        public static FileInfo cardioFile = new FileInfo(Environment.CurrentDirectory + "/data/input/organ/4 article_abstract_cardio.csv");

        public static List<FileInfo> brainFileList = new List<FileInfo>(){
            new FileInfo( Environment.CurrentDirectory + "/data/input/organ/4 article_abstract_brain_unique.csv" ), 
            //new FileInfo( Environment.CurrentDirectory + "/data/input/organ/" ) 
        };


        public static Dictionary<string, OrganState> getOrganDictionary()
        {

            Dictionary<string, OrganState> organDictionary = new Dictionary<string, OrganState>();

            HashSet<string> overlappingPmIdHashSet = new HashSet<string>();

            // testis
            using (StreamReader sr = new StreamReader(testisFile.FullName))
            {

                sr.ReadLine();

                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] values = line.Split(',');

                    string pmid = values[7].Trim();

                    if (organDictionary.ContainsKey(pmid))
                    {

                        OrganState organSate = organDictionary[pmid];

                        organSate.testis = true;

                        organDictionary.Add(pmid, organSate);

                        overlappingPmIdHashSet.Add(pmid);

                    }
                    else
                    {

                        organDictionary.Add(pmid, new OrganState() { testis = true });

                    }

                }

            }


            // liver
            using (StreamReader sr = new StreamReader(liverFile.FullName))
            {

                sr.ReadLine();

                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] values = line.Split(',');

                    string pmid = values[7].Trim();

                    if (organDictionary.ContainsKey(pmid))
                    {

                        OrganState organSate = organDictionary[pmid];

                        organSate.liver = true;

                        organDictionary.Add(pmid, organSate);

                        overlappingPmIdHashSet.Add(pmid);

                    }
                    else
                    {

                        organDictionary.Add(pmid, new OrganState() { liver = true });

                    }

                }

            }


            // kidney
            using (StreamReader sr = new StreamReader(kidneyFile.FullName))
            {

                sr.ReadLine();

                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] values = line.Split(',');

                    string pmid = values[7].Trim();

                    if (organDictionary.ContainsKey(pmid))
                    {

                        OrganState organSate = organDictionary[pmid];

                        organSate.kidney = true;

                        organDictionary.Add(pmid, organSate);

                        overlappingPmIdHashSet.Add(pmid);

                    }
                    else
                    {

                        organDictionary.Add(pmid, new OrganState() { kidney = true });

                    }

                }

            }

            // heart
            using (StreamReader sr = new StreamReader(cardioFile.FullName))
            {

                sr.ReadLine();

                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] values = line.Split(',');

                    string pmid = values[7].Trim();

                    if (organDictionary.ContainsKey(pmid))
                    {

                        OrganState organSate = organDictionary[pmid];

                        organSate.heart = true;

                        organDictionary.Add(pmid, organSate);

                        overlappingPmIdHashSet.Add(pmid);

                    }
                    else
                    {

                        organDictionary.Add(pmid, new OrganState() { heart = true });

                    }

                }

            }

            // cerebellum
            using (StreamReader sr = new StreamReader(cerebellumFile.FullName))
            {

                sr.ReadLine();

                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] values = line.Split(',');

                    string pmid = values[7].Trim();

                    if (organDictionary.ContainsKey(pmid))
                    {

                        OrganState organSate = organDictionary[pmid];

                        organSate.cerebellum = true;

                        organDictionary.Add(pmid, organSate);

                        overlappingPmIdHashSet.Add(pmid);

                    }
                    else
                    {

                        organDictionary.Add(pmid, new OrganState() { cerebellum = true });

                    }

                }

            }

            // cardio

            // brain
            foreach (FileInfo brainFile in brainFileList)
            {

                using (StreamReader sr = new StreamReader(brainFile.FullName))
                {

                    sr.ReadLine();

                    while (!sr.EndOfStream)
                    {

                        var line = sr.ReadLine();

                        string[] values = line.Split(',');

                        string pmid = values[7].Trim();

                        if (organDictionary.ContainsKey(pmid))
                        {

                            OrganState organSate = organDictionary[pmid];

                            organSate.brain = true;

                            organDictionary.Add(pmid, organSate);

                            overlappingPmIdHashSet.Add(pmid);

                        }
                        else
                        {

                            organDictionary.Add(pmid, new OrganState() { brain = true });

                        }

                    }

                }

            }


            Console.WriteLine("# of organ-overlapping PmIds: " + overlappingPmIdHashSet);

            return organDictionary;

        }

    }

}