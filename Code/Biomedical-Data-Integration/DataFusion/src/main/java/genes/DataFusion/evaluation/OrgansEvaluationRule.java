package genes.DataFusion.evaluation;

import java.util.HashSet;
import java.util.Set;

import genes.DataFusion.model.Organ;
import genes.DataFusion.model.Gene;

import de.uni_mannheim.informatik.dws.winter.datafusion.EvaluationRule;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

public class OrgansEvaluationRule extends EvaluationRule<Gene, Attribute> {

    @Override
    public boolean isEqual(Gene record1, Gene record2, Attribute schemaElement) {

        Set<String> organs1 = new HashSet<>();
        for (Organ a : record1.getOrgans()) {
            organs1.add(a.getOrganName());
        }

        Set<String> organs2 = new HashSet<>();
        for (Organ a : record2.getOrgans()) {
            organs2.add(a.getOrganName());
        }

        return organs1.containsAll(organs2) && organs2.containsAll(organs1);
    }

    @Override
    public boolean isEqual(Gene record1, Gene record2,
                           Correspondence<Attribute, Matchable> schemaCorrespondence) {
        return isEqual(record1, record2, (Attribute)null);
    }

}
