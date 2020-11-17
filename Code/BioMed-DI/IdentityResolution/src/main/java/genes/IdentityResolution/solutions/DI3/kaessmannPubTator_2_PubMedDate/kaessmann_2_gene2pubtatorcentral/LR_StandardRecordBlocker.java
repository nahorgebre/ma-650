package genes.IdentityResolution.solutions.DI3.kaessmannPubTator_2_PubMedDate.kaessmann_2_gene2pubtatorcentral;

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
import genes.IdentityResolution.model.Gene.Gene;

// solutions
import genes.IdentityResolution.solutions.Correspondences;
import genes.IdentityResolution.solutions.Datasets;
import genes.IdentityResolution.solutions.Evaluation;
import genes.IdentityResolution.solutions.GeneLinearCombinationMatchingRule_GeneName_NCBI;
import genes.IdentityResolution.solutions.GoldStandard;

import genes.IdentityResolution.solutions.Variables;

public class LR_StandardRecordBlocker {
    private static final Logger logger = WinterLogManager.activateLogger("default");

    public static void main( String[] args ) throws Exception
    {

        for (int fileNumber = 1; fileNumber <= Variables.partitionNumbers; fileNumber++) {

            // loading datasets
            System.out.println("*\n*\tLoading datasets\n*");   
            HashedDataSet<Gene, Attribute> ds1 = Datasets.kaessmann();
            HashedDataSet<Gene, Attribute> ds2 = Datasets.gene2pubtatorcentral(fileNumber);
    
            // goldstandard directory
            String comparisonDescription = "kaessmann_2_gene2pubtatorcentral_" + fileNumber;
            String solution = "DI2";
            String goldstandardDirectory = "data/goldstandard/" + solution + "/" + comparisonDescription;
    
            // load the gold standard (test set)
            MatchingGoldStandard gsTest = GoldStandard.getTestDataset(goldstandardDirectory);
    
            String blockerName = "_StandardRecordBlocker";
            List<GeneLinearCombinationMatchingRule_GeneName_NCBI> matchingRuleList = GeneLinearCombinationMatchingRule_GeneName_NCBI.getMatchingRuleList(solution, comparisonDescription, blockerName, gsTest);
    
            for (GeneLinearCombinationMatchingRule_GeneName_NCBI geneLinearCombinationMatchingRule_NCBI_GeneName : matchingRuleList) {
    
                LinearCombinationMatchingRule<Gene, Attribute> matchingRule = geneLinearCombinationMatchingRule_NCBI_GeneName.matchingRule;
                String outputDirectory = geneLinearCombinationMatchingRule_NCBI_GeneName.outputDirectory;
    
                // create a blocker (blocking strategy)
                StandardRecordBlocker<Gene, Attribute> blocker = new StandardRecordBlocker<Gene, Attribute>(new GeneBlockingKeyByGeneName());
                blocker.setMeasureBlockSizes(true);
                blocker.collectBlockSizeData(outputDirectory + "/debugResultsBlocking.csv", 100);
    
                // initialize matching engine
                MatchingEngine<Gene, Attribute> engine = new MatchingEngine<>();
    
                // execute the matching
                System.out.println("*\n*\tRunning identity resolution\n*");
                Processable<Correspondence<Gene, Attribute>> correspondences = engine.runIdentityResolution(
                    ds1, ds2, null, matchingRule, blocker);
    
                // write the correspondences to the output file
                Correspondences.output(outputDirectory, correspondences);
    
                // evaluate your result
                Evaluation.run(correspondences, gsTest, outputDirectory, comparisonDescription, geneLinearCombinationMatchingRule_NCBI_GeneName.modelType);
            
            }

        }

    }

}