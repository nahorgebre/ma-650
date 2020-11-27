package genes.DataFusion.SAXParser2.Publication;

public class Publication {

    private String pmId;
    private String year;
    private String ressource;

    // Getter
    public String getPmId() {
        return pmId;
    }

    public String getYear() {
        return year;
    }

    public String getRessource() {
        return ressource;
    }

    // Setter
    public void setPmId(String pmId) {
        this.pmId = pmId;
    }

    public void setYear(String year) {
        this.year = year;
    }

    public void setRessource(String ressource) {
        this.ressource = ressource;
    }

}