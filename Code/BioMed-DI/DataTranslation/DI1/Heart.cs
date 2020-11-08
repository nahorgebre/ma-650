using System;
using System.IO;
using System.Collections.Generic;

namespace DataTranslation
{

    public class Heart
    {


        public static void runDataTranslation() 
        {

            Directory.CreateDirectory(string.Format("{0}/{1}", Environment.CurrentDirectory, DI1.outputDirectory));

            Heart.Heart_dt();

            Heart.mart_export_heart_dt();

            Heart.Heart_Ensembl_NCBI_Crosswalk_dt();

        }


        // heart.csv; 0-geneId; 1-disagreement; 2-call
        public static void Heart_dt()
        {

            Genes genes = new Genes();

            List<Gene> gene_list = new List<Gene>();

            using (var reader = new StreamReader(string.Format("{0}/{1}/{2}", Environment.CurrentDirectory, DI1.inputDirectory, "Heart.csv")))
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

                    List<Organ> organList = new List<Organ>();

                    Organ organ = new Organ();

                    organ.organName = OrganNames.heart;

                    organ.disagreement = values[1];

                    organ.call = values[2];

                    organList.Add(organ);

                    gene.organs = organList;

                    gene_list.Add(gene);

                    counter++;

                }

            }

            Methods.createXmlGene(gene_list: gene_list, fileName: "Heart_dt.xml", directory: DI1.outputDirectory);

            Methods.createTsv(gene_list: gene_list, fileName: "Heart_dt.tsv", directory: DI1.outputDirectory);

        }


        // mart.txt; 0-geneId; 1-geneDescription; 2-geneName
        public static void mart_export_heart_dt()
        {

            Genes genes = new Genes();

            List<Gene> gene_list = new List<Gene>();

            using (var reader = new StreamReader(string.Format("{0}/{1}/{2}", Environment.CurrentDirectory, DI1.inputDirectory, "mart_export_heart.txt")))
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

                    gene.geneDescriptions = line.Substring(line.LastIndexOf(",") + 1);

                    gene.geneNames = (line.Substring(line.IndexOf(",") + 1)).Substring(0, line.Substring(line.IndexOf(",") + 1).LastIndexOf(","));

                    gene_list.Add(gene);

                    counter++;

                }

            }

            Methods.createXmlGene(gene_list: gene_list, fileName: "mart_export_heart_dt.xml", directory: DI1.outputDirectory);

            Methods.createTsv(gene_list: gene_list, fileName: "mart_export_heart_dt.tsv", directory: DI1.outputDirectory);

        }


        // ncbi; 0-ncbi; 1-geneId; 2-geneName
        public static void Heart_Ensembl_NCBI_Crosswalk_dt()
        {

            Genes genes = new Genes();

            List<Gene> gene_list = new List<Gene>();

            using (var reader = new StreamReader(string.Format("{0}/{1}/{2}", Environment.CurrentDirectory, DI1.inputDirectory, "Heart_Ensembl_NCBI_Crosswalk.txt")))
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

                    gene.geneNames = values[2];

                    gene_list.Add(gene);

                    counter++;

                }

            }

            Methods.createXmlGene(gene_list: gene_list, fileName: "Heart_Ensembl_NCBI_Crosswalk_dt.xml", directory: DI1.outputDirectory);
            
            Methods.createTsv(gene_list: gene_list, fileName: "Heart_Ensembl_NCBI_Crosswalk_dt.tsv", directory: DI1.outputDirectory);

        }

    }

}