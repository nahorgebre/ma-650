namespace DataTranslation
{

    public class DI3
    {

        public static string inputDirectory = "data/input/DI3";

        public static string outputDirectory = "data/output/DI3";

        public static void runDataTranslation() 
        {

            gene2pubtatorcentral.runDataTranslationWtaxonomy();

            KaessmannDiseaseAssociations.runDataTranslation();

        }

    }

}