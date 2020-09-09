package genes.IdentityResolution.Comparators.EnsemblIdComperator;

import de.uni_mannheim.informatik.dws.winter.matching.rules.Comparator;
import de.uni_mannheim.informatik.dws.winter.matching.rules.ComparatorLogger;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.similarity.string.LevenshteinEditDistance;
import de.uni_mannheim.informatik.dws.winter.similarity.string.TokenizingJaccardSimilarity;
import genes.IdentityResolution.model.Gene;

public class GeneIdComparatorLevenshteinEditDistance implements Comparator<Gene, Attribute> {

    private static final long serialVersionUID = 1L;
    LevenshteinEditDistance sim = new LevenshteinEditDistance();

    private ComparatorLogger comparisonLog;

    @Override
    public double compare(
            Gene record1,
            Gene record2,
            Correspondence<Attribute, Matchable> schemaCorrespondences) {

        String s1 = record1.getEnsemblId();
        String s2 = record2.getEnsemblId();

        // calculate similarity
        double similarity = sim.calculate(s1, s2);

        // postprocessing
        //int postSimilarity = 0;
        //if (similarity <= 0.3) {
            //postSimilarity = 0;
        //}

        //postSimilarity *= similarity;

        if(this.comparisonLog != null){
            this.comparisonLog.setComparatorName(getClass().getName());

            this.comparisonLog.setRecord1Value(s1);
            this.comparisonLog.setRecord2Value(s2);

            this.comparisonLog.setSimilarity(Double.toString(similarity));
            //this.comparisonLog.setPostprocessedSimilarity(Double.toString(postSimilarity));
            this.comparisonLog.setPostprocessedSimilarity(Double.toString(similarity));
        }
        //return postSimilarity;
        return similarity;
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
