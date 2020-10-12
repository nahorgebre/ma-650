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
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilarityCosine.EnsemblIdComperatorCosine;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilarityCosine.EnsemblIdComperatorLowerCaseCosine;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilarityJaccardOnNGrams.EnsemblIdComperatorJaccardOnNGrams;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilarityJaccardOnNGrams.EnsemblIdComperatorLowerCaseJaccardOnNGrams;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilarityLevenshtein.EnsemblIdComperatorLevenshtein;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilarityLevenshtein.EnsemblIdComperatorLowerCaseLevenshtein;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilaritySorensenDice.EnsemblIdComperatorLowerCaseSorensenDice;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilaritySorensenDice.EnsemblIdComperatorSorensenDice;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilarityTokenizingJaccard.EnsemblIdComperatorLowerCaseTokenizingJaccard;
import genes.IdentityResolution.Comparators.EnsemblIdComperator.SimilarityTokenizingJaccard.EnsemblIdComperatorTokenizingJaccard;

// model
import genes.IdentityResolution.model.Gene;

public class GeneLinearCombinationMatchingRule_EnsemblId {

    public static String modelType;
    public static String outputDirectory;
    public LinearCombinationMatchingRule<Gene, Attribute> matchingRule;

    public static List<GeneLinearCombinationMatchingRule_EnsemblId> getMatchingRuleList(String solution, String comparisonDescription, String blockerName, MatchingGoldStandard gsTest) throws Exception {
        List<GeneLinearCombinationMatchingRule_EnsemblId> matchingRuleList = new ArrayList<GeneLinearCombinationMatchingRule_EnsemblId>();

        // Cosine
        GeneLinearCombinationMatchingRule_EnsemblId cosine = new GeneLinearCombinationMatchingRule_EnsemblId();
        cosine.modelType = "LR_Cosine" + blockerName;
        cosine.outputDirectory = "data/output/" + solution + "/" + comparisonDescription + "/" + cosine.modelType;
        cosine.matchingRule = EnsemblId_Cosine(cosine.outputDirectory, gsTest);
        //matchingRuleList.add(cosine);

        // Jaccard
        GeneLinearCombinationMatchingRule_EnsemblId jaccard = new GeneLinearCombinationMatchingRule_EnsemblId();
        jaccard.modelType = "LR_Jaccard" + blockerName;
        jaccard.outputDirectory = "data/output/" + solution + "/" + comparisonDescription + "/" + cosine.modelType;
        jaccard.matchingRule = EnsemblId_Jaccard(jaccard.outputDirectory, gsTest);
        //matchingRuleList.add(jaccard);

        // Levenshtein
        GeneLinearCombinationMatchingRule_EnsemblId levenshtein = new GeneLinearCombinationMatchingRule_EnsemblId();
        levenshtein.modelType = "LR_Levenshtein" + blockerName;
        levenshtein.outputDirectory = "data/output/" + solution + "/" + comparisonDescription + "/" + cosine.modelType;
        levenshtein.matchingRule = EnsemblId_Levenshtein(levenshtein.outputDirectory, gsTest);
        matchingRuleList.add(levenshtein);

        // SorensenDice
        GeneLinearCombinationMatchingRule_EnsemblId sorensenDice = new GeneLinearCombinationMatchingRule_EnsemblId();
        sorensenDice.modelType = "LR_SorensenDice" + blockerName;
        sorensenDice.outputDirectory = "data/output/" + solution + "/" + comparisonDescription + "/" + cosine.modelType;
        sorensenDice.matchingRule = EnsemblId_SorensenDice(sorensenDice.outputDirectory, gsTest);
        //matchingRuleList.add(sorensenDice);

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
        matchingRule.addComparator(new EnsemblIdComperatorCosine(), 0.5);
        matchingRule.addComparator(new EnsemblIdComperatorLowerCaseCosine(), 0.5);

        return matchingRule;
    }

    public static LinearCombinationMatchingRule<Gene, Attribute> EnsemblId_Jaccard(String outputDirectory, MatchingGoldStandard gsTest) throws Exception {
        LinearCombinationMatchingRule<Gene, Attribute> matchingRule = createMatchingRule(outputDirectory, gsTest);

        // add comparators
        //matchingRule.addComparator(new EnsemblIdComperatorJaccardOnNGrams(), 0.25);
        //matchingRule.addComparator(new EnsemblIdComperatorLowerCaseJaccardOnNGrams(), 0.25);
        matchingRule.addComparator(new EnsemblIdComperatorTokenizingJaccard(), 0.5);
        matchingRule.addComparator(new EnsemblIdComperatorLowerCaseTokenizingJaccard(), 0.5);

        return matchingRule;
    }

    public static LinearCombinationMatchingRule<Gene, Attribute> EnsemblId_Levenshtein(String outputDirectory, MatchingGoldStandard gsTest) throws Exception {
        LinearCombinationMatchingRule<Gene, Attribute> matchingRule = createMatchingRule(outputDirectory, gsTest);

        // add comparators
        matchingRule.addComparator(new EnsemblIdComperatorLevenshtein(), 0.5);
        matchingRule.addComparator(new EnsemblIdComperatorLowerCaseLevenshtein(), 0.5);

        return matchingRule;
    }

    public static LinearCombinationMatchingRule<Gene, Attribute> EnsemblId_SorensenDice(String outputDirectory, MatchingGoldStandard gsTest) throws Exception {
        LinearCombinationMatchingRule<Gene, Attribute> matchingRule = createMatchingRule(outputDirectory, gsTest);

        // add comparators
        matchingRule.addComparator(new EnsemblIdComperatorSorensenDice(), 0.5);
        matchingRule.addComparator(new EnsemblIdComperatorLowerCaseSorensenDice(), 0.5);

        return matchingRule;
    }
    
}
