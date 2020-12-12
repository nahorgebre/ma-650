namespace DataFusion2
{

    public class MatchingEngines
    {

        // Rule-based identity resolution

        public static string LC_StandardRecordBlocker = "LinearCombination_StandardRecordBlocker";

        public static string LC_SortedNeighbourhoodBlocker = "LinearCombination_SortedNeighbourhoodBlocker";


        // Learning Matching Rules

        public static string ML_SimpleLogistic_StandardRecordBlocker = "ML_SimpleLogistic_StandardRecordBlocker";

        public static string ML_SimpleLogistic_SortedNeighbourhoodBlocker = "ML_SimpleLogistic_SortedNeighbourhoodBlocker";


        public static string ML_KNN_StandardRecordBlocker = "ML_KNN_StandardRecordBlocker";

        public static string ML_KNN_SortedNeighbourhoodBlocker = "ML_KNN_SortedNeighbourhoodBlocker";


        public static string ML_DecisionTree_StandardRecordBlocker = "ML_DecisionTree_StandardRecordBlocker";

        public static string ML_DecisionTree_SortedNeighbourhoodBlocker = "ML_DecisionTree_SortedNeighbourhoodBlocker";


        public static string ML_AdaBoost_StandardRecordBlocker = "ML_AdaBoost_StandardRecordBlocker";

        public static string ML_AdaBoost_SortedNeighbourhoodBlocker = "ML_AdaBoost_SortedNeighbourhoodBlocker";
        

    }

}