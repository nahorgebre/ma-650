package genes.IdentityResolution.model;

import org.w3c.dom.Document;
import org.w3c.dom.Element;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLFormatter;

public class OrganXMLFormatter extends XMLFormatter<Organ> {

    @Override
    public Element createRootElement(Document doc) {
        return doc.createElement("organs");
    }

    @Override
    public Element createElementFromRecord(Organ record, Document doc) {
        Element organ = doc.createElement("organ");

        organ.appendChild(createTextElement("organName", record.getOrganName(), doc));
        organ.appendChild(createTextElement("disagreement", record.getDisagreement(), doc));
        organ.appendChild(createTextElement("probEqualOrthoAdj", record.getProbEqualOrthoAdj(), doc));
        organ.appendChild(createTextElement("call", record.getCall(), doc));

        return organ;
    }
    
}
