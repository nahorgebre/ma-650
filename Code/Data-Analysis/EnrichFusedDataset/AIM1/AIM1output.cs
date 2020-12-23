using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    class AIM1output
    {

        public string year;

        // pubAll
        public int pubAll = 0;
        public int pubAllMusMusculus = 0;
        public int pubAllHomoSapiens = 0;
        public int pubAllMusMusculusHomoSapiens = 0;

        // pubSame
        public int pubSame = 0;
        public int pubSameMusMusculus = 0;
        public int pubSameHomoSapiens = 0;
        public int pubSameMusMusculusHomoSapiens = 0;

        // pubDiff
        public int pubDiff = 0;
        public int pubDiffMusMusculus = 0;
        public int pubDiffHomoSapiens = 0;
        public int pubDiffMusMusculusHomoSapiens = 0;


        public static void run()
        {

            List<AIM1output> aim1List = getAim1List();

            // aim1
            // year, pubAll, pubSame, pubDiff
            FileInfo aim1 = new FileInfo(Environment.CurrentDirectory + "/AIM1/aim1.tsv");
            using (StreamWriter sw = new StreamWriter(aim1.FullName))
            {

                List<string> firstLine = new List<string>() { "year", "pubAll", "pubSame", "pubDiff" };
                
                sw.WriteLine(string.Join('\t', firstLine));

            }

            // aim1MusMusculus
            // year, pubAllMusMusculus, pubSameMusMusculus, pubDiffMusMusculus
            FileInfo aim1MusMusculus = new FileInfo(Environment.CurrentDirectory + "/AIM1/aim1MusMusculus.tsv");
            using (StreamWriter sw = new StreamWriter(aim1MusMusculus.FullName))
            {

                List<string> firstLine = new List<string>() { "year", "pubAllMusMusculus", "pubSameMusMusculus", "pubDiffMusMusculus" };
                
                sw.WriteLine(string.Join('\t', firstLine));
                
            }

            // aim1HomoSapiens
            // year, pubAllHomoSapiens, pubSameHomoSapiens, pubDiffHomoSapiens
            FileInfo aim1HomoSapiens = new FileInfo(Environment.CurrentDirectory + "/AIM1/aim1HomoSapiens.tsv");
            using (StreamWriter sw = new StreamWriter(aim1HomoSapiens.FullName))
            {

                List<string> firstLine = new List<string>() { "year", "pubAllHomoSapiens", "pubSameHomoSapiens", "pubDiffHomoSapiens" };
                
                sw.WriteLine(string.Join('\t', firstLine));
                
            }

            // aim1MusMusculusHomoSapiens
            // year, pubAllMusMusculusHomoSapiens, pubSameMusMusculusHomoSapiens, pubDiffMusMusculusHomoSapiens
            FileInfo aim1MusMusculusHomoSapiens = new FileInfo(Environment.CurrentDirectory + "/AIM1/aim1MusMusculusHomoSapiens.tsv");
            using (StreamWriter sw = new StreamWriter(aim1MusMusculusHomoSapiens.FullName))
            {

                List<string> firstLine = new List<string>() { "year", "pubAllMusMusculusHomoSapiens", "pubSameMusMusculusHomoSapiens", "pubDiffMusMusculusHomoSapiens" };
                
                sw.WriteLine(string.Join('\t', firstLine));
                
            }

        }

        public static List<AIM1output> getAim1List()
        {

            List<AIM1output> aim1List = new List<AIM1output>();


            List<Gene> geneList = Parser.getGeneList(EnrichDataset.analysis2Output);


            HashSet<string> homoSapiensHashSet = TaxonomyDatasets.getHomoSapiens();

            HashSet<string> musMusculusHashSet = TaxonomyDatasets.getMusMusculus();

            HashSet<string> musMusculusHomoSapiensHashSet =TaxonomyDatasets.getMusMusculusHomoSapiens();


            Dictionary<int, AIM1output> aim1Dictionary = new Dictionary<int, AIM1output>();

            foreach (Gene geneItem in geneList)
            {

                foreach (GenePublicationMention publicationItem in geneItem.publicationMentions)
                {

                    int year = Int32.Parse(publicationItem.year);

                    if (!aim1Dictionary.ContainsKey(year))
                    {
                        
                        aim1Dictionary.Add(year, new AIM1output{year = publicationItem.year, pubAll = 0, pubAllMusMusculus = 0, pubAllHomoSapiens = 0, 
                            pubAllMusMusculusHomoSapiens = 0, pubSame = 0, pubSameMusMusculus = 0, pubSameHomoSapiens = 0, pubSameMusMusculusHomoSapiens = 0, 
                            pubDiff = 0, pubDiffMusMusculus = 0, pubDiffHomoSapiens = 0, pubDiffMusMusculusHomoSapiens = 0} );

                    }


                    AIM1output item = aim1Dictionary[year];

                    // all

                    

                    aim1Dictionary[year] = item;



                    // all

                    AIM1output item_all = aim1Dictionary[year];

                    aim1Dictionary[year] = item_all;


                    // mus musculus

                    AIM1output item_mus_musculus = aim1Dictionary[year];

                    aim1Dictionary[year] = item_mus_musculus;


                    // homo sapiens

                    AIM1output item_homo_sapiens = aim1Dictionary[year];

                    aim1Dictionary[year] = item_homo_sapiens;


                    // mus musculus & homo sapiens

                    AIM1output item_mus_musculus_homo_sapiens = aim1Dictionary[year];

                    aim1Dictionary[year] = item_mus_musculus_homo_sapiens;
                    
                }
                
            }

            return aim1List;

        }



        // publication year
        // average # of genes with same behaviour in humans vs mice

        //Overall number of genes with Same-Classification in each publication year
        public static void runx()
        {

            List<Gene> geneList = Parser.getGeneList(new FileInfo(Environment.CurrentDirectory + "/data/output/analysis2.xml"));

            Dictionary<int, int> ds = new Dictionary<int, int>();

            foreach (Gene geneItem in geneList)
            {

                if (geneItem.overallCall.Equals("1"))
                {

                    foreach (GenePublicationMention pubItem in geneItem.publicationMentions)
                    {

                        if (!string.IsNullOrEmpty(pubItem.year))
                        {

                            if (ds.ContainsKey(Convert.ToInt16(pubItem.year)))
                            {
                                ds[Convert.ToInt16(pubItem.year)] = ds[Convert.ToInt16(pubItem.year)] + 1;
                            }
                            else
                            {
                                ds.Add(Convert.ToInt16(pubItem.year), 1);
                            }

                        }

                    }

                }

            }

            foreach (var item in ds)
            {

                if (item.Key < 1985)
                {

                    ds.Remove(item.Key);
                    
                }

            }

            ds.Remove(2020);

            List<KeyValuePair<int,int>> dsList = ds.OrderByDescending(k => k.Key).ToList();

            using (StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "/AIM1/graph1.csv"))
            {

                foreach (var item in dsList)
                {
                    sw.WriteLine(item.Key + "," + item.Value);
                }

            }
  
        }

        public static void run2() {

            List<Gene> geneList = Parser.getGeneList(new FileInfo(Environment.CurrentDirectory + "/data/output/analysis2.xml"));

            Dictionary<int, Tuple<int, int, int>> ds = new Dictionary<int, Tuple<int, int, int>>();

            foreach (Gene geneItem in geneList)
            {

                if (geneItem.overallCall.Equals("1"))
                {

                    foreach (GenePublicationMention pubItem in geneItem.publicationMentions)
                    {

                        if (!string.IsNullOrEmpty(pubItem.year))
                        {

                            if (ds.ContainsKey(Convert.ToInt16(pubItem.year)))
                            {
                                ds[Convert.ToInt16(pubItem.year)] = new Tuple<int, int, int>(ds[Convert.ToInt16(pubItem.year)].Item1 + 1, ds[Convert.ToInt16(pubItem.year)].Item2, ds[Convert.ToInt16(pubItem.year)].Item3);
                            }
                            else
                            {
                                ds.Add(Convert.ToInt16(pubItem.year), new Tuple<int, int, int>(1, 0, 0));
                            }

                        }

                    }

                }
                else
                {

                    foreach (GenePublicationMention pubItem in geneItem.publicationMentions)
                    {

                        if (!string.IsNullOrEmpty(pubItem.year))
                        {

                            if (ds.ContainsKey(Convert.ToInt16(pubItem.year)))
                            {
                                ds[Convert.ToInt16(pubItem.year)] = new Tuple<int, int, int>(ds[Convert.ToInt16(pubItem.year)].Item1, ds[Convert.ToInt16(pubItem.year)].Item2 + 1, ds[Convert.ToInt16(pubItem.year)].Item3);
                            }
                            else
                            {
                                ds.Add(Convert.ToInt16(pubItem.year), new Tuple<int, int, int>(0, 1, 0));
                            }

                        }

                    }

                }

            }

            foreach (var item in ds)
            {

                if (item.Key < 1985)
                {

                    ds.Remove(item.Key);
                    
                }

            }

            ds.Remove(2020);

            using (StreamReader sr = new StreamReader(Environment.CurrentDirectory + "/data/input/PubMedDate.csv"))
            {

                sr.ReadLine();
                
                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] values = line.Split(',');

                    if (!string.IsNullOrEmpty(values[1]))
                    {

                        if (ds.ContainsKey(Int16.Parse(values[1])))
                        {

                            ds[Int16.Parse(values[1])] = new Tuple<int, int, int>(ds[Int16.Parse(values[1])].Item1, ds[Int16.Parse(values[1])].Item2, ds[Int16.Parse(values[1])].Item3 + 1);
                        
                        }

                    }
         
                }

            }


            List<KeyValuePair<int,Tuple<int, int, int>>> dsList = ds.OrderByDescending(k => k.Key).ToList();

            using (StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "/AIM1/graph4.csv"))
            {

                //item1 contains same classification
                //item2 contains different classification
                //item3 contains all PubMed publications

                foreach (var item in dsList)
                {

                    sw.WriteLine(item.Key + "," + item.Value.Item1 + "," + item.Value.Item2 + "," + item.Value.Item3);

                }

            }

        }




        //Average number of genes with Same-Classification per publication
        public static void run3() {

            List<Gene> geneList = Parser.getGeneList(new FileInfo(Environment.CurrentDirectory + "/data/output/analysis2.xml"));

            Dictionary<string, Tuple<int,int>> dic1 = new Dictionary<string, Tuple<int, int>>();

            foreach (Gene geneItem in geneList)
            {

                if (geneItem.overallCall.Equals("1"))
                {

                    foreach (GenePublicationMention pubItem in geneItem.publicationMentions)
                    {

                        if (!string.IsNullOrEmpty(pubItem.year))
                        {

                            if (dic1.ContainsKey(pubItem.pmId))
                            {

                                dic1[pubItem.pmId] = new Tuple<int, int>((dic1[pubItem.pmId].Item1), (dic1[pubItem.pmId].Item2 + 1));
                                
                            }
                            else
                            {

                                dic1.Add(pubItem.pmId, new Tuple<int, int>(Convert.ToInt16(pubItem.year), 1));

                            }

                        }

                    }

                }

            }


            Dictionary<int, List<int>> dic2 = new Dictionary<int, List<int>>();

            foreach (var item in dic1)
            {
                if (dic2.ContainsKey(item.Value.Item1))
                {

                    int X = item.Value.Item2;
                    List<int> xList = dic2[item.Value.Item1];
                    xList.Add(X);

                    dic2[item.Value.Item1] = xList;

                }
                else
                {

                    dic2.Add(item.Value.Item1, new List<int>(item.Value.Item2));

                }

            }


            foreach (var item in dic2)
            {

                if (item.Key < 1985)
                {

                    dic2.Remove(item.Key);
                    
                }

            }


            Dictionary<int, double> dic3 = new Dictionary<int, double>();

            foreach (var item in dic2)
            {

                dic3.Add(item.Key, item.Value.Average());
                
            }

            

            List<KeyValuePair<int,double>> dsList = dic3.OrderByDescending(k => k.Value).ToList();

            using (StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "/AIM1/graph2.csv"))
            {

                foreach (var item in dsList)
                {
                    sw.WriteLine(item.Key + "," + item.Value);
                }

            }


        }

    }

}