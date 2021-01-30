using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;

namespace DataTranslation
{

    public class Kaessmann
    {

        public static void runDataTranslation()
        {

            FileInfo xmlInput = new FileInfo(DI1.outputDirectory + "/DI1_dt.xml");

            FileInfo tsvInput = new FileInfo(DI1.outputDirectory + "/DI1_dt.tsv");


            List<Gene> gene_list = Parser.getGeneList(xmlInput);

            getNcbiIdFrequency(gene_list);


            DirectoryInfo DI2Directory = new DirectoryInfo(DI2.outputDirectory);

            DI2Directory.Create();

            File.Copy(xmlInput.FullName, DI2Directory.FullName + "/" + xmlInput.Name);

            File.Copy(tsvInput.FullName, DI2Directory.FullName + "/" + tsvInput.Name);


            DirectoryInfo DI3Directory = new DirectoryInfo(DI3.outputDirectory);

            DI3Directory.Create();

            File.Copy(xmlInput.FullName, DI3Directory.FullName + "/" + xmlInput.Name);

            File.Copy(tsvInput.FullName, DI3Directory.FullName + "/" + tsvInput.Name);

        }

        public static void runDataTranslationForDI3Output()
        {

            FileInfo file = new FileInfo(DI4.inputDirectory + "/DI3-fused.xml");

            List<Gene> gene_list = Parser.getGeneList(file);

            getNcbiIdFrequency(gene_list);

            gene_list = Output.adjustRecordId(gene_list, "DI3_{0}_rid");

            Output.createXml(gene_list: gene_list, file: new FileInfo(DI4.outputDirectory + "/DI3_dt.xml"));

            Output.createTsv(gene_list: gene_list, file: new FileInfo(DI4.outputDirectory + "/DI3_dt.tsv"));

        }

        public static void getNcbiIdFrequency(List<Gene> gene_list)
        {

            int numbRecords = gene_list.Count;

            Console.WriteLine("# of records: " + numbRecords);

            int numbRecordsWoNcbiId = 0;

            foreach (Gene geneItem in gene_list)
            {

                if (string.IsNullOrEmpty(geneItem.ncbiId))
                {
                    
                    numbRecordsWoNcbiId ++;

                }
                
            }

            Console.WriteLine("# of records without NcbiId: " + numbRecordsWoNcbiId);

            double freq = numbRecordsWoNcbiId / numbRecords;

            Console.WriteLine("Frequency of records without NcbiId: " + freq );

        }

    }

}