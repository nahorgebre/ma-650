using System;
using System.Collections.Generic;

namespace DataPreparation
{
    class Program
    {
        static void Main(string[] args)
        {

            var watch = System.Diagnostics.Stopwatch.StartNew();

            all_gene_disease_pmid_associations.runDataPreparation();

            watch.Stop();

            double elapsedMinutes = TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds).TotalMinutes;

            Console.WriteLine("Time: " + elapsedMinutes);
            
        }
    }
}
