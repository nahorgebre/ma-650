package genes.DataFusion.SAXParser.Patent;

public class Patent {

    private String patentId;
    private String patentDate;
    private String patentClaimsCount;

    // Getter
    public String getPatentId() {
        return patentId;
    }

    public String getPatentDate() {
        return patentDate;
    }

    public String getPatentClaimsCount() {
        return patentClaimsCount;
    }

    // Setter
    public void setPatentId(String patentId) {
        this.patentId = patentId;
    }

    public void setPatentDate(String patentDate) {
        this.patentDate = patentDate;
    }

    public void setPatentClaimsCount(String patentClaimsCount) {
        this.patentClaimsCount = patentClaimsCount;
    }

}
