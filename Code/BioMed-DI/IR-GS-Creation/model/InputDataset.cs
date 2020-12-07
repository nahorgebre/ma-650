using System;
using System.IO;
using System.Collections.Generic;

namespace IR_GS_Creation
{

    class InputDataset
    {

        public string ensemblId = string.Empty;
        
        public string ncbiId = string.Empty;
        
        public string geneNames = string.Empty;

        public static Dictionary<string, InputDataset> getDatasetDictionary(FileInfo file)
        {

            Dictionary<string, InputDataset> datasetDictionary = new Dictionary<string, InputDataset>();

            using (StreamReader sr = new StreamReader(file.FullName))
            {
                
                sr.ReadLine();

                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] values = line.Split("\t");


                    InputDataset inputDS = new InputDataset();

                    if (!values[1].Equals("NV"))
                    {

                        inputDS.ensemblId = values[1];
                        
                    }

                    if (!values[2].Equals("NV"))
                    {

                        inputDS.ncbiId = values[2];
                        
                    }

                    if (!values[3].Equals("NV"))
                    {

                        inputDS.geneNames = values[3];
                        
                    }

                    datasetDictionary.Add(values[0], inputDS);
                    
                }

            }

            return datasetDictionary;
        
        }

    }

}