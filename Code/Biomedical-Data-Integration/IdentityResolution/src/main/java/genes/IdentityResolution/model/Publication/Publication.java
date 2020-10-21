package genes.IdentityResolution.model.Publication;

import de.uni_mannheim.informatik.dws.winter.model.AbstractRecord;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import java.io.Serializable;

public class Publication extends AbstractRecord<Attribute> implements Serializable {

    private static final long serialVersionUID = 1L;
    private String pmid;
    private String year;
    private String ressource;

    public Publication(String identifier, String provenance) {
        super(identifier, provenance);
    }

    // Getter
    public String getPmId() { return pmid; }
    public String getYear() { return year; }
    public String getRessource() { return ressource; }

    // Setter
    public void setPmId(String pmid) { this.pmid = pmid; }
    public void setYear(String year) { this.year = year; }
    public void setRessource(String ressource) { this.ressource = ressource; }

    @Override
    public int hashCode() {
        int result = 31 + ((pmid == null) ? 0 : pmid.hashCode());
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
        if (pmid == null) {
            if (other.pmid != null)
                return false;
        } else if (!pmid.equals(other.pmid))
            return false;
        return true;
    }

    public static final Attribute PMID = new Attribute("pmId");
    public static final Attribute YEAR = new Attribute("year");
    public static final Attribute RESSOURCE = new Attribute("ressource");

    @Override
    public boolean hasValue(Attribute attribute) {
        if(attribute==PMID)
            return PMID!=null;
        else if(attribute==YEAR)
            return YEAR!=null;
        else if(attribute==RESSOURCE)
            return RESSOURCE!=null;
        return false;
    }

}