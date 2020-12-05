using System;

namespace DataTranslation
{

    public class DI3
    {

        public static string inputDirectory = Environment.CurrentDirectory + "/data/input/DI3";

        public static string outputDirectory = Environment.CurrentDirectory + "/data/output/DI3";

        public static void runDataTranslation() 
        {

            gene2pubtatorcentral.runDataTranslationMultipleOutputs();

            KaessmannDiseaseAssociations.runDataTranslation();

        }

    }

}