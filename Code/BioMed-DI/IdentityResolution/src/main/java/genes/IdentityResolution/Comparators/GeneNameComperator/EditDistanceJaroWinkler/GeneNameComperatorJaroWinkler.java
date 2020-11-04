package genes.IdentityResolution.Comparators.GeneNameComperator.EditDistanceJaroWinkler;

import de.uni_mannheim.informatik.dws.winter.matching.rules.Comparator;
import de.uni_mannheim.informatik.dws.winter.matching.rules.ComparatorLogger;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import info.debatty.java.stringsimilarity.JaroWinkler;

import genes.IdentityResolution.Comparators.GeneNameComperator.Comparison;
import genes.IdentityResolution.model.Gene.Gene;
import genes.IdentityResolution.model.GeneName.GeneName;

import java.util.List;

public class GeneNameComperatorJaroWinkler implements Comparator<Gene, Attribute> {

    private static final long serialVersionUID = 1L;
    JaroWinkler sim = new JaroWinkler();

    private ComparatorLogger comparisonLog;

    @Override
    public double compare(
            Gene record1,
            Gene record2,
            Correspondence<Attribute, Matchable> schemaCorrespondences) {

        List<GeneName> record1GeneNames = record1.getGeneNames();

        List<GeneName> record2GeneNames = record2.getGeneNames();

        Comparison comparison = new Comparison();
        comparison.s1 = record1GeneNames.get(0).getName();
        comparison.s2 = record2GeneNames.get(0).getName(); 
        comparison.similarity = sim.similarity(comparison.s1, comparison.s2);

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