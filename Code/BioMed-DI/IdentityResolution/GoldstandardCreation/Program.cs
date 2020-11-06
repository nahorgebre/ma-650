using System;
using System.IO;

namespace GoldstandardCreation
{

    class Program
    {

        static void Main(string[] args)
        {

            foreach (String parameter in args)
            {
                
                if (parameter.Equals("DI1"))
                {

                    DI1.run();

                    DirectoryInfo outputDirectory = new DirectoryInfo(string.Format("{0}/data/output/{1}", Environment.CurrentDirectory, parameter));

                    Output.run(outputDirectory);

                    AWSupload.run(outputDirectory);

                } 
                else if (parameter.Equals("DI2"))
                {

                    DI2.run();

                    //DirectoryInfo outputDirectory = new DirectoryInfo(string.Format("{0}/data/output/{1}/{2}", Environment.CurrentDirectory, parameter, Variables.pubTatorPartitionSize));

                    DirectoryInfo outputDirectory = new DirectoryInfo(string.Format("{0}/data/input/DI2/50/gene2pubtatorcentral_1", Environment.CurrentDirectory));

                    //Output.run(outputDirectory);

                    //AWSupload.run(outputDirectory, parameter);

                }

            }

        }

    }

}