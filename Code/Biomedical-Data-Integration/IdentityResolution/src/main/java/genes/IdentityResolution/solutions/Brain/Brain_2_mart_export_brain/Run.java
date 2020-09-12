package genes.IdentityResolution.solutions.Brain.Brain_2_mart_export_brain;

import java.io.File;

import org.apache.jena.atlas.data.DataBag;
import org.apache.jena.tdb.setup.DatasetBuilder;

import de.uni_mannheim.informatik.dws.winter.model.HashedDataSet;
import de.uni_mannheim.informatik.dws.winter.model.MatchingGoldStandard;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import genes.IdentityResolution.model.Gene;
import genes.IdentityResolution.solutions.Datasets;
import genes.IdentityResolution.solutions.GoldStandard;

public class Run {

    public static void main(String[] args) throws Exception {
        LR_Cosine_StandardRecordBlocker.main(args);
        ML_SimpleLogistic_StandardRecordBlocker.main(args);
        LR_Levenshtein_StandardRecordBlocker.main(args);
        LR_Cosine_StandardRecordBlocker.main(args);
    }

    public static void alternative() throws Exception {
        String className = "x";
        // create output folder
        String comparisonDescription = "Brain_2_mart_export_brain";
        String outputDirectory = "data/output/Brain/" + comparisonDescription + "/" + className;
        new File(outputDirectory).mkdirs();
        String goldstandardDirectory = "data/goldstandard/Brain/" + comparisonDescription;

        // loading datasetse
        System.out.println("*\n*\tLoading datasets\n*");
        HashedDataSet<Gene, Attribute> Brain = Datasets.Brain();
        HashedDataSet<Gene, Attribute> mart_export_brain = Datasets.mart_export_brain();

        // load the gold standard (test set)
        MatchingGoldStandard gsTest = GoldStandard.getTestDataset(goldstandardDirectory);
        MatchingGoldStandard gsTrain = GoldStandard.getTrainDataset(goldstandardDirectory);
    }
    
}