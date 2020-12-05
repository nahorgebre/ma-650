using System;
using System.IO;
using System.Collections.Generic;

namespace DataTranslation
{

    public class Kidney
    {


        public static void runDataTranslation() 
        {

            Kidney.Kidney_dt();

            Kidney.mart_export_kidney_dt();

        }


        // Kidney.csv; 0-geneId; 1-disagreement; 2-prob_equal_ortho_adj; 3-call
        public static void Kidney_dt()
        {

            Genes genes = new Genes();

            List<Gene> gene_list = new List<Gene>();

            using (var reader = new StreamReader(DI1.inputDirectory + "/Kidney.csv"))
            {

                reader.ReadLine();

                int counter = 1;

                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();

                    String[] values = line.Split(',');

                    Gene gene = new Gene();

                    gene.recordId = string.Format("Kidney_{0}_rid", counter);

                    gene.ensemblId = values[0];

                    List<Organ> organList = new List<Organ>();

                    Organ organ = new Organ();

                    organ.organName = OrganNames.kidney;

                    organ.disagreement = values[1];

                    organ.probEqualOrthoAdj = values[2];

                    organ.call = values[3];

                    organList.Add(organ);

                    gene.organs = organList;

                    gene_list.Add(gene);

                    counter++;

                }

            }

            Output.createXml(gene_list: gene_list, file: new FileInfo(DI1.outputDirectory + "/Kidney_dt.xml"));

            Output.createTsv(gene_list: gene_list, file: new FileInfo(DI1.outputDirectory + "/Kidney_dt.tsv"));

        }


        // mart.txt; 0-geneId; 1-geneDescription; 2-geneName
        public static void mart_export_kidney_dt()
        {

            Genes genes = new Genes();

            List<Gene> gene_list = new List<Gene>();

            using (var reader = new StreamReader(DI1.inputDirectory + "/mart_export_kidney.txt"))
            {

                reader.ReadLine();
                
                int counter = 1;

                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();

                    String[] values = line.Split(',');

                    Gene gene = new Gene();

                    gene.recordId = string.Format("mart_export_kidney_{0}_rid", counter);

                    gene.ensemblId = values[0];

                    gene.geneDescriptions = (line.Substring(line.IndexOf(",") + 1)).Substring(0, line.Substring(line.IndexOf(",") + 1).LastIndexOf(","));
                    
                    gene.geneNames = line.Substring(line.LastIndexOf(",") + 1);

                    gene_list.Add(gene);

                    counter++;

                }

            }

            Output.createXml(gene_list: gene_list, file: new FileInfo(DI1.outputDirectory + "/mart_export_kidney_dt.xml"));
            
            Output.createTsv(gene_list: gene_list, file: new FileInfo(DI1.outputDirectory + "/mart_export_kidney_dt.tsv"));

        }

    }

}