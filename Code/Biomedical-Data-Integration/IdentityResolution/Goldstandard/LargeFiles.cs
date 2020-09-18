using System;
using System.IO;

namespace Goldstandard
{
    class LargeFiles
    {

        public static void Gene2Pubtatorcentral() {
            string outputFileName = Environment.CurrentDirectory + "/data/output/Gene2Pubtatorcentral.csv";
            using (StreamWriter sw = new StreamWriter(outputFileName)) 
            {
                using (var reader = new StreamReader(Environment.CurrentDirectory + "/data/input/files/gene2pubtatorcentral.tsv"))
                {
                    reader.ReadLine();
                    int counter = 1;
                    for (int i = 0; i < 1500000; i++)
                    {
                        var line = reader.ReadLine();
                        String[] values = line.Split('\t');

                        string recordId = string.Format("gene2pubtatorcentral_{0}_rid", counter);
                        string ncbiId = values[2];
                        string geneNames = values[3];

                        sw.WriteLine(recordId + "," + ncbiId + "," + geneNames);
                    }
                }
            }
            Console.WriteLine("Done - Gene2Pubtatorcentral!");
        }

        public static void all_gene_disease_pmid_associations() {
            string outputFileName = Environment.CurrentDirectory + "/data/output/all_gene_disease_pmid_associations.csv";
            using (StreamWriter sw = new StreamWriter(outputFileName)) 
            {
                using (var reader = new StreamReader(Environment.CurrentDirectory + "/data/input/files/all_gene_disease_pmid_associations.tsv"))
                {
                    reader.ReadLine();
                    int counter = 1;
                    for (int i = 0; i < 1500000; i++)
                    {
                        var line = reader.ReadLine();
                        String[] values = line.Split('\t');

                        string recordId = string.Format("gene_disease_pmid_associations_{0}_rid", counter);
                        string ncbiId = values[0];
                        string geneNames = values[1];

                        sw.WriteLine(recordId + "," + ncbiId + "," + geneNames);
                    }
                }
            }
            Console.WriteLine("Done - all_gene_disease_pmid_associations!");
        }


    }
}