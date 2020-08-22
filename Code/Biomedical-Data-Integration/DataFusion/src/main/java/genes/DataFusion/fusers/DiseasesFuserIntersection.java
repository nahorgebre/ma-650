package genes.DataFusion.fusers;

import java.util.List;

import genes.DataFusion.model.Disease;
import genes.DataFusion.model.Gene;
import de.uni_mannheim.informatik.dws.winter.datafusion.AttributeValueFuser;
import de.uni_mannheim.informatik.dws.winter.datafusion.conflictresolution.list.Intersection;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.FusedValue;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.RecordGroup;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;

public class DiseasesFuserIntersection extends AttributeValueFuser<List<Disease>, Gene, Attribute> {

    public DiseasesFuserIntersection() {
        super(new Intersection<Disease, Gene, Attribute>());
    }

    @Override
    public boolean hasValue(Gene record, Correspondence<Attribute, Matchable> correspondence) {
        return record.hasValue(Gene.DISEASES);
    }

    @Override
    public List<Disease> getValue(Gene record, Correspondence<Attribute, Matchable> correspondence) {
        return record.getDiseases();
    }

    @Override
    public void fuse(RecordGroup<Gene, Attribute> group, Gene fusedRecord, Processable<Correspondence<Attribute, Matchable>> schemaCorrespondences, Attribute schemaElement) {
        FusedValue<List<Disease>, Gene, Attribute> fused = getFusedValue(group, schemaCorrespondences, schemaElement);
        fusedRecord.setDiseases(fused.getValue());
        fusedRecord.setAttributeProvenance(Gene.DISEASES, fused.getOriginalIds());
    }

}
