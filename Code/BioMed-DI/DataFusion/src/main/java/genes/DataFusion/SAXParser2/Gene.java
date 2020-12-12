package genes.DataFusion.SAXParser2;

import java.util.List;

import genes.DataFusion.SAXParser2.Disease.Disease;
import genes.DataFusion.SAXParser2.Organ.Organ;
import genes.DataFusion.SAXParser2.Patent.Patent;
import genes.DataFusion.SAXParser2.Publication.Publication;

public class Gene {

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
    
}
