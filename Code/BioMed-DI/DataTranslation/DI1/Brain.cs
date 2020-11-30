using System;
using System.IO;
using System.Collections.Generic;

namespace DataTranslation
{

    public class Brain
    {


        public static void runDataTranslation() 
        {

            Directory.CreateDirectory(string.Format("{0}/{1}", Environment.CurrentDirectory, DI1.outputDirectory));

            Brain.Brain_dt();

            Brain.mart_export_brain_dt();

        }


        // Brain.csv; 0-geneId; 1-disagreement; 2-prob_equal_ortho_adj; 3-call
        public static void Brain_dt()
        {
            
            Genes genes = new Genes();

            List<Gene> gene_list = new List<Gene>();
            
            using (var reader = new StreamReader(string.Format("{0}/{1}/{2}", Environment.CurrentDirectory, DI1.inputDirectory, "Brain.csv")))
            {

                reader.ReadLine();

                int counter = 1;

                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();

                    String[] values = line.Split(',');

                    Gene gene = new Gene();

                    gene.recordId = string.Format("Brain_{0}_rid", counter);

                    gene.ensemblId = values[0];

                    List<Organ> organList = new List<Organ>();

                    Organ organ = new Organ();

                    organ.organName = OrganNames.brain;

                    organ.disagreement = values[1];

                    organ.probEqualOrthoAdj = values[2];

                    organ.call = values[3];

                    organList.Add(organ);

                    gene.organs = organList;

                    gene_list.Add(gene);

                    counter++;

                }

            }

            Output.createXml(gene_list: gene_list, fileName: "Brain_dt.xml", directory: DI1.outputDirectory);

            Output.createTsv(gene_list: gene_list, fileName: "Brain_dt.tsv", directory: DI1.outputDirectory);

        }


        // mart_export_brain.txt; 0-geneId; 1-geneDescription; 2-geneName
        public static void mart_export_brain_dt()
        {

            Genes genes = new Genes();

            List<Gene> gene_list = new List<Gene>();
            
            using (var reader = new StreamReader(string.Format("{0}/{1}/{2}", Environment.CurrentDirectory, DI1.inputDirectory, "mart_export_brain.txt")))
            {

                reader.ReadLine();

                int counter = 1;

                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();

                    String[] values = line.Split(',');

                    Gene gene = new Gene();

                    gene.recordId = string.Format("mart_export_brain_{0}_rid", counter);

                    gene.ensemblId = values[0];

                    gene.geneDescriptions = (line.Substring(line.IndexOf(",") + 1)).Substring(0, line.Substring(line.IndexOf(",") + 1).LastIndexOf(","));

                    gene.geneNames = line.Substring(line.LastIndexOf(",") + 1);

                    gene_list.Add(gene);

                    counter++;

                }

            }

            Output.createXml(gene_list: gene_list, fileName: "mart_export_brain_dt.xml", directory: DI1.outputDirectory);
            
            Output.createTsv(gene_list: gene_list, fileName: "mart_export_brain_dt.tsv", directory: DI1.outputDirectory);

        }

    }

}