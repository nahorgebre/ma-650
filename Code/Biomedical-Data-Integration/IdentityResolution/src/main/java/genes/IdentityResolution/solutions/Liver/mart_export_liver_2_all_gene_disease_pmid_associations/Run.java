package genes.IdentityResolution.solutions.Liver.mart_export_liver_2_all_gene_disease_pmid_associations;

public class Run {
    public static void main( String[] args ) throws Exception
    {
        LR_Cosine_StandardRecordBlocker.main(args);
        LR_Jaccard_StandardRecordBlocker.main(args);
        LR_Levenshtein_StandardRecordBlocker.main(args);
        LR_SorensenDice_StandardRecordBlocker.main(args);
        ML_SimpleLogistic_StandardRecordBlocker.main(args);
    }
}
