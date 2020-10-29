using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataTranslation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            DI1.runDataTranslation();
            
            DI2.runDataTranslation();

            //GeneDiseaseAssociations.runDataTranslation();

            AWSupload.run();

        }

    }

}