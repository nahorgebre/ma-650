using System;
using System.IO;

namespace Data_Preparation
{

    class Datasets_CHEMDNER_TEST_TEXT
    {
        public static string chemdner_patents_test_background_text_release = string.Format("{0}/data/input/CHEMDNERgoldstandard/CHEMDNER_TEST_TEXT/chemdner_patents_test_background_text_release.txt", Environment.CurrentDirectory);
        // 1- Patent identifier
        // 2- Title of the patent
        // 3- Abstract of the patent
    }

    class Datasets_GPRO_development_baseline
    {
        public static string gpro_official_dev_lookup_baseline = string.Format("{0}/data/input/CHEMDNERgoldstandard/GPRO_development_baseline/gpro_official_dev_lookup_baseline.tsv", Environment.CurrentDirectory);
        // 1- Patent identifier
        // 2- Offset string consisting in a triplet joined by the ':' character. You have to provide the text type (T: Title, A:Abstract), the start offset and the end offset.
        // 3- The rank of the GPRO-type 1 entity returned for this document
        // 4- A confidence score
        // 5- The string of the GPRO-type 1 entity mention

        public static string grpo_official_train_lookup_list = string.Format("{0}/data/input/CHEMDNERgoldstandard/GPRO_development_baseline/grpo_official_train_lookup_list.tsv", Environment.CurrentDirectory);
        // Content: list of GPRO type 1 names used for the baseline prediction
    }

    class Datasets_gpro_development_set
    {
        public static string chemdner_gpro_gold_standard_development_eval = string.Format("{0}/data/input/CHEMDNERgoldstandard/gpro_development_set/chemdner_gpro_gold_standard_development_eval.tsv", Environment.CurrentDirectory);
        // 1- Patent identifier
        // 2- Offset string consisting in a triplet joined by the ':' character. You have to provide the text type (T: Title, A:Abstract), the start offset and the end offset.

        public static FileInfo chemdner_gpro_gold_standard_development = new FileInfo(string.Format("{0}/data/input/CHEMDNERgoldstandard/gpro_development_set/chemdner_gpro_gold_standard_development.tsv", Environment.CurrentDirectory));
        // 1- Patent identifier
        // 2- Type of text from which the annotation was derived (T: Title, A: Abstract)
        // 3- Start offset
        // 4- End offset
        // 5- Text string of the entity mention
        // 6- Type of GPRO entity mention (NO CLASS,NESTED MENTIONS,IDENTIFIER,SEQUENCE, FULL NAME,ABBREVIATION,FAMILY,MULTIPLE)
        // 7- Database identifier of type 1 GPRO mentions, otherwise the tag 'GPRO_TYPE_2' if provided.

        public static FileInfo chemdner_patents_development_text = new FileInfo(string.Format("{0}/data/input/CHEMDNERgoldstandard/gpro_development_set/chemdner_patents_development_text.txt", Environment.CurrentDirectory));
        // 1- Patent identifier
        // 2- Title of the patent
        // 3- Abstract of the patent
    }

    class Datasets_gpro_training_set_v02
    {
        public static string chemdner_gpro_gold_standard_train_eval_v02 = string.Format("{0}/data/input/CHEMDNERgoldstandard/gpro_training_set_v02/chemdner_gpro_gold_standard_train_eval_v02.tsv", Environment.CurrentDirectory);
        // 1- Patent identifier
        // 2- Offset string consisting in a triplet joined by the ':' character. You have to provide the text type (T: Title, A:Abstract), the start offset and the end offset.

        public static FileInfo chemdner_gpro_gold_standard_train_v02 = new FileInfo(string.Format("{0}/data/input/CHEMDNERgoldstandard/gpro_training_set_v02/chemdner_gpro_gold_standard_train_v02.tsv", Environment.CurrentDirectory));
        // 1- Patent identifier
        // 2- Type of text from which the annotation was derived (T: Title, A: Abstract)
        // 3- Start offset
        // 4- End offset
        // 5- Text string of the entity mention
        // 6- Type of GPRO entity mention (NO CLASS,NESTED MENTIONS,IDENTIFIER,SEQUENCE, FULL NAME,ABBREVIATION,FAMILY,MULTIPLE)
        // 7- Database identifier of type 1 GPRO mentions, otherwise the tag 'GPRO_TYPE_2' if provided.

        public static FileInfo chemdner_patents_train_text = new FileInfo(string.Format("{0}/data/input/CHEMDNERgoldstandard/gpro_training_set_v02/chemdner_patents_train_text.txt", Environment.CurrentDirectory));
        // 1- Patent identifier
        // 2- Title of the patent
        // 3- Abstract of the patent
    }

    class Datasests_PatNum
    {
        public static FileInfo US_Patents_1985_2016_313392 = new FileInfo(string.Format("{0}/data/input/PatNum/US_Patents_1985_2016_313392.csv", Environment.CurrentDirectory));
    }        

}