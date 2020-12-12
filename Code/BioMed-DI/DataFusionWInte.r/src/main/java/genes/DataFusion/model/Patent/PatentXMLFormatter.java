package genes.DataFusion.model.Patent;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLFormatter;

import org.w3c.dom.Document;
import org.w3c.dom.Element;

public class PatentXMLFormatter extends XMLFormatter<Patent> {

    @Override
    public Element createRootElement(Document doc) {

        return doc.createElement("patentMentions");

    }

    @Override
    public Element createElementFromRecord(Patent record, Document doc) {

        Element patent = doc.createElement("patentMention");
       
        if(record.getPatentId()!=null) {

            patent.appendChild(createTextElement("patentId", record.getPatentId(), doc));

        }

        if(record.getPatentDate()!=null) {

            patent.appendChild(createTextElement("patentDate", record.getPatentDate(), doc));

        }

        if(record.getPatentClaimsCount()!=null) {

            patent.appendChild(createTextElement("patentClaimsCount", record.getPatentClaimsCount(), doc));

        }

        return patent;

    }

}