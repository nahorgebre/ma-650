package genes.IdentityResolution.solutions;

import java.io.File;

import de.uni_mannheim.informatik.dws.winter.model.MatchingGoldStandard;

public class GoldStandard {
    public static MatchingGoldStandard getTestDataset(String goldstandardDirectory) throws Exception {
        System.out.println("*\n*\tLoading test gold standard\n*");
        MatchingGoldStandard gsTest = new MatchingGoldStandard();
        gsTest.loadFromCSVFile(new File(goldstandardDirectory + "/test.csv"));
        return gsTest;
    }

    public static MatchingGoldStandard getTrainDataset(String goldstandardDirectory) throws Exception {
        System.out.println("*\n*\tLoading train gold standard\n*");
        MatchingGoldStandard gsTrain = new MatchingGoldStandard();
        gsTrain.loadFromCSVFile(new File(goldstandardDirectory + "/train.csv"));
        return gsTrain;
    }
}
