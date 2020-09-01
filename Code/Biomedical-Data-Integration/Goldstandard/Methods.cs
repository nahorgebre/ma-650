using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Collections.Generic;

namespace Goldstandard
{

    class Methods
    {
        public static List<Gene> readXmlFile(string path)
        {
            List<Gene> gene_list = new List<Gene>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/genes/gene");

            foreach (XmlNode node in nodeList)
            {
                Gene gene = new Gene();

                gene.recordId = node.SelectSingleNode("recordId").InnerText;
                
                gene.ensemblId = node.SelectSingleNode("ensemblId").InnerText;

                XmlNodeList geneNameNodeList =node.SelectNodes("/geneNames/geneName");
                List<string> geneNameList = new List<string>();
                foreach (XmlNode geneNameNode in geneNameNodeList)
                {
                    geneNameList.Add(geneNameNode.SelectSingleNode("Name").InnerText);
                }
                gene.geneNameList = geneNameList;

                gene.ncbiId = node.SelectSingleNode("ncbiId").InnerText;

                gene_list.Add(gene);
            }

            return gene_list;
        }



        public static (List<Goldstandard>, List<Goldstandard>) compareUsingGeneName(List<Gene> file1, List<Gene> file2, int length)
        {
            List<Goldstandard> goldstandardListTrue = new List<Goldstandard>();
            List<Goldstandard> goldstandardListFalse = new List<Goldstandard>();

            foreach (Gene gene1 in file1.GetRange(0, file1.Count / 2))
            {
                foreach (Gene gene2 in file2.GetRange(0, file2.Count / 2))
                {
                    Goldstandard goldstandard = new Goldstandard();

                    foreach (string gene1Name in gene1.geneNameList)
                    {
                        foreach (string gene2Name in gene2.geneNameList)
                        {
                            
                        if (goldstandardListTrue.Count < length / 2 && gene1Name.Equals(gene2Name))
                        {
                            goldstandard.dataset1_id = gene1.recordId;
                            goldstandard.dataset2_id = gene2.recordId;
                            goldstandard.value = "TRUE";
                            goldstandardListTrue.Add(goldstandard);
                        }

                        if (goldstandardListFalse.Count < length / 2 && !gene1Name.Equals(gene2Name))
                        {
                            if (checkIfList1ContainsItem(goldstandardListFalse, gene1.recordId) && checkIfList2ContainsItem(goldstandardListFalse, gene2.recordId))
                            {
                                goldstandard.dataset1_id = gene1.recordId;
                                goldstandard.dataset2_id = gene2.recordId;
                                goldstandard.value = "FALSE";
                                goldstandardListFalse.Add(goldstandard);
                            }
                        }

                        }
                    }

                }
            }
            return (goldstandardListTrue, goldstandardListFalse);
        }

        public static (List<Goldstandard>, List<Goldstandard>) compareUsingGeneId(List<Gene> file1, List<Gene> file2, int length)
        {
            List<Goldstandard> goldstandardListTrue = new List<Goldstandard>();
            List<Goldstandard> goldstandardListFalse = new List<Goldstandard>();

            foreach (Gene gene1 in file1.GetRange(0, file1.Count / 2))
            {
                foreach (Gene gene2 in file2.GetRange(0, file2.Count / 2))
                {
                    Goldstandard goldstandard = new Goldstandard();

                    if (goldstandardListTrue.Count < length / 2 && gene1.ensemblId.Equals(gene2.ensemblId))
                    {
                        goldstandard.dataset1_id = gene1.recordId;
                        goldstandard.dataset2_id = gene2.recordId;
                        goldstandard.value = "TRUE";
                        goldstandardListTrue.Add(goldstandard);
                    }

                    if (goldstandardListFalse.Count < length / 2 && !gene1.ensemblId.Equals(gene2.ensemblId))
                    {
                        if(checkIfList1ContainsItem(goldstandardListFalse, gene1.recordId) && checkIfList2ContainsItem(goldstandardListFalse, gene2.recordId))
                        {
                            goldstandard.dataset1_id = gene1.recordId;
                            goldstandard.dataset2_id = gene2.recordId;
                            goldstandard.value = "FALSE";
                            goldstandardListFalse.Add(goldstandard);
                        }

                    }
                }
            }

            return (goldstandardListTrue, goldstandardListFalse);
        }

        public static bool checkIfList1ContainsItem(List<Goldstandard> list, string iD)
        {
            foreach(Goldstandard goldstandard in list)
            {
                if (goldstandard.dataset1_id.Equals(iD)) return false;
            }
            return true;
        }

        public static bool checkIfList2ContainsItem(List<Goldstandard> list, string iD)
        {
            foreach (Goldstandard goldstandard in list)
            {
                if (goldstandard.dataset2_id.Equals(iD)) return false;
            }
            return true;
        }

        public static void createGoldStandard(List<Goldstandard> goldstandardTrue, List<Goldstandard> goldstandardFalse, string fileName)
        {
            Console.WriteLine("1. True: " + goldstandardTrue.Count + " False: " + goldstandardFalse.Count);
            createTestAndTrainFile(goldstandardTrue, goldstandardFalse, fileName);
            Console.WriteLine("2. True: " + goldstandardTrue.Count + " False: " + goldstandardFalse.Count);
            createSingleFile(goldstandardTrue, goldstandardFalse, fileName);          
        }

