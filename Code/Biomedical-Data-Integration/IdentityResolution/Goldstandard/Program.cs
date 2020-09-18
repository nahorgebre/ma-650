using System;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;

namespace Goldstandard
{
    class Program
    {
        static void Main(string[] args)
        {
            //smallFiles();
            largeFiles();
        }

        public static void smallFiles() {
            Brain.brainGoldStandard();
            Cerebellum.cerebellumGoldStandard();
            Heart.heartGoldStandard();
            Kidney.kidneyGoldStandard();
            Liver.liverGoldStandard();
            Testis.testisGoldStandard();
        }

        public static void largeFiles() {
            LargeFiles.Gene2Pubtatorcentral();
        }
    }
}