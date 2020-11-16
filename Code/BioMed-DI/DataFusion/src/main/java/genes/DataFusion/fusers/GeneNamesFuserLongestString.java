package genes.DataFusion.fusers;

import genes.DataFusion.model.Gene.Gene;

import de.uni_mannheim.informatik.dws.winter.datafusion.AttributeValueFuser;
import de.uni_mannheim.informatik.dws.winter.datafusion.conflictresolution.string.LongestString;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.FusedValue;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.RecordGroup;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;

public class GeneNamesFuserLongestString extends AttributeValueFuser<String, Gene, Attribute>  {

    public GeneNamesFuserLongestString() {
        super(new LongestString<Gene, Attribute>());
    }

    @Override
    public void fuse(RecordGroup<Gene, Attribute> group, Gene fusedRecord, Processable<Correspondence<Attribute, Matchable>> schemaCorrespondences, Attribute schemaElement) {

        // get the fused value
        FusedValue<String, Gene, Attribute> fused = getFusedValue(group, schemaCorrespondences, schemaElement);
  
        System.out.println("fused getValue - Gene Names: " + fused.getValue());

        // set the value for the fused record
        fusedRecord.setGeneNames(fused.getValue());

        // add provenance info
        fusedRecord.setAttributeProvenance(Gene.GENENAMES, fused.getOriginalIds());
    }

    @Override
    public boolean hasValue(Gene record, Correspondence<Attribute, Matchable> correspondence) {
        return record.hasValue(Gene.GENENAMES);
    }

    @Override
    public String getValue(Gene record, Correspondence<Attribute, Matchable> correspondence) {
        return record.getGeneNames();
    }

}
