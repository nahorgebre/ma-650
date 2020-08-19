using System;
using System.IO;
using System.Collections.Generic;

namespace DataTranslation
{
    public class Liver
    {
        public static string liverInputDirectory = @"data\input\Liver";
        public static string liverOutputDirectory = @"data\output\Liver";

        // liver.csv; 0-geneId; 1-disagreement; 2-prob_equal_ortho_adj; 3-call
        public static void Liver_dt()
        {
            Genes genes = new Genes();
            List<Gene> gene_list = new List<Gene>();

            using (var reader = new StreamReader(string.Format(@"{0}\{1}\{2}", Environment.CurrentDirectory, liverInputDirectory, "Liver.csv")))
            {
                reader.ReadLine();
                int counter = 1;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split(',');

                    Gene gene = new Gene();
                    gene.recordId = string.Format("Liver_{0}_rid", counter);
                    gene.ensemblId = values[0];
                    gene.disagreement = values[1];
                    gene.probEqualOrthoAdj = values[2];
                    gene.call = values[3];

                    gene_list.Add(gene);

                    counter++;
                }
            }
            Methods.createXml(gene_list: gene_list, fileName: "Liver_dt.xml", directory: liverOutputDirectory);
        }

        // mart.txt; 0-geneId; 1-geneDescription; 2-geneName
        public static void mart_export_liver_dt()
        {
            Genes genes = new Genes();
            List<Gene> gene_list = new List<Gene>();

            using (var reader = new StreamReader(string.Format(@"{0}\{1}\{2}", Environment.CurrentDirectory, liverInputDirectory, "mart_export_liver.txt")))
            {
                reader.ReadLine();
                int counter = 1;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split(',');

                    Gene gene = new Gene();
                    gene.recordId = string.Format("mart_export_liver_{0}_rid", counter);
                    gene.ensemblId = values[0];
                    gene.geneDescription = (line.Substring(line.IndexOf(",") + 1)).Substring(0, line.Substring(line.IndexOf(",") + 1).LastIndexOf(","));
                    
                    List<geneName> geneNameList = new List<geneName>();
                    geneName GeneName = new geneName();
                    GeneName.Name = line.Substring(line.LastIndexOf(",") + 1);
                    geneNameList.Add(GeneName);
                    gene.geneNames = geneNameList;
                    
                    gene_list.Add(gene);

                    counter++;
                }
            }
            Methods.createXml(gene_list: gene_list, fileName: "mart_export_liver_dt.xml", directory: liverOutputDirectory);
        }
    }
}