package genes.IdentityResolution.gene2pubtatorcentralXMLReader;

public class gene2pubtatorcentral {

    public String recordId;
    public String ncbiId;
    public String name;
    public String pmid;
    public String ressource;

    public String getRecordId() {
        return recordId;
    }

    public void setRecordId(String recordId) {
        this.recordId = recordId;
    }

    public String getNcbiId() {
        return ncbiId;
    }

    public void setNcbiId(String ncbiId) {
        this.ncbiId = ncbiId;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getPmid() {
        return pmid;
    }

    public void setPmid(String pmid) {
        this.pmid = pmid;
    }

    public String getRessource() {
        return ressource;
    }

    public void setRessource(String ressource) {
        this.ressource = ressource;
    }

    @Override
    public String toString() {
        return "gene2pubtatorcentral [recordId=" + recordId + " , ncbiId=" + ncbiId + " , name=" + name + " , pmid=" + pmid + " , ressource=" + ressource + "]";
    }

}
