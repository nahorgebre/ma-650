package publication.IR.Comparators;

import de.uni_mannheim.informatik.dws.winter.matching.rules.Comparator;
import de.uni_mannheim.informatik.dws.winter.matching.rules.ComparatorLogger;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.similarity.numeric.DeviationSimilarity;
import publication.IR.model.Publication;

public class PmidComparatorJaccard implements Comparator<Publication, Attribute> {

    private static final long serialVersionUID = 1L;
    //TokenizingJaccardSimilarity sim = new TokenizingJaccardSimilarity();
    DeviationSimilarity sim = new DeviationSimilarity();

    private ComparatorLogger comparisonLog;

    @Override
    public double compare(
            Publication record1,
            Publication record2,
            Correspondence<Attribute, Matchable> schemaCorrespondences) {
       
        double s1 = Double.parseDouble(record1.getPmid());
        double s2 = Double.parseDouble(record2.getPmid());

        // calculate similarity
        //double similarity = sim.calculate(s1, s2);
        //System.out.println(s1 + ", " + s2 + ", " + sim);
        double similarity;
        if(record1.getPmid().equals(record2.getPmid())) {
            similarity = 1;
        } else {
            similarity = 0;
        }


        // postprocessing
        //int postSimilarity = 0;
        //if (similarity <= 0.3) {
            //postSimilarity = 0;
        //}

        //postSimilarity *= similarity;

        if(this.comparisonLog != null){
            this.comparisonLog.setComparatorName(getClass().getName());

            this.comparisonLog.setRecord1Value(Double.toString(s1));
            this.comparisonLog.setRecord2Value(Double.toString(s2));

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
