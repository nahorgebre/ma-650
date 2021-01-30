using System;
using System.IO;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    class OrganCollection
    {

        public HashSet<string> heart = OrganDatasets.getHeart();

        public HashSet<string> liver = OrganDatasets.getLiver();

        public HashSet<string> testis = OrganDatasets.getTestis();

        public HashSet<string> barin = OrganDatasets.getBrain();

        public HashSet<string> kidney = OrganDatasets.getKidney();

    }


    public class OrganDatasets
    {

        public static FileInfo testisFile = new FileInfo(Environment.CurrentDirectory + "/data/organ/4 article_abstract_testis.csv");

        public static FileInfo liverFile = new FileInfo(Environment.CurrentDirectory + "/data/organ/4 article_abstract_liver.csv");

        public static FileInfo kidneyFile = new FileInfo(Environment.CurrentDirectory + "/data/organ/4 article_abstract_kidney.csv");

        public static FileInfo cerebellumFile = new FileInfo(Environment.CurrentDirectory + "/data/organ/4 article_abstract_cerebellum.csv");

        public static FileInfo heartFile = new FileInfo(Environment.CurrentDirectory + "/data/organ/4 article_abstract_cardio.csv");

        public static FileInfo brainFile = new FileInfo(Environment.CurrentDirectory + "/data/organ/4 article_abstract_brain_unique.csv");


        public static HashSet<string> getTestis()
        {

            HashSet<string> organ = new HashSet<string>();

            using (StreamReader sr = new StreamReader(testisFile.FullName))
            {

                sr.ReadLine();

                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] values = line.Split(',');

                    string pmid = values[7].Trim();

                    organ.Add(pmid);

                }

            }

            return organ;

        }

        public static HashSet<string> getLiver()
        {

            HashSet<string> organ = new HashSet<string>();

            using (StreamReader sr = new StreamReader(liverFile.FullName))
            {

                sr.ReadLine();

                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] values = line.Split(',');

                    string pmid = values[7].Trim();

                    organ.Add(pmid);

                }

            }

            return organ;

        }

        public static HashSet<string> getKidney()
        {

            HashSet<string> organ = new HashSet<string>();

            using (StreamReader sr = new StreamReader(kidneyFile.FullName))
            {

                sr.ReadLine();

                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] values = line.Split(',');

                    string pmid = values[7].Trim();

                    organ.Add(pmid);

                }

            }

            return organ;

        }

        public static HashSet<string> getHeart()
        {

            HashSet<string> organ = new HashSet<string>();

            using (StreamReader sr = new StreamReader(heartFile.FullName))
            {

                sr.ReadLine();

                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] values = line.Split(',');

                    string pmid = values[7].Trim();

                    organ.Add(pmid);

                }

            }

            return organ;

        }

        public static HashSet<string> getBrain()
        {

            HashSet<string> organ = new HashSet<string>();

            using (StreamReader sr = new StreamReader(brainFile.FullName))
            {

                sr.ReadLine();

                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] values = line.Split(',');

                    string pmid = values[7].Trim();

                    organ.Add(pmid);

                }

            }

            return organ;

        }

    }

}