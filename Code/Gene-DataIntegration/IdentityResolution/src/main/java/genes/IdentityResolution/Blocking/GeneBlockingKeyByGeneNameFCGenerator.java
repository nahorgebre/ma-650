package genes.IdentityResolution.Blocking;

import de.uni_mannheim.informatik.dws.winter.matching.blockers.generators.RecordBlockingKeyGenerator;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.Pair;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.processing.DataIterator;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;
import genes.IdentityResolution.model.Gene;

public class GeneBlockingKeyByGeneNameFCGenerator extends
        RecordBlockingKeyGenerator<Gene, Attribute> {

    private static final long serialVersionUID = 1L;

    @Override
    public void generateBlockingKeys(Gene record, Processable<Correspondence<Attribute, Matchable>> correspondences,
                                     DataIterator<Pair<String, Gene>> resultCollector) {
        String geneName = record.getGeneName().toLowerCase();
        resultCollector.next(new Pair<>(geneName.substring(0,2), record));
    }
}
