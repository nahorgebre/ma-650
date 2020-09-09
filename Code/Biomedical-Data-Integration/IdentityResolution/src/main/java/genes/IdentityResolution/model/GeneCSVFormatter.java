package genes.IdentityResolution.model;

import java.util.List;

import de.uni_mannheim.informatik.dws.winter.model.DataSet;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.model.io.CSVDataSetFormatter;

public class GeneCSVFormatter extends CSVDataSetFormatter<Gene, Attribute> {

    @Override
    public String[] getHeader(List<Attribute> orderedHeader) {
        return new String[] { "recordId", "ensemblId", "geneDescription", "disagreement", "probEqualOrthoAdj", "call", "ncbiId" };
    }

    @Override
    public String[] format(Gene record, DataSet<Gene, Attribute> dataset, List<Attribute> orderedHeader) {
        return new String[] {
                record.getIdentifier(),
                record.getEnsemblId(),
                record.getGeneDescription(),
                record.getDisagreement(),
                record.getProbEqualOrthoAdj(),
                record.getCall(),
                record.getNcbiId(),
        };
    }
}
