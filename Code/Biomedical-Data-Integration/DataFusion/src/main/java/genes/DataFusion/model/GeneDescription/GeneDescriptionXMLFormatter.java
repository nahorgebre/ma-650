package genes.DataFusion.model.GeneDescription;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLFormatter;

import org.w3c.dom.Document;
import org.w3c.dom.Element;

public class GeneDescriptionXMLFormatter extends XMLFormatter<GeneDescription> {

    @Override
    public Element createRootElement(Document doc) {
        return doc.createElement("geneDescriptions");
    }

    @Override
    public Element createElementFromRecord(GeneDescription record, Document doc) {
        Element geneDescription = doc.createElement("geneDescriptions");

        //geneDescription.appendChild(createTextElement("description", record.getDescription(), doc));
       
        if(record.getDescription()!=null) {
            geneDescription.appendChild(createTextElement("description", record.getDescription(), doc));
        }

        return geneDescription;
    }

}