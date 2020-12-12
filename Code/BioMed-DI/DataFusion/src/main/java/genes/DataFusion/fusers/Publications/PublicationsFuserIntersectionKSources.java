package genes.DataFusion.fusers.Publications;

import genes.DataFusion.model.Publication.Publication;
import genes.DataFusion.model.Gene.Gene;

import de.uni_mannheim.informatik.dws.winter.datafusion.AttributeValueFuser;
import de.uni_mannheim.informatik.dws.winter.datafusion.conflictresolution.list.IntersectionKSources;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.FusedValue;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.RecordGroup;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;

import java.util.List;

public class PublicationsFuserIntersectionKSources extends
        AttributeValueFuser<List<Publication>, Gene, Attribute> {

    public PublicationsFuserIntersectionKSources(int k) {
        super(new IntersectionKSources<Publication, Gene, Attribute>(k));
    }

    @Override
    public boolean hasValue(Gene record, Correspondence<Attribute, Matchable> correspondence) {
        return record.hasValue(Gene.PUBLICATIONMENTIONS);
    }

    @Override
    public List<Publication> getValue(Gene record, Correspondence<Attribute, Matchable> correspondence) {
        return record.getPublicationMentions();
    }

    @Override
    public void fuse(RecordGroup<Gene, Attribute> group, Gene fusedRecord, Processable<Correspondence<Attribute, Matchable>> schemaCorrespondences, Attribute schemaElement) {
        FusedValue<List<Publication>, Gene, Attribute> fused = getFusedValue(group, schemaCorrespondences, schemaElement);
        fusedRecord.setPublicationMentions(fused.getValue());
        fusedRecord.setAttributeProvenance(Gene.PUBLICATIONMENTIONS, fused.getOriginalIds());
    }
    
}
