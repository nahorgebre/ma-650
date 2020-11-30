using System;
using System.IO;
using System.Collections.Generic;

namespace DataTranslation
{

    public class Liver
    {

        public static void runDataTranslation() 
        {

            Directory.CreateDirectory(string.Format("{0}/{1}", Environment.CurrentDirectory, DI1.outputDirectory));

            Liver.Liver_dt();

            Liver.mart_export_liver_dt();

        }

        
        // liver.csv; 0-geneId; 1-disagreement; 2-prob_equal_ortho_adj; 3-call
        public static void Liver_dt()
        {

            Genes genes = new Genes();

            List<Gene> gene_list = new List<Gene>();

            using (var reader = new StreamReader(string.Format("{0}/{1}/{2}", Environment.CurrentDirectory, DI1.inputDirectory, "Liver.csv")))
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

                    List<Organ> organList = new List<Organ>();

                    Organ organ = new Organ();

                    organ.organName = OrganNames.liver;

                    organ.disagreement = values[1];

                    organ.probEqualOrthoAdj = values[2];

                    organ.call = values[3];

                    organList.Add(organ);

                    gene.organs = organList;

                    gene_list.Add(gene);

                    counter++;

                }

            }

            Output.createXml(gene_list: gene_list, fileName: "Liver_dt.xml", directory: DI1.outputDirectory);

            Output.createTsv(gene_list: gene_list, fileName: "Liver_dt.tsv", directory: DI1.outputDirectory);

        }


        // mart.txt; 0-geneId; 1-geneDescription; 2-geneName
        public static void mart_export_liver_dt()
        {

            Genes genes = new Genes();

            List<Gene> gene_list = new List<Gene>();

            using (var reader = new StreamReader(string.Format("{0}/{1}/{2}", Environment.CurrentDirectory, DI1.inputDirectory, "mart_export_liver.txt")))
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

                    gene.geneNames = line.Substring(line.LastIndexOf(",") + 1);

                    gene.geneDescriptions = (line.Substring(line.IndexOf(",") + 1)).Substring(0, line.Substring(line.IndexOf(",") + 1).LastIndexOf(","));
                    
                    gene_list.Add(gene);

                    counter++;

                }

            }

            Output.createXml(gene_list: gene_list, fileName: "mart_export_liver_dt.xml", directory: DI1.outputDirectory);
            
            Output.createTsv(gene_list: gene_list, fileName: "mart_export_liver_dt.tsv", directory: DI1.outputDirectory);

        }

    }

}