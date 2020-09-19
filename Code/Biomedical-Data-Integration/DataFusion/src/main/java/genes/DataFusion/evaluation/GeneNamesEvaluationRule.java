package genes.DataFusion.evaluation;

import java.util.HashSet;
import java.util.Set;

import genes.DataFusion.model.GeneName.GeneName;
import genes.DataFusion.model.Gene.Gene;

import de.uni_mannheim.informatik.dws.winter.datafusion.EvaluationRule;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

public class GeneNamesEvaluationRule extends EvaluationRule<Gene, Attribute> {

    @Override
    public boolean isEqual(Gene record1, Gene record2, Attribute schemaElement) {

        Set<String> geneNames1 = new HashSet<>();
        for (GeneName a : record1.getGeneNames()) {
            // note: evaluating using the disease's name only suffices for simple lists
            // in your project, you should have disease ids which you use here (and in the identity resolution)
            geneNames1.add(a.getName());
        }

        Set<String> geneNames2 = new HashSet<>();
        for (GeneName a : record2.getGeneNames()) {
            geneNames2.add(a.getName());
        }

        return geneNames1.containsAll(geneNames2) && geneNames2.containsAll(geneNames1);
    }

    @Override
    public boolean isEqual(Gene record1, Gene record2,
                           Correspondence<Attribute, Matchable> schemaCorrespondence) {
        return isEqual(record1, record2, (Attribute)null);
    }
    
}
