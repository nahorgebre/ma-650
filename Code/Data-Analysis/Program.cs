using System;

namespace EnrichFusedDataset
{

    class Program
    {

        static void Main(string[] args)
        {

            /*
            double x = double.Parse("0.10".Replace('.', ','));

            Console.WriteLine(x.ToString());
            */
            
            EnrichDataset.run();

            AIM_TimeDependentOutput.run();

            AIM_PatentingActivity.run();

        }

    }

}