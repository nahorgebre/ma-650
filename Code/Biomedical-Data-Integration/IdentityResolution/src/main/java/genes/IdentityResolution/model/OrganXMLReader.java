package genes.IdentityResolution.model;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLMatchableReader;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import org.w3c.dom.Node;

public class OrganXMLReader extends XMLMatchableReader<Organ, Attribute> {

    @Override
    public Organ createModelFromElement(Node node, String provenanceInfo) {
        String id = getValueFromChildElement(node, "recordId");

        Organ organ = new Organ(id, provenanceInfo);

        organ.setOrganName(getValueFromChildElement(node, "organName"));
        organ.setDisagreement(getValueFromChildElement(node, "disagreement"));
        organ.setProbEqualOrthoAdj(getValueFromChildElement(node, "probEqualOrthoAdj"));
        organ.setCall(getValueFromChildElement(node, "call"));

        return organ;
    }
    
}
