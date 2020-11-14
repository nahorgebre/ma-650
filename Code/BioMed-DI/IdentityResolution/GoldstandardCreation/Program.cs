﻿using System;
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

                    Output.runEnsemblId(outputDirectory);

                    AWSupload.runDI1(outputDirectory);

                } 
                else if (parameter.Equals("DI2"))
                {

                    DI2.runDataTranslation();

                    /*
                    DI2.run();

                    DirectoryInfo outputDirectory = new DirectoryInfo(string.Format("{0}/data/output/{1}/{2}", Environment.CurrentDirectory, parameter, Variables.pubTatorPartitionSize));

                    Output.runPmId(outputDirectory);

                    AWSupload.run(outputDirectory, parameter);
                    */

                }

            }

        }

    }

}