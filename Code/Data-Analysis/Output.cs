using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    public class Output
    {



        public static void createXml(List<Gene> gene_list, FileInfo file)
        {

            file.Directory.Create();

            XmlSerializer serializer = new XmlSerializer(typeof(Genes));

            TextWriter writer = new StreamWriter(file.FullName);

            Genes genes = new Genes();

            genes.gene = gene_list;

            serializer.Serialize(writer, genes);

            writer.Close();

            Console.WriteLine("Xml: ..." + file.FullName);

        }

        public static void createDaTsv(List<Gene> gene_list, FileInfo file)
        {

            var delimiter = "\t";

            using (StreamWriter sw = new StreamWriter(file.FullName))
            {

                List<string> firstLineContent = new List<string>()
                {

                    "ensemblId",

                    "diseaseIdUMLS",

                    "diseaseName",

                    "diseaseSpecificityIndex",

                    "diseasePleiotropyIndex",

                    "diseaseTypeDisGeNET",

                    "diseaseClassMeSH",

                    "diseaseSemanticTypeUMLS",

                    "associationScore",

                    "evidenceIndex",

                    "yearInitialReport",

                    "yearFinalReport",

                    "pmId"

                };

                var firstLine = string.Join(delimiter, firstLineContent);

                sw.WriteLine(firstLine);

                foreach (Gene item in gene_list)
                {

                    foreach (var daItem in item.diseaseAssociations)
                    {

                        List<string> lineContent = new List<string>()
                        {

                        item.ensemblId,

                        daItem.diseaseIdUMLS,

                        daItem.diseaseName,

                        daItem.diseaseSpecificityIndex,

                        daItem.diseasePleiotropyIndex,

                        daItem.diseaseTypeDisGeNET,

                        daItem.diseaseClassMeSH,

                        daItem.diseaseSemanticTypeUMLS,

                        daItem.associationScore,

                        daItem.evidenceIndex,

                        daItem.yearInitialReport,

                        daItem.yearFinalReport,

                        daItem.pmId

                        };


                        var line = string.Join(delimiter, lineContent);

                        sw.WriteLine(line);

                    }

                }

            }

            Console.WriteLine("Tsv: ..." + file.FullName);

        }


        public static void createDaTsv2(List<Gene> gene_list, FileInfo file)
        {

            var delimiter = "\t";

            using (StreamWriter sw = new StreamWriter(file.FullName))
            {

                List<string> firstLineContent = new List<string>()
                {

                    "ensemblId",

                    "diseaseIdUMLS",

                    "associationScore",

                    "evidenceIndex",

                    "pmId"

                };

                var firstLine = string.Join(delimiter, firstLineContent);

                sw.WriteLine(firstLine);

                foreach (Gene item in gene_list)
                {

                    foreach (var daItem in item.diseaseAssociations)
                    {

                        List<string> lineContent = new List<string>()
                        {

                        item.ensemblId,

                        daItem.diseaseIdUMLS,

                        daItem.associationScore,

                        daItem.evidenceIndex,

                        daItem.pmId

                        };


                        var line = string.Join(delimiter, lineContent);

                        sw.WriteLine(line);

                    }

                }

            }

            Console.WriteLine("Tsv: ..." + file.FullName);

        }

    }

}