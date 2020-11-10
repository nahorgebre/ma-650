using System;
using System.IO;
using System.Collections.Generic;

namespace DataTranslation
{

    public class pubMedDate_dt
    {

        public static void runDataTranslation()
        {

            Directory.CreateDirectory(string.Format("{0}/{1}", Environment.CurrentDirectory, DI2.outputDirectory));

            List<Publication> publication_list = new List<Publication>();

            using (var reader = new StreamReader(string.Format("{0}/{1}/{2}", Environment.CurrentDirectory, DI2.inputDirectory, "PubMedDate.csv")))
            {

                reader.ReadLine();

                int counter = 1;

                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();
                    
                    String[] values = line.Split(",");

                    Publication publication = new Publication();

                    publication.recordId = string.Format("pubMedDate_{0}_rid", counter);

                    publication.pmId = values[0].Trim();

                    publication.year = values[1].Trim();

                    publication_list.Add(publication);

                    counter++;

                }

            }

            Methods.createXmlPublication(publication_list: publication_list, fileName: "PubMedDate_dt.xml", directory: DI2.outputDirectory);

            Methods.createTsvPublication(publication_list: publication_list, fileName: "PubMedDate_dt.tsv", directory: DI2.outputDirectory);

        }

    }

}