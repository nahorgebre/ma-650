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

                }
                else if (parameter.Equals("DI3"))
                {
                    
                    DI3.runDataTranslation();

                    AWSupload.run(parameter);
                    
                }
                else if (parameter.Equals("DI4"))
                {

                    DI4.runDataTranslation();

                    AWSupload.run(parameter);
                    
                }
                else if (parameter.Equals("test"))
                {

                    Test.runDataTranslation();

                }

            }
            
        }

    }

}