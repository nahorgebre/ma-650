package genes.IdentityResolution.model;

import org.w3c.dom.Document;
import org.w3c.dom.Element;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLFormatter;

public class PublicationXMLFormatter extends XMLFormatter<Publication> {

    @Override
    public Element createRootElement(Document doc) {
        return doc.createElement("publicationMentions");
    }

    @Override
    public Element createElementFromRecord(Publication record, Document doc) {
        Element publication = doc.createElement("publicationMentions");

        publication.appendChild(createTextElement("pmid", record.getPmId(), doc));
        publication.appendChild(createTextElement("year", record.getYear(), doc));          
        publication.appendChild(createTextElement("ressource", record.getRessource(), doc));

        return publication;
    }
    
}
