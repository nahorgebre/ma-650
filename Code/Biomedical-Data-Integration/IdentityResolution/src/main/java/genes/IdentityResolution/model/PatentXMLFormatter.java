package genes.IdentityResolution.model;

import org.w3c.dom.Document;
import org.w3c.dom.Element;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLFormatter;

public class PatentXMLFormatter extends XMLFormatter<Patent> {
    
    @Override
    public Element createRootElement(Document doc) {
        return doc.createElement("patentMentions");
    }

    @Override
    public Element createElementFromRecord(Patent record, Document doc) {
        Element patent = doc.createElement("patentMentions");

        patent.appendChild(createTextElement("patentId", record.getPatentId(), doc));
        patent.appendChild(createTextElement("patentDate", record.getPatentDate(), doc));
        patent.appendChild(createTextElement("patentClaimsCount", record.getPatentClaimsCount(), doc));

        return patent;
    }

}
