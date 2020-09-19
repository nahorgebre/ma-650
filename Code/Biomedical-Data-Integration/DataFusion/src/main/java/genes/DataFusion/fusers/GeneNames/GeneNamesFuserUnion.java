package genes.DataFusion.fusers.GeneNames;

import java.util.List;

import genes.DataFusion.model.Gene.Gene;
import genes.DataFusion.model.GeneName.GeneName;

import de.uni_mannheim.informatik.dws.winter.datafusion.AttributeValueFuser;
import de.uni_mannheim.informatik.dws.winter.datafusion.conflictresolution.list.Union;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.FusedValue;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.RecordGroup;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;

public class GeneNamesFuserUnion extends AttributeValueFuser<List<GeneName>, Gene, Attribute> {

    public GeneNamesFuserUnion() {
        super(new Union<GeneName, Gene, Attribute>());
    }

    @Override
    public boolean hasValue(Gene record, Correspondence<Attribute, Matchable> correspondence) {
        return record.hasValue(Gene.GENENAMES);
    }

    @Override
    public List<GeneName> getValue(Gene record, Correspondence<Attribute, Matchable> correspondence) {
        return record.getGeneNames();
    }

    @Override
    public void fuse(RecordGroup<Gene, Attribute> group, Gene fusedRecord, Processable<Correspondence<Attribute, Matchable>> schemaCorrespondences, Attribute schemaElement) {
        FusedValue<List<GeneName>, Gene, Attribute> fused = getFusedValue(group, schemaCorrespondences, schemaElement);
        fusedRecord.setGeneNames(fused.getValue());
        fusedRecord.setAttributeProvenance(Gene.GENENAMES, fused.getOriginalIds());
    }

}