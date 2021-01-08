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

            FileInfo file = new FileInfo(DI2.inputDirectory + "/DI1-fused.xml");

            List<Gene> gene_list = Parser.getGeneList(file);

            getNcbiIdFrequency(gene_list);

            gene_list = Output.adjustRecordId(gene_list, "DI1_{0}_rid");


            Output.createXml(gene_list: gene_list, file: new FileInfo(DI2.outputDirectory + "/DI1_dt.xml"));

            Output.createXml(gene_list: gene_list, file: new FileInfo(DI3.outputDirectory + "/DI1_dt.xml"));

            Output.createXml(gene_list: gene_list, file: new FileInfo(DI4.outputDirectory + "/DI1_dt.xml"));


            Output.createTsv(gene_list: gene_list, file: new FileInfo(DI2.outputDirectory + "/DI1_dt.tsv"));

            Output.createTsv(gene_list: gene_list, file: new FileInfo(DI3.outputDirectory + "/DI1_dt.tsv"));

            Output.createTsv(gene_list: gene_list, file: new FileInfo(DI4.outputDirectory + "/DI1_dt.tsv"));

        }

        public static void runDataTranslationForDI3()
        {

            FileInfo file = new FileInfo(DI4.inputDirectory + "/DI2-fused.xml");

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