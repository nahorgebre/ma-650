package genes.IdentityResolution.solutions.Cerebellum.mart_export_cerebellum_2_all_gene_disease_pmid_associations;

// winter
import de.uni_mannheim.informatik.dws.winter.matching.MatchingEngine;
import de.uni_mannheim.informatik.dws.winter.matching.blockers.StandardRecordBlocker;
import de.uni_mannheim.informatik.dws.winter.matching.rules.WekaMatchingRule;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.HashedDataSet;
import de.uni_mannheim.informatik.dws.winter.model.MatchingGoldStandard;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;
import de.uni_mannheim.informatik.dws.winter.utils.WinterLogManager;
import de.uni_mannheim.informatik.dws.winter.matching.algorithms.RuleLearner;

// Blocker
import genes.IdentityResolution.Blocking.GeneBlockingKeyByGeneName;

// model
import genes.IdentityResolution.model.Gene;

// solutions
import genes.IdentityResolution.solutions.Evaluation;
import genes.IdentityResolution.solutions.GeneWekaMatchingRule;
import genes.IdentityResolution.solutions.GoldStandard;
import genes.IdentityResolution.solutions.Correspondences;
import genes.IdentityResolution.solutions.Datasets;

// logger
import org.slf4j.Logger;

// java
import java.io.File;
import java.util.ArrayList;
import java.util.List;

import com.wcohen.ss.expt.Blocker;

// GeneNameComperator
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityJaccardOnNGrams.GeneNameComperatorJaccardOnNGrams;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityJaccardOnNGrams.GeneNameComperatorLowerCaseJaccardOnNGrams;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityTokenizingJaccard.GeneNameComperatorTokenizingJaccard;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityTokenizingJaccard.GeneNameComperatorLowerCaseTokenizingJaccard;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityCosine.GeneNameComperatorCosine;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityCosine.GeneNameComperatorLowerCaseCosine;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityLevenshtein.GeneNameComperatorLevenshtein;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityLevenshtein.GeneNameComperatorLowerCaseLevenshtein;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilaritySorensenDice.GeneNameComperatorSorensenDice;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilaritySorensenDice.GeneNameComperatorLowerCaseSorensenDice;

public class ML_StandardRecordBlocker {
    
    private static final Logger logger = WinterLogManager.activateLogger("default");

    public static void main( String[] args ) throws Exception
    {            
        // loading datasets
        System.out.println("*\n*\tLoading datasets\n*");
        HashedDataSet<Gene, Attribute> all_gene_disease_pmid_associations = Datasets.all_gene_disease_pmid_associations();
        HashedDataSet<Gene, Attribute> mart_export_cerebellum = Datasets.mart_export_cerebellum();

        // goldstandard directory
        String comparisonDescription = "mart_export_cerebellum_2_all_gene_disease_pmid_associations";
        String solution = "Cerebellum";
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
            matchingRule.addComparator(new GeneNameComperatorJaccardOnNGrams());
            matchingRule.addComparator(new GeneNameComperatorLowerCaseJaccardOnNGrams());
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
            learner.learnMatchingRule(all_gene_disease_pmid_associations, mart_export_cerebellum, null, matchingRule, gsTrain);

            // create a blocker (blocking strategy)
            StandardRecordBlocker<Gene, Attribute> blocker = new StandardRecordBlocker<Gene, Attribute>(new GeneBlockingKeyByGeneName());
            blocker.setMeasureBlockSizes(true);
            blocker.collectBlockSizeData(outputDirectory + "/debugResultsBlocking.csv", 100);

            // initialize matching engine
            MatchingEngine<Gene, Attribute> engine = new MatchingEngine<>();
   
            // execute the matching
            Processable<Correspondence<Gene, Attribute>> correspondences = engine.runIdentityResolution(
                all_gene_disease_pmid_associations, mart_export_cerebellum, null, matchingRule, blocker);
        
            // write the correspondences to the output file
            Correspondences.output(outputDirectory, correspondences);

            // evaluate your result
            Evaluation.run(correspondences, gsTest, outputDirectory, comparisonDescription, geneMatchingRule.modelType);

        }
    }
}