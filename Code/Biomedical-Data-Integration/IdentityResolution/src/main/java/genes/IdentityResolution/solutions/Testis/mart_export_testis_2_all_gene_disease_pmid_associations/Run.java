package genes.IdentityResolution.solutions.Testis.mart_export_testis_2_all_gene_disease_pmid_associations;

import edu.stanford.nlp.parser.lexparser.MLEDependencyGrammar;
import genes.IdentityResolution.solutions.Brain.Brain_2_mart_export_brain.ML_SimpleLogistic_StandardRecordBlocker;

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
