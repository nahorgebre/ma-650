using System;

namespace GoldstandardNER
{
    public class PatNum
    {
        public static string targetPatentNumbersFileName = Environment.CurrentDirectory + @"\data\PatNum\US_Patents_1985_2016_313392.csv";  
    }

    class CHEMDNER_TEST_TEXT
    {
        public static string directory = Environment.CurrentDirectory + @"\data\CHEMDNERgoldstandard\CHEMDNER_TEST_TEXT\";
        public static string chemdner_patents_test_background_text_release = "chemdner_patents_test_background_text_release.txt";
        // 1- Patent identifier
        // 2- Title of the patent
        // 3- Abstract of the patent
    }

    class GPRO_development_baseline
    {
        public static string directory = Environment.CurrentDirectory + @"\data\CHEMDNERgoldstandard\GPRO_development_baseline\";
        public static string gpro_official_dev_lookup_baseline = directory + "gpro_official_dev_lookup_baseline.tsv";
        // 1- Patent identifier
        // 2- Offset string consisting in a triplet joined by the ':' character. You have to provide the text type (T: Title, A:Abstract), the start offset and the end offset.
        // 3- The rank of the GPRO-type 1 entity returned for this document
        // 4- A confidence score
        // 5- The string of the GPRO-type 1 entity mention

        public static string grpo_official_train_lookup_list = directory + "grpo_official_train_lookup_list.tsv";
    }

    class gpro_development_set
    {
        public static string directory = Environment.CurrentDirectory + @"\data\CHEMDNERgoldstandard\gpro_development_set\";
        public static string chemdner_gpro_gold_standard_development = directory + "chemdner_gpro_gold_standard_development.tsv";
        // 1- Patent identifier
        // 2- Type of text from which the annotation was derived (T: Title, A: Abstract)
        // 3- Start offset
        // 4- End offset
        // 5- Text string of the entity mention
        // 6- Type of GPRO entity mention (NO CLASS,NESTED MENTIONS,IDENTIFIER,SEQUENCE, FULL NAME,ABBREVIATION,FAMILY,MULTIPLE)
        // 7- Database identifier of type 1 GPRO mentions, otherwise the tag 'GPRO_TYPE_2' if provided.

        public static string chemdner_gpro_gold_standard_development_eval = directory + "chemdner_gpro_gold_standard_development_eval.tsv";
        // 1- Patent identifier
        // 2- Offset string consisting in a triplet joined by the ':' character. You have to provide the text type (T: Title, A:Abstract), the start offset and the end offset.

        public static string chemdner_patents_development_text = directory + "chemdner_patents_development_text.txt";
        // 1- Patent identifier
        // 2- Title of the patent
        // 3- Abstract of the patent
    }

    class gpro_training_set_v02
    {
        public static string directory = Environment.CurrentDirectory + @"\data\CHEMDNERgoldstandard\gpro_training_set_v02\";
        public static string chemdner_gpro_gold_standard_train_eval_v02 = directory + "chemdner_gpro_gold_standard_train_eval_v02.tsv";
        // 1- Patent identifier
        // 2- Offset string consisting in a triplet joined by the ':' character. You have to provide the text type (T: Title, A:Abstract), the start offset and the end offset.

        public static string chemdner_gpro_gold_standard_train_v02 = directory + "chemdner_gpro_gold_standard_train_v02.tsv";
        // 1- Patent identifier
        // 2- Type of text from which the annotation was derived (T: Title, A: Abstract)
        // 3- Start offset
        // 4- End offset
        // 5- Text string of the entity mention
        // 6- Type of GPRO entity mention (NO CLASS,NESTED MENTIONS,IDENTIFIER,SEQUENCE, FULL NAME,ABBREVIATION,FAMILY,MULTIPLE)
        // 7- Database identifier of type 1 GPRO mentions, otherwise the tag 'GPRO_TYPE_2' if provided.

        public static string chemdner_patents_train_text = directory + "chemdner_patents_train_text.txt";
        // 1- Patent identifier
        // 2- Title of the patent
        // 3- Abstract of the patent
    }

}