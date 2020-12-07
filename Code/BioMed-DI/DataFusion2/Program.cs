using System;
using System.IO;
using System.Collections.Generic;

namespace DataFusion2
{
    class Program
    {
        static void Main(string[] args)
        {

            AWSlistingContents.createCorrespondencesShellScriptOutput("DI2");

            AWSlistingContents.createCorrespondencesShellScriptOutput("DI3");

            foreach (String parameter in args)
            {
                
                if (parameter.Equals("DI1"))
                {

                    DI1DataFusion.run();

                }
                else if (parameter.Equals("DI2"))
                {

                    DI2DataFusion.run();

                }
                else if (parameter.Equals("DI3"))
                {

                    DI3DataFusion.run();

                }

            }

        }

    }

}