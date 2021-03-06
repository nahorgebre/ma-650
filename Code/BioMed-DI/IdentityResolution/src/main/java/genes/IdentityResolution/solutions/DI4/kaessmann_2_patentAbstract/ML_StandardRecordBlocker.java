package genes.IdentityResolution.solutions.DI4.kaessmann_2_patentAbstract;

// java
import java.io.File;
import java.util.Date;
import java.util.List;

import org.slf4j.Logger;

// winter
import de.uni_mannheim.informatik.dws.winter.model.HashedDataSet;
import de.uni_mannheim.informatik.dws.winter.model.MatchingGoldStandard;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;
import de.uni_mannheim.informatik.dws.winter.utils.WinterLogManager;
import de.uni_mannheim.informatik.dws.winter.matching.MatchingEngine;
import de.uni_mannheim.informatik.dws.winter.matching.algorithms.RuleLearner;
import de.uni_mannheim.informatik.dws.winter.matching.blockers.StandardRecordBlocker;
import de.uni_mannheim.informatik.dws.winter.matching.rules.WekaMatchingRule;

// models
import genes.IdentityResolution.model.Gene.Gene;

// solutions
import genes.IdentityResolution.solutions.Blocker;
import genes.IdentityResolution.solutions.Correspondences;
import genes.IdentityResolution.solutions.Evaluation;
import genes.IdentityResolution.solutions.GeneWekaMatchingRule;
import genes.IdentityResolution.solutions.GoldStandard;
import genes.IdentityResolution.solutions.WinterLogFile;
import genes.IdentityResolution.solutions.DI4.DI4Datasets;
// Blocker
import genes.IdentityResolution.Blocking.GeneBlockingKeyByGeneName;

// Comperator
import genes.IdentityResolution.Comparators.NcbiIdComperator.NcbiIdComperator;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityCosine.GeneNameComperatorCosine;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityCosine.GeneNameComperatorLowerCaseCosine;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityLevenshtein.GeneNameComperatorLevenshtein;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityLevenshtein.GeneNameComperatorLowerCaseLevenshtein;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilaritySorensenDice.GeneNameComperatorLowerCaseSorensenDice;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilaritySorensenDice.GeneNameComperatorSorensenDice;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityTokenizingJaccard.GeneNameComperatorLowerCaseTokenizingJaccard;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityTokenizingJaccard.GeneNameComperatorTokenizingJaccard;

public class ML_StandardRecordBlocker {

    private static final Logger logger = WinterLogManager.activateLogger("traceFile");

    public static void main(String[] args) throws Exception {

        //WinterLogFile.deleteLog();

        int matchingRuleIndex = Integer.parseInt(args[0]);

        // loading datasets
        System.out.println("*\n*\tLoading datasets\n*");
        HashedDataSet<Gene, Attribute> ds1 = DI4Datasets.kaessmann();
        HashedDataSet<Gene, Attribute> ds2 = DI4Datasets.patentAbstract();

        // goldstandard directory
        String comparisonDescription = "kaessmann_2_patentAbstract";
        String solution = "DI4";
        String goldstandardDirectory = "data/goldstandard/" + solution + "/" + comparisonDescription;

        // load the gold standard (test set)
        MatchingGoldStandard gsTest = GoldStandard.getTestDataset(goldstandardDirectory);
        MatchingGoldStandard gsTrain = GoldStandard.getTrainDataset(goldstandardDirectory);

        // iterate gene matching rules
        List<GeneWekaMatchingRule> matchingRuleList = GeneWekaMatchingRule.createGeneMatchingRuleList();

        GeneWekaMatchingRule geneMatchingRule = matchingRuleList.get(matchingRuleIndex);

        String blockerName = "_StandardRecordBlocker";
        String className = geneMatchingRule.className + blockerName;

        // output directory
        String outputDirectory = "data/output/" + solution + "/" + comparisonDescription + "/" + className;
        new File(outputDirectory).mkdirs();

        // start counting
        Date startDate = new Date();

        // create matching rule
        String options[] = geneMatchingRule.options;
        String modelType = geneMatchingRule.modelType;
        WekaMatchingRule<Gene, Attribute> matchingRule = new WekaMatchingRule<>(0.99, modelType, options);
        if (geneMatchingRule.backwardSelection) {
            matchingRule.setBackwardSelection(true);
        }

        // create debug log
        matchingRule.activateDebugReport(outputDirectory + "/debugResultsMatchingRule.csv", 1000);

        // add comparators
        // matchingRule.addComparator(new NcbiIdComperator());
        matchingRule.addComparator(new GeneNameComperatorTokenizingJaccard());
        matchingRule.addComparator(new GeneNameComperatorLowerCaseTokenizingJaccard());
        matchingRule.addComparator(new GeneNameComperatorCosine());
        matchingRule.addComparator(new GeneNameComperatorLowerCaseCosine());
        matchingRule.addComparator(new GeneNameComperatorLevenshtein());
        matchingRule.addComparator(new GeneNameComperatorLowerCaseLevenshtein());
        matchingRule.addComparator(new GeneNameComperatorSorensenDice());
        matchingRule.addComparator(new GeneNameComperatorLowerCaseSorensenDice());

        // learn the matching rule
        RuleLearner<Gene, Attribute> learner = new RuleLearner<>();
        learner.learnMatchingRule(ds1, ds2, null, matchingRule, gsTrain);

        // create a blocker (blocking strategy)
        StandardRecordBlocker<Gene, Attribute> blocker = new StandardRecordBlocker<Gene, Attribute>(
                new GeneBlockingKeyByGeneName());
        blocker.setMeasureBlockSizes(true);
        blocker.collectBlockSizeData(outputDirectory + "/debugResultsBlocking.csv", 100);

        // write blocker results to the output file
        Blocker.writeStandardRecordBlockerResults(blocker, outputDirectory);

        // initialize matching engine
        MatchingEngine<Gene, Attribute> engine = new MatchingEngine<>();

        // execute the matching
        Processable<Correspondence<Gene, Attribute>> correspondences = engine.runIdentityResolution(ds1, ds2, null,
                matchingRule, blocker);

        // End counting
        Date endDate = new Date();
        int numSeconds = (int) ((endDate.getTime() - startDate.getTime()) / 1000);

        // write the correspondences to the output file
        Correspondences.output(outputDirectory, correspondences);

        // evaluate your result
        Evaluation.run(correspondences, gsTest, outputDirectory, comparisonDescription, className, numSeconds);

        // copy winter log
        //WinterLogFile.copyLogFile(outputDirectory);

    }

}