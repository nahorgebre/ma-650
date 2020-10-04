package genes.IdentityResolution.solutions.Kidney.Kidney_2_mart_export_kidney;

// java
import java.io.File;
import java.util.ArrayList;
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
import genes.IdentityResolution.model.Gene;

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

public class ML_StandardRecordBlocker {

    public static void main( String[] args ) throws Exception
    {
        // loading datasets
        System.out.println("*\n*\tLoading datasets\n*");
        HashedDataSet<Gene, Attribute> Kidney = Datasets.Kidney();
        HashedDataSet<Gene, Attribute> mart_export_kidney = Datasets.mart_export_kidney();

        // goldstandard directory
        String comparisonDescription = "Kidney_2_mart_export_kidney";
        String solution = "Kidney";
        String goldstandardDirectory = "data/goldstandard/" + solution + "/" + comparisonDescription;
        
        // load the gold standard (test set)
        MatchingGoldStandard gsTest = GoldStandard.getTestDataset(goldstandardDirectory);
        MatchingGoldStandard gsTrain = GoldStandard.getTrainDataset(goldstandardDirectory);

        // iterate gene matching rules
        List<GeneWekaMatchingRule> matchingRuleList = GeneWekaMatchingRule.createGeneMatchingRuleList();
        for (GeneWekaMatchingRule geneMatchingRule : matchingRuleList) {

            String modelType = geneMatchingRule.modelType;

            // output directory
            String outputDirectory = "data/output/" + solution + "/" + comparisonDescription + "/" + modelType;
            new File(outputDirectory).mkdirs();
            
            WekaMatchingRule<Gene, Attribute> matchingRule = geneMatchingRule.matchingRule;

            matchingRule.activateDebugReport(outputDirectory + "/debugResultsMatchingRule.csv", 1000);

            // add comparators
            matchingRule.addComparator(new EnsemblIdComperatorJaccardOnNGrams());
            matchingRule.addComparator(new EnsemblIdComperatorLowerCaseJaccardOnNGrams());
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
            learner.learnMatchingRule(Kidney, mart_export_kidney, null, matchingRule, gsTrain);

            // create a blocker (blocking strategy)
            StandardRecordBlocker<Gene, Attribute> blocker = new StandardRecordBlocker<Gene, Attribute>(new GeneBlockingKeyByEnsemblId());
            blocker.setMeasureBlockSizes(true);
            blocker.collectBlockSizeData(outputDirectory + "/debugResultsBlocking.csv", 100);

            // initialize matching engine
            MatchingEngine<Gene, Attribute> engine = new MatchingEngine<>();
   
            // execute the matching
            Processable<Correspondence<Gene, Attribute>> correspondences = engine.runIdentityResolution(
                Kidney, mart_export_kidney, null, matchingRule, blocker);
                
            // write the correspondences to the output file
            Correspondences.output(outputDirectory, modelType, correspondences);
        
            // evaluate your result
            Evaluation.run(correspondences, gsTest, outputDirectory, modelType, comparisonDescription);
           
        }
    }  
}