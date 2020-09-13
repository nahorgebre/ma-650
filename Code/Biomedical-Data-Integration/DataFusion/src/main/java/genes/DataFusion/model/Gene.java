package genes.DataFusion.model;

import de.uni_mannheim.informatik.dws.winter.model.AbstractRecord;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import org.apache.commons.lang3.StringUtils;

import java.io.Serializable;
import java.util.Collection;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.Map;
import java.util.List;


public class Gene extends AbstractRecord<Attribute> implements Serializable {
    private static final long serialVersionUID = 1L;

    public Gene(String identifier, String provenance) {
        super(identifier, provenance);

        geneNames = new LinkedList<>();
        publicationMentions = new LinkedList<>();
        patentMentions = new LinkedList<>();
        diseaseAssociations = new LinkedList<>();
    }

    private String ensemblId;
    private String geneName;
    private String geneDescription;
    private String disagreement;
    private String probEqualOrthoAdj;
    private String call;
    private String ncbiId;

    private List<GeneName> geneNames;
    private List<Publication> publicationMentions;
    private List<Patent> patentMentions;
    private List<Disease> diseaseAssociations;

    // Getter
    public String getEnsemblId() { return ensemblId; }
    public String getGeneDescription() { return geneDescription; }
    public String getDisagreement() { return disagreement; }
    public String getProbEqualOrthoAdj() { return probEqualOrthoAdj; }
    public String getCall() { return call; }
    public String getNcbiId() { return ncbiId; }
    public List<GeneName> getGeneNames() { return geneNames; }
    public List<Publication> getPublicationMentions() { return publicationMentions; }
    public List<Patent> getPatentMentions() { return publicationMentions; }
    public List<Disease> getDiseaseAssociations() { return diseaseAssociations; }

    // Setter
    public void setEnsemblId(String ensemblId) { this.ensemblId = ensemblId; }
    public void setGeneDescription(String geneDescription) { this.geneDescription = geneDescription; }
    public void setDisagreement(String disagreement) { this.disagreement = disagreement; }
    public void setProbEqualOrthoAdj(String probEqualOrthoAdj) { this.probEqualOrthoAdj = probEqualOrthoAdj; }
    public void setCall(String call) { this.call = call; }
    public void setNcbiId(String ncbiId) { this.ncbiId = ncbiId; }
    public void setGeneNames(List<GeneName> geneNames) { this.geneNames = geneNames; }
    public void setPublicationMentions(List<Publication> publicationMentions) { this.publicationMentions = publicationMentions; }
    public void setPatentMentions(List<Patent> patentMentions) { this.patentMentions = patentMentions; }
    public void setDiseaseAssociations(List<Disease> diseaseAssociations) { this.diseaseAssociations = diseaseAssociations; }

    private Map<Attribute, Collection<String>> provenance = new HashMap<>();
    private Collection<String> recordProvenance;

    public void setRecordProvenance(Collection<String> provenance) {
        recordProvenance = provenance;
    }

    public Collection<String> getRecordProvenance() {
        return recordProvenance;
    }

    public void setAttributeProvenance(Attribute attribute,
                                       Collection<String> provenance) {
        this.provenance.put(attribute, provenance);
    }

    public Collection<String> getAttributeProvenance(String attribute) {
        return provenance.get(attribute);
    }

    public String getMergedAttributeProvenance(Attribute attribute) {
        Collection<String> prov = provenance.get(attribute);

        if (prov != null) {
            return StringUtils.join(prov, "+");
        } else {
            return "";
        }
    }

    public static final Attribute ENSEMBLID = new Attribute("ensemblId");
    public static final Attribute GENEDESCRIPTION = new Attribute("geneDescription");
    public static final Attribute DISAGREEMENT = new Attribute("disagreement");
    public static final Attribute PROBEQUALORTHOADJ = new Attribute("probEqualOrthoAdj");
    public static final Attribute CALL = new Attribute("call");
    public static final Attribute NCBIID = new Attribute("ncbiId");

    public static final Attribute GENENAMES = new Attribute("geneNames");
    public static final Attribute PUBLICATIONMENTIONS = new Attribute("publicationMentions");
    public static final Attribute PATENTMENTIONS = new Attribute("patentMentions");
    public static final Attribute DISEASEASSOCIATIONS = new Attribute("diseaseAssociations");

    @Override
    public boolean hasValue(Attribute attribute) {
        if(attribute== ENSEMBLID)
            return getEnsemblId() != null && !getEnsemblId().isEmpty();
        else if(attribute==GENEDESCRIPTION)
            return getGeneDescription() != null && !getGeneDescription().isEmpty();
        else if(attribute==DISAGREEMENT)
            return getDisagreement() != null && !getDisagreement().isEmpty();
        else if(attribute==PROBEQUALORTHOADJ)
            return getProbEqualOrthoAdj() != null && !getProbEqualOrthoAdj().isEmpty();
        else if(attribute==CALL)
            return getCall() != null && !getCall().isEmpty();
        else if(attribute==NCBIID)
            return getNcbiId() != null && !getNcbiId().isEmpty();
        else if(attribute== GENENAMES)
            return getGeneNames() != null && !getGeneNames().isEmpty();
        else if(attribute== PUBLICATIONMENTIONS)
            return getPublicationMentions() != null && !getPublicationMentions().isEmpty();
        else if(attribute== PATENTMENTIONS)
            return getPatentMentions() != null && !getPatentMentions().isEmpty();
        else if(attribute== DISEASEASSOCIATIONS)
            return getDiseaseAssociations() != null && getDiseaseAssociations().size() > 0;
        else
            return false;
    }

    @Override
    public String toString() {
        return String.format("[Gene %s: %s / %s / %s / %s / %s / %s /]",
                getIdentifier(), getEnsemblId(), getGeneDescription(),
                getDisagreement(), getProbEqualOrthoAdj(), getCall(), getNcbiId());
    }

    @Override
    public int hashCode() {
        return getIdentifier().hashCode();
    }

    @Override
    public boolean equals(Object obj) {
        if(obj instanceof Gene){
            return this.getIdentifier().equals(((Gene) obj).getIdentifier());
        }else
            return false;
    }
}
