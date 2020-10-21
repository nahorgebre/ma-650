package genes.IdentityResolution.model.GeneName;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLMatchableReader;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import org.w3c.dom.Node;

public class GeneNameXMLReader extends XMLMatchableReader<GeneName, Attribute> {
    @Override
    public GeneName createModelFromElement(Node node, String provenanceInfo) {
        String id = getValueFromChildElement(node, "id");

        GeneName geneName = new GeneName(id, provenanceInfo);

        geneName.setName(getValueFromChildElement(node, "name"));

        return geneName;
    }
}
