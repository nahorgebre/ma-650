package genes.IdentityResolution.Comparators;

import de.uni_mannheim.informatik.dws.winter.matching.rules.Comparator;
import de.uni_mannheim.informatik.dws.winter.matching.rules.ComparatorLogger;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.similarity.string.TokenizingJaccardSimilarity;
import genes.IdentityResolution.model.Gene;

public class NcbiIdComperatorJaccard implements Comparator<Gene, Attribute> {
    private static final long serialVersionUID = 1L;
    TokenizingJaccardSimilarity sim = new TokenizingJaccardSimilarity();

    private ComparatorLogger comparisonLog;

    @Override
    public double compare(
            Gene record1,
            Gene record2,
            Correspondence<Attribute, Matchable> schemaCorrespondences) {

        String s1 = record1.getNcbiId().toLowerCase();
        String s2 = record2.getNcbiId().toLowerCase();

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
        System.out.println("----------------------------");
        System.out.println(s1 + ", " +  s2 + ", " + similarity);
        System.out.println("----------------------------");
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
