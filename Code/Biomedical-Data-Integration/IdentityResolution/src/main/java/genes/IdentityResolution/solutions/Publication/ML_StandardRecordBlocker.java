package genes.IdentityResolution.solutions.Publication;

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
import genes.IdentityResolution.model.Gene;

// solutions
import genes.IdentityResolution.solutions.Datasets;
import genes.IdentityResolution.solutions.Correspondences;
import genes.IdentityResolution.solutions.Evaluation;
import genes.IdentityResolution.solutions.GeneWekaMatchingRule;
import genes.IdentityResolution.solutions.GoldStandard;

// Blocker
import genes.IdentityResolution.Blocking.PublicationBlockingKeyByPmId;

// comporator
import genes.IdentityResolution.Comparators.PmIdComperator.SimilarityCosine.PmIdComperatorCosine;
import genes.IdentityResolution.Comparators.PmIdComperator.SimilarityJaccardOnNGrams.PmIdComperatorJaccardOnNGrams;
import genes.IdentityResolution.Comparators.PmIdComperator.SimilarityLevenshtein.PmIdComperatorLevenshtein;
import genes.IdentityResolution.Comparators.PmIdComperator.SimilaritySorensenDice.PmIdComperatorSorensenDice;
import genes.IdentityResolution.Comparators.PmIdComperator.SimilarityTokenizingJaccard.PmIdComperatorTokenizingJaccard;

public class ML_StandardRecordBlocker {

    public static void main( String[] args ) throws Exception
    {

        for (int fileNumber = 1; fileNumber <= 35; fileNumber++) {

            // loading datasets
            System.out.println("*\n*\tLoading datasets\n*");
            HashedDataSet<Gene, Attribute> gene2pubtatorcentral = Datasets.gene2pubtatorcentral(fileNumber);
            HashedDataSet<Gene, Attribute> PubMedDate = Datasets.PubMedDate();
    
            // goldstandard directory
            String comparisonDescription = "gene2pubtatorcentral_2_PubMedDate_" + fileNumber;
            String solution = "Publication";
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
                matchingRule.addComparator(new PmIdComperatorCosine());
                //matchingRule.addComparator(new PmIdComperatorJaccardOnNGrams());
                matchingRule.addComparator(new PmIdComperatorLevenshtein());
                matchingRule.addComparator(new PmIdComperatorSorensenDice());
                matchingRule.addComparator(new PmIdComperatorTokenizingJaccard());
    
                // learn the matching rule
                RuleLearner<Gene, Attribute> learner = new RuleLearner<>();
                learner.learnMatchingRule(gene2pubtatorcentral, PubMedDate, null, matchingRule, gsTrain);
    
                // create a blocker (blocking strategy)
                StandardRecordBlocker<Gene, Attribute> blocker = new StandardRecordBlocker<Gene, Attribute>(new PublicationBlockingKeyByPmId());
                blocker.setMeasureBlockSizes(true);
                blocker.collectBlockSizeData(outputDirectory + "/debugResultsBlocking.csv", 100);
    
                // initialize matching engine
                MatchingEngine<Gene, Attribute> engine = new MatchingEngine<>();
       
                // execute the matching
                Processable<Correspondence<Gene, Attribute>> correspondences = engine.runIdentityResolution(
                    gene2pubtatorcentral, PubMedDate, null, matchingRule, blocker);
                    
                // write the correspondences to the output file
                Correspondences.output(outputDirectory, correspondences);
            
                // evaluate your result
                Evaluation.run(correspondences, gsTest, outputDirectory, comparisonDescription, className);
    
            }

        }

    }

}