using System;
using System.IO;
using System.Collections.Generic;

namespace DataFusion2
{
    class Program
    {
        static void Main(string[] args)
        {

            foreach (String parameter in args)
            {
                
                if (parameter.Equals("DI1"))
                {

                    DI1DataFusion.run();

                }
                else if (parameter.Equals("DI2"))
                {

                }
                else if (parameter.Equals("DI3"))
                {

                    AWSlistingContents.createCorrespondencesShellScriptOutput(parameter);

                }

            }

            for (int i = 1; i <= 50; i++)
            {
                Console.WriteLine("new FileInfo(Environment.CurrentDirectory + \"/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_" + i + "/correspondences.csv\"),");
            }

        }

    }

}