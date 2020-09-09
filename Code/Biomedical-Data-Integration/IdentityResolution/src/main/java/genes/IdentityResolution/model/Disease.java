package genes.IdentityResolution.model;

import de.uni_mannheim.informatik.dws.winter.model.AbstractRecord;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import java.io.Serializable;

public class Disease extends AbstractRecord<Attribute> implements Serializable {

    private static final long serialVersionUID = 1L;
    private String diseaseIdUMLS;
    private String diseaseName;
    private String diseaseSpecificityIndex;
    private String diseasePleiotropyIndex;
    private String diseaseTypeDisGeNET;
    private String diseaseClassMeSH;
    private String diseaseSemanticTypeUMLS;
    private String associationScore;
    private String evidenceIndex;
    private String yearInitialReport;
    private String yearFinalReport;
    private String pmId;
    private String source;

    public Disease(String identifier, String provenance) {
        super(identifier, provenance);
    }

    // Getter
    public String getDiseaseIdUMLS() { return diseaseIdUMLS; }
    public String getDiseaseName() { return diseaseName; }
    public String getDiseaseSpecificityIndex() { return diseaseSpecificityIndex; }
    public String getDiseasePleiotropyIndex() { return diseasePleiotropyIndex; }
    public String getDiseaseTypeDisGeNET() { return diseaseTypeDisGeNET; }
    public String getDiseaseClassMeSH() { return diseaseClassMeSH; }
    public String getDiseaseSemanticTypeUMLS() { return diseaseSemanticTypeUMLS; }
    public String getAssociationScore() { return associationScore; }
    public String getEvidenceIndex() { return evidenceIndex; }
    public String getYearInitialReport() { return  yearInitialReport; }
    public String getYearFinalReport() { return yearFinalReport; }
    public String getPmId() { return pmId; }
    public String getSource() { return source; }

    // Setter
    public void setDiseaseIdUMLS(String diseaseIdUMLS) { this.diseaseIdUMLS = diseaseIdUMLS; }
    public void setDiseaseName(String diseaseName) { this.diseaseName = diseaseName; }
    public void setDiseaseSpecificityIndex(String diseaseSpecificityIndex) { this.diseaseSpecificityIndex = diseaseSpecificityIndex; }
    public void setDiseasePleiotropyIndex(String diseasePleiotropyIndex) { this.diseasePleiotropyIndex = diseasePleiotropyIndex; }
    public void setDiseaseTypeDisGeNET(String diseaseTypeDisGeNET) { this.diseaseTypeDisGeNET = diseaseTypeDisGeNET; }
    public void setDiseaseClassMeSH(String diseaseClassMeSH) { this.diseaseClassMeSH = diseaseClassMeSH; }
    public void setDiseaseSemanticTypeUMLS(String diseaseSemanticTypeUMLS) { this.diseaseSemanticTypeUMLS = diseaseSemanticTypeUMLS; }
    public void setAssociationScore(String associationScore) { this.associationScore = associationScore; }
    public void setEvidenceIndex(String evidenceIndex) { this.evidenceIndex = evidenceIndex; }
    public void setYearInitialReport(String yearInitialReport) { this.yearInitialReport = yearInitialReport; }
    public void setYearFinalReport(String yearFinalReport) { this.yearFinalReport = yearFinalReport; }
    public void setPmId(String pmId) { this.pmId = pmId; }
    public void setSource(String source) { this.source = source; }

    @Override
    public int hashCode() {
        int result = 31 + ((diseaseIdUMLS == null) ? 0 : diseaseIdUMLS.hashCode());
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
        if (diseaseIdUMLS == null) {
            if (other.diseaseIdUMLS != null)
                return false;
        } else if (!diseaseIdUMLS.equals(other.diseaseIdUMLS))
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
            return diseaseIdUMLS!=null;
        else if(attribute==DISEASENAME)
            return diseaseName!=null;
        else if(attribute==DISEASETYPE)
            return diseaseTypeDisGeNET!=null;
        else if(attribute==DISEASECLASS)
            return diseaseClassMeSH!=null;
        else if(attribute==DISEASESEMANTICTYPE)
            return diseaseSemanticTypeUMLS!=null;
        else if(attribute==SCORE)
            return associationScore!=null;
        else if(attribute==EI)
            return evidenceIndex!=null;
        else if(attribute==YEARINITIAL)
            return yearInitialReport!=null;
        else if(attribute==YEARFINAL)
            return yearFinalReport!=null;
        else if(attribute==PMID)
            return pmId!=null;
        else if(attribute==SOURCE)
            return source!=null;
        return false;
    }
}