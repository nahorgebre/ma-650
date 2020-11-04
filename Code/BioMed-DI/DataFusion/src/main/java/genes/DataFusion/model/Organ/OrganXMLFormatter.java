package genes.DataFusion.model.Organ;

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

        Element organ = doc.createElement("organ");
        
        if(record.getOrganName()!=null) {

            organ.appendChild(createTextElement("organName", record.getOrganName(), doc));

        }

        if(record.getDisagreement()!=null) {

            organ.appendChild(createTextElement("disagreement", record.getDisagreement(), doc));

        }

        if(record.getProbEqualOrthoAdj()!=null) {

            organ.appendChild(createTextElement("probEqualOrthoAdj", record.getProbEqualOrthoAdj(), doc));

        }

        if(record.getCall()!=null) {

            organ.appendChild(createTextElement("call", record.getCall(), doc));

        }

        return organ;

    }

}