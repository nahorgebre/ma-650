package genes.DataFusion.model;

import java.io.Serializable;

import de.uni_mannheim.informatik.dws.winter.model.AbstractRecord;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

public class GeneDescription extends AbstractRecord<Attribute> implements Serializable {

    private static final long serialVersionUID = 1L;
    private String description;

    public GeneDescription(String identifier, String provenance) {
        super(identifier, provenance);
    }

    // Getter
    public String getDescription() { return description; }

    // Setter
    public void setGeneDescription(String description) { this.description = description; }

    @Override
    public int hashCode() {
        int result = 31 + ((description == null) ? 0 : description.hashCode());
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
        GeneDescription other = (GeneDescription) obj;
        if (description == null) {
            if (other.description != null)
                return false;
        } else if (!description.equals(other.description))
            return false;
        return true;
    }

    public static final Attribute DESCRIPTION = new Attribute("description");

    @Override
    public boolean hasValue(Attribute attribute) {
        if(attribute==DESCRIPTION)
            return description!=null;
        return false;
    }

    @Override
    public String toString() {
        return String.format("[GeneDescription: %s /]",
            getDescription());
    }
    
}