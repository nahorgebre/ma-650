package genes.DataFusion.model.Gene;

import de.uni_mannheim.informatik.dws.winter.model.AbstractRecord;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import genes.DataFusion.model.Disease.Disease;
import genes.DataFusion.model.Organ.Organ;
import genes.DataFusion.model.Patent.Patent;
import genes.DataFusion.model.Publication.Publication;

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

        organs = new LinkedList<>();
        publicationMentions = new LinkedList<>();
        patentMentions = new LinkedList<>();
        diseaseAssociations = new LinkedList<>();

    }

    private String ensemblId;
    private String ncbiId;
    private String geneNames;
    private String geneDescriptions;

    private List<Organ> organs;
    private List<Publication> publicationMentions;
    private List<Patent> patentMentions;
    private List<Disease> diseaseAssociations;

    // Getter
    public String getEnsemblId() { return ensemblId; }
    public String getNcbiId() { return ncbiId; }
    public String getGeneNames() { return geneNames; }
    public String getGeneDescriptions() { return geneDescriptions; }

    public List<Organ> getOrgans() { return organs; }
    public List<Publication> getPublicationMentions() { return publicationMentions; }
    public List<Patent> getPatentMentions() { return patentMentions; }
    public List<Disease> getDiseaseAssociations() { return diseaseAssociations; }

    // Setter
    public void setEnsemblId(String ensemblId) { this.ensemblId = ensemblId; }
    public void setNcbiId(String ncbiId) { this.ncbiId = ncbiId; }
    public void setGeneNames(String geneNames) { this.geneNames = geneNames; }
    public void setGeneDescriptions(String geneDescriptions) { this.geneDescriptions = geneDescriptions; }
    
    public void setOrgans(List<Organ> organs) { this.organs = organs; }
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

    public void setAttributeProvenance(Attribute attribute, Collection<String> provenance) {
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
    public static final Attribute NCBIID = new Attribute("ncbiId");
    public static final Attribute GENENAMES = new Attribute("geneNames");
    public static final Attribute GENEDESCRIPTIONS = new Attribute("geneDescriptions");

    public static final Attribute ORGANS = new Attribute("organs");
    public static final Attribute PUBLICATIONMENTIONS = new Attribute("publicationMentions");
    public static final Attribute PATENTMENTIONS = new Attribute("patentMentions");
    public static final Attribute DISEASEASSOCIATIONS = new Attribute("diseaseAssociations");

    @Override
    public boolean hasValue(Attribute attribute) {
        if(attribute== ENSEMBLID)
            return getEnsemblId() != null && !getEnsemblId().isEmpty();
        else if(attribute==NCBIID)
            return getNcbiId() != null && !getNcbiId().isEmpty();
        else if(attribute== GENENAMES)
            return getGeneNames() != null && !getGeneNames().isEmpty();
        else if(attribute==GENEDESCRIPTIONS)
            return getGeneDescriptions() != null && !getGeneDescriptions().isEmpty();
        else if(attribute==ORGANS)
            return getOrgans() != null && getOrgans().size() > 0;
        else if(attribute== PUBLICATIONMENTIONS)
            return getPublicationMentions() != null && getPublicationMentions().size() > 0;
        else if(attribute== PATENTMENTIONS)
            return getPatentMentions() != null && getPatentMentions().size() > 0;
        else if(attribute== DISEASEASSOCIATIONS)
            return getDiseaseAssociations() != null && getDiseaseAssociations().size() > 0;
        else
            return false;
    }

    @Override
    public String toString() {
        return String.format("[Gene %s: %s / %s /]",
                getIdentifier(), getEnsemblId(), getNcbiId());
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
