package genes.IdentityResolution.model;

import de.uni_mannheim.informatik.dws.winter.model.Matchable;

import java.util.LinkedList;
import java.util.List;

public class Gene implements Matchable {

    protected String recordId;
    protected String provenance;

    private String ensemblId;

    private List<GeneName> geneNames;

    private String geneDescription;
    private String disagreement;
    private String probEqualOrthoAdj;
    private String call;
    private String ncbiId;

    private List<Disease> diseases;

    private List<Publication> publications;

    private List<Patent> patents;

    public Gene(String identifier, String provenance) {
        recordId = identifier;
        this.provenance = provenance;
        geneNames = new LinkedList<>();
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
    public List<GeneName> getGeneNames() { return geneNames; }
    public String getGeneDescription() { return geneDescription; }
    public String getDisagreement() { return disagreement; }
    public String getProbEqualOrthoAdj() {return probEqualOrthoAdj; }
    public String getCall() { return call; }
    public String getNcbiId() { return ncbiId; }
    public List<Disease> getDiseases() { return diseases; }
    public List<Publication> getPublications() { return publications; }
    public List<Patent> getPatents() { return patents; }

    // Setter
    public void setEnsemblId(String geneId) { this.ensemblId = geneId; }
    public void setGeneNames(List<GeneName> geneNames) { this.geneNames = geneNames; }
    public void setGeneDescription(String geneDescription) { this.geneDescription = geneDescription; }
    public void setDisagreement(String disagreement) { this.disagreement = disagreement; }
    public void setProbEqualOrthoAdj(String probEqualOrthoAdj) { this.probEqualOrthoAdj = probEqualOrthoAdj; }
    public void setCall(String call) { this.call = call; }
    public void setNcbiId(String ncbiId) { this.ncbiId = ncbiId; }
    public void setDiseases(List<Disease> diseases) { this.diseases = diseases; }
    public void setPublications(List<Publication> publications) { this.publications = publications; }
    public void setPatents(List<Patent> patents) { this.patents = patents; }

    @Override
    public String toString() {
        return String.format("[Gene %s: %s / %s / %s / %s / %s / %s / %s]", getIdentifier(), getEnsemblId(), getGeneDescription(), getDisagreement(), getProbEqualOrthoAdj(), getCall(), getNcbiId(), getDiseases());
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
