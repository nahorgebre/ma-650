package genes.IdentityResolution.model;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLMatchableReader;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import org.w3c.dom.Node;

public class GeneDescriptionXMLReader extends XMLMatchableReader<GeneDescription, Attribute> {
    
    @Override
    public GeneDescription createModelFromElement(Node node, String provenanceInfo) {
        String id = getValueFromChildElement(node, "id");

        GeneDescription geneDescription = new GeneDescription(id, provenanceInfo);

        geneDescription.setDescription(getValueFromChildElement(node, "dsecription"));

        return geneName;
    }

}
