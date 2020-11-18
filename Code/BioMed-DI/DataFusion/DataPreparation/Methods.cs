using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DataPreparation
{


    public class Methods
    {


        public static void createXmlGene(List<Gene> gene_list, FileInfo file)
        {

            Console.WriteLine("Create Xml: " + file.Name);

            Console.WriteLine("Count: " + gene_list.Count);

            file.Directory.Create();

            XmlSerializer serializer = new XmlSerializer(typeof(Genes));

            TextWriter writer = new StreamWriter(file.FullName);

            Genes genes = new Genes();

            genes.gene = gene_list;

            serializer.Serialize(writer, genes);

            writer.Close();

            Console.WriteLine(file.FullName);

        }


        public static void createRecordIdListFile(FileInfo correspondences, FileInfo recordIdListFile, int index) 
        {

            HashSet<string> recordIdHashSet = new HashSet<string>();

            using (StreamReader sr = new StreamReader(correspondences.FullName))
            {
                
                while (!sr.EndOfStream)
                {
                    
                    var line = sr.ReadLine();

                    string[] values = line.Split(",");

                    recordIdHashSet.Add(values[index].Replace("\"", string.Empty));

                }

            }

            recordIdListFile.Directory.Create();

            using (StreamWriter sw = new StreamWriter(recordIdListFile.FullName))
            {

                foreach (string item in recordIdHashSet)
                {

                    sw.WriteLine(item);

                }

            }

        }


        public static bool checkRecordId(string inputRecordId, FileInfo recordIdListFile)
        {

            bool returnValue = false;

            using (StreamReader sr = new StreamReader(recordIdListFile.FullName))
            {
                
                while (!sr.EndOfStream)
                {
                    
                    string line = sr.ReadLine().Trim();

                    if (line.Equals(inputRecordId.Trim()))
                    {

                        returnValue = true;
                        
                    }

                }

            }

            return returnValue;

        }


    }


}