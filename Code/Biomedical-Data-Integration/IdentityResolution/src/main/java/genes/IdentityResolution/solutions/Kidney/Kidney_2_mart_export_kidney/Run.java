package genes.IdentityResolution.solutions.Kidney.Kidney_2_mart_export_kidney;

import genes.IdentityResolution.solutions.Brain.Brain_2_mart_export_brain.ML_SimpleLogistic_StandardRecordBlocker;

public class Run {

    public static void main( String[] args ) throws Exception
    {
        LR_Cosine_StandardRecordBlocker.main(args);
        LR_Jaccard_StandardRecordBlocker.main(args);
        LR_Levenshtein_StandardRecordBlocker.main(args);
        LR_Cosine_StandardRecordBlocker.main(args);
        ML_SimpleLogistic_StandardRecordBlocker.main(args);
    }
    
}