package genes.DataFusion.SAXParser;

import java.io.Serializable;
import java.util.LinkedList;
import java.util.Collection;
import java.util.HashMap;
import java.util.Map;
import java.util.List;

import de.uni_mannheim.informatik.dws.winter.model.AbstractRecord;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import genes.DataFusion.SAXParser.Disease.Disease;
import genes.DataFusion.SAXParser.Organ.Organ;
import genes.DataFusion.SAXParser.Patent.Patent;
import genes.DataFusion.SAXParser.Publication.Publication;

import org.apache.commons.lang3.StringUtils;

public class Gene extends AbstractRecord<Attribute> implements Serializable {

    private static final long serialVersionUID = 1L;

    public Gene(String identifier, String provenance) {
        super(identifier, provenance);

        organs = new LinkedList<>();
        
        publications = new LinkedList<>();

        patents = new LinkedList<>();

        diseases = new LinkedList<>();
        
    }

    private String recordId;
    private String ensemblId;
    private String ncbiId;
    private String geneNames;
    private String geneDescriptions;

    private List <Organ> organs;
    private List <Disease> diseases;
    private List <Patent> patents;
    private List <Publication> publications;

    public String getRecordId() {
        return recordId;
    }

    public void setRecordId(String recordId) {
        this.recordId = recordId;
    }

    public String getEnsemblId() {
        return ensemblId;
    }

    public void setEnsemblId(String firstName) {
        this.ensemblId = firstName;
    }

    public String getNcbiId() {
        return ncbiId;
    }

    public void setNcbiId(String lastName) {
        this.ncbiId = lastName;
    }

    public String getGeneNames() {
        return geneNames;
    }

    public void setGeneNames(String geneNames) {
        this.geneNames = geneNames;
    }

    public String getGeneDescriptions() {
        return geneDescriptions;
    }

    public void setGeneDescriptions(String geneDescriptions) {
        this.geneDescriptions = geneDescriptions;
    }

    public List<Organ> getOrgans() {
        return organs;
    }

    public void setOrgans(List<Organ> organs) {
        this.organs = organs;
    }

    public List<Disease> getDiseases() {
        return diseases;
    }

    public void setDiseases(List<Disease> diseases) {
        this.diseases = diseases;
    }

    public List<Patent> getPatents() {
        return patents;
    }

    public void setPatents(List<Patent> patents) {
        this.patents = patents;
    }

    public List<Publication> getPublications() {
        return publications;
    }

    public void setPublications(List<Publication> publications) {
        this.publications = publications;
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
            return getPublications() != null && getPublications().size() > 0;
        else if(attribute== PATENTMENTIONS)
            return getPatents() != null && getPatents().size() > 0;
        else if(attribute== DISEASEASSOCIATIONS)
            return getDiseases() != null && getDiseases().size() > 0;
        else
            return false;
    }

    // ----

    /*

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
            return getPublications() != null && getPublications().size() > 0;
        else if(attribute== PATENTMENTIONS)
            return getPatents() != null && getPatents().size() > 0;
        else if(attribute== DISEASEASSOCIATIONS)
            return getDiseases() != null && getDiseases().size() > 0;
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

    */
    
}
