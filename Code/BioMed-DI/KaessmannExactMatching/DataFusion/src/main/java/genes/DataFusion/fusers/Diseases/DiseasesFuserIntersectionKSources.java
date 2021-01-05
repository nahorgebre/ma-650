package genes.DataFusion.fusers.Diseases;

import genes.DataFusion.model.Disease.Disease;
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

public class DiseasesFuserIntersectionKSources extends
        AttributeValueFuser<List<Disease>, Gene, Attribute> {

    public DiseasesFuserIntersectionKSources(int k) {
        super(new IntersectionKSources<Disease, Gene, Attribute>(k));
    }

    @Override
    public boolean hasValue(Gene record, Correspondence<Attribute, Matchable> correspondence) {
        return record.hasValue(Gene.DISEASEASSOCIATIONS);
    }

    @Override
    public List<Disease> getValue(Gene record, Correspondence<Attribute, Matchable> correspondence) {
        return record.getDiseaseAssociations();
    }

    @Override
    public void fuse(RecordGroup<Gene, Attribute> group, Gene fusedRecord, Processable<Correspondence<Attribute, Matchable>> schemaCorrespondences, Attribute schemaElement) {
        FusedValue<List<Disease>, Gene, Attribute> fused = getFusedValue(group, schemaCorrespondences, schemaElement);
        fusedRecord.setDiseaseAssociations(fused.getValue());
        fusedRecord.setAttributeProvenance(Gene.DISEASEASSOCIATIONS, fused.getOriginalIds());
    }

}