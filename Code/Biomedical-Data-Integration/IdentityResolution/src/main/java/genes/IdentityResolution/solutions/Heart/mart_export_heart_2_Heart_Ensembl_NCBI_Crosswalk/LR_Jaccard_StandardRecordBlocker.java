package genes.IdentityResolution.solutions.Heart.mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk;

import de.uni_mannheim.informatik.dws.winter.matching.MatchingEngine;
import de.uni_mannheim.informatik.dws.winter.matching.MatchingEvaluator;
import de.uni_mannheim.informatik.dws.winter.matching.blockers.StandardRecordBlocker;
import de.uni_mannheim.informatik.dws.winter.matching.rules.LinearCombinationMatchingRule;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.HashedDataSet;
import de.uni_mannheim.informatik.dws.winter.model.MatchingGoldStandard;
import de.uni_mannheim.informatik.dws.winter.model.Performance;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.model.io.CSVCorrespondenceFormatter;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;
import de.uni_mannheim.informatik.dws.winter.utils.WinterLogManager;
import genes.IdentityResolution.Blocking.GeneBlockingKeyByGeneNameFCGenerator;
import genes.IdentityResolution.Comparators.GeneIdComparatorJaccard;
import genes.IdentityResolution.Comparators.GeneIdComparatorLevenshteinEditDistance;
import genes.IdentityResolution.Comparators.GeneNameComperatorCosine;
import genes.IdentityResolution.Comparators.GeneNameComperatorJaccard;
import genes.IdentityResolution.model.Gene;
import genes.IdentityResolution.model.GeneXMLReader;
import genes.IdentityResolution.solutions.Evaluation;
import genes.IdentityResolution.solutions.Correspondences;
import org.slf4j.Logger;

import java.io.File;

public class LR_Jaccard_StandardRecordBlocker 
{
    private static final Logger logger = WinterLogManager.activateLogger("default");
    public static String className = "LR_Jaccard_StandardRecordBlocker";

    public static void main( String[] args ) throws Exception
    {
        // create debug folder
        String comparisonDescription = "mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk";
        String outputDirectory = "data/output/Heart/" + comparisonDescription + "/" + className;
        new File(outputDirectory).mkdirs();
        String goldstandardDirectory = "data/goldstandard/Heart/" + comparisonDescription;

        System.out.println("*\n*\tLoading datasets\n*");

        HashedDataSet<Gene, Attribute> mart_export_heart = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Heart/mart_export_heart_dt.xml"), "/genes/gene", mart_export_heart);

        HashedDataSet<Gene, Attribute> Ensembl_NCBI_Crosswalk = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Heart/Heart_Ensembl_NCBI_Crosswalk_dt.xml"), "/genes/gene", Ensembl_NCBI_Crosswalk);

        // load the gold standard (test set)
        System.out.println("*\n*\tLoading gold standard\n*");
        MatchingGoldStandard gsTest = new MatchingGoldStandard();
        gsTest.loadFromCSVFile(new File(goldstandardDirectory + "/test.csv"));

        // create a matching rule
        LinearCombinationMatchingRule<Gene, Attribute> matchingRule = new LinearCombinationMatchingRule<>(
                0.9);
        matchingRule.activateDebugReport(outputDirectory + "/debugResultsMatchingRule.csv", 1000, gsTest);

        // add comparators
        matchingRule.addComparator(new GeneIdComparatorLevenshteinEditDistance(), 0.5);
        matchingRule.addComparator(new GeneNameComperatorCosine(), 0.5);

        // create a blocker (blocking strategy
        StandardRecordBlocker<Gene, Attribute> blocker = new StandardRecordBlocker<Gene, Attribute>(new GeneBlockingKeyByGeneNameFCGenerator());
        blocker.setMeasureBlockSizes(true);
        blocker.collectBlockSizeData(outputDirectory + "/debugResultsBlocking.csv", 100);

        // Initialize Matching Engine
        MatchingEngine<Gene, Attribute> engine = new MatchingEngine<>();

        // Execute the matching
        System.out.println("*\n*\tRunning identity resolution\n*");
        Processable<Correspondence<Gene, Attribute>> correspondences = engine.runIdentityResolution(
                mart_export_heart, Ensembl_NCBI_Crosswalk, null, matchingRule,
                blocker);

        // write the correspondences to the output file
        Correspondences.output(outputDirectory, className, correspondences);

        // evaluate your result
        Evaluation.run(correspondences, gsTest, outputDirectory, className, comparisonDescription);

    }
}
