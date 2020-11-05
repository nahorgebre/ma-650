using System;

namespace DataTranslation
{
    public class Program
    {
        public static void Main(string[] args)
        {

            foreach (String parameter in args)
            {
                
                if (parameter.Equals("DI1"))
                {

                    DI1.runDataTranslation();
                    
                    AWSupload.run(parameter);
                    
                }
                else if (parameter.Equals("DI2"))
                {

                    DI2.runDataTranslation();

                    AWSupload.run(parameter);

                    AWSupload.run(parameter, Variables.partitionNumbers.ToString());

                }

            }
            
        }

    }

}