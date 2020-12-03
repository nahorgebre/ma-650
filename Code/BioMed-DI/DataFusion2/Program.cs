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

                    AWSlistingContents.createCorrespondencesShellScriptOutput(parameter);

                }
                else if (parameter.Equals("DI3"))
                {  

                    AWSlistingContents.createCorrespondencesShellScriptOutput(parameter);

                    DI3DataFusion.run();

                }

            }

        }

    }

}