package genes.IdentityResolution.solutions.Brain.mart_export_brain_2_all_gene_disease_pmid_associations;

import de.uni_mannheim.informatik.dws.winter.matching.MatchingEngine;
import de.uni_mannheim.informatik.dws.winter.matching.MatchingEvaluator;
import de.uni_mannheim.informatik.dws.winter.matching.blockers.NoBlocker;
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
import genes.IdentityResolution.Comparators.GeneNameComperatorJaccard;
import genes.IdentityResolution.Comparators.NcbiIdComperatorJaccard;
import genes.IdentityResolution.model.Gene;
import genes.IdentityResolution.model.GeneXMLReader;
import org.slf4j.Logger;

import java.io.File;

public class LR {
    private static final Logger logger = WinterLogManager.activateLogger("default");

    public static void main( String[] args ) throws Exception
    {
        for(int i = 1; i<=25; i++) {
            System.out.println("*\n*\tLoading datasets\n*");

            HashedDataSet<Gene, Attribute> all_gene_disease_pmid_associations = new HashedDataSet<>();
            new GeneXMLReader().loadFromXML(new File("data/input/Gene-Disease-Associations/all_gene_disease_pmid_associations_dt_"+ i +".xml"), "/genes/gene", all_gene_disease_pmid_associations);

            HashedDataSet<Gene, Attribute> mart_export_brain = new HashedDataSet<>();
            new GeneXMLReader().loadFromXML(new File("data/input/Brain/mart_export_brain_dt.xml"), "/genes/gene", mart_export_brain);

            // load the gold standard (test set)
            System.out.println("*\n*\tLoading gold standard\n*");
            MatchingGoldStandard gsTest = new MatchingGoldStandard();
            gsTest.loadFromCSVFile(new File("data/goldstandard/Brain/mart_export_brain_2_all_gene_disease_pmid_associations.csv"));

            // create debug folder
            new File("data/output/Brain/mart_export_brain_2_all_gene_disease_pmid_associations").mkdirs();

            // create a matching rule
            LinearCombinationMatchingRule<Gene, Attribute> matchingRule = new LinearCombinationMatchingRule<>(
                    0.9);
            matchingRule.activateDebugReport("data/output/Brain/mart_export_brain_2_all_gene_disease_pmid_associations/debugResultsMatchingRule_LR_" + i + ".csv", 1000, gsTest);

            // add comparators
            matchingRule.addComparator(new GeneNameComperatorJaccard(), 0.5);
            matchingRule.addComparator(new NcbiIdComperatorJaccard(), 0.5);

            // create a blocker (blocking strategy)
            StandardRecordBlocker<Gene, Attribute> blocker = new StandardRecordBlocker<Gene, Attribute>(new GeneBlockingKeyByGeneNameFCGenerator());
            //NoBlocker<Gene, Attribute> blocker = new NoBlocker<>();
            blocker.setMeasureBlockSizes(true);
            blocker.collectBlockSizeData("data/output/Brain/mart_export_brain_2_all_gene_disease_pmid_associations/debugResultsBlocking_LR_" + i + ".csv", 100);

            // Initialize Matching Engine
            MatchingEngine<Gene, Attribute> engine = new MatchingEngine<>();

            // Execute the matching
            System.out.println("*\n*\tRunning identity resolution\n*");
            Processable<Correspondence<Gene, Attribute>> correspondences = engine.runIdentityResolution(
                    mart_export_brain, all_gene_disease_pmid_associations, null, matchingRule,
                    blocker);

            // write the correspondences to the output file               LR_gene_disease_pmid_associations_2_Ensemble_NCBI_Crosswalk
            new CSVCorrespondenceFormatter().writeCSV(new File("data/output/Brain/mart_export_brain_2_all_gene_disease_pmid_associations_correspondences_" + i + ".csv"), correspondences);

            // evaluate your result
            System.out.println("*\n*\tEvaluating result\n*");
            MatchingEvaluator<Gene, Attribute> evaluator = new MatchingEvaluator<Gene, Attribute>();
            Performance perfTest = evaluator.evaluateMatching(correspondences,
                    gsTest);

            // print the evaluation result
            System.out.println("mart_export_brain <-> all_gene_disease_pmid_associations");
            System.out.println(String.format(
                    "Precision: %.4f",perfTest.getPrecision()));
            System.out.println(String.format(
                    "Recall: %.4f",	perfTest.getRecall()));
            System.out.println(String.format(
                    "F1: %.4f",perfTest.getF1()));
        }

    }
}
