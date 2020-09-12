package genes.IdentityResolution.solutions.Kidney.mart_export_kidney_2_all_gene_disease_pmid_associations;

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

import genes.IdentityResolution.Blocking.GeneBlockingKeyByEnsemblId;
import genes.IdentityResolution.model.Gene;
import genes.IdentityResolution.solutions.Evaluation;
import genes.IdentityResolution.solutions.GoldStandard;
import genes.IdentityResolution.solutions.Correspondences;
import genes.IdentityResolution.solutions.Datasets;

import org.slf4j.Logger;

import java.io.File;

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

public class ML_SimpleLogistic_StandardRecordBlocker 
{
    private static final Logger logger = WinterLogManager.activateLogger("default");
    public static String className = "ML_SimpleLogistic_StandardRecordBlocker";

    public static void main( String[] args ) throws Exception
    {            
        // create debug folder
        String comparisonDescription = "mart_export_kidney_2_all_gene_disease_pmid_associations";
        String outputDirectory = "data/output/Kidney/" + comparisonDescription + "/" + className;
        new File(outputDirectory).mkdirs();
        String goldstandardDirectory = "data/goldstandard/Kidney/" + comparisonDescription;

        // loading datasets
        System.out.println("*\n*\tLoading datasets\n*");
        HashedDataSet<Gene, Attribute> all_gene_disease_pmid_associations = Datasets.all_gene_disease_pmid_associations();
        HashedDataSet<Gene, Attribute> mart_export_kidney = Datasets.mart_export_kidney();

        // load the gold standard (test set)
        MatchingGoldStandard gsTest = GoldStandard.getTestDataset(goldstandardDirectory);
        MatchingGoldStandard gsTrain = GoldStandard.getTrainDataset(goldstandardDirectory);

        // create a matching rule
        String options[] = new String[] { "-S" };
        String modelType = "SimpleLogistic"; // use a logistic regression
        WekaMatchingRule<Gene, Attribute> matchingRule = new WekaMatchingRule<>(0.7, modelType, options);
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
        learner.learnMatchingRule(all_gene_disease_pmid_associations, mart_export_kidney, null, matchingRule, gsTrain);

        // create a blocker (blocking strategy)
        StandardRecordBlocker<Gene, Attribute> blocker = new StandardRecordBlocker<Gene, Attribute>(new GeneBlockingKeyByEnsemblId());
        blocker.setMeasureBlockSizes(true);
        blocker.collectBlockSizeData(outputDirectory + "/debugResultsBlocking.csv", 100);

        // initialize matching engine
        MatchingEngine<Gene, Attribute> engine = new MatchingEngine<>();
   
        // execute the matching
        Processable<Correspondence<Gene, Attribute>> correspondences = engine.runIdentityResolution(
            all_gene_disease_pmid_associations, mart_export_kidney, null, matchingRule, blocker);
        
        // write the correspondences to the output file
        Correspondences.output(outputDirectory, className, correspondences);

        // evaluate your result
        Evaluation.run(correspondences, gsTest, outputDirectory, className, comparisonDescription);
        
    }
}