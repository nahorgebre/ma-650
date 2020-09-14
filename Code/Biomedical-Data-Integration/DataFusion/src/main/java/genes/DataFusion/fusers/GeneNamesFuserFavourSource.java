package genes.DataFusion.fusers;

import java.util.List;

import genes.DataFusion.model.GeneName;
import genes.DataFusion.model.Gene;

import de.uni_mannheim.informatik.dws.winter.datafusion.AttributeValueFuser;
import de.uni_mannheim.informatik.dws.winter.datafusion.conflictresolution.meta.FavourSources;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.FusedValue;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.RecordGroup;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;

public class GeneNamesFuserFavourSource extends AttributeValueFuser<List<GeneName>, Gene, Attribute> {

    public GeneNamesFuserFavourSource() {
        super(new FavourSources<List<GeneName>, Gene, Attribute>());
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