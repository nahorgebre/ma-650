using System;
using System.IO;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    class TaxonomyCollection
    {
        
        // Homo Sapiens -- homo_sapiens
        // https://www.ncbi.nlm.nih.gov/Taxonomy/Browser/wwwtax.cgi?mode=Info&id=9606&lvl=3&p=has_linkout&p=blast_url&p=genome_blast&lin=f&keep=1&srchmode=1&unlock
        public HashSet<string> HomoSapiensNcbiIdHashSet = TaxonomyDatasets.getHomoSapiens();

        // Mus Musculus -- mus_musculus
        // https://www.ncbi.nlm.nih.gov/Taxonomy/Browser/wwwtax.cgi?mode=Info&id=10090&lvl=3&p=has_linkout&p=blast_url&p=genome_blast&lin=f&keep=1&srchmode=1&unlock
        public HashSet<string> MusMusculusNcbiIdHashSet = TaxonomyDatasets.getMusMusculus();

        public HashSet<string> MusMusculusHomoSapiensNcbiIdHashSet = TaxonomyDatasets.getMusMusculusHomoSapiens();

        // Drosophila Melanogaster -- drosophila_melanogaster
        // https://www.ncbi.nlm.nih.gov/Taxonomy/Browser/wwwtax.cgi?mode=Info&id=7227&lvl=3&lin=f&keep=1&srchmode=1&unlock
        public HashSet<string> DrosophilaMelanogasterNcbiIdHashSet = TaxonomyDatasets.getDrosophilaMelanogaster();

        // Macaca Mulatta -- macaca_mulatta
        // https://www.ncbi.nlm.nih.gov/Taxonomy/Browser/wwwtax.cgi?mode=Info&id=9544&lvl=3&lin=f&keep=1&srchmode=1&unlock
        public HashSet<string> MacacaMulattaNcbiIdHashSet = TaxonomyDatasets.getMacacaMulatta();

        // Saccharomyces Cerevisiae -- saccharomyces_cerevisiae
        // https://www.ncbi.nlm.nih.gov/Taxonomy/Browser/wwwtax.cgi?mode=Info&id=4932&lvl=3&p=has_linkout&p=blast_url&p=genome_blast&lin=f&keep=1&srchmode=1&unlock
        public HashSet<string> SaccharomycesCerevisiaeNcbiIdHashSet = TaxonomyDatasets.getSaccharomycesCerevisiae();

        // Sus Scrofa -- sus_scrofa
        // https://www.ncbi.nlm.nih.gov/Taxonomy/Browser/wwwtax.cgi?mode=Info&id=9823&lvl=3&p=has_linkout&p=blast_url&p=genome_blast&lin=f&keep=1&srchmode=1&unlock
        public HashSet<string> SusScrofaNcbiIdHashSet = TaxonomyDatasets.getSusScrofa();

    }
    

    public class TaxonomyDatasets
    {

        public static FileInfo mus_musculus = new FileInfo(Environment.CurrentDirectory + "/data/taxonomy/gene_result_mus_musculus.txt");

        public static FileInfo homo_sapiens = new FileInfo(Environment.CurrentDirectory + "/data/taxonomy/gene_result_homo_sapiens.txt");

        public static FileInfo drosophila_melanogaster = new FileInfo(Environment.CurrentDirectory + "/data/taxonomy/gene_result_drosophila_melanogaster.txt");

        public static FileInfo macaca_mulatta = new FileInfo(Environment.CurrentDirectory + "/data/taxonomy/gene_result_macaca_mulatta.txt");

        public static FileInfo saccharomyces_cerevisiae = new FileInfo(Environment.CurrentDirectory + "/data/taxonomy/gene_result_saccharomyces_cerevisiae.txt");

        public static FileInfo sus_scrofa = new FileInfo(Environment.CurrentDirectory + "/data/taxonomy/gene_result_sus_scrofa.txt");


        public static HashSet<string> getSusScrofa()
        {

            HashSet<string> ncbiIdHashSet = new HashSet<string>();

            using (StreamReader sr = new StreamReader(sus_scrofa.FullName))
            {

                sr.ReadLine();

                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] values = line.Split('\t');

                    ncbiIdHashSet.Add(values[2]);

                }

            }

            return ncbiIdHashSet;

        }

        public static HashSet<string> getSaccharomycesCerevisiae()
        {

            HashSet<string> ncbiIdHashSet = new HashSet<string>();

            using (StreamReader sr = new StreamReader(saccharomyces_cerevisiae.FullName))
            {

                sr.ReadLine();

                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] values = line.Split('\t');

                    ncbiIdHashSet.Add(values[2]);

                }

            }

            return ncbiIdHashSet;

        }

        public static HashSet<string> getMacacaMulatta()
        {

            HashSet<string> ncbiIdHashSet = new HashSet<string>();

            using (StreamReader sr = new StreamReader(macaca_mulatta.FullName))
            {

                sr.ReadLine();

                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] values = line.Split('\t');

                    ncbiIdHashSet.Add(values[2]);

                }

            }

            return ncbiIdHashSet;

        }

        public static HashSet<string> getDrosophilaMelanogaster()
        {

            HashSet<string> ncbiIdHashSet = new HashSet<string>();

            using (StreamReader sr = new StreamReader(drosophila_melanogaster.FullName))
            {

                sr.ReadLine();

                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] values = line.Split('\t');

                    ncbiIdHashSet.Add(values[2]);

                }

            }

            return ncbiIdHashSet;

        }

        public static HashSet<string> getHomoSapiens()
        {

            HashSet<string> ncbiIdHashSet = new HashSet<string>();

            using (StreamReader sr = new StreamReader(homo_sapiens.FullName))
            {

                sr.ReadLine();

                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] values = line.Split('\t');

                    ncbiIdHashSet.Add(values[2]);

                }

            }

            return ncbiIdHashSet;

        }

        public static HashSet<string> getMusMusculus()
        {

            HashSet<string> ncbiIdHashSet = new HashSet<string>();

            using (StreamReader sr = new StreamReader(mus_musculus.FullName))
            {

                sr.ReadLine();

                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] values = line.Split('\t');

                    ncbiIdHashSet.Add(values[2]);

                }

            }

            return ncbiIdHashSet;

        }

        public static HashSet<string> getMusMusculusHomoSapiens()
        {

            HashSet<string> ncbiIdHashSet = new HashSet<string>();

            List<FileInfo> fileList = new List<FileInfo>() {

                mus_musculus,

                homo_sapiens,

            };

            foreach (FileInfo fileItem in fileList)
            {

                using (StreamReader sr = new StreamReader(fileItem.FullName))
                {

                    sr.ReadLine();

                    while (!sr.EndOfStream)
                    {

                        var line = sr.ReadLine();

                        string[] values = line.Split('\t');

                        ncbiIdHashSet.Add(values[2]);

                    }

                }

            }

            return ncbiIdHashSet;

        }

    }

}