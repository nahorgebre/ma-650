using System;

namespace GoldstandardCreation
{
    class Program
    {
        static void Main(string[] args)
        {

            // Kaessmann
            Brain.run();
            Cerebellum.run();
            Heart.run();
            Kidney.run();
            Liver.run();
            Organs.run();     
            Testis.run();

            // Publication
            Publication.run();

            Output.run();

            AWSupload.run();

        }

    }

}