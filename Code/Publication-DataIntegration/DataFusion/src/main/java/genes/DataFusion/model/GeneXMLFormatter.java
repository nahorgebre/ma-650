package genes.DataFusion.model;

import org.w3c.dom.Document;
import org.w3c.dom.Element;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLFormatter;

public class GeneXMLFormatter extends XMLFormatter<Gene> 
{
    @Override
    public Element createRootElement(Document doc) 
    {
        return doc.createElement("genes");
    }

    @Override
    public Element createElementFromRecord(Gene record, Document doc) 
    {
        Element gene = doc.createElement("gene");

        gene.appendChild(createTextElement("ncbiId", record.getNcbiId(), doc));

        return gene;
    }
}