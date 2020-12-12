package genes.DataFusion.SAXParser2.Organ;

public class Organ {

    private String organName;
    private String disagreement;
    private String probEqualOrthoAdj;
    private String call;

    // Getter
    public String getOrganName() {
        return organName;
    }

    public String getDisagreement() {
        return disagreement;
    }

    public String getProbEqualOrthoAdj() {
        return probEqualOrthoAdj;
    }

    public String getCall() {
        return call;
    }

    // Setter
    public void setOrganName(String organName) {
        this.organName = organName;
    }

    public void setDisagreement(String disagreement) {
        this.disagreement = disagreement;
    }

    public void setProbEqualOrthoAdj(String probEqualOrthoAdj) {
        this.probEqualOrthoAdj = probEqualOrthoAdj;
    }

    public void setCall(String call) {
        this.call = call;
    }

}
