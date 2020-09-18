package genes.DataFusion.model.Organ;

import java.io.Serializable;

import de.uni_mannheim.informatik.dws.winter.model.AbstractRecord;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

public class Organ extends AbstractRecord<Attribute> implements Serializable 
{

    private static final long serialVersionUID = 1L;
    private String organName;
    private String disagreement;
    private String probEqualOrthoAdj;
    private String call;

    public Organ(String identifier, String provenance) {
        super(identifier, provenance);
    }

    // Getter
    public String getOrganName() { return organName; }
    public String getDisagreement() { return disagreement; }
    public String getProbEqualOrthoAdj() { return probEqualOrthoAdj; }
    public String getCall() { return call; }

    // Setter
    public void setOrganName(String organName) { this.organName = organName; }
    public void setDisagreement(String disagreement) { this.disagreement = disagreement; }
    public void setProbEqualOrthoAdj(String probEqualOrthoAdj) { this.probEqualOrthoAdj = probEqualOrthoAdj; }
    public void setCall(String call) { this.call = call; }

    @Override
    public int hashCode() {
        int result = 31 + ((organName == null) ? 0 : organName.hashCode());
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
        Organ other = (Organ) obj;
        if (organName == null) {
            if (other.organName != null)
                return false;
        } else if (!organName.equals(other.organName))
            return false;
        return true;
    }

    public static final Attribute ORGANNAME = new Attribute("organName");
    public static final Attribute DISAGREEMENT = new Attribute("disagreement");
    public static final Attribute PROBEQUALORTHOADJ = new Attribute("probEqualOrthoAdj");
    public static final Attribute CALL = new Attribute("call");
 
    @Override
    public boolean hasValue(Attribute attribute) {
        if(attribute==ORGANNAME)
            return organName!=null;
        else if(attribute==DISAGREEMENT)
            return disagreement!=null;
        else if(attribute==PROBEQUALORTHOADJ)
            return probEqualOrthoAdj!=null;
        else if(attribute==CALL)
            return call!=null;
        return false;
    }
}