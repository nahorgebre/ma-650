using System;
using System.IO;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    public class TaxonomyDatasets
    {

        public static FileInfo mus_musculus = new FileInfo(Environment.CurrentDirectory + "/data/taxonomy/gene_result_mus_musculus.txt");

        public static FileInfo homo_sapiens = new FileInfo(Environment.CurrentDirectory + "/data/taxonomy/gene_result_homo_sapiens.txt");


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