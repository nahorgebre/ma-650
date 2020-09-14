package genes.DataFusion.fusers.Patents;

import genes.DataFusion.model.Patent;
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

public class PatentsFuserMostRecent extends
        AttributeValueFuser<List<Patent>, Gene, Attribute> {

    public PatentsFuserMostRecent() {
        super(new MostRecent<List<Patent>, Gene, Attribute>());
    }

    @Override
    public boolean hasValue(Gene record, Correspondence<Attribute, Matchable> correspondence) {
        return record.hasValue(Gene.PATENTMENTIONS);
    }

    @Override
    public List<Patent> getValue(Gene record, Correspondence<Attribute, Matchable> correspondence) {
        return record.getPatentMentions();
    }

    @Override
    public void fuse(RecordGroup<Gene, Attribute> group, Gene fusedRecord, Processable<Correspondence<Attribute, Matchable>> schemaCorrespondences, Attribute schemaElement) {
        FusedValue<List<Patent>, Gene, Attribute> fused = getFusedValue(group, schemaCorrespondences, schemaElement);
        fusedRecord.setPatentMentions(fused.getValue());
        fusedRecord.setAttributeProvenance(Gene.PATENTMENTIONS, fused.getOriginalIds());
    }
    
}
