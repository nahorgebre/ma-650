package genes.IdentityResolution.solutions.Testis.mart_export_testis_2_all_gene_disease_pmid_associations;

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

import genes.IdentityResolution.Blocking.GeneBlockingKeyByGeneName;
import genes.IdentityResolution.model.Gene;
import genes.IdentityResolution.model.GeneXMLReader;
import genes.IdentityResolution.solutions.Evaluation;
import genes.IdentityResolution.solutions.GoldStandard;
import genes.IdentityResolution.solutions.Correspondences;
import genes.IdentityResolution.solutions.Datasets;

import org.slf4j.Logger;

import java.io.File;
import java.io.PrintWriter;

// GeneNameComperator
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityLevenshtein.GeneNameComperatorLevenshtein;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityLevenshtein.GeneNameComperatorLowerCaseLevenshtein;

// EnsemblIdComperator
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilarityLevenshtein.EnsemblIdComperatorLevenshtein;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilarityLevenshtein.EnsemblIdComperatorLowerCaseLevenshtein;

public class LR_Levenshtein_StandardRecordBlocker 
{
    private static final Logger logger = WinterLogManager.activateLogger("default");
    public static String className = "LR_Jaccard_StandardRecordBlocker";

    public static void main( String[] args ) throws Exception
    {
        // create debug folder
        String comparisonDescription = "mart_export_testis_2_all_gene_disease_pmid_associations";
        String outputDirectory = "data/output/Testis/" + comparisonDescription + "/" + className;
        new File(outputDirectory).mkdirs();
        String goldstandardDirectory = "data/goldstandard/Testis/" + comparisonDescription;

        // loading datasets
        System.out.println("*\n*\tLoading datasets\n*");
        HashedDataSet<Gene, Attribute> all_gene_disease_pmid_associations = Datasets.all_gene_disease_pmid_associations();
        HashedDataSet<Gene, Attribute> mart_export_testis = Datasets.mart_export_testis();

        // load the gold standard (test set)
        MatchingGoldStandard gsTest = GoldStandard.getTestDataset(goldstandardDirectory);

        // create a matching rule
        LinearCombinationMatchingRule<Gene, Attribute> matchingRule = new LinearCombinationMatchingRule<>(
                0.9);
        matchingRule.activateDebugReport(outputDirectory + "/debugResultsMatchingRule.csv", 1000, gsTest);

        matchingRule.addComparator(new GeneNameComperatorLevenshtein(), 0.25);
        matchingRule.addComparator(new GeneNameComperatorLowerCaseLevenshtein(), 0.25);
        matchingRule.addComparator(new EnsemblIdComperatorLevenshtein(), 0.25);
        matchingRule.addComparator(new EnsemblIdComperatorLowerCaseLevenshtein(), 0.25);

        // create a blocker (blocking strategy)
        StandardRecordBlocker<Gene, Attribute> blocker = new StandardRecordBlocker<Gene, Attribute>(new GeneBlockingKeyByGeneName());
        //NoBlocker<Gene, Attribute> blocker = new NoBlocker<>();
        blocker.setMeasureBlockSizes(true);
        blocker.collectBlockSizeData(outputDirectory + "/debugResultsBlocking.csv", 100);

        // initialize matching engine
        MatchingEngine<Gene, Attribute> engine = new MatchingEngine<>();

        // execute the matching
        System.out.println("*\n*\tRunning identity resolution\n*");
        Processable<Correspondence<Gene, Attribute>> correspondences = engine.runIdentityResolution(
            mart_export_testis, all_gene_disease_pmid_associations, null, matchingRule,
                blocker);

        // write the correspondences to the output file
        Correspondences.output(outputDirectory, className, correspondences);

        // evaluate your result
        Evaluation.run(correspondences, gsTest, outputDirectory, className, comparisonDescription);

    }
}
