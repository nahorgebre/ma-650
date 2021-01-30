using System;

namespace DataTranslation
{

    public class DI4
    {

        public static string inputDirectory = Environment.CurrentDirectory + "/data/input/DI4";

        public static string outputDirectory = Environment.CurrentDirectory + "/data/output/DI4";

        public static void runDataTranslation() 
        {

            Kaessmann.runDataTranslationForDI3Output();

            patent.runDataTranslationTitle();

            patent.runDataTranslationAbstract();

        }

    }

}