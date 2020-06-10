package genes.IdentityResolution.solutions.Heart.Heart_2_Heart_Ensembl_NCBI_Crosswalk;

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
import org.slf4j.Logger;

import java.io.File;

public class LR {
    private static final Logger logger = WinterLogManager.activateLogger("default");

    public static void main( String[] args ) throws Exception
    {
        System.out.println("*\n*\tLoading datasets\n*");

        HashedDataSet<Gene, Attribute> Heart = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Heart/Heart_dt.xml"), "/genes/gene", Heart);

        HashedDataSet<Gene, Attribute> Heart_Ensembl_NCBI_Crosswalk = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Heart/Heart_Ensembl_NCBI_Crosswalk_dt.xml"), "/genes/gene", Heart_Ensembl_NCBI_Crosswalk);

        // load the gold standard (test set)
        System.out.println("*\n*\tLoading gold standard\n*");
        MatchingGoldStandard gsTest = new MatchingGoldStandard();
        gsTest.loadFromCSVFile(new File("data/goldstandard/Heart/Heart_2_Heart_Ensembl_NCBI_Crosswalk.csv"));

        // create debug folder
        new File("data/output/Heart/Heart_2_Heart_Ensembl_NCBI_Crosswalk").mkdirs();

        // create a matching rule
        LinearCombinationMatchingRule<Gene, Attribute> matchingRule = new LinearCombinationMatchingRule<>(
                0.9);
        matchingRule.activateDebugReport("data/output/Heart/Heart_2_Heart_Ensembl_NCBI_Crosswalk/debugResultsMatchingRule.csv", 1000, gsTest);

        // add comparators
        matchingRule.addComparator(new GeneIdComparatorJaccard(), 1.0);

        // create a blocker (blocking strategy
        StandardRecordBlocker<Gene, Attribute> blocker = new StandardRecordBlocker<Gene, Attribute>(new GeneBlockingKeyByGeneIdLCGenerator());
        blocker.setMeasureBlockSizes(true);
        blocker.collectBlockSizeData("data/output/Heart/Heart_2_Heart_Ensembl_NCBI_Crosswalk/debugResultsBlocking.csv", 100);

        // Initialize Matching Engine
        MatchingEngine<Gene, Attribute> engine = new MatchingEngine<>();

        // Execute the matching
        System.out.println("*\n*\tRunning identity resolution\n*");
        Processable<Correspondence<Gene, Attribute>> correspondences = engine.runIdentityResolution(
                Heart, Heart_Ensembl_NCBI_Crosswalk, null, matchingRule,
                blocker);

        // write the correspondences to the output file
        new CSVCorrespondenceFormatter().writeCSV(new File("data/output/Heart/Heart_2_Heart_Ensembl_NCBI_Crosswalk/Heart_2_Heart_Ensembl_NCBI_Crosswalk_correspondences.csv"), correspondences);

        // evaluate your result
        System.out.println("*\n*\tEvaluating result\n*");
        MatchingEvaluator<Gene, Attribute> evaluator = new MatchingEvaluator<Gene, Attribute>();
        Performance perfTest = evaluator.evaluateMatching(correspondences,
                gsTest);

        // print the evaluation result
        System.out.println("Heart <-> Heart_Ensembl_NCBI_Crosswalk");
        System.out.println(String.format(
                "Precision: %.4f",perfTest.getPrecision()));
        System.out.println(String.format(
                "Recall: %.4f",	perfTest.getRecall()));
        System.out.println(String.format(
                "F1: %.4f",perfTest.getF1()));
    }
}
