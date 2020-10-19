using System;

namespace GoldstandardCreation
{
    class Program
    {
        static void Main(string[] args)
        {

            
            Brain.run();
            Cerebellum.run();
            Heart.run();
            Kidney.run();
            Liver.run();
            Organs.run();     
            Testis.run();
            Publication.run();

            Output.run();

            AWSupload.run();
            

/*
            for (int i = 36; i <= 100; i++)
            {
                string x = "wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/input/gene2pubtatorcentral_" + i + "_dt.tsv -O data/input/Publication/gene2pubtatorcentral_" + i + "_dt.tsv";

                Console.WriteLine(x);
            }
            */

        }

    }

}