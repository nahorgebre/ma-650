package genes.IdentityResolution.solutions.Heart.Heart_2_Heart_Ensembl_NCBI_Crosswalk;

// java
import java.util.List;

// logger
import org.slf4j.Logger;

// winter
import de.uni_mannheim.informatik.dws.winter.matching.MatchingEngine;
import de.uni_mannheim.informatik.dws.winter.matching.blockers.StandardRecordBlocker;
import de.uni_mannheim.informatik.dws.winter.matching.rules.LinearCombinationMatchingRule;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.HashedDataSet;
import de.uni_mannheim.informatik.dws.winter.model.MatchingGoldStandard;
import de.uni_mannheim.informatik.dws.winter.utils.WinterLogManager;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;

// blockig
import genes.IdentityResolution.Blocking.GeneBlockingKeyByEnsemblId;

// model
import genes.IdentityResolution.model.Gene;

// solutions
import genes.IdentityResolution.solutions.Correspondences;
import genes.IdentityResolution.solutions.Datasets;
import genes.IdentityResolution.solutions.Evaluation;
import genes.IdentityResolution.solutions.GeneLinearCombinationMatchingRule_EnsemblId;
import genes.IdentityResolution.solutions.GoldStandard;

public class LR_StandardRecordBlocker {
    private static final Logger logger = WinterLogManager.activateLogger("default");

    public static void main( String[] args ) throws Exception
    {
        // loading datasets
        System.out.println("*\n*\tLoading datasets\n*");
        HashedDataSet<Gene, Attribute> Heart = Datasets.Heart();
        HashedDataSet<Gene, Attribute> Heart_Ensembl_NCBI_Crosswalk = Datasets.Heart_Ensembl_NCBI_Crosswalk();

        // goldstandard directory
        String comparisonDescription = "Heart_2_Heart_Ensembl_NCBI_Crosswalk";
        String solution = "Heart";
        String goldstandardDirectory = "data/goldstandard/" + solution + "/" + comparisonDescription;

        // load the gold standard (test set)
        MatchingGoldStandard gsTest = GoldStandard.getTestDataset(goldstandardDirectory);

        String blockerName = "_StandardRecordBlocker";
        List<GeneLinearCombinationMatchingRule_EnsemblId> matchingRuleList = GeneLinearCombinationMatchingRule_EnsemblId.getMatchingRuleList(solution, comparisonDescription, blockerName, gsTest);

        for (GeneLinearCombinationMatchingRule_EnsemblId geneLinearCombinationMatchingRule_EnsemblId : matchingRuleList) {

            LinearCombinationMatchingRule<Gene, Attribute> matchingRule = geneLinearCombinationMatchingRule_EnsemblId.matchingRule;
            String outputDirectory = geneLinearCombinationMatchingRule_EnsemblId.outputDirectory;

            // create a blocker (blocking strategy)
            StandardRecordBlocker<Gene, Attribute> blocker = new StandardRecordBlocker<Gene, Attribute>(new GeneBlockingKeyByEnsemblId());
            blocker.setMeasureBlockSizes(true);
            blocker.collectBlockSizeData(outputDirectory + "/debugResultsBlocking.csv", 100);

            // initialize matching engine
            MatchingEngine<Gene, Attribute> engine = new MatchingEngine<>();

            // execute the matching
            System.out.println("*\n*\tRunning identity resolution\n*");
            Processable<Correspondence<Gene, Attribute>> correspondences = engine.runIdentityResolution(
                Heart, Heart_Ensembl_NCBI_Crosswalk, null, matchingRule, blocker);

            // write the correspondences to the output file
            Correspondences.output(outputDirectory, correspondences);

            // evaluate your result
            Evaluation.run(correspondences, gsTest, outputDirectory, comparisonDescription, geneLinearCombinationMatchingRule_EnsemblId.modelType);
        }
    }
}
