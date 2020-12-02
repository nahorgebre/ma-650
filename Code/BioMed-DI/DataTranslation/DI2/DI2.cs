namespace DataTranslation
{

    public class DI2
    {


        public static string inputDirectory = "data/input/DI2";

        public static string outputDirectory = "data/output/DI2";


        public static void runDataTranslation() 
        {

            all_gene_disease_pmid_associations_dt.runDataTranslation();
            
            Kaessmann.runDataTranslation();

        }

    }

}