package genes.DataFusion.fusers;

import genes.DataFusion.model.Gene;
import de.uni_mannheim.informatik.dws.winter.datafusion.AttributeValueFuser;
import de.uni_mannheim.informatik.dws.winter.datafusion.conflictresolution.string.LongestString;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.FusedValue;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.RecordGroup;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;

public class NcbiIdFuserLongestString extends AttributeValueFuser<String, Gene, Attribute>  {

    public NcbiIdFuserLongestString() {
        super(new LongestString<Gene, Attribute>());
    }

    @Override
    public void fuse(RecordGroup<Gene, Attribute> group, Gene fusedRecord, Processable<Correspondence<Attribute, Matchable>> schemaCorrespondences, Attribute schemaElement) {

        // get the fused value
        FusedValue<String, Gene, Attribute> fused = getFusedValue(group, schemaCorrespondences, schemaElement);

        // set the value for the fused record
        fusedRecord.setNcbiId(fused.getValue());

        // add provenance info
        fusedRecord.setAttributeProvenance(Gene.NCBIID, fused.getOriginalIds());
    }

    @Override
    public boolean hasValue(Gene record, Correspondence<Attribute, Matchable> correspondence) {
        return record.hasValue(Gene.NCBIID);
    }

    @Override
    public String getValue(Gene record, Correspondence<Attribute, Matchable> correspondence) {
        return record.getNcbiId();
    }

}