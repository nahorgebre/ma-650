package genes.IdentityResolution.model.Gene;

import de.uni_mannheim.informatik.dws.winter.model.Matchable;

import genes.IdentityResolution.model.Disease.Disease;
import genes.IdentityResolution.model.Organ.Organ;
import genes.IdentityResolution.model.Patent.Patent;
import genes.IdentityResolution.model.Publication.Publication;

import java.util.LinkedList;
import java.util.List;

public class Gene implements Matchable {

    protected String recordId;
    protected String provenance;

    private String ensemblId;
    private String ncbiId;
    private String geneNames;
    private String geneDescriptions;

    private String overallCall;
    private String firstPublicationYear;
    private String frequencyPatent;
    private String frequencyPatentTitle;
    private String frequencyPatentAbstract;
    private String frequencyPatentDescription;
    private String frequencyPatentClaims;

    private List<Organ> organs;
    private List<Disease> diseases;
    private List<Publication> publications;
    private List<Patent> patents;

    public Gene(String identifier, String provenance) {
        recordId = identifier;
        this.provenance = provenance;

        organs = new LinkedList<>();
        diseases = new LinkedList<>();
        publications = new LinkedList<>();
        patents = new LinkedList<>();
    }

    @Override
    public String getIdentifier() {
        return recordId;
    }

    @Override
    public String getProvenance() {
        return provenance;
    }

    // Getter
    public String getEnsemblId() { return ensemblId; }
    public String getNcbiId() { return ncbiId; }
    public String getGeneNames() { return geneNames; }
    public String getGeneDescriptions() { return geneDescriptions; }

    public String getOverallCall() { return overallCall; }
    public String getFirstPublicationYear() { return firstPublicationYear; }
    public String getFrequencyPatent() { return frequencyPatent; }
    public String getFrequencyPatentTitle() { return frequencyPatentTitle; }
    public String getFrequencyPatentAbstract() { return frequencyPatentAbstract; }
    public String getFrequencyPatentDescription() { return frequencyPatentDescription; }
    public String getFrequencyPatentClaims() { return frequencyPatentClaims; }

    public List<Organ> getOrgans() { return organs; }
    public List<Disease> getDiseases() { return diseases; }
    public List<Publication> getPublications() { return publications; }
    public List<Patent> getPatents() { return patents; }

    // Setter
    public void setEnsemblId(String geneId) { this.ensemblId = geneId; }
    public void setNcbiId(String ncbiId) { this.ncbiId = ncbiId; }
    public void setGeneNames(String geneNames) { this.geneNames = geneNames; }
    public void setGeneDescriptions(String geneDescriptions) { this.geneDescriptions = geneDescriptions; }

    public void setOverallCall(String overallCall) { this.overallCall = overallCall; }
    public void setFirstPublicationYear(String firstPublicationYear) { this.firstPublicationYear = firstPublicationYear; }
    public void setFrequencyPatent(String frequencyPatent) { this.frequencyPatent = frequencyPatent; }
    public void setFrequencyPatentTitle(String frequencyPatentTitle) { this.frequencyPatentTitle = frequencyPatentTitle; }
    public void setFrequencyPatentAbstract(String frequencyPatentAbstract) { this.frequencyPatentAbstract = frequencyPatentAbstract; }
    public void setFrequencyPatentDescription(String frequencyPatentDescription) { this.frequencyPatentDescription = frequencyPatentDescription; }
    public void setFrequencyPatentClaims(String frequencyPatentClaims) { this.frequencyPatentClaims = frequencyPatentClaims; }

    public void setOrgans(List<Organ> organs) { this.organs = organs; }
    public void setDiseases(List<Disease> diseases) { this.diseases = diseases; }
    public void setPublications(List<Publication> publications) { this.publications = publications; }
    public void setPatents(List<Patent> patents) { this.patents = patents; }

    @Override
    public String toString() {
        return String.format("[Gene %s: %s / %s /]", getIdentifier(), getEnsemblId(), getNcbiId());
    }

    @Override
    public int hashCode() {
        return getIdentifier().hashCode();
    }

    @Override
    public boolean equals(Object obj) {
        if(obj instanceof Gene){
            return this.getIdentifier().equals(((Gene) obj).getIdentifier());
        } else {
            return false;
        }
    }

}