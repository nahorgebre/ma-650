package genes.IdentityResolution.solutions.Brain.Brain_2_mart_export_brain;

import java.io.File;

import org.slf4j.Logger;

import de.uni_mannheim.informatik.dws.winter.matching.MatchingEngine;
import de.uni_mannheim.informatik.dws.winter.matching.blockers.StandardRecordBlocker;
import de.uni_mannheim.informatik.dws.winter.matching.rules.LinearCombinationMatchingRule;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.HashedDataSet;
import de.uni_mannheim.informatik.dws.winter.model.MatchingGoldStandard;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;
import de.uni_mannheim.informatik.dws.winter.utils.WinterLogManager;

import genes.IdentityResolution.Blocking.GeneBlockingKeyByEnsemblId;
import genes.IdentityResolution.model.Gene;
import genes.IdentityResolution.solutions.Correspondences;
import genes.IdentityResolution.solutions.Datasets;
import genes.IdentityResolution.solutions.Evaluation;
import genes.IdentityResolution.solutions.GoldStandard;

import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilarityCosine.EnsemblIdComperatorCosine;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilarityCosine.EnsemblIdComperatorLowerCaseCosine;

public class LR_Cosine_StandardRecordBlocker {

    private static final Logger logger = WinterLogManager.activateLogger("default");
    public static String className = "LR_Cosine_StandardRecordBlocker";

    public static void main( String[] args ) throws Exception
    {
        // create output folder
        String comparisonDescription = "Brain_2_mart_export_brain";
        String outputDirectory = "data/output/Brain/" + comparisonDescription + "/" + className;
        new File(outputDirectory).mkdirs();
        String goldstandardDirectory = "data/goldstandard/Brain/" + comparisonDescription;

        // loading datasetse
        System.out.println("*\n*\tLoading datasets\n*");
        HashedDataSet<Gene, Attribute> Brain = Datasets.Brain();
        HashedDataSet<Gene, Attribute> mart_export_brain = Datasets.mart_export_brain();

        // load the gold standard (test set)
        MatchingGoldStandard gsTest = GoldStandard.getTestDataset(goldstandardDirectory);

        // create a matching rule
        LinearCombinationMatchingRule<Gene, Attribute> matchingRule = new LinearCombinationMatchingRule<>(
                0.9);
        matchingRule.activateDebugReport(outputDirectory + "/debugResultsMatchingRule.csv", 1000, gsTest);

        // add comparators
        matchingRule.addComparator(new EnsemblIdComperatorCosine(), 0.5);
        matchingRule.addComparator(new EnsemblIdComperatorLowerCaseCosine(), 0.5);

        // create a blocker (blocking strategy)
        StandardRecordBlocker<Gene, Attribute> blocker = new StandardRecordBlocker<Gene, Attribute>(new GeneBlockingKeyByEnsemblId());
        blocker.setMeasureBlockSizes(true);
        blocker.collectBlockSizeData(outputDirectory + "/debugResultsBlocking.csv", 100);

        // initialize matching engine
        MatchingEngine<Gene, Attribute> engine = new MatchingEngine<>();

        // execute the matching
        System.out.println("*\n*\tRunning identity resolution\n*");
        Processable<Correspondence<Gene, Attribute>> correspondences = engine.runIdentityResolution(
                Brain, mart_export_brain, null, matchingRule, blocker);

        // write the correspondences to the output file
        Correspondences.output(outputDirectory, className, correspondences);

        // evaluate your result
        Evaluation.run(correspondences, gsTest, outputDirectory, className, comparisonDescription);
    }
    
}