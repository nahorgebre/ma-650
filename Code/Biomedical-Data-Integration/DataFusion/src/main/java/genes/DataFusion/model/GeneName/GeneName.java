package genes.DataFusion.model.GeneName;

import java.io.Serializable;

import de.uni_mannheim.informatik.dws.winter.model.AbstractRecord;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

public class GeneName extends AbstractRecord<Attribute> implements Serializable {

    private static final long serialVersionUID = 1L;
    private String name;

    public GeneName(String identifier, String provenance) {
        super(identifier, provenance);
    }

    // Getter
    public String getName() { return name; }

    // Setter
    public void setName(String name) { this.name = name; }

    @Override
    public int hashCode() {
        int result = 31 + ((name == null) ? 0 : name.hashCode());
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
        if (name == null) {
            if (other.name != null)
                return false;
        } else if (!name.equals(other.name))
            return false;
        return true;
    }

    public static final Attribute NAME = new Attribute("name");

    @Override
    public boolean hasValue(Attribute attribute) {
        if(attribute==NAME)
            return name!=null;
        return false;
    }

    @Override
    public String toString() {
        return String.format("[GeneName: %s /]",
            getName());
    }
    
}