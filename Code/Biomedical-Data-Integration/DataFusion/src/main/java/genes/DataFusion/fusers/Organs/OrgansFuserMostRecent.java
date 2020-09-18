package genes.DataFusion.fusers.Organs;

import genes.DataFusion.model.GeneName;
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

public class OrgansFuserMostRecent extends
        AttributeValueFuser<List<Organ>, Gene, Attribute> {

    public OrgansFuserMostRecent() {
        super(new MostRecent<List<Organ>, Gene, Attribute>());
    }

    @Override
    public boolean hasValue(Gene record, Correspondence<Attribute, Matchable> correspondence) {
        return record.hasValue(Gene.ORGANS);
    }

    @Override
    public List<Organ> getValue(Organ record, Correspondence<Attribute, Matchable> correspondence) {
        return record.getOrgans();
    }

    @Override
    public void fuse(RecordGroup<Gene, Attribute> group, Gene fusedRecord, Processable<Correspondence<Attribute, Matchable>> schemaCorrespondences, Attribute schemaElement) {
        FusedValue<List<Organ>, Gene, Attribute> fused = getFusedValue(group, schemaCorrespondences, schemaElement);
        fusedRecord.setOrgans(fused.getValue());
        fusedRecord.setAttributeProvenance(Gene.ORGANS, fused.getOriginalIds());
    }

}