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

                    //AWSupload.run(parameter);

                    //AWSupload.run(parameter, Variables.gene2pubtatorcentral_partitionNumbers.ToString());

                }
                else if (parameter.Equals("DI3"))
                {
                    
                    DI3.runDataTranslation();
                    

                }
                else if (parameter.Equals("DI4"))
                {

                    DI4.runDataTranslation();
                }

            }
            
        }

    }

}