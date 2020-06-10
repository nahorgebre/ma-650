package genes.IdentityResolution.model;

import java.util.List;

import de.uni_mannheim.informatik.dws.winter.model.DataSet;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.model.io.CSVDataSetFormatter;

public class PublicationCSVFormatter extends CSVDataSetFormatter<Publication, Attribute> 
{
    @Override
    public String[] getHeader(List<Attribute> orderedHeader) 
    {
        return new String[] { "id", "pmid" };
    }

    @Override
    public String[] format(Publication record, DataSet<Publication, Attribute> dataset, List<Attribute> orderedHeader) 
    {
        return new String[] 
        {
                record.getIdentifier(),
                record.getPmid()
        };
    }    
}