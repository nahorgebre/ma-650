using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace GoldstandardCreation
{
    class Publication
    {

        public static int pubTatorPartitionSize = 100;

        public static void run() {

            createKaessmannTsv();
            kaessmann_2_gene2pubtatorcentral();

        }

        public static void kaessmann_2_gene2pubtatorcentral() {

            FileInfo tsvFile = new FileInfo(string.Format("{0}/data/input/Kaessmann/kaessmann-fused.tsv", Environment.CurrentDirectory));

            if (File.Exists(tsvFile.FullName))
            {

                for (int i = 1; i <= Publication.pubTatorPartitionSize; i++)
                {
                    string comparison = "kaessmann_2_gene2pubtatorcentral_" + i;
                    string directoryName = string.Format("{0}/data/output/Publication/{1}", Environment.CurrentDirectory, comparison);
                    string trueFile = string.Format("{0}/true.csv", directoryName);
                    string falseFile = string.Format("{0}/false.csv", directoryName);
                    Directory.CreateDirectory(directoryName);
                    if (!File.Exists(trueFile) | !File.Exists(falseFile))
                    {
                        Console.WriteLine(comparison);
                        (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFilesPubTator(tsvFile.FullName, Datasets.getGene2pubtatorcentral_path(i), 4);
                        Methods.createOuput(trueFile, trueList);
                        Methods.createOuput(falseFile, falseList);
                    }
                }
                
            }

        }

        public static void createKaessmannTsv() {

            FileInfo xmlFile = new FileInfo(string.Format("{0}/data/input/Kaessmann/kaessmann-fused.xml", Environment.CurrentDirectory));
            FileInfo tsvFile = new FileInfo(string.Format("{0}/data/input/Kaessmann/kaessmann-fused.tsv", Environment.CurrentDirectory));

            if (File.Exists(xmlFile.FullName))
            {

                var delimiter = "\t";

                using (StreamWriter sw = new StreamWriter(tsvFile.FullName)) 
                {
                
                    List<string> firstLineContent = new List<string>()
                    {
                        "recordId",
                        "ensemblId",
                        "ncbiId",
                        "geneName",
                        "pmId"
                    };
                    var firstLine = string.Join(delimiter, firstLineContent);
                    sw.WriteLine(firstLine);

                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.DtdProcessing = DtdProcessing.Parse;

                    using (XmlReader reader = XmlReader.Create(xmlFile.FullName, settings))
                    {

                        while (reader.ReadToFollowing("gene"))
                        {
                        
                            string recordId = "NaN";
                            reader.ReadToFollowing("recordId");
                            recordId = reader.ReadElementContentAsString();

                            string ensemblId = "NaN";
                            reader.ReadToFollowing("ensemblId");
                            ensemblId = reader.ReadElementContentAsString();

                            string ncbiId = "NaN";

                            string geneName = "NaN";
                            reader.ReadToFollowing("geneName");
                            geneName = reader.ReadElementContentAsString();

                            string pmId = "NaN";

                            List<string> lineContent = new List<string>()
                            {
                                recordId,
                                ensemblId,
                                ncbiId,
                                geneName,
                                pmId
                            };
                            var line = string.Join(delimiter, lineContent);
                            sw.WriteLine(line);

                        }

                    }

                }
                
            }

        }
    
    }

}