using System;

namespace DataTranslation
{

    public class DI2
    {

        public static string inputDirectory = Environment.CurrentDirectory + "/data/input/DI2";

        public static string outputDirectory = Environment.CurrentDirectory + "/data/output/DI2";

        public static void runDataTranslation() 
        {

            all_gene_disease_pmid_associations.runDataTranslationMultipleOutputs();
            
            Kaessmann.runDataTranslation();

        }

    }

}