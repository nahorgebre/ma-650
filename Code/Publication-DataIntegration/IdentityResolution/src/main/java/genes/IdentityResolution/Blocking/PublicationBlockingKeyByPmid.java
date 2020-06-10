package genes.IdentityResolution.Blocking;

import de.uni_mannheim.informatik.dws.winter.matching.blockers.generators.RecordBlockingKeyGenerator;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.Pair;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.processing.DataIterator;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;
import genes.IdentityResolution.model.Publication;

public class PublicationBlockingKeyByPmid extends RecordBlockingKeyGenerator<Publication, Attribute>
{
    private static final long serialVersionUID = 1L;

    @Override
    public void generateBlockingKeys(Publication record, Processable<Correspondence<Attribute, Matchable>> correspondences, DataIterator<Pair<String, Publication>> resultCollector) 
    {
        String pmid = record.getPmid().toLowerCase();
        resultCollector.next(new Pair<>(pmid.substring(0,2), record));
    }
}