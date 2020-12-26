package genes.IdentityResolution.solutions.DI2.experiments;

// java
import java.io.File;
import java.util.Date;

import org.slf4j.Logger;

// winter
import de.uni_mannheim.informatik.dws.winter.matching.MatchingEngine;
import de.uni_mannheim.informatik.dws.winter.matching.blockers.StandardRecordBlocker;
import de.uni_mannheim.informatik.dws.winter.matching.rules.LinearCombinationMatchingRule;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.HashedDataSet;
import de.uni_mannheim.informatik.dws.winter.model.MatchingGoldStandard;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;
import de.uni_mannheim.informatik.dws.winter.utils.WinterLogManager;

// comparators
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityCosine.GeneNameComperatorCosine;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityCosine.GeneNameComperatorLowerCaseCosine;

// model
import genes.IdentityResolution.model.Gene.Gene;

// blockig
import genes.IdentityResolution.Blocking.GeneBlockingKeyByEnsemblId;
import genes.IdentityResolution.Blocking.GeneBlockingKeyByGeneName;
// solutions
import genes.IdentityResolution.solutions.Correspondences;
import genes.IdentityResolution.solutions.DI2.DI2Datasets;
import genes.IdentityResolution.solutions.Evaluation;
import genes.IdentityResolution.solutions.GoldStandard;
import genes.IdentityResolution.solutions.WinterLogFile;
import genes.IdentityResolution.solutions.Blocker;

public class Cosine_StandardRecordBlocker 
{

	private static final Logger logger = WinterLogManager.activateLogger("traceFile");
	
    public static void main( String[] args ) throws Exception
    {

        WinterLogFile.deleteLog();

        double t = Double.parseDouble(args[0]);

		// loading data
        System.out.println("*\n*\tLoading datasets\n*");
        HashedDataSet<Gene, Attribute> ds1 = DI2Datasets.kaessmann();
        HashedDataSet<Gene, Attribute> ds2 = DI2Datasets.all_gene_disease_pmid_associations(1);

		// load the gold standard (test set)
        String comparisonDescription = "kaessmann_2_all_gene_disease_pmid_associations_1";
        String solution = "DI2";
        String goldstandardDirectory = "data/goldstandard/" + solution + "/" + comparisonDescription;
        String className = "Cosine_StandardRecordBlocker";

        // load the gold standard (test set)
        MatchingGoldStandard gsTest = GoldStandard.getTestDataset(goldstandardDirectory);

        // create output directory
        String outputDirectory = "data/output/" + solution + "/" + comparisonDescription + "/" + className;
        new File(outputDirectory).mkdirs();

        // start counting
        Date startDate = new Date();

		// create a matching rule
		LinearCombinationMatchingRule<Gene, Attribute> matchingRule = new LinearCombinationMatchingRule<>(t);
		matchingRule.activateDebugReport(outputDirectory + "/debugResultsMatchingRule.csv", 1000, gsTest);
		
        // add comparators
        matchingRule.addComparator(new GeneNameComperatorCosine(), 0.5);
        matchingRule.addComparator(new GeneNameComperatorLowerCaseCosine(), 0.5);

		// create a blocker (blocking strategy)
		StandardRecordBlocker<Gene, Attribute> blocker = new StandardRecordBlocker<Gene, Attribute>(new GeneBlockingKeyByGeneName());
        blocker.setMeasureBlockSizes(true);
        blocker.collectBlockSizeData(outputDirectory + "/debugResultsBlocking.csv", 100);
        
        // write blocker results to the output file
        Blocker.writeStandardRecordBlockerResults(blocker, outputDirectory);
		
		// initialize Matching Engine
		MatchingEngine<Gene, Attribute> engine = new MatchingEngine<>();

		// execute the matching
		System.out.println("*\n*\tRunning identity resolution\n*");
		Processable<Correspondence<Gene, Attribute>> correspondences = engine.runIdentityResolution(
				ds1, ds2, null, matchingRule,
                blocker);
                
        // end counting
        Date endDate = new Date();
        int numSeconds = (int)((endDate.getTime() - startDate.getTime()) / 1000);

        // write the correspondences to the output file
        Correspondences.output(outputDirectory, correspondences);
                
        // evaluate your result
        Evaluation.run(correspondences, gsTest, outputDirectory, comparisonDescription, className, numSeconds);

        // copy winter log
        WinterLogFile.copyLogFile(outputDirectory);

    }

}