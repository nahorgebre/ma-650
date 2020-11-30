using System;
using System.IO;

namespace IR_GS_Creation
{
    class Program
    {
        static void Main(string[] args)
        {

            foreach (String parameter in args)
            {

                if (parameter.Equals("DI3"))
                {

                    DI3.run();

                    DirectoryInfo outputDirectory = new DirectoryInfo(string.Format("{0}/data/output/{1}", Environment.CurrentDirectory, parameter));

                    Output.createOutputWithCornerCases(outputDirectory);

                    AWSupload.run(outputDirectory, parameter);

                }

            }
        }
    }
}
