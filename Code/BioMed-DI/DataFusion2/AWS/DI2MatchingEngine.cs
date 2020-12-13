namespace DataFusion2
{

    public class DI2MatchingEngine
    {

        public static string checkMatchingEngine(string comparisonName)
        {

            if (comparisonName.Equals("kaessmann_2_all_gene_disease_pmid_associations_1"))
            {

                return MatchingEngines.ML_AdaBoost_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("kaessmann_2_all_gene_disease_pmid_associations_2"))
            {

                return MatchingEngines.ML_AdaBoost_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("kaessmann_2_all_gene_disease_pmid_associations_3"))
            {

                return MatchingEngines.ML_AdaBoost_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("kaessmann_2_all_gene_disease_pmid_associations_4"))
            {

                return MatchingEngines.ML_AdaBoost_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("kaessmann_2_all_gene_disease_pmid_associations_5"))
            {

                return MatchingEngines.ML_AdaBoost_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("kaessmann_2_all_gene_disease_pmid_associations_6"))
            {

                return MatchingEngines.ML_AdaBoost_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("kaessmann_2_all_gene_disease_pmid_associations_7"))
            {

                return MatchingEngines.ML_AdaBoost_StandardRecordBlocker;

            }

            return string.Empty;

        }

    }

}