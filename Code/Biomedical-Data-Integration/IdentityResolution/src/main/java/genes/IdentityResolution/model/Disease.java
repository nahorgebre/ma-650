package genes.IdentityResolution.model;

import de.uni_mannheim.informatik.dws.winter.model.AbstractRecord;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import java.io.Serializable;

public class Disease extends AbstractRecord<Attribute> implements Serializable {

    private static final long serialVersionUID = 1L;
    private String diseaseId;
    private String diseaseName;
    private String diseaseType;
    private String diseaseClass;
    private String diseaseSemanticType;
    private String score;
    private String ei;
    private String yearInitial;
    private String yearFinal;
    private String pmid;
    private String source;

    public Disease(String identifier, String provenance) {
        super(identifier, provenance);
    }

    // Getter
    public String getDiseaseId() { return diseaseId; }
    public String getDiseaseName() { return diseaseName; }
    public String getDiseaseType() { return diseaseType; }
    public String getDiseaseClass() { return diseaseClass; }
    public String getDiseaseSemanticType() { return diseaseSemanticType; }
    public String getScore() { return score; }
    public String getEi() { return ei; }
    public String getYearInitial() { return  yearInitial; }
    public String getYearFinal() { return yearFinal; }
    public String getPmid() { return pmid; }
    public String getSource() { return source; }

    // Setter
    public void setDiseaseId(String diseaseId) { this.diseaseId = diseaseId; }
    public void setDiseaseName(String diseaseName) { this.diseaseName = diseaseName; }
    public void setDiseaseType(String diseaseType) { this.diseaseType = diseaseType; }
    public void setDiseaseClass(String diseaseClass) { this.diseaseClass = diseaseClass; }
    public void setDiseaseSemanticType(String diseaseSemanticType) { this.diseaseSemanticType = diseaseSemanticType; }
    public void setScore(String score) { this.score = score; }
    public void setEi(String ei) { this.ei = ei; }
    public void setYearInitial(String yearInitial) { this.yearInitial = yearInitial; }
    public void setYearFinal(String yearFinal) { this.yearFinal = yearFinal; }
    public void setPmid(String pmid) { this.pmid = pmid; }
    public void setSource(String source) { this.source = source; }

    @Override
    public int hashCode() {
        int result = 31 + ((diseaseId == null) ? 0 : diseaseId.hashCode());
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
        Disease other = (Disease) obj;
        if (diseaseId == null) {
            if (other.diseaseId != null)
                return false;
        } else if (!diseaseId.equals(other.diseaseId))
            return false;
        return true;
    }

    public static final Attribute DISEASEID = new Attribute("diseaseId");
    public static final Attribute DISEASENAME = new Attribute("diseaseName");
    public static final Attribute DISEASETYPE = new Attribute("diseaseType");
    public static final Attribute DISEASECLASS = new Attribute("diseaseClass");
    public static final Attribute DISEASESEMANTICTYPE = new Attribute("diseaseSemanticType");
    public static final Attribute SCORE = new Attribute("score");
    public static final Attribute EI = new Attribute("ei");
    public static final Attribute YEARINITIAL = new Attribute("yearInitial");
    public static final Attribute YEARFINAL = new Attribute("yearFinal");
    public static final Attribute PMID = new Attribute("pmid");
    public static final Attribute SOURCE = new Attribute("source");

    @Override
    public boolean hasValue(Attribute attribute) {
        if(attribute==DISEASEID)
            return diseaseId!=null;
        else if(attribute==DISEASENAME)
            return diseaseName!=null;
        else if(attribute==DISEASETYPE)
            return diseaseType!=null;
        else if(attribute==DISEASECLASS)
            return diseaseClass!=null;
        else if(attribute==DISEASESEMANTICTYPE)
            return diseaseSemanticType!=null;
        else if(attribute==SCORE)
            return score!=null;
        else if(attribute==EI)
            return ei!=null;
        else if(attribute==YEARINITIAL)
            return yearInitial!=null;
        else if(attribute==YEARFINAL)
            return yearFinal!=null;
        else if(attribute==PMID)
            return pmid!=null;
        else if(attribute==SOURCE)
            return source!=null;
        return false;
    }
}
