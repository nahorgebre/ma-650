package genes.IdentityResolution.solutions.Heart.Heart_Ensembl_NCBI_Crosswalk_2_gene2pubtatorcentral;

public class Run {

    public static void main( String[] args ) throws Exception
    {
        LR_Cosine_StandardRecordBlocker.main(args);
        LR_Jaccard_StandardRecordBlocker.main(args);
        LR_Levenshtein_StandardRecordBlocker.main(args);
        LR_Cosine_StandardRecordBlocker.main(args);
        ML_SimpleLogistic_StandardRecordBlocker.main(args);
        ML_KNN_StandardRecordBlocker.main(args);
        ML_DecisionTree_StandardRecordBlocker.main(args);
        ML_AdaBoost_StandardRecordBlocker.main(args);
    }
    
}