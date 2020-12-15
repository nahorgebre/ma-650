using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace EnrichFusedDataset
{
    class AIM1output
    {

        // publication year
        // average # of genes with same behaviour in humans vs mice

        //Overall number of genes with Same-Classification in each publication year
        public static void run()
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