package genes.IdentityResolution.Comparators.GeneNameComperator;

import java.util.List;

public class Comparison {

    public String s1 = null;
    public String s2 = null;
    public double similarity = 0;

    public static Comparison getBestResult(List<Comparison> comparisonList) {
        Comparison result = new Comparison();
        for (Comparison comparison : comparisonList) {
            if (result.similarity < comparison.similarity) {
                result.s1 = comparison.s1;
                result.s2 = comparison.s2;
                result.similarity = comparison.similarity;
            }
        }
        return result;
    }
    
}