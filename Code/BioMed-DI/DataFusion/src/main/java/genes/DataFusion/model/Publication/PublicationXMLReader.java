package genes.DataFusion.model.Publication;

import org.w3c.dom.Node;

import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.model.io.XMLMatchableReader;

public class PublicationXMLReader extends XMLMatchableReader<Publication, Attribute> {

    @Override
    public Publication createModelFromElement(Node node, String provenanceInfo) {
        String recordId = getValueFromChildElement(node, "recordId");

        Publication publication = new Publication(recordId, provenanceInfo);

        publication.setPmId(getValueFromChildElement(node, "pmId"));
        publication.setYear(getValueFromChildElement(node, "year"));
        publication.setRessource(getValueFromChildElement(node, "ressource"));

        return publication;
    }

}