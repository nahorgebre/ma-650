package genes.DataFusion.model;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLFormatter;
import org.w3c.dom.Document;
import org.w3c.dom.Element;

public class OrganXMLFormatter extends XMLFormatter<Organ> {

    @Override
    public Element createRootElement(Document doc) {
        return doc.createElement("organs");
    }

    @Override
    public Element createElementFromRecord(Organ record, Document doc) {
        Element organ = doc.createElement("organs");

        organ.appendChild(createTextElement("organName", record.getOrganName(), doc));
        organ.appendChild(createTextElement("disagreement", record.getDisagreement(), doc));
        organ.appendChild(createTextElement("probEqualOrthoAdj", record.getProbEqualOrthoAdj(), doc));
        organ.appendChild(createTextElement("call", record.getCall(), doc));
        
        if(record.getOrganName()!=null) {
            publication.appendChild(createTextElement("organName", record.getPmId(), doc));
        }

        if(record.getDisagreement()!=null) {
            organ.appendChild(createTextElement("disagreement", record.getRessource(), doc));
        }

        if(record.getProbEqualOrthoAdj()!=null) {
            organ.appendChild(createTextElement("probEqualOrthoAdj", record.getRessource(), doc));
        }

        if(record.getCall()!=null) {
            organ.appendChild(createTextElement("call", record.getRessource(), doc));
        }

        return organ;
    }

}