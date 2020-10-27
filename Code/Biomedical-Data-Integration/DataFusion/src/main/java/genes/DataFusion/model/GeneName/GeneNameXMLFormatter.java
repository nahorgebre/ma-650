package genes.DataFusion.model.GeneName;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLFormatter;

import org.w3c.dom.Document;
import org.w3c.dom.Element;

public class GeneNameXMLFormatter extends XMLFormatter<GeneName> {

    @Override
    public Element createRootElement(Document doc) {
        return doc.createElement("geneNames");
    }

    @Override
    public Element createElementFromRecord(GeneName record, Document doc) {
        Element geneName = doc.createElement("geneNames");
       
        if(record.getName()!=null) {
            geneName.appendChild(createTextElement("name", record.getName(), doc));
        }

        return geneName;
    }

}