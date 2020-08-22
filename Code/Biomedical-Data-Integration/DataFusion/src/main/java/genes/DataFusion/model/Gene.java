package genes.DataFusion.model;

import de.uni_mannheim.informatik.dws.winter.model.AbstractRecord;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import org.apache.commons.lang3.StringUtils;

import java.io.Serializable;
import java.util.Collection;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.Map;
import java.util.List;


public class Gene extends AbstractRecord<Attribute> implements Serializable {
    private static final long serialVersionUID = 1L;

    public Gene(String identifier, String provenance) {
        super(identifier, provenance);
        diseases = new LinkedList<>();
    }

    private String geneId;
    private String geneName;
    private String geneDescription;
    private String disagreement;
    private String call;
    private String ncbiId;
    private String dsi;
    private String dpi;
    private List<Disease> diseases;

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

    private Map<Attribute, Collection<String>> provenance = new HashMap<>();
    private Collection<String> recordProvenance;

    public void setRecordProvenance(Collection<String> provenance) {
        recordProvenance = provenance;
    }

    public Collection<String> getRecordProvenance() {
        return recordProvenance;
    }

    public void setAttributeProvenance(Attribute attribute,
                                       Collection<String> provenance) {
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

    public static final Attribute GENEID = new Attribute("geneId");
    public static final Attribute GENENAME = new Attribute("geneName");
    public static final Attribute GENEDESCRIPTION = new Attribute("geneDescription");
    public static final Attribute DISAGREEMENT = new Attribute("disagreement");
    public static final Attribute CALL = new Attribute("call");
    public static final Attribute NCBIID = new Attribute("ncbiId");
    public static final Attribute DSI = new Attribute("dsi");
    public static final Attribute DPI = new Attribute("dpi");
    public static final Attribute DISEASES = new Attribute("diseases");

    @Override
    public boolean hasValue(Attribute attribute) {
        if(attribute==GENEID)
            return getGeneId() != null && !getGeneId().isEmpty();
        else if(attribute==GENENAME)
            return getGeneName() != null && !getGeneName().isEmpty();
        else if(attribute==GENEDESCRIPTION)
            return getGeneDescription() != null && !getGeneDescription().isEmpty();
        else if(attribute==DISAGREEMENT)
            return getDisagreement() != null && !getDisagreement().isEmpty();
        else if(attribute==CALL)
            return getCall() != null && !getCall().isEmpty();
        else if(attribute==NCBIID)
            return getNcbiId() != null && !getNcbiId().isEmpty();
        else if(attribute==DSI)
            return getDsi() != null && !getDsi().isEmpty();
        else if(attribute==DPI)
            return getDpi() != null && !getDpi().isEmpty();
        else if(attribute==DISEASES)
            return getDiseases() != null && getDiseases().size() > 0;
        else
            return false;
    }

    @Override
    public String toString() {
        return String.format("[Gene %s: %s / %s / %s / %s / %s / %s / %s / %s /]",
                getIdentifier(), getGeneId(), getGeneName(), getGeneDescription(),
                getDisagreement(), getCall(), getNcbiId(), getDsi(), getDpi());
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
}
