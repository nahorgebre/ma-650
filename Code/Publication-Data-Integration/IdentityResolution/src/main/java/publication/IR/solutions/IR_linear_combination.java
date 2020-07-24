package publication.IR.solutions;

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
import publication.IR.Blocking.PublicationBlockingKeyByPmid;
import publication.IR.Comparators.PmidComparatorJaccard;
import publication.IR.model.Publication;
import publication.IR.model.PublicationXMLReader;
import org.slf4j.Logger;

import java.io.File;

public class IR_linear_combination 
{
    private static final Logger logger = WinterLogManager.activateLogger("default"); 

    public static void main( String[] args ) throws Exception
    {
        // int[] arrYears = {1986, 1988, 1990, 1992, 1994, 1996, 1998, 2000, 2002, 2004, 2006, 2008, 2010, 2015, 2016};
        int year = 1986;
        for (int i = 1; i <= 25; i++) {
            // Load the datasets
            System.out.println("*\n*\tLoading datasets\n*");
            HashedDataSet<Publication, Attribute> RePORTER_PUBLNK_C_dt = new HashedDataSet<>();
            new PublicationXMLReader().loadFromXML(new File("data/input/PubProj/RePORTER_PUBLNK_C_" + year + "_dt.xml"), "/publications/publication", RePORTER_PUBLNK_C_dt);
            HashedDataSet<Publication, Attribute> gene2pubtatorcentral_dt = new HashedDataSet<>();
            new PublicationXMLReader().loadFromXML(new File("data/input/PubGene/gene2pubtatorcentral_" + i + "_dt.xml"), "/publications/publication", gene2pubtatorcentral_dt);
            
            // Load the gold standard (test set)
            System.out.println("*\n*\tLoading gold standard\n*");
            MatchingGoldStandard gsTest = new MatchingGoldStandard();
            gsTest.loadFromCSVFile(new File("data/goldstandard/gene2pubtatorcentral_2_RePORTER_PUBLNK_C_" + year + ".csv"));
            
            // Create debug folder
            new File("data/output").mkdirs();
            
            // Create a matching rule
            LinearCombinationMatchingRule<Publication, Attribute> matchingRule = new LinearCombinationMatchingRule<>(0.8);
            matchingRule.activateDebugReport("data/output/debugResultsMatchingRule_"+ i + "_" + year + ".csv", 1000, gsTest);
            
            // Add comparators
            matchingRule.addComparator(new PmidComparatorJaccard(), 1.0);
            
            // Create a blocker (blocking strategy
            StandardRecordBlocker<Publication, Attribute> blocker = new StandardRecordBlocker<Publication, Attribute>(new PublicationBlockingKeyByPmid());
            blocker.setMeasureBlockSizes(true);
            blocker.collectBlockSizeData("data/output/debugResultsBlocking_"+ i + "_" + year + ".csv", 100);
            
            // Initialize Matching Engine
            MatchingEngine<Publication, Attribute> engine = new MatchingEngine<>();
            
            // Execute the matching
            System.out.println("*\n*\tRunning identity resolution\n*");
            Processable<Correspondence<Publication, Attribute>> correspondences = engine.runIdentityResolution(
                RePORTER_PUBLNK_C_dt, gene2pubtatorcentral_dt, null, matchingRule,
                blocker);
            
            // Write the correspondences to the output file
            new CSVCorrespondenceFormatter().writeCSV(new File("data/output/gene2pubtatorcentral_"+ i + "_2_RePORTER_PUBLNK_C_" + year + "_correspondences.csv"), correspondences);
            
            // Evaluate your result
            System.out.println("*\n*\tEvaluating result\n*");
            MatchingEvaluator<Publication, Attribute> evaluator = new MatchingEvaluator<Publication, Attribute>();
            Performance perfTest = evaluator.evaluateMatching(correspondences,
                    gsTest);
            
            // Print the evaluation result
            System.out.println("gene2pubtatorcentral_" + i + " <-> RePORTER_PUBLNK_C_" + year);
            System.out.println(String.format(
                    "Precision: %.4f",perfTest.getPrecision()));
            System.out.println(String.format(
                    "Recall: %.4f",	perfTest.getRecall()));
            System.out.println(String.format(
                    "F1: %.4f",perfTest.getF1()));
        }
    }
}