using System;
using System.Collections.Generic;
using System.IO;

namespace Analysis
{
    class Program
    {
        static void Main(string[] args)
        {

            FileInfo inputFile = new FileInfo(string.Format("{0}/data/input/kaessmann-fused.xml", Environment.CurrentDirectory));

            List<Gene> geneList = Parser.parseGene(inputFile);

            Methods.createTsvFile(geneList);

            Methods.createXmlGene(geneList);

            AWSupload.run();

        }

    }
}
