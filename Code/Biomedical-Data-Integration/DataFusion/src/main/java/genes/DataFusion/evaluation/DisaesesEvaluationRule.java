package genes.DataFusion.evaluation;

import java.util.HashSet;
import java.util.Set;

import genes.DataFusion.model.Disease;
import genes.DataFusion.model.Gene;
import de.uni_mannheim.informatik.dws.winter.datafusion.EvaluationRule;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

public class DisaesesEvaluationRule extends EvaluationRule<Gene, Attribute> {

    @Override
    public boolean isEqual(Gene record1, Gene record2, Attribute schemaElement) {
        Set<String> diseases1 = new HashSet<>();

        for (Disease a : record1.getDiseaseAssociations()) {
            // note: evaluating using the disease's name only suffices for simple lists
            // in your project, you should have disease ids which you use here (and in the identity resolution)
            diseases1.add(a.getDiseaseId());
        }

        Set<String> diseases2 = new HashSet<>();
        for (Disease a : record2.getDiseaseAssociations()) {
            diseases2.add(a.getDiseaseId());
        }

        return diseases1.containsAll(diseases2) && diseases2.containsAll(diseases1);
    }

    @Override
    public boolean isEqual(Gene record1, Gene record2,
                           Correspondence<Attribute, Matchable> schemaCorrespondence) {
        return isEqual(record1, record2, (Attribute)null);
    }

}
