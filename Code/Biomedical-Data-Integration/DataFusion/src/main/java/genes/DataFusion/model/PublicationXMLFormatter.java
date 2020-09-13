package genes.DataFusion.model;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLFormatter;
import org.w3c.dom.Document;
import org.w3c.dom.Element;

public class PublicationXMLFormatter extends XMLFormatter<Publication> {

    @Override
    public Element createRootElement(Document doc) {
        return doc.createElement("publicationMentions");
    }

    @Override
    public Element createElementFromRecord(Publication record, Document doc) {
        Element publication = doc.createElement("publicationMention");

        publication.appendChild(createTextElement("pmId", record.getPmId(), doc));
        publication.appendChild(createTextElement("ressource", record.getRessource(), doc));
        
        if(record.getPmId()!=null) {
            publication.appendChild(createTextElement("pmId", record.getPmId(), doc));
        }

        if(record.getRessource()!=null) {
            publication.appendChild(createTextElement("ressource", record.getRessource(), doc));
        }

        return publication;
    }

}