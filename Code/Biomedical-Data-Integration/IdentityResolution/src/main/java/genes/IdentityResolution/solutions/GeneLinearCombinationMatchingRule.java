package genes.IdentityResolution.solutions;

import java.util.ArrayList;
import java.util.List;

// winter
import de.uni_mannheim.informatik.dws.winter.matching.rules.LinearCombinationMatchingRule;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import genes.IdentityResolution.model.Gene;

public class GeneLinearCombinationMatchingRule {

    public String modelType;
    public LinearCombinationMatchingRule<Gene, Attribute> matchingRule;

    public static List<GeneLinearCombinationMatchingRule> getMatchingRuleList_EnsemblId() {
        List<GeneLinearCombinationMatchingRule> matchingRuleList = new ArrayList<GeneLinearCombinationMatchingRule>();

        // Cosine

        // Jaccard

        // Levenshtein

        // SorensenDice


        return matchingRuleList;
    }

    public static LinearCombinationMatchingRule<Gene, Attribute> createMatchingRule() {
        // output directory
        String outputDirectory = "data/output/" + solution + "/" + comparisonDescription + "/" + modelType;
        new File(outputDirectory).mkdirs();

        // create a matching rule
        LinearCombinationMatchingRule<Gene, Attribute> matchingRule = new LinearCombinationMatchingRule<>(
                0.9);
        matchingRule.activateDebugReport(outputDirectory + "/debugResultsMatchingRule.csv", 1000, gsTest);

    }

    public static LinearCombinationMatchingRule<Gene, Attribute> EnsemblId_Cosine() {

    }

    public static LinearCombinationMatchingRule<Gene, Attribute> EnsemblId_Jaccard() {

    }

    public static LinearCombinationMatchingRule<Gene, Attribute> EnsemblId_Levenshtein() {

    }

    public static LinearCombinationMatchingRule<Gene, Attribute> EnsemblId_SorensenDice() {

    }
    
}
