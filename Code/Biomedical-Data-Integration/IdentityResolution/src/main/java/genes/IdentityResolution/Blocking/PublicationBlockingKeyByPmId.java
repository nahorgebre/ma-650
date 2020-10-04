package genes.IdentityResolution.Blocking;

import de.uni_mannheim.informatik.dws.winter.matching.blockers.generators.RecordBlockingKeyGenerator;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.Pair;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.processing.DataIterator;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;

import genes.IdentityResolution.model.Gene;

public class PublicationBlockingKeyByPmId extends
        RecordBlockingKeyGenerator<Gene, Attribute> {
    
    private static final long serialVersionUID = 1L;

    @Override
    public void generateBlockingKeys(Gene record, Processable<Correspondence<Attribute, Matchable>> correspondences,
                                    DataIterator<Pair<String, Gene>> resultCollector) {
        String pmId = record.getPublications().get(0).getPmId();
        String key = pmId.substring(0, 1);
        resultCollector.next(new Pair<>(key, record));
    }
}
