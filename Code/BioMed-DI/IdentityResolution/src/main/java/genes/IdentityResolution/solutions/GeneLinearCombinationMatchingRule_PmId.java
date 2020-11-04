package genes.IdentityResolution.solutions;

// java
import java.io.File;
import java.util.ArrayList;
import java.util.List;

// winter
import de.uni_mannheim.informatik.dws.winter.matching.rules.LinearCombinationMatchingRule;
import de.uni_mannheim.informatik.dws.winter.model.MatchingGoldStandard;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

// comparators
import genes.IdentityResolution.Comparators.PmIdComperator.SimilarityCosine.PmIdComperatorCosine;
import genes.IdentityResolution.Comparators.PmIdComperator.SimilarityJaccardOnNGrams.PmIdComperatorJaccardOnNGrams;
import genes.IdentityResolution.Comparators.PmIdComperator.SimilarityLevenshtein.PmIdComperatorLevenshtein;
import genes.IdentityResolution.Comparators.PmIdComperator.SimilaritySorensenDice.PmIdComperatorSorensenDice;
import genes.IdentityResolution.Comparators.PmIdComperator.SimilarityTokenizingJaccard.PmIdComperatorTokenizingJaccard;

// model
import genes.IdentityResolution.model.Gene.Gene;

public class GeneLinearCombinationMatchingRule_PmId {

    public static String modelType;
    public static String outputDirectory;
    public LinearCombinationMatchingRule<Gene, Attribute> matchingRule;

    public static List<GeneLinearCombinationMatchingRule_PmId> getMatchingRuleList(String solution, String comparisonDescription, String blockerName, MatchingGoldStandard gsTest) throws Exception {
        List<GeneLinearCombinationMatchingRule_PmId> matchingRuleList = new ArrayList<GeneLinearCombinationMatchingRule_PmId>();

        // Cosine
        GeneLinearCombinationMatchingRule_PmId cosine = new GeneLinearCombinationMatchingRule_PmId();
        cosine.modelType = "LR_Cosine" + blockerName;
        cosine.outputDirectory = "data/output/" + solution + "/" + comparisonDescription + "/" + cosine.modelType;
        cosine.matchingRule = EnsemblId_Cosine(cosine.outputDirectory, gsTest);
        matchingRuleList.add(cosine);

        // Jaccard
        GeneLinearCombinationMatchingRule_PmId jaccard = new GeneLinearCombinationMatchingRule_PmId();
        jaccard.modelType = "LR_Jaccard" + blockerName;
        jaccard.outputDirectory = "data/output/" + solution + "/" + comparisonDescription + "/" + cosine.modelType;
        jaccard.matchingRule = EnsemblId_Jaccard(jaccard.outputDirectory, gsTest);
        matchingRuleList.add(jaccard);

        // Levenshtein
        GeneLinearCombinationMatchingRule_PmId levenshtein = new GeneLinearCombinationMatchingRule_PmId();
        levenshtein.modelType = "LR_Levenshtein" + blockerName;
        levenshtein.outputDirectory = "data/output/" + solution + "/" + comparisonDescription + "/" + cosine.modelType;
        levenshtein.matchingRule = EnsemblId_Levenshtein(levenshtein.outputDirectory, gsTest);
        matchingRuleList.add(levenshtein);

        // SorensenDice
        GeneLinearCombinationMatchingRule_PmId sorensenDice = new GeneLinearCombinationMatchingRule_PmId();
        sorensenDice.modelType = "LR_SorensenDice" + blockerName;
        sorensenDice.outputDirectory = "data/output/" + solution + "/" + comparisonDescription + "/" + cosine.modelType;
        sorensenDice.matchingRule = EnsemblId_SorensenDice(sorensenDice.outputDirectory, gsTest);
        matchingRuleList.add(sorensenDice);

        return matchingRuleList;
    }

    public static LinearCombinationMatchingRule<Gene, Attribute> createMatchingRule(String outputDirectory, MatchingGoldStandard gsTest) {
        // output directory
        new File(outputDirectory).mkdirs();

        // create a matching rule
        LinearCombinationMatchingRule<Gene, Attribute> matchingRule = new LinearCombinationMatchingRule<>(
                0.7);
        matchingRule.activateDebugReport(outputDirectory + "/debugResultsMatchingRule.csv", 1000, gsTest);

        return matchingRule;
    }

    public static LinearCombinationMatchingRule<Gene, Attribute> EnsemblId_Cosine(String outputDirectory, MatchingGoldStandard gsTest) throws Exception {
        LinearCombinationMatchingRule<Gene, Attribute> matchingRule = createMatchingRule(outputDirectory, gsTest);

        // add comparators
        matchingRule.addComparator(new PmIdComperatorCosine(), 1.0);

        return matchingRule;
    }

    public static LinearCombinationMatchingRule<Gene, Attribute> EnsemblId_Jaccard(String outputDirectory, MatchingGoldStandard gsTest) throws Exception {
        LinearCombinationMatchingRule<Gene, Attribute> matchingRule = createMatchingRule(outputDirectory,gsTest);

        // add comparators
        //matchingRule.addComparator(new PmIdComperatorJaccardOnNGrams(), 0.5);
        matchingRule.addComparator(new PmIdComperatorTokenizingJaccard(), 1.0);

        return matchingRule;
    }

    public static LinearCombinationMatchingRule<Gene, Attribute> EnsemblId_Levenshtein(String outputDirectory, MatchingGoldStandard gsTest) throws Exception {
        LinearCombinationMatchingRule<Gene, Attribute> matchingRule = createMatchingRule(outputDirectory, gsTest);

        // add comparators
        matchingRule.addComparator(new PmIdComperatorLevenshtein(), 1.0);

        return matchingRule;
    }

    public static LinearCombinationMatchingRule<Gene, Attribute> EnsemblId_SorensenDice(String outputDirectory, MatchingGoldStandard gsTest) throws Exception {
        LinearCombinationMatchingRule<Gene, Attribute> matchingRule = createMatchingRule(outputDirectory, gsTest);

        // add comparators
        matchingRule.addComparator(new PmIdComperatorSorensenDice(), 1.0);

        return matchingRule;
    }
    
}
