package genes.IdentityResolution.model.Patent;

import de.uni_mannheim.informatik.dws.winter.model.AbstractRecord;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import java.io.Serializable;

public class Patent extends AbstractRecord<Attribute> implements Serializable {

    private static final long serialVersionUID = 1L;
    private String patentId;
    private String patentDate;
    private String patentClaimsCount;

    public Patent(String identifier, String provenance) {
        super(identifier, provenance);
    }

    // Getter
    public String getPatentId() { return patentId; }
    public String getPatentDate() { return patentDate; }
    public String getPatentClaimsCount() { return patentClaimsCount; }

    // Setter
    public void setPatentId(String patentId) { this.patentId = patentId; }
    public void setPatentDate(String patentDate) { this.patentDate = patentDate; }
    public void setPatentClaimsCount(String patentClaimsCount) { this.patentClaimsCount = patentClaimsCount; }

    @Override
    public int hashCode() {
        int result = 31 + ((patentId == null) ? 0 : patentId.hashCode());
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
        Patent other = (Patent) obj;
        if (patentId == null) {
            if (other.patentId != null)
                return false;
        } else if (!patentId.equals(other.patentId))
            return false;
        return true;
    }

    public static final Attribute PATENTID = new Attribute("patentId");
    public static final Attribute PATENTDATE = new Attribute("patentDate");
    public static final Attribute PATENTCLAIMSCOUNT = new Attribute("patentClaimsCount");

    @Override
    public boolean hasValue(Attribute attribute) {
        if(attribute==PATENTID)
            return PATENTID!=null;
        else if(attribute==PATENTDATE)
            return PATENTDATE!=null;
        else if(attribute==PATENTCLAIMSCOUNT)
            return PATENTCLAIMSCOUNT!=null;
        return false;
    }
    
}
