package genes.IdentityResolution.Comparators.NcbiIdComperator;

// winter
import de.uni_mannheim.informatik.dws.winter.matching.rules.Comparator;
import de.uni_mannheim.informatik.dws.winter.matching.rules.ComparatorLogger;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import info.debatty.java.stringsimilarity.Cosine;

import genes.IdentityResolution.model.Gene.Gene;

public class NcbiIdComperator implements Comparator<Gene, Attribute> {

    private static final long serialVersionUID = 1L;
    Cosine sim = new Cosine();

    private ComparatorLogger comparisonLog;

    @Override
    public double compare(Gene record1, Gene record2, Correspondence<Attribute, Matchable> schemaCorrespondences) {

        String s1 = "";
        String s2 = "";

        double similarity = 0;

        try {

            s1 = record1.getNcbiId();
            s2 = record2.getNcbiId();

            if (s1 != null && !s1.isEmpty()) {

                if (s2 != null && !s2.isEmpty()) {

                    if (s1.equals(s2)) similarity = 1;

                }

            }

        } catch (Exception e) {

            System.out.println(e);

        }

        if (this.comparisonLog != null) {

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
