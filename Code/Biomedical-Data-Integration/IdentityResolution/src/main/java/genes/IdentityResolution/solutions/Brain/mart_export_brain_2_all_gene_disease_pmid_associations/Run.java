package genes.IdentityResolution.solutions.Brain.mart_export_brain_2_all_gene_disease_pmid_associations;

public class Run {

    public static void main( String[] args ) throws Exception
    {
        LR_SorensenDice_StandardRecordBlocker.main(args);
        LR_Jaccard_StandardRecordBlocker.main(args);
        LR_Cosine_StandardRecordBlocker.main(args);
        LR_SorensenDice_StandardRecordBlocker.main(args);
        ML_StandardRecordBlocker.main(args);
    }
  
}
