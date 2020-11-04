package genes.DataFusion.model.Patent;

import org.w3c.dom.Node;

import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.model.io.XMLMatchableReader;

public class PatentXMLReader extends XMLMatchableReader<Patent, Attribute> {

    @Override
    public Patent createModelFromElement(Node node, String provenanceInfo) {
        String recordId = getValueFromChildElement(node, "recordId");

        Patent patent = new Patent(recordId, provenanceInfo);

        patent.setPatentId(getValueFromChildElement(node, "patentId"));
        patent.setPatentDate(getValueFromChildElement(node, "patentDate"));
        patent.setPatentClaimsCount(getValueFromChildElement(node, "patentClaimsCount"));

        return patent;
    }

}