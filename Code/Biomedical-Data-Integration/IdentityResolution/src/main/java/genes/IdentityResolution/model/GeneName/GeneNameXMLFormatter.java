package genes.IdentityResolution.model.GeneName;

import org.w3c.dom.Document;
import org.w3c.dom.Element;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLFormatter;

public class GeneNameXMLFormatter extends XMLFormatter<GeneName> {

    @Override
    public Element createRootElement(Document doc) {
        return doc.createElement("geneNames");
    }

    @Override
    public Element createElementFromRecord(GeneName record, Document doc) {
        Element geneName = doc.createElement("geneNames");

        geneName.appendChild(createTextElement("name", record.getName(), doc));
    
        return geneName;
    }
}
