package genes.IdentityResolution.solutions.Cerebellum.Cerebellum_2_mart_export_cerebellum;

public class Run {

    public static void main( String[] args ) throws Exception
    {
        LR_Cosine_StandardRecordBlocker.main(args);
        LR_Jaccard_StandardRecordBlocker.main(args);
        LR_Levenshtein_StandardRecordBlocker.main(args);
        LR_Cosine_StandardRecordBlocker.main(args);
        ML_StandardRecordBlocker.main(args);
    }
    
}