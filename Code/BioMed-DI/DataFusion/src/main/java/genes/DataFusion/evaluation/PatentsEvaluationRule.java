package genes.DataFusion.evaluation;

import java.util.HashSet;
import java.util.Set;

import genes.DataFusion.model.Patent.Patent;
import genes.DataFusion.model.Gene.Gene;

import de.uni_mannheim.informatik.dws.winter.datafusion.EvaluationRule;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

public class PatentsEvaluationRule extends EvaluationRule<Gene, Attribute> {

    @Override
    public boolean isEqual(Gene record1, Gene record2, Attribute schemaElement) {

        Set<String> patents1 = new HashSet<>();
        for (Patent a : record1.getPatentMentions()) {
            // note: evaluating using the disease's name only suffices for simple lists
            // in your project, you should have disease ids which you use here (and in the identity resolution)
            patents1.add(a.getPatentId());
        }

        Set<String> patents2 = new HashSet<>();
        for (Patent a : record2.getPatentMentions()) {
            patents2.add(a.getPatentId());
        }

        return patents1.containsAll(patents2) && patents2.containsAll(patents1);
    }

    @Override
    public boolean isEqual(Gene record1, Gene record2,
                           Correspondence<Attribute, Matchable> schemaCorrespondence) {
        return isEqual(record1, record2, (Attribute)null);
    }

}
