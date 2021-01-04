using System;
using System.IO;
using System.Collections.Generic;

namespace DataFusion2
{
    class Program
    {
        static void Main(string[] args)
        {

            //AWSlistingContents.createCorrespondencesShellScriptOutput("DI1");

            //AWSlistingContents.createDatasetsShellScriptOutput("DI1");

            AWSlistingContents.createCorrespondencesShellScriptOutput("DI2");

            AWSlistingContents.createDatasetsShellScriptOutput("DI2");

            AWSlistingContents.createCorrespondencesShellScriptOutput2("DI3");

            AWSlistingContents.createDatasetsShellScriptOutput("DI3");

            AWSlistingContents.createCorrespondencesShellScriptOutput("DI4");

            AWSlistingContents.createDatasetsShellScriptOutput("DI4");

            
            foreach (String parameter in args)
            {

                if (parameter.Equals("DF"))
                {

                    DIDataFusion.run();

                    AWSupload.run();

                }

            }

        }

    }

}