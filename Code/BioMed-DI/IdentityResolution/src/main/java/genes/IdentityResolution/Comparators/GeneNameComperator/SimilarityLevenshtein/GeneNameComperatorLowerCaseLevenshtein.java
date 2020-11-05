package genes.IdentityResolution.Comparators.GeneNameComperator.SimilarityLevenshtein;

import de.uni_mannheim.informatik.dws.winter.matching.rules.Comparator;
import de.uni_mannheim.informatik.dws.winter.matching.rules.ComparatorLogger;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.similarity.string.LevenshteinSimilarity;

import genes.IdentityResolution.Comparators.GeneNameComperator.Comparison;
import genes.IdentityResolution.model.Gene.Gene;
import genes.IdentityResolution.model.GeneName.GeneName;

import java.util.List;
import java.util.ArrayList;

public class GeneNameComperatorLowerCaseLevenshtein implements Comparator<Gene, Attribute> {
    
    private static final long serialVersionUID = 1L;
    LevenshteinSimilarity sim = new LevenshteinSimilarity();

    private ComparatorLogger comparisonLog;

    @Override
    public double compare(
            Gene record1,
            Gene record2,
            Correspondence<Attribute, Matchable> schemaCorrespondences) {

        String record1GeneNames = record1.getGeneNames();
        String record2GeneNames = record2.getGeneNames();

        String[] record1GeneNameArray = record1GeneNames.split("|");
        String[] record2GeneNameArray = record2GeneNames.split("|");

        List<Comparison> comparisonList = new List<Comparison>();

        for (String record1GeneName : record1GeneNameArray) {
            
            for (String record2GeneName : record2GeneNameArray) {

                Comparison comparison = new Comparison();

                comparison.s1 = record1GeneName;

                comparison.s2 = record2GeneName;

                comparison.similarity = sim.calculate(comparison.s1, comparison.s2);

                comparisonList.add(comparison);
                
            }
        }

        Comparison comparison = getBestComparisonResult(comparisonList);

        double postSimilarity = 0;
        if (comparison.similarity <= 0.3) {
            postSimilarity = 0;
        }

        if(this.comparisonLog != null){
            this.comparisonLog.setComparatorName(getClass().getName());
            this.comparisonLog.setRecord1Value(comparison.s1);
            this.comparisonLog.setRecord2Value(comparison.s2);
            this.comparisonLog.setSimilarity(Double.toString(comparison.similarity));
            this.comparisonLog.setPostprocessedSimilarity(Double.toString(comparison.similarity));
        }

        return comparison.similarity;
        
    }

    @Override
    public ComparatorLogger getComparisonLog() {
        return this.comparisonLog;
    }

    @Override
    public void setComparisonLog(ComparatorLogger comparatorLog) {
        this.comparisonLog = comparatorLog;
    }

}
