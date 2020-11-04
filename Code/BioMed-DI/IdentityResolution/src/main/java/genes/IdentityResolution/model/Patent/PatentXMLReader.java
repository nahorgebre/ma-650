package genes.IdentityResolution.model.Patent;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLMatchableReader;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import org.w3c.dom.Node;

public class PatentXMLReader extends XMLMatchableReader<Patent, Attribute>{
    
    @Override
    public Patent createModelFromElement(Node node, String provenanceInfo) {
        String id = getValueFromChildElement(node, "recordId");

        Patent patent = new Patent(id, provenanceInfo);

        patent.setPatentId(getValueFromChildElement(node, "patentId"));
        patent.setPatentDate(getValueFromChildElement(node, "patentDate"));
        patent.setPatentClaimsCount(getValueFromChildElement(node, "patentClaimsCount"));

        return patent;
    }

}
