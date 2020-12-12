package genes.DataFusion.model.Publication;

import java.io.Serializable;

import de.uni_mannheim.informatik.dws.winter.model.AbstractRecord;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

public class Publication extends AbstractRecord<Attribute> implements Serializable {

    private static final long serialVersionUID = 1L;
    private String pmId;
    private String year;
    private String ressource;

    public Publication(String identifier, String provenance) {
        super(identifier, provenance);
    }

    // Getter
    public String getPmId() { return pmId; }
    public String getYear() { return year; }
    public String getRessource() { return ressource; }

    // Setter
    public void setPmId(String pmId) { this.pmId = pmId; }
    public void setYear(String year) { this.year = year; }
    public void setRessource(String ressource) { this.ressource = ressource; }

    @Override
    public int hashCode() {
        int result = 31 + ((pmId == null) ? 0 : pmId.hashCode());
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
        Publication other = (Publication) obj;
        if (pmId == null) {
            if (other.pmId != null)
                return false;
        } else if (!pmId.equals(other.pmId))
            return false;
        return true;
    }

    public static final Attribute PMID = new Attribute("pmId");
    public static final Attribute YEAR = new Attribute("year");
    public static final Attribute RESSOURCE = new Attribute("ressource");

    @Override
    public boolean hasValue(Attribute attribute) {
        if(attribute==PMID)
            return pmId!=null;
        else if(attribute==YEAR)
            return YEAR!=null;
        else if(attribute==RESSOURCE)
            return ressource!=null;
        return false;
    }

    @Override
    public String toString() {
        return String.format("[Publication: %s / %s /]",
            getPmId(), getRessource());
    }

}