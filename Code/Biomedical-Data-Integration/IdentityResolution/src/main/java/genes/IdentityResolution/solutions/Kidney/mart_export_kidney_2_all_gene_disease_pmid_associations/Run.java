package genes.IdentityResolution.solutions.Kidney.mart_export_kidney_2_all_gene_disease_pmid_associations;

import genes.IdentityResolution.solutions.Brain.Brain_2_mart_export_brain.ML_LinearRegression_StandardRecordBlocker;

public class Run {
    public static void main( String[] args ) throws Exception
    {
        LR_Cosine_StandardRecordBlocker.main(args);
        LR_Jaccard_StandardRecordBlocker.main(args);
        LR_Levenshtein_StandardRecordBlocker.main(args);
        LR_SorensenDice_StandardRecordBlocker.main(args);
        ML_LinearRegression_StandardRecordBlocker.main(args);
    }
}
