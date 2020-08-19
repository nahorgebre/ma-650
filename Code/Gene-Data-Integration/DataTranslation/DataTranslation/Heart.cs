using System;
using System.IO;
using System.Collections.Generic;

namespace DataTranslation
{
    public class Heart
    {
        public static string heartInputDirectory = @"data\input\Heart";
        public static string heartOutputDirectory = @"data\output\Heart";

        // heart.csv; 0-geneId; 1-disagreement; 2-call
        public static void Heart_dt()
        {
            Genes genes = new Genes();
            List<Gene> gene_list = new List<Gene>();

            using (var reader = new StreamReader(string.Format(@"{0}\{1}\{2}", Environment.CurrentDirectory, heartInputDirectory, "Heart.csv")))
            {
                reader.ReadLine();
                int counter = 1;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split(',');

                    Gene gene = new Gene();
                    gene.recordId = string.Format("Heart_{0}_rid", counter);
                    gene.ensemblId = values[0];
                    gene.disagreement = values[1];
                    gene.call = values[2];

                    gene_list.Add(gene);

                    counter++;
                }
            }
            Methods.createXml(gene_list: gene_list, fileName: "Heart_dt.xml", directory: heartOutputDirectory);
        }

        // mart.txt; 0-geneId; 1-geneDescription; 2-geneName
        public static void mart_export_heart_dt()
        {
            Genes genes = new Genes();
            List<Gene> gene_list = new List<Gene>();

            using (var reader = new StreamReader(string.Format(@"{0}\{1}\{2}", Environment.CurrentDirectory, heartInputDirectory, "mart_export_heart.txt")))
            {
                reader.ReadLine();
                int counter = 1;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split(',');

                    Gene gene = new Gene();
                    gene.recordId = string.Format("mart_export_heart_{0}_rid", counter);
                    gene.ensemblId = values[0];

                    List<geneName> geneNameList = new List<geneName>();
                    geneName GeneName = new geneName();
                    GeneName.Name = (line.Substring(line.IndexOf(",") + 1)).Substring(0, line.Substring(line.IndexOf(",") + 1).LastIndexOf(","));
                    geneNameList.Add(GeneName);
                    gene.geneNames = geneNameList;

                    gene.geneDescription = line.Substring(line.LastIndexOf(",") + 1);

                    gene_list.Add(gene);

                    counter++;
                }
            }
            Methods.createXml(gene_list: gene_list, fileName: "mart_export_heart_dt.xml", directory: heartOutputDirectory);
        }

        // ncbi; 0-ncbi; 1-geneId; 2-geneName
        public static void Heart_Ensembl_NCBI_Crosswalk_dt()
        {
            Genes genes = new Genes();
            List<Gene> gene_list = new List<Gene>();

            using (var reader = new StreamReader(string.Format(@"{0}\{1}\{2}", Environment.CurrentDirectory, heartInputDirectory, "Heart_Ensembl_NCBI_Crosswalk.txt")))
            {
                reader.ReadLine();
                int counter = 1;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split(',');

                    Gene gene = new Gene();
                    gene.recordId = string.Format("Heart_Ensembl_NCBI_Crosswalk_{0}_rid", counter);
                    gene.ncbiId = values[0];
                    gene.ensemblId = values[1];

                    List<geneName> geneNameList = new List<geneName>();
                    geneName GeneName = new geneName();
                    GeneName.Name = values[2];
                    geneNameList.Add(GeneName);
                    gene.geneNames = geneNameList;

                    gene_list.Add(gene);

                    counter++;
                }
            }
            Methods.createXml(gene_list: gene_list, fileName: "Heart_Ensembl_NCBI_Crosswalk_dt.xml", directory: heartOutputDirectory);
        }
    }
}