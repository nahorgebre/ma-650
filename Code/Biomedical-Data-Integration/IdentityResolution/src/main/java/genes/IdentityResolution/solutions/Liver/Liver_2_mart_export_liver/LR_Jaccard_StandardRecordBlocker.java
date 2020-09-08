package genes.IdentityResolution.solutions.Liver.Liver_2_mart_export_liver;

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
import genes.IdentityResolution.Blocking.GeneBlockingKeyByGeneIdLCGenerator;
import genes.IdentityResolution.Comparators.GeneIdComparatorJaccard;
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
        System.out.println("*\n*\tLoading datasets\n*");

        HashedDataSet<Gene, Attribute> Liver = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Liver/Liver_dt.xml"), "/genes/gene", Liver);

        HashedDataSet<Gene, Attribute> mart_export_liver = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Liver/mart_export_liver_dt.xml"), "/genes/gene", mart_export_liver);

        // load the gold standard (test set)
        System.out.println("*\n*\tLoading gold standard\n*");
        MatchingGoldStandard gsTest = new MatchingGoldStandard();
        gsTest.loadFromCSVFile(new File("data/goldstandard/Liver/Liver_2_mart_export_liver.csv"));

        // create debug folder
        String comparisonDescription = "Liver_2_mart_export_liver";
        String outputDirectory = "data/output/Liver/" + comparisonDescription + "/" + className;
        new File(outputDirectory).mkdirs();

        // create a matching rule
        LinearCombinationMatchingRule<Gene, Attribute> matchingRule = new LinearCombinationMatchingRule<>(
                0.9);
        matchingRule.activateDebugReport(outputDirectory + "/debugResultsMatchingRule.csv", 1000, gsTest);

        // add comparators
        matchingRule.addComparator(new GeneIdComparatorJaccard(), 1.0);

        // create a blocker (blocking strategy
        StandardRecordBlocker<Gene, Attribute> blocker = new StandardRecordBlocker<Gene, Attribute>(new GeneBlockingKeyByGeneIdLCGenerator());
        blocker.setMeasureBlockSizes(true);
        blocker.collectBlockSizeData(outputDirectory + "/debugResultsBlocking.csv", 100);

        // Initialize Matching Engine
        MatchingEngine<Gene, Attribute> engine = new MatchingEngine<>();

        // Execute the matching
        System.out.println("*\n*\tRunning identity resolution\n*");
        Processable<Correspondence<Gene, Attribute>> correspondences = engine.runIdentityResolution(
                Liver, mart_export_liver, null, matchingRule, blocker);

        // write the correspondences to the output file
        Correspondences.output(outputDirectory, className, correspondences);

        // evaluate your result
        Evaluation.run(correspondences, gsTest, outputDirectory, className, comparisonDescription);

    }
}
