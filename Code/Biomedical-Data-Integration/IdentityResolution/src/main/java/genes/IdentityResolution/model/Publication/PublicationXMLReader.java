package genes.IdentityResolution.model.Publication;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLMatchableReader;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import org.w3c.dom.Node;

public class PublicationXMLReader extends XMLMatchableReader<Publication, Attribute> {

    @Override
    public Publication createModelFromElement(Node node, String provenanceInfo) {
        String id = getValueFromChildElement(node, "recordId");

        Publication publication = new Publication(id, provenanceInfo);

        publication.setPmId(getValueFromChildElement(node, "pmId"));
        publication.setYear(getValueFromChildElement(node, "year"));
        publication.setRessource(getValueFromChildElement(node, "ressource"));

        return publication;
    }
    
}
