namespace DataTranslation
{

    public class DI1
    {


        public static string inputDirectory = "data/input/DI1";

        public static string outputDirectory = "data/output/DI1";


        public static void runDataTranslation() 
        {

            Heart.runDataTranslation();

            Brain.runDataTranslation();

            Cerebellum.runDataTranslation();

            Kidney.runDataTranslation();

            Liver.runDataTranslation();
            
            Testis.runDataTranslation();

        }

    }

}