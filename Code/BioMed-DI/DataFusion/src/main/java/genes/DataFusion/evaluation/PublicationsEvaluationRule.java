package genes.DataFusion.evaluation;

import java.util.HashSet;
import java.util.Set;

import genes.DataFusion.model.Publication.Publication;
import genes.DataFusion.model.Gene.Gene;

import de.uni_mannheim.informatik.dws.winter.datafusion.EvaluationRule;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

public class PublicationsEvaluationRule extends EvaluationRule<Gene, Attribute> {

    @Override
    public boolean isEqual(Gene record1, Gene record2, Attribute schemaElement) {

        Set<String> publications1 = new HashSet<>();
        for (Publication a : record1.getPublicationMentions()) {
            // note: evaluating using the disease's name only suffices for simple lists
            // in your project, you should have disease ids which you use here (and in the identity resolution)
            publications1.add(a.getPmId());
        }

        Set<String> publications2 = new HashSet<>();
        for (Publication a : record2.getPublicationMentions()) {
            publications2.add(a.getPmId());
        }

        return publications1.containsAll(publications2) && publications2.containsAll(publications1);
    }

    @Override
    public boolean isEqual(Gene record1, Gene record2,
                           Correspondence<Attribute, Matchable> schemaCorrespondence) {
        return isEqual(record1, record2, (Attribute)null);
    }

}
