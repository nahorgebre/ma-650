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

                if (parameter.Equals("listing"))
                {

                    AWSlistingContents.getS3ObjectList("DI2");

                    AWSlistingContents.getS3ObjectList("DI3");

                    AWSlistingContents.getS3ObjectList("DI4");

                }
                else if (parameter.Equals("DI2"))
                {

                    DI2.run();

                    DirectoryInfo outputDirectory = new DirectoryInfo(string.Format("{0}/data/output/{1}", Environment.CurrentDirectory, parameter));

                    Output.createOutputWithCornerCases(outputDirectory);

                    AWSupload.run(outputDirectory, parameter);

                }
                else if (parameter.Equals("DI3"))
                {

                    DI3.run();

                    DirectoryInfo outputDirectory = new DirectoryInfo(string.Format("{0}/data/output/{1}", Environment.CurrentDirectory, parameter));

                    Output.createOutputWithCornerCases(outputDirectory);

                    AWSupload.run(outputDirectory, parameter);

                }
                else if (parameter.Equals("DI4"))
                {

                    DI4.runAbstract();

                    DI4.runTitle();

                    DirectoryInfo outputDirectory = new DirectoryInfo(string.Format("{0}/data/output/{1}", Environment.CurrentDirectory, parameter));

                    AWSupload.run(outputDirectory, parameter);

                }

            }

        }

    }

}