package genes.IdentityResolution.Comparators.NcbiIdComperator.SimilarityLevenshtein;

import de.uni_mannheim.informatik.dws.winter.matching.rules.Comparator;
import de.uni_mannheim.informatik.dws.winter.matching.rules.ComparatorLogger;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.similarity.string.LevenshteinSimilarity;

import genes.IdentityResolution.model.Gene.Gene;

public class NcbiIdComperatorLevenshtein implements Comparator<Gene, Attribute> {
   
    private static final long serialVersionUID = 1L;
    LevenshteinSimilarity sim = new LevenshteinSimilarity();

    private ComparatorLogger comparisonLog;

    @Override
    public double compare(
            Gene record1,
            Gene record2,
            Correspondence<Attribute, Matchable> schemaCorrespondences) {

        String s1 = record1.getNcbiId();
        String s2 = record2.getNcbiId();

        if (!s1.equals("") & !s2.equals("")) {

            // calculate similarity
            double similarity = sim.calculate(s1, s2);

            if (this.comparisonLog != null) {
                this.comparisonLog.setComparatorName(getClass().getName());

                this.comparisonLog.setRecord1Value(s1);
                this.comparisonLog.setRecord2Value(s2);

                this.comparisonLog.setSimilarity(Double.toString(similarity));
                this.comparisonLog.setPostprocessedSimilarity(Double.toString(similarity));
            }

            return similarity;

        } else {

            return 0;

        }

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
