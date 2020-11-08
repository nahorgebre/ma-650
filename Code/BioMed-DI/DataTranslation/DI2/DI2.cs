namespace DataTranslation
{

    public class DI2
    {


        public static string inputDirectory = "data/input/DI2";

        public static string outputDirectory = "data/output/DI2";


        public static void runDataTranslation() 
        {

            gene2pubtatorcentral_dt.runDataTranslation();

            pubMedDate_dt.runDataTranslation();

        }

    }

}