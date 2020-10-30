package genes.IdentityResolution.solutions.DI1.Brain_2_Liver;

// java
import java.io.File;
import java.util.List;

// winter
import de.uni_mannheim.informatik.dws.winter.model.HashedDataSet;
import de.uni_mannheim.informatik.dws.winter.model.MatchingGoldStandard;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;
import de.uni_mannheim.informatik.dws.winter.matching.MatchingEngine;
import de.uni_mannheim.informatik.dws.winter.matching.algorithms.RuleLearner;
import de.uni_mannheim.informatik.dws.winter.matching.blockers.StandardRecordBlocker;
import de.uni_mannheim.informatik.dws.winter.matching.rules.WekaMatchingRule;

// models
import genes.IdentityResolution.model.Gene.Gene;

// solutions
import genes.IdentityResolution.solutions.Datasets;
import genes.IdentityResolution.solutions.Correspondences;
import genes.IdentityResolution.solutions.Evaluation;
import genes.IdentityResolution.solutions.GeneWekaMatchingRule;
import genes.IdentityResolution.solutions.GoldStandard;

// Blocker
import genes.IdentityResolution.Blocking.GeneBlockingKeyByEnsemblId;

// EnsemblIdComperator
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilarityJaccardOnNGrams.EnsemblIdComperatorJaccardOnNGrams;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilarityJaccardOnNGrams.EnsemblIdComperatorLowerCaseJaccardOnNGrams;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilarityTokenizingJaccard.EnsemblIdComperatorTokenizingJaccard;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilarityTokenizingJaccard.EnsemblIdComperatorLowerCaseTokenizingJaccard;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilarityCosine.EnsemblIdComperatorCosine;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilarityCosine.EnsemblIdComperatorLowerCaseCosine;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilarityLevenshtein.EnsemblIdComperatorLevenshtein;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilarityLevenshtein.EnsemblIdComperatorLowerCaseLevenshtein;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilaritySorensenDice.EnsemblIdComperatorSorensenDice;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilaritySorensenDice.EnsemblIdComperatorLowerCaseSorensenDice;

// GeneNameComperator
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityCosine.GeneNameComperatorCosine;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityCosine.GeneNameComperatorLowerCaseCosine;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityJaccardOnNGrams.GeneNameComperatorJaccardOnNGrams;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityJaccardOnNGrams.GeneNameComperatorLowerCaseJaccardOnNGrams;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityLevenshtein.GeneNameComperatorLevenshtein;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityLevenshtein.GeneNameComperatorLowerCaseLevenshtein;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilaritySorensenDice.GeneNameComperatorLowerCaseSorensenDice;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilaritySorensenDice.GeneNameComperatorSorensenDice;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityTokenizingJaccard.GeneNameComperatorLowerCaseTokenizingJaccard;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityTokenizingJaccard.GeneNameComperatorTokenizingJaccard;


public class ML_StandardRecordBlocker {

    public static void main( String[] args ) throws Exception
    {
        // loading datasets
        System.out.println("*\n*\tLoading datasets\n*");
        HashedDataSet<Gene, Attribute> ds1 = Datasets.Brain();
        HashedDataSet<Gene, Attribute> ds2 = Datasets.Liver();

        // goldstandard directory
        String comparisonDescription = "Brain_2_Liver";
        String solution = "Kaessmann";
        String goldstandardDirectory = "data/goldstandard/" + solution + "/" + comparisonDescription;
        
        // load the gold standard (test set)
        MatchingGoldStandard gsTest = GoldStandard.getTestDataset(goldstandardDirectory);
        MatchingGoldStandard gsTrain = GoldStandard.getTrainDataset(goldstandardDirectory);

        // iterate gene matching rules
        List<GeneWekaMatchingRule> matchingRuleList = GeneWekaMatchingRule.createGeneMatchingRuleList();
        for (GeneWekaMatchingRule geneMatchingRule : matchingRuleList) {

            String blockerName = "_StandardRecordBlocker";
            String className = geneMatchingRule.className + blockerName;

            // output directory
            String outputDirectory = "data/output/" + solution + "/" + comparisonDescription + "/" + className;
            new File(outputDirectory).mkdirs();

            // create matching rule
            String options[] = geneMatchingRule.options;
            String modelType = geneMatchingRule.modelType;
            WekaMatchingRule<Gene, Attribute> matchingRule = new WekaMatchingRule<>(0.7, modelType, options);
            if (geneMatchingRule.backwardSelection) {
                matchingRule.setBackwardSelection(true);
            }

            // create debug log
            matchingRule.activateDebugReport(outputDirectory + "/debugResultsMatchingRule.csv", 1000);

            // add comparators
            //matchingRule.addComparator(new EnsemblIdComperatorJaccardOnNGrams());
            //matchingRule.addComparator(new EnsemblIdComperatorLowerCaseJaccardOnNGrams());
            matchingRule.addComparator(new EnsemblIdComperatorTokenizingJaccard());
            matchingRule.addComparator(new EnsemblIdComperatorLowerCaseTokenizingJaccard());
            matchingRule.addComparator(new EnsemblIdComperatorCosine());
            matchingRule.addComparator(new EnsemblIdComperatorLowerCaseCosine());
            matchingRule.addComparator(new EnsemblIdComperatorLevenshtein());
            matchingRule.addComparator(new EnsemblIdComperatorLowerCaseLevenshtein());
            matchingRule.addComparator(new EnsemblIdComperatorSorensenDice());
            matchingRule.addComparator(new EnsemblIdComperatorLowerCaseSorensenDice());

            // learn the matching rule
            RuleLearner<Gene, Attribute> learner = new RuleLearner<>();
            learner.learnMatchingRule(ds1, ds2, null, matchingRule, gsTrain);

            // create a blocker (blocking strategy)
            StandardRecordBlocker<Gene, Attribute> blocker = new StandardRecordBlocker<Gene, Attribute>(new GeneBlockingKeyByEnsemblId());
            blocker.setMeasureBlockSizes(true);
            blocker.collectBlockSizeData(outputDirectory + "/debugResultsBlocking.csv", 100);

            // initialize matching engine
            MatchingEngine<Gene, Attribute> engine = new MatchingEngine<>();
   
            // execute the matching
            Processable<Correspondence<Gene, Attribute>> correspondences = engine.runIdentityResolution(
                ds1, ds2, null, matchingRule, blocker);
                
            // write the correspondences to the output file
            Correspondences.output(outputDirectory, correspondences);
        
            // evaluate your result
            Evaluation.run(correspondences, gsTest, outputDirectory, comparisonDescription, className);
           
        }
    }  
}