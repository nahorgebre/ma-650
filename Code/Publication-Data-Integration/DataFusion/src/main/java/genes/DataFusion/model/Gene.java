package genes.DataFusion.model;

import de.uni_mannheim.informatik.dws.winter.model.AbstractRecord;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import java.io.Serializable;
import java.util.LinkedList;
import java.util.List;

public class Gene extends AbstractRecord<Attribute> implements Serializable {

    private static final long serialVersionUID = 1L;
    private String ncbiId;
    private List<GeneName> geneNames;

    public Gene(String identifier, String provenance) 
    {
        super(identifier, provenance);
        geneNames = new LinkedList<>();
    }

    // Getter
    public String getNcbiId() 
    { 
        return ncbiId; 
    }
    public List<GeneName> getGeneNames() 
    {
        return geneNames;
    }

    // Setter
    public void setNcbiId(String ncbiId) 
    { 
        this.ncbiId = ncbiId; 
    }
    public void setGeneNames(List<GeneName> geneNames) 
    {
        this.geneNames = geneNames;
    }

    @Override
    public int hashCode() {
        int result = 31 + ((ncbiId == null) ? 0 : ncbiId.hashCode());
        return result;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj)
            return true;
        if (obj == null)
            return false;
        if (getClass() != obj.getClass())
            return false;
        Gene other = (Gene) obj;
        if (ncbiId == null) {
            if (other.ncbiId != null)
                return false;
        } else if (!ncbiId.equals(other.ncbiId))
            return false;
        return true;
    }

    public static final Attribute NCBIID = new Attribute("ncbiId");

    @Override
    public boolean hasValue(Attribute attribute) {
        if(attribute==NCBIID)
            return ncbiId!=null;
        return false;
    }
}