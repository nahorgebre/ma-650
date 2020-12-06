package genes.IdentityResolution.solutions.DI1.Kidney_2_Testis;

// java
import java.io.File;
import java.util.Date;

import org.slf4j.Logger;

// winter
import de.uni_mannheim.informatik.dws.winter.matching.MatchingEngine;
import de.uni_mannheim.informatik.dws.winter.matching.blockers.StandardRecordBlocker;
import de.uni_mannheim.informatik.dws.winter.matching.rules.LinearCombinationMatchingRule;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.HashedDataSet;
import de.uni_mannheim.informatik.dws.winter.model.MatchingGoldStandard;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;
import de.uni_mannheim.informatik.dws.winter.utils.WinterLogManager;

// comparators
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilarityCosine.EnsemblIdComperatorCosine;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilarityCosine.EnsemblIdComperatorLowerCaseCosine;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilarityLevenshtein.EnsemblIdComperatorLevenshtein;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilarityLevenshtein.EnsemblIdComperatorLowerCaseLevenshtein;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilaritySorensenDice.EnsemblIdComperatorLowerCaseSorensenDice;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilaritySorensenDice.EnsemblIdComperatorSorensenDice;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilarityTokenizingJaccard.EnsemblIdComperatorLowerCaseTokenizingJaccard;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilarityTokenizingJaccard.EnsemblIdComperatorTokenizingJaccard;

// model
import genes.IdentityResolution.model.Gene.Gene;

// blockig
import genes.IdentityResolution.Blocking.GeneBlockingKeyByEnsemblId;

// solutions
import genes.IdentityResolution.solutions.Correspondences;
import genes.IdentityResolution.solutions.DI1.DI1Datasets;
import genes.IdentityResolution.solutions.Evaluation;
import genes.IdentityResolution.solutions.GoldStandard;
import genes.IdentityResolution.solutions.Blocker;

public class LR_StandardRecordBlocker 
{

	private static final Logger logger = WinterLogManager.activateLogger("default");
	
    public static void main( String[] args ) throws Exception
    {
		// loading data
        System.out.println("*\n*\tLoading datasets\n*");
        HashedDataSet<Gene, Attribute> ds1 = DI1Datasets.Kidney();
        HashedDataSet<Gene, Attribute> ds2 = DI1Datasets.Testis();

		// load the gold standard (test set)
        String comparisonDescription = "Kidney_2_Testis";
        String solution = "DI1";
        String goldstandardDirectory = "data/goldstandard/" + solution + "/" + comparisonDescription;
        String className = "LinearCombination_StandardRecordBlocker";

        // load the gold standard (test set)
        MatchingGoldStandard gsTest = GoldStandard.getTestDataset(goldstandardDirectory);

        // create output directory
        String outputDirectory = "data/output/" + solution + "/" + comparisonDescription + "/" + className;
        new File(outputDirectory).mkdirs();

        // start counting
        Date startDate = new Date();

		// create a matching rule
		LinearCombinationMatchingRule<Gene, Attribute> matchingRule = new LinearCombinationMatchingRule<>(
				0.9);
		matchingRule.activateDebugReport(outputDirectory + "/debugResultsMatchingRule.csv", 1000, gsTest);
		
        // add comparators
        matchingRule.addComparator(new EnsemblIdComperatorCosine(), 0.125);
        matchingRule.addComparator(new EnsemblIdComperatorLowerCaseCosine(), 0.125);
        matchingRule.addComparator(new EnsemblIdComperatorTokenizingJaccard(), 0.125);
        matchingRule.addComparator(new EnsemblIdComperatorLowerCaseTokenizingJaccard(), 0.125);
        matchingRule.addComparator(new EnsemblIdComperatorLevenshtein(), 0.125);
        matchingRule.addComparator(new EnsemblIdComperatorLowerCaseLevenshtein(), 0.125);
        matchingRule.addComparator(new EnsemblIdComperatorSorensenDice(), 0.125);
        matchingRule.addComparator(new EnsemblIdComperatorLowerCaseSorensenDice(), 0.125);

		// create a blocker (blocking strategy)
		StandardRecordBlocker<Gene, Attribute> blocker = new StandardRecordBlocker<Gene, Attribute>(new GeneBlockingKeyByEnsemblId());
        blocker.setMeasureBlockSizes(true);
        blocker.collectBlockSizeData(outputDirectory + "/debugResultsBlocking.csv", 100);
        
        // write blocker results to the output file
        Blocker.writeStandardRecordBlockerResults(blocker, outputDirectory);
		
		// initialize Matching Engine
		MatchingEngine<Gene, Attribute> engine = new MatchingEngine<>();

		// execute the matching
		System.out.println("*\n*\tRunning identity resolution\n*");
		Processable<Correspondence<Gene, Attribute>> correspondences = engine.runIdentityResolution(
				ds1, ds2, null, matchingRule,
                blocker);
                
        // end counting
        Date endDate = new Date();
        int numSeconds = (int)((endDate.getTime() - startDate.getTime()) / 1000);

        // write the correspondences to the output file
        Correspondences.output(outputDirectory, correspondences);
                
        // evaluate your result
        Evaluation.run(correspondences, gsTest, outputDirectory, comparisonDescription, className, numSeconds);

    }

}