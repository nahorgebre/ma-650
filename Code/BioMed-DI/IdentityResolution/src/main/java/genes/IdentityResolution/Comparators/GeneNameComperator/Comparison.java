package genes.IdentityResolution.Comparators.GeneNameComperator;

import java.util.List;
import java.util.ArrayList;

public class Comparison {

    public String s1 = null;
    public String s2 = null;
    public double similarity = 0;

    public static Comparison getBestComparisonResult(List<Comparison> comparisonList) {

        Comparison comparison = new Comparison();

        for (Comparison comparisonItem : comparisonList) {
            
            if (comparisonItem.similarity >= comparison.similarity) {
                
                comparison.s1 = comparisonItem.s1;

                comparison.s2 = comparisonItem.s2;

                comparison.similarity = comparisonItem.similarity;

            }
            
        }

        return comparison;

    }
  
}