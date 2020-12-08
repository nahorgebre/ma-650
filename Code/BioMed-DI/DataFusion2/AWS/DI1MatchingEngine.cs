namespace DataFusion2
{

    public class DI1MatchingEngine
    {

        public static string checkMatchingEngine(string comparisonName)
        {

            if (comparisonName.Equals("Heart_2_Brain"))
            {

                return MatchingEngines.LC_SortedNeighbourhoodBlocker;

            }
            else if (comparisonName.Equals("Heart_2_Cerebellum"))
            {

                return MatchingEngines.ML_SimpleLogistic_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("Heart_2_Kidney"))
            {

                return MatchingEngines.ML_SimpleLogistic_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("Heart_2_Liver"))
            {

                return MatchingEngines.ML_SimpleLogistic_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("Heart_2_Testis"))
            {

                return MatchingEngines.ML_SimpleLogistic_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("Heart_2_Heart_Ensembl_NCBI_Crosswalk"))
            {

                return MatchingEngines.ML_SimpleLogistic_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk"))
            {

                return MatchingEngines.ML_SimpleLogistic_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("Cerebellum_2_Brain"))
            {

                return MatchingEngines.ML_SimpleLogistic_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("Cerebellum_2_Kidney"))
            {

                return MatchingEngines.ML_SimpleLogistic_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("Cerebellum_2_Liver"))
            {

                return MatchingEngines.ML_SimpleLogistic_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("Cerebellum_2_Testis"))
            {

                return MatchingEngines.ML_SimpleLogistic_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("Cerebellum_2_mart_export_cerebellum"))
            {

                return MatchingEngines.ML_SimpleLogistic_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("Brain_2_Kidney"))
            {

                return MatchingEngines.ML_SimpleLogistic_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("Brain_2_Liver"))
            {

                return MatchingEngines.ML_SimpleLogistic_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("Brain_2_Testis"))
            {

                return MatchingEngines.ML_SimpleLogistic_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("Brain_2_mart_export_brain"))
            {

                return MatchingEngines.ML_SimpleLogistic_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("Kidney_2_Liver"))
            {

                return MatchingEngines.ML_SimpleLogistic_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("Kidney_2_Testis"))
            {

                return MatchingEngines.ML_SimpleLogistic_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("Kidney_2_mart_export_kidney"))
            {

                return MatchingEngines.ML_SimpleLogistic_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("Testis_2_Liver"))
            {

                return MatchingEngines.ML_SimpleLogistic_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("Liver_2_mart_export_liver"))
            {

                return MatchingEngines.ML_SimpleLogistic_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("Testis_2_mart_export_testis"))
            {

                return MatchingEngines.ML_SimpleLogistic_StandardRecordBlocker;

            }

            return string.Empty;

        }

    }

}