package genes.IdentityResolution.solutions.Kidney.mart_export_kidney_2_all_gene_disease_pmid_associations;

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
import genes.IdentityResolution.Blocking.GeneBlockingKeyByGeneName;

// model
import genes.IdentityResolution.model.Gene;

// solutions
import genes.IdentityResolution.solutions.Correspondences;
import genes.IdentityResolution.solutions.Datasets;
import genes.IdentityResolution.solutions.Evaluation;
import genes.IdentityResolution.solutions.GeneLinearCombinationMatchingRule_GeneName;
import genes.IdentityResolution.solutions.GoldStandard;

public class LR_StandardRecordBlocker {
    private static final Logger logger = WinterLogManager.activateLogger("default");

    public static void main( String[] args ) throws Exception
    {
        // loading datasets
        System.out.println("*\n*\tLoading datasets\n*");
        HashedDataSet<Gene, Attribute> all_gene_disease_pmid_associations = Datasets.all_gene_disease_pmid_associations();
        HashedDataSet<Gene, Attribute> mart_export_kidney = Datasets.mart_export_kidney();

        // goldstandard directory
        String comparisonDescription = "mart_export_kidney_2_all_gene_disease_pmid_associations";
        String solution = "Kidney";
        String goldstandardDirectory = "data/goldstandard/" + solution + "/" + comparisonDescription;

        // load the gold standard (test set)
        MatchingGoldStandard gsTest = GoldStandard.getTestDataset(goldstandardDirectory);

        String blockerName = "_StandardRecordBlocker";
        List<GeneLinearCombinationMatchingRule_GeneName> matchingRuleList = GeneLinearCombinationMatchingRule_GeneName.getMatchingRuleList(solution, comparisonDescription, blockerName, gsTest);

        for (GeneLinearCombinationMatchingRule_GeneName geneLinearCombinationMatchingRule_GeneName : matchingRuleList) {

            LinearCombinationMatchingRule<Gene, Attribute> matchingRule = geneLinearCombinationMatchingRule_GeneName.matchingRule;
            String outputDirectory = GeneLinearCombinationMatchingRule_GeneName.outputDirectory;

            // create a blocker (blocking strategy)
            StandardRecordBlocker<Gene, Attribute> blocker = new StandardRecordBlocker<Gene, Attribute>(new GeneBlockingKeyByGeneName());
            blocker.setMeasureBlockSizes(true);
            blocker.collectBlockSizeData(outputDirectory + "/debugResultsBlocking.csv", 100);

            // initialize matching engine
            MatchingEngine<Gene, Attribute> engine = new MatchingEngine<>();

            // execute the matching
            System.out.println("*\n*\tRunning identity resolution\n*");
            Processable<Correspondence<Gene, Attribute>> correspondences = engine.runIdentityResolution(
                all_gene_disease_pmid_associations, mart_export_kidney, null, matchingRule, blocker);

            // write the correspondences to the output file
            Correspondences.output(outputDirectory, correspondences);

            // evaluate your result
            Evaluation.run(correspondences, gsTest, outputDirectory, comparisonDescription);
        }
    }
}