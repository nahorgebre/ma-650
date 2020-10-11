using System;
using System.Collections.Generic;
using System.IO;

namespace Data_Preparation
{
    class CreateTestGoldStandardDatasets
    {
        public string patNumber;
        public string startOffset;
        public string endOffset;
        public string entityMention;
        public string entityMentionType;
        public string databaseIdentifier;

        // 1- Patent identifier
        // 2- Type of text from which the annotation was derived (T: Title, A: Abstract)
        // 3- Start offset
        // 4- End offset
        // 5- Text string of the entity mention
        // 6- Type of GPRO entity mention (NO CLASS,NESTED MENTIONS,IDENTIFIER,SEQUENCE, FULL NAME,ABBREVIATION,FAMILY,MULTIPLE)
        // 7- Database identifier of type 1 GPRO mentions, otherwise the tag 'GPRO_TYPE_2' if provided.

        public static void run() {
            DirectoryInfo outputDirectory = new DirectoryInfo(string.Format("{0}/data/output/goldstandard", Environment.CurrentDirectory));
            outputDirectory.Create();

            List<FileInfo> patents_goldstandard_list = new List<FileInfo>()
            {
                Datasets_gpro_development_set.chemdner_gpro_gold_standard_development,
                Datasets_gpro_training_set_v02.chemdner_gpro_gold_standard_train_v02
            };

            create_patents_test_gold_title(outputDirectory);
            create_patents_test_gold_abstract(outputDirectory);
        }

        public static void create_patents_test_gold_title(DirectoryInfo outputDirectory ) {
            FileInfo fileName = new FileInfo(string.Format("{0}/patents_test_gold_title.txt", outputDirectory.FullName));
            fileName.Delete();
        }

        public static void create_patents_test_gold_abstract(DirectoryInfo outputDirectory ) {
            FileInfo fileName = new FileInfo(string.Format("{0}/patents_test_gold_abstract.txt", outputDirectory.FullName));
            fileName.Delete();
        }
    }
}