        public static void createSingleFile(List<Goldstandard> goldstandardTrue, List<Goldstandard> goldstandardFalse, string fileName)
        {
            generateCsv(fileName + ".csv", combineLists(goldstandardTrue, goldstandardFalse));
        }

        public static void createTestAndTrainFile(List<Goldstandard> goldstandardTrue, List<Goldstandard> goldstandardFalse, string fileName)
        {
            List<Goldstandard> TrainTrue = new List<Goldstandard>();
            List<Goldstandard> TrainFalse = new List<Goldstandard>();

            List<Goldstandard> TestTrue = new List<Goldstandard>();
            List<Goldstandard> TestFalse = new List<Goldstandard>();

            Console.WriteLine("3. True: " + goldstandardTrue.Count + " False: " + goldstandardFalse.Count);

            
            int lengthTrue = goldstandardTrue.Count / 2;
            for (int i = 0; i < goldstandardTrue.Count; i++)
            {
                if (i < lengthTrue)
                {
                    TrainTrue.Add(goldstandardTrue[i]);
                }
                else if (i >= lengthTrue)
                {
                    TestTrue.Add(goldstandardTrue[i]);
                }
            }

            int lengthFalse = goldstandardTrue.Count / 2;
            for (int i = 0; i < goldstandardFalse.Count; i++)
            {
                if (i < lengthFalse)
                {
                    TrainFalse.Add(goldstandardFalse[i]);
                }
                else if (i >= lengthFalse)
                {
                    TestFalse.Add(goldstandardFalse[i]);
                }
            }

            generateCsv(fileName + "_Train.csv", combineLists(TrainTrue, TrainFalse));
            Console.WriteLine(fileName + "-Train: True:" + TrainTrue.Count + ", False:" + TrainFalse.Count);
            
            generateCsv(fileName + "_Test.csv", combineLists(TestTrue, TestFalse));
            Console.WriteLine(fileName + "-Test: True:" + TestTrue.Count + ", False:" + TestFalse.Count);
        }

        public static List<Goldstandard> combineLists(List<Goldstandard> list1, List<Goldstandard> list2)
        {
            List<Goldstandard> combined = new List<Goldstandard>();
            combined = list1;
            foreach (Goldstandard goldstandard in list2)
            {
                combined.Add(goldstandard);
            }
            return combined;
        }

        public static void generateCsv(string fileName, List<Goldstandard> goldstandardList)
        {
            var csv = new StringBuilder();
            foreach (Goldstandard goldstandard in goldstandardList)
            {
                var newLine = string.Format("{0},{1},{2}", goldstandard.dataset1_id, goldstandard.dataset2_id, goldstandard.value);
                csv.AppendLine(newLine);
            }
            File.WriteAllText(fileName, csv.ToString());
        }
    }

    class PublicationMethods
    {
        public static List<PubMedPublication> readXmlFile(string path)
        {
            List<PubMedPublication> publication_list = new List<PubMedPublication>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(string.Format("./data/{0}", path));
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/publications/publication");

            foreach (XmlNode node in nodeList)
            {
                PubMedPublication publication = new PubMedPublication();
                publication.id = node.SelectSingleNode("recordId").InnerText;
                publication.pmid = node.SelectSingleNode("pmid").InnerText;

                publication_list.Add(publication);
            }

            return publication_list;
        }

        public static (List<Goldstandard>, List<Goldstandard>) CompareUsingPmid(List<PubMedPublication> file1, List<PubMedPublication> file2, int length)
        {
            List<Goldstandard> goldstandardListTrue = new List<Goldstandard>();
            List<Goldstandard> goldstandardListFalse = new List<Goldstandard>();

            foreach (PubMedPublication pub1 in file1.GetRange(0, file1.Count / 2))
            {
                foreach (PubMedPublication pub2 in file2.GetRange(0, file2.Count / 2))
                {
                    Goldstandard goldstandard = new Goldstandard();

                    if (goldstandardListTrue.Count < length / 2 && pub1.pmid.Equals(pub2.pmid))
                    {
                        goldstandard.dataset1_id = pub1.id;
                        goldstandard.dataset2_id = pub2.id;
                        goldstandard.value = "TRUE";
                        goldstandardListTrue.Add(goldstandard);
                    }

                    if (goldstandardListFalse.Count < length / 2 && !pub1.pmid.Equals(pub2.pmid))
                    {
                        if (checkIfList1ContainsItem(goldstandardListFalse, pub1.id) && checkIfList2ContainsItem(goldstandardListFalse, pub2.id))
                        {
                            goldstandard.dataset1_id = pub1.id;
                            goldstandard.dataset2_id = pub2.id;
                            goldstandard.value = "FALSE";
                            goldstandardListFalse.Add(goldstandard);
                        }

                    }
                }
            }

            return (goldstandardListTrue, goldstandardListFalse);
        }

        public static bool checkIfList1ContainsItem(List<Goldstandard> list, string iD)
        {
            foreach (Goldstandard goldstandard in list)
            {
                if (goldstandard.dataset1_id.Equals(iD)) return false;
            }
            return true;
        }

        public static bool checkIfList2ContainsItem(List<Goldstandard> list, string iD)
        {
            foreach (Goldstandard goldstandard in list)
            {
                if (goldstandard.dataset2_id.Equals(iD)) return false;
            }
            return true;
        }
    }
}