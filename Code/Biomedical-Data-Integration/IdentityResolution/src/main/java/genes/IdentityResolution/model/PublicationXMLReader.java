package genes.IdentityResolution.model;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLMatchableReader;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import org.w3c.dom.Node;

public class PublicationXMLReader extends XMLMatchableReader<Publication, Attribute> {

    @Override
    public Publication createModelFromElement(Node node, String provenanceInfo) {
        String id = getValueFromChildElement(node, "id");

        Publication publication = new Publication(id, provenanceInfo);

        publication.setPmId(getValueFromChildElement(node, "pmid"));
        publication.setRessource(getValueFromChildElement(node, "ressource"));

        return publication;
    }
    
}
