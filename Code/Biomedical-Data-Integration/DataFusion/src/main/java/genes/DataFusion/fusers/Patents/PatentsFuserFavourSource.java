package genes.DataFusion.fusers.Patents;

import java.util.List;

import genes.DataFusion.model.Patent.Patent;
import genes.DataFusion.model.Gene.Gene;

import de.uni_mannheim.informatik.dws.winter.datafusion.AttributeValueFuser;
import de.uni_mannheim.informatik.dws.winter.datafusion.conflictresolution.meta.FavourSources;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.FusedValue;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.RecordGroup;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;

public class PatentsFuserFavourSource extends AttributeValueFuser<List<Patent>, Gene, Attribute>{
    
    public PatentsFuserFavourSource() {
        super(new FavourSources<List<Patent>, Gene, Attribute>());
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
