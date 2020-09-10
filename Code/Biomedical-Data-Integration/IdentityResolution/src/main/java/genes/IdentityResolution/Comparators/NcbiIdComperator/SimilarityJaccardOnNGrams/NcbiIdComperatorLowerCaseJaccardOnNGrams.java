package genes.IdentityResolution.Comparators.NcbiIdComperator.SimilarityJaccardOnNGrams;

import de.uni_mannheim.informatik.dws.winter.matching.rules.Comparator;
import de.uni_mannheim.informatik.dws.winter.matching.rules.ComparatorLogger;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.similarity.string.JaccardOnNGramsSimilarity;

import genes.IdentityResolution.Comparators.GeneNameComperator.Comparison;
import genes.IdentityResolution.model.Gene;
import genes.IdentityResolution.model.GeneName;

import java.util.List;
import java.util.ArrayList;

public class NcbiIdComperatorLowerCaseJaccardOnNGrams implements Comparator<Gene, Attribute> {

    private static final long serialVersionUID = 1L;
    JaccardOnNGramsSimilarity sim = new JaccardOnNGramsSimilarity(3);

    private ComparatorLogger comparisonLog;

    @Override
    public double compare(
            Gene record1,
            Gene record2,
            Correspondence<Attribute, Matchable> schemaCorrespondences) {

        List<GeneName> record1GeneNames = record1.getGeneNames();
        List<GeneName> record2GeneNames = record2.getGeneNames();

        List<Comparison> comparisonList = new ArrayList<Comparison>();
        for (GeneName record1geneName : record1GeneNames) {
            for (GeneName record2geneName : record2GeneNames) {
                Comparison comparison = new Comparison();
                comparison.s1 = record1geneName.getName().toLowerCase();
                comparison.s2 = record2geneName.getName().toLowerCase(); 
                comparison.similarity = sim.calculate(comparison.s1, comparison.s2);
                comparisonList.add(comparison);
            }
        }

        Comparison bestResult = Comparison.getBestResult(comparisonList);

        double postSimilarity = 0;
        if (bestResult.similarity <= 0.3) {
            postSimilarity = 0;
        }

        if(this.comparisonLog != null){
            this.comparisonLog.setComparatorName(getClass().getName());
            this.comparisonLog.setRecord1Value(bestResult.s1);
            this.comparisonLog.setRecord2Value(bestResult.s2);
            this.comparisonLog.setSimilarity(Double.toString(bestResult.similarity));
            this.comparisonLog.setPostprocessedSimilarity(Double.toString(postSimilarity));
        }

        return bestResult.similarity;
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
