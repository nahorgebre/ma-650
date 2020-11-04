package genes.DataFusion.fusers.GeneDescriptions;

import java.util.List;

import genes.DataFusion.model.GeneDescription.GeneDescription;
import genes.DataFusion.model.Gene.Gene;

import de.uni_mannheim.informatik.dws.winter.datafusion.AttributeValueFuser;
import de.uni_mannheim.informatik.dws.winter.datafusion.conflictresolution.list.Intersection;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.FusedValue;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.RecordGroup;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;

public class GeneDescriptionsFuserIntersection extends AttributeValueFuser<List<GeneDescription>, Gene, Attribute> {

    public GeneDescriptionsFuserIntersection() {
        super(new Intersection<GeneDescription, Gene, Attribute>());
    }

    @Override
    public boolean hasValue(Gene record, Correspondence<Attribute, Matchable> correspondence) {
        return record.hasValue(Gene.GENEDESCRIPTIONS);
    }

    @Override
    public List<GeneDescription> getValue(Gene record, Correspondence<Attribute, Matchable> correspondence) {
        return record.getGeneDescriptions();
    }

    @Override
    public void fuse(RecordGroup<Gene, Attribute> group, Gene fusedRecord, Processable<Correspondence<Attribute, Matchable>> schemaCorrespondences, Attribute schemaElement) {
        FusedValue<List<GeneDescription>, Gene, Attribute> fused = getFusedValue(group, schemaCorrespondences, schemaElement);
        fusedRecord.setGeneDescriptions(fused.getValue());
        fusedRecord.setAttributeProvenance(Gene.GENEDESCRIPTIONS, fused.getOriginalIds());
    }

}