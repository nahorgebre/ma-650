package genes.DataFusion.model;

import de.uni_mannheim.informatik.dws.winter.model.DataSet;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.model.io.CSVDataSetFormatter;

import java.util.List;

public class GeneCSVFormatter extends CSVDataSetFormatter<Gene, Attribute> {

    @Override
    public String[] getHeader(List<Attribute> orderedHeader) {
        return new String[] { "recordId", "ensemblId", "ncbiId" };
    }

    @Override
    public String[] format(Gene record, DataSet<Gene, Attribute> dataset, List<Attribute> orderedHeader) {
        return new String[] {
                record.getIdentifier(),
                record.getEnsemblId(),
                record.getNcbiId()
        };
    }
}
