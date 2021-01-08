namespace DataFusion
{

    public class DI4MatchingEngine
    {

        public static string checkMatchingEngine(string comparisonName)
        {

            if (comparisonName.Equals("kaessmann_2_patentAbstract"))
            {

                return MatchingEngines.ML_AdaBoost_StandardRecordBlocker;

            }

            return string.Empty;
        
        }

    }

}