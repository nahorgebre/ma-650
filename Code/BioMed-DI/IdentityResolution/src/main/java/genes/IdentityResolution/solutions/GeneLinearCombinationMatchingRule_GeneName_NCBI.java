package genes.IdentityResolution.solutions;

// java
import java.io.File;
import java.util.ArrayList;
import java.util.List;

// winter
import de.uni_mannheim.informatik.dws.winter.matching.rules.LinearCombinationMatchingRule;
import de.uni_mannheim.informatik.dws.winter.model.MatchingGoldStandard;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

// GeneNameComperator
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityCosine.GeneNameComperatorCosine;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityCosine.GeneNameComperatorLowerCaseCosine;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityJaccardOnNGrams.GeneNameComperatorJaccardOnNGrams;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityJaccardOnNGrams.GeneNameComperatorLowerCaseJaccardOnNGrams;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityLevenshtein.GeneNameComperatorLevenshtein;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityLevenshtein.GeneNameComperatorLowerCaseLevenshtein;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilaritySorensenDice.GeneNameComperatorLowerCaseSorensenDice;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilaritySorensenDice.GeneNameComperatorSorensenDice;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityTokenizingJaccard.GeneNameComperatorLowerCaseTokenizingJaccard;
import genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityTokenizingJaccard.GeneNameComperatorTokenizingJaccard;

// NcbiIdComperator
import genes.IdentityResolution.Comparators.NcbiIdComperator.SimilarityCosine.NcbiIdComperatorCosine;
import genes.IdentityResolution.Comparators.NcbiIdComperator.SimilarityJaccardOnNGrams.NcbiIdComperatorJaccardOnNGrams;
import genes.IdentityResolution.Comparators.NcbiIdComperator.SimilarityLevenshtein.NcbiIdComperatorLevenshtein;
import genes.IdentityResolution.Comparators.NcbiIdComperator.SimilaritySorensenDice.NcbiIdComperatorSorensenDice;
import genes.IdentityResolution.Comparators.NcbiIdComperator.SimilarityTokenizingJaccard.NcbiIdComperatorTokenizingJaccard;

// model
import genes.IdentityResolution.model.Gene.Gene;

public class GeneLinearCombinationMatchingRule_GeneName_NCBI {

    public static String modelType;
    public static String outputDirectory;
    public LinearCombinationMatchingRule<Gene, Attribute> matchingRule;

    public static List<GeneLinearCombinationMatchingRule_GeneName_NCBI> getMatchingRuleList(String solution, String comparisonDescription, String blockerName, MatchingGoldStandard gsTest) throws Exception {
        List<GeneLinearCombinationMatchingRule_GeneName_NCBI> matchingRuleList = new ArrayList<GeneLinearCombinationMatchingRule_GeneName_NCBI>();

        // Cosine
        GeneLinearCombinationMatchingRule_GeneName_NCBI cosine = new GeneLinearCombinationMatchingRule_GeneName_NCBI();
        cosine.modelType = "LR_Cosine" + blockerName;
        cosine.outputDirectory = "data/output/" + solution + "/" + comparisonDescription + "/" + cosine.modelType;
        cosine.matchingRule = EnsemblId_Cosine(cosine.outputDirectory, gsTest);
        matchingRuleList.add(cosine);

        // Jaccard
        GeneLinearCombinationMatchingRule_GeneName_NCBI jaccard = new GeneLinearCombinationMatchingRule_GeneName_NCBI();
        jaccard.modelType = "LR_Jaccard" + blockerName;
        jaccard.outputDirectory = "data/output/" + solution + "/" + comparisonDescription + "/" + cosine.modelType;
        jaccard.matchingRule = EnsemblId_Jaccard(jaccard.outputDirectory, gsTest);
        matchingRuleList.add(jaccard);

        // Levenshtein
        GeneLinearCombinationMatchingRule_GeneName_NCBI levenshtein = new GeneLinearCombinationMatchingRule_GeneName_NCBI();
        levenshtein.modelType = "LR_Levenshtein" + blockerName;
        levenshtein.outputDirectory = "data/output/" + solution + "/" + comparisonDescription + "/" + cosine.modelType;
        levenshtein.matchingRule = EnsemblId_Levenshtein(levenshtein.outputDirectory, gsTest);
        matchingRuleList.add(levenshtein);

        // SorensenDice
        GeneLinearCombinationMatchingRule_GeneName_NCBI sorensenDice = new GeneLinearCombinationMatchingRule_GeneName_NCBI();
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
        matchingRule.addComparator(new GeneNameComperatorCosine(), 0.4);
        matchingRule.addComparator(new GeneNameComperatorLowerCaseCosine(), 0.2);
        matchingRule.addComparator(new NcbiIdComperatorCosine(), 0.4);

        return matchingRule;
    }

    public static LinearCombinationMatchingRule<Gene, Attribute> EnsemblId_Jaccard(String outputDirectory, MatchingGoldStandard gsTest) throws Exception {
        LinearCombinationMatchingRule<Gene, Attribute> matchingRule = createMatchingRule(outputDirectory,gsTest);

        // add comparators
        //matchingRule.addComparator(new GeneNameComperatorJaccardOnNGrams(), 0.16);
        //matchingRule.addComparator(new GeneNameComperatorLowerCaseJaccardOnNGrams(), 0.16);
        matchingRule.addComparator(new GeneNameComperatorTokenizingJaccard(), 0.4);
        matchingRule.addComparator(new GeneNameComperatorLowerCaseTokenizingJaccard(), 0.3);
        //matchingRule.addComparator(new NcbiIdComperatorJaccardOnNGrams(), 0.2);
        matchingRule.addComparator(new NcbiIdComperatorTokenizingJaccard(), 0.3);

        return matchingRule;
    }

    public static LinearCombinationMatchingRule<Gene, Attribute> EnsemblId_Levenshtein(String outputDirectory, MatchingGoldStandard gsTest) throws Exception {
        LinearCombinationMatchingRule<Gene, Attribute> matchingRule = createMatchingRule(outputDirectory, gsTest);

        // add comparators
        matchingRule.addComparator(new GeneNameComperatorLevenshtein(), 0.4);
        matchingRule.addComparator(new GeneNameComperatorLowerCaseLevenshtein(), 0.2);
        matchingRule.addComparator(new NcbiIdComperatorLevenshtein(), 0.4);

        return matchingRule;
    }

    public static LinearCombinationMatchingRule<Gene, Attribute> EnsemblId_SorensenDice(String outputDirectory, MatchingGoldStandard gsTest) throws Exception {
        LinearCombinationMatchingRule<Gene, Attribute> matchingRule = createMatchingRule(outputDirectory, gsTest);

        // add comparators
        matchingRule.addComparator(new GeneNameComperatorSorensenDice(), 0.4);
        matchingRule.addComparator(new GeneNameComperatorLowerCaseSorensenDice(), 0.2);
        matchingRule.addComparator(new NcbiIdComperatorSorensenDice(), 0.4);

        return matchingRule;
    }
    
}
