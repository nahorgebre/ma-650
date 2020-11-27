using System;
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

                }

            }

        }

    }

}