package genes.IdentityResolution.solutions.Testis.Testis_2_mart_export_testis;

import org.slf4j.Logger;

import de.uni_mannheim.informatik.dws.winter.model.HashedDataSet;
import de.uni_mannheim.informatik.dws.winter.model.MatchingGoldStandard;
import de.uni_mannheim.informatik.dws.winter.utils.WinterLogManager;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import genes.IdentityResolution.model.Gene;
import genes.IdentityResolution.solutions.Datasets;
import genes.IdentityResolution.solutions.GoldStandard;

public class LR_StandardRecordBlocker {
    private static final Logger logger = WinterLogManager.activateLogger("default");

    public static void main( String[] args ) throws Exception
    {
        // loading datasets
        System.out.println("*\n*\tLoading datasets\n*");
        HashedDataSet<Gene, Attribute> Testis = Datasets.Testis();
        HashedDataSet<Gene, Attribute> mart_export_testis = Datasets.mart_export_testis();

        // goldstandard directory
        String comparisonDescription = "Testis_2_mart_export_testis";
        String solution = "Testis";
        String goldstandardDirectory = "data/goldstandard/" + solution + "/" + comparisonDescription;

        // load the gold standard (test set)
        MatchingGoldStandard gsTest = GoldStandard.getTestDataset(goldstandardDirectory);






    }

}
