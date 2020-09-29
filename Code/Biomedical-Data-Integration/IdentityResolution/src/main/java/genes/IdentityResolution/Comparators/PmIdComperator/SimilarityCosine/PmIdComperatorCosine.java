package genes.IdentityResolution.Comparators.PmIdComperator.SimilarityCosine;

import de.uni_mannheim.informatik.dws.winter.matching.rules.Comparator;
import de.uni_mannheim.informatik.dws.winter.matching.rules.ComparatorLogger;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import info.debatty.java.stringsimilarity.Cosine;

import genes.IdentityResolution.model.Publication;

public class PmIdComperatorCosine implements Comparator<Publication, Attribute> {

    private static final long serialVersionUID = 1L;
    Cosine sim = new Cosine();

    private ComparatorLogger comparisonLog;

    @Override
    public double compare(
            Publication record1,
            Publication record2,
            Correspondence<Attribute, Matchable> schemaCorrespondences) {

        String s1 = record1.getPmId();
        String s2 = record2.getPmId();

        // calculate similarity
        double similarity = sim.similarity(s1, s2);

        if(this.comparisonLog != null){
            this.comparisonLog.setComparatorName(getClass().getName());

            this.comparisonLog.setRecord1Value(s1);
            this.comparisonLog.setRecord2Value(s2);

            this.comparisonLog.setSimilarity(Double.toString(similarity));
            this.comparisonLog.setPostprocessedSimilarity(Double.toString(similarity));
        }

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