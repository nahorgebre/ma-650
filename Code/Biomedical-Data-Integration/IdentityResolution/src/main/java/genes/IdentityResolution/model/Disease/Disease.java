package genes.IdentityResolution.model.Disease;

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

    public static final Attribute DISEASEIDUMLS = new Attribute("diseaseIdUMLS");
    public static final Attribute DISEASENAME = new Attribute("diseaseName");
    public static final Attribute DISEASESPECIFITYINDEX = new Attribute("diseaseSpecificityIndex");
    public static final Attribute DISEASEPLEIOTROPYINDEX = new Attribute("diseasePleiotropyIndex");
    public static final Attribute DISEASETYPEDISGENET = new Attribute("diseaseTypeDisGeNET");
    public static final Attribute DISEASECLASSMESH = new Attribute("diseaseClassMeSH");
    public static final Attribute DISEASESEMANTICTYPEUMLS = new Attribute("diseaseSemanticTypeUMLS");
    public static final Attribute ASSOCIATIONSCORE = new Attribute("associationScore");
    public static final Attribute EVIDENCEINDEX = new Attribute("evidenceIndex");
    public static final Attribute YEARINITIALREPORT = new Attribute("yearInitialReport");
    public static final Attribute YEARFINALREPORT = new Attribute("yearFinalReport");
    public static final Attribute PMID = new Attribute("pmId");
    public static final Attribute SOURCE = new Attribute("source");

    @Override
    public boolean hasValue(Attribute attribute) {
        if(attribute==DISEASEIDUMLS)
            return diseaseIdUMLS!=null;
        else if(attribute==DISEASENAME)
            return diseaseName!=null;
        else if(attribute==DISEASESPECIFITYINDEX)
            return diseaseSpecificityIndex!=null;
        else if(attribute==DISEASEPLEIOTROPYINDEX)
            return diseasePleiotropyIndex!=null;
        else if(attribute==DISEASETYPEDISGENET)
            return diseaseTypeDisGeNET!=null;
        else if(attribute==DISEASECLASSMESH)
            return diseaseClassMeSH!=null;
        else if(attribute==DISEASESEMANTICTYPEUMLS)
            return diseaseSemanticTypeUMLS!=null;
        else if(attribute==ASSOCIATIONSCORE)
            return associationScore!=null;
        else if(attribute==EVIDENCEINDEX)
            return evidenceIndex!=null;
        else if(attribute==YEARINITIALREPORT)
            return yearInitialReport!=null;
        else if(attribute==YEARFINALREPORT)
            return yearFinalReport!=null;
        else if(attribute==PMID)
            return pmId!=null;
        else if(attribute==SOURCE)
            return source!=null;
        return false;
    }
}