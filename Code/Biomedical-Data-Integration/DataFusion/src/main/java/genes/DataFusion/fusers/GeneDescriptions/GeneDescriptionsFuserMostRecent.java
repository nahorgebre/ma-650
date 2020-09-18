package genes.DataFusion.fusers.GeneDescriptions;

import genes.DataFusion.model.GeneDescription;
import genes.DataFusion.model.Gene;

import de.uni_mannheim.informatik.dws.winter.datafusion.AttributeValueFuser;
import de.uni_mannheim.informatik.dws.winter.datafusion.conflictresolution.meta.MostRecent;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.FusedValue;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.RecordGroup;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;

import java.util.List;

public class GeneDescriptionsFuserMostRecent extends
        AttributeValueFuser<List<GeneDescription>, Gene, Attribute> {

    public GeneDescriptionsFuserMostRecent() {
        super(new MostRecent<List<GeneDescription>, Gene, Attribute>());
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