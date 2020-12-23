using System;
using System.IO;
using System.Collections.Generic;


namespace EnrichFusedDataset
{
    class Program
    {
        static void Main(string[] args)
        {

            EnrichDataset.run();

            AIM1output.run2();

            //AIM1output.run2();

        }
    }
}
