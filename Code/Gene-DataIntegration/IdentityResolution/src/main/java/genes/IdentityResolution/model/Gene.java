package genes.IdentityResolution.model;

import de.uni_mannheim.informatik.dws.winter.model.Matchable;

import java.util.LinkedList;
import java.util.List;

public class Gene implements Matchable {

    protected String id;
    protected String provenance;
    private String geneId;
    private String geneName;
    private String geneDescription;
    private String disagreement;
    private String call;
    private String ncbiId;
    private String dsi;
    private String dpi;
    private List<Disease> diseases;

    public Gene(String identifier, String provenance) {
        id = identifier;
        this.provenance = provenance;
        diseases = new LinkedList<>();
    }

    @Override
    public String getIdentifier() {
        return id;
    }

    @Override
    public String getProvenance() {
        return provenance;
    }

    // Getter
    public String getGeneId() { return geneId; }
    public String getGeneName() { return geneName; }
    public String getGeneDescription() { return geneDescription; }
    public String getDisagreement() { return disagreement; }
    public String getCall() { return call; }
    public String getNcbiId() { return ncbiId; }
    public String getDsi() { return dsi; }
    public String getDpi() { return dpi; }
    public List<Disease> getDiseases() {
        return diseases;
    }

    // Setter
    public void setGeneId(String geneId) { this.geneId = geneId; }
    public void setGeneName(String geneName) { this.geneName = geneName; }
    public void setGeneDescription(String geneDescription) { this.geneDescription = geneDescription; }
    public void setDisagreement(String disagreement) { this.disagreement = disagreement; }
    public void setCall(String call) { this.call = call; }
    public void setNcbiId(String ncbiId) { this.ncbiId = ncbiId; }
    public void setDsi(String dsi) { this.dsi = dsi; }
    public void setDpi(String dpi) { this.dpi = dpi; }
    public void setDiseases(List<Disease> diseases) {
        this.diseases = diseases;
    }

    @Override
    public String toString() {
        return String.format("[Gene %s: %s / %s / %s]", getIdentifier(), getGeneId(), getGeneName(), getGeneDescription(), getDisagreement(), getCall(), getNcbiId(), getDsi(), getDpi(), getDiseases());
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
