package genes.DataFusion.model;

import de.uni_mannheim.informatik.dws.winter.model.AbstractRecord;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import java.io.Serializable;

public class GeneName extends AbstractRecord<Attribute> implements Serializable 
{
    private static final long serialVersionUID = 1L;
    private String geneName;

    public GeneName(String identifier, String provenance) 
    {
        super(identifier, provenance);
    }

    // Getter
    public String getGeneName() 
    { 
        return geneName; 
    }

    // Setter
    public void setGeneName(String geneName) 
    { 
        this.geneName = geneName; 
    }

    @Override
    public int hashCode() {
        int result = 31 + ((geneName == null) ? 0 : geneName.hashCode());
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
        GeneName other = (GeneName) obj;
        if (geneName == null) {
            if (other.geneName != null)
                return false;
        } else if (!geneName.equals(other.geneName))
            return false;
        return true;
    }

    public static final Attribute GENENAME = new Attribute("geneName");

    @Override
    public boolean hasValue(Attribute attribute) {
        if(attribute==GENENAME)
            return geneName!=null;
        return false;
    }

}