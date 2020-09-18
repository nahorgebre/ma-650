package genes.DataFusion.model;

import org.w3c.dom.Node;

import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.model.io.XMLMatchableReader;

public class OrganXMLReader extends XMLMatchableReader<Organ, Attribute> {

    @Override
    public Organ createModelFromElement(Node node, String provenanceInfo) {
        String recordId = getValueFromChildElement(node, "recordId");

        Organ organ = new Organ(recordId, provenanceInfo);

        organ.setOrganName(getValueFromChildElement(node, "organName"));
        organ.setDisagreement(getValueFromChildElement(node, "disagreement"));
        organ.setProbEqualOrthoAdj(getValueFromChildElement(node, "probEqualOrthoAdj") );
        organ.setCall(getValueFromChildElement(node, "call"));

        return organ;
    }

}
