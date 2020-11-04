package genes.IdentityResolution.model.Gene;

import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import genes.IdentityResolution.model.Disease.Disease;
import genes.IdentityResolution.model.GeneDescription.GeneDescription;
import genes.IdentityResolution.model.GeneName.GeneName;
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
    private List<GeneName> geneNames;
    private List<GeneDescription> geneDescriptions;

    private List<Organ> organs;
    private List<Disease> diseases;
    private List<Publication> publications;
    private List<Patent> patents;

    public Gene(String identifier, String provenance) {
        recordId = identifier;
        this.provenance = provenance;

        geneNames = new LinkedList<>();
        geneDescriptions = new LinkedList<>();

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
    public List<GeneName> getGeneNames() { return geneNames; }
    public List<GeneDescription> getGeneDescriptions() { return geneDescriptions; }

    public List<Organ> getOrgans() { return organs; }
    public List<Disease> getDiseases() { return diseases; }
    public List<Publication> getPublications() { return publications; }
    public List<Patent> getPatents() { return patents; }

    // Setter
    public void setEnsemblId(String geneId) { this.ensemblId = geneId; }
    public void setNcbiId(String ncbiId) { this.ncbiId = ncbiId; }
    public void setGeneNames(List<GeneName> geneNames) { this.geneNames = geneNames; }
    public void setGeneDescriptions(List<GeneDescription> geneDescriptions) { this.geneDescriptions = geneDescriptions; }
   
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