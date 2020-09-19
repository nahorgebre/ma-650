package genes.DataFusion.evaluation;

import java.util.HashSet;
import java.util.Set;

import genes.DataFusion.model.Organ.Organ;
import genes.DataFusion.model.Gene.Gene;
import genes.DataFusion.model.GeneDescription.GeneDescription;
import de.uni_mannheim.informatik.dws.winter.datafusion.EvaluationRule;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

public class GeneDescriptionsEvaluationRule extends EvaluationRule<Gene, Attribute> {

    @Override
    public boolean isEqual(Gene record1, Gene record2, Attribute schemaElement) {

        Set<String> geneDescriptions1 = new HashSet<>();
        for (GeneDescription a : record1.getGeneDescriptions()) {
            geneDescriptions1.add(a.getDescription());
        }

        Set<String> geneDescriptions2 = new HashSet<>();
        for (GeneDescription a : record2.getGeneDescriptions()) {
            geneDescriptions2.add(a.getDescription());
        }

        return geneDescriptions1.containsAll(geneDescriptions2) && geneDescriptions2.containsAll(geneDescriptions1);
    }

    @Override
    public boolean isEqual(Gene record1, Gene record2,
                           Correspondence<Attribute, Matchable> schemaCorrespondence) {
        return isEqual(record1, record2, (Attribute)null);
    }

}
