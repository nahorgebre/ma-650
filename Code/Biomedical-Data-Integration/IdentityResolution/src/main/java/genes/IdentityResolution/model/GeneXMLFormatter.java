package genes.IdentityResolution.model;

import org.w3c.dom.Document;
import org.w3c.dom.Element;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLFormatter;

public class GeneXMLFormatter extends XMLFormatter<Gene> {

    DiseaseXMLFormatter diseaseFormatter = new DiseaseXMLFormatter();

    @Override
    public Element createRootElement(Document doc) {
        return doc.createElement("genes");
    }

    @Override
    public Element createElementFromRecord(Gene record, Document doc) {
        Element movie = doc.createElement("gene");

        movie.appendChild(createTextElement("id", record.getIdentifier(), doc));
        movie.appendChild(createTextElement("geneId", record.getGeneId(), doc));
        movie.appendChild(createTextElement("geneName", record.getGeneName(), doc));
        movie.appendChild(createTextElement("geneDescription", record.getGeneDescription(), doc));
        movie.appendChild(createTextElement("disagreement", record.getDisagreement(), doc));
        movie.appendChild(createTextElement("call", record.getCall(), doc));
        movie.appendChild(createTextElement("ncbiId", record.getNcbiId(), doc));
        movie.appendChild(createTextElement("dsi", record.getDsi(), doc));
        movie.appendChild(createTextElement("dpi", record.getDpi(), doc));

        movie.appendChild(createDiseasesElement(record, doc));

        return movie;
    }

    protected Element createTextElementWithProvenance(String name, String value, String provenance, Document doc) {
        Element elem = createTextElement(name, value, doc);
        elem.setAttribute("provenance", provenance);
        return elem;
    }

    protected Element createDiseasesElement(Gene record, Document doc) {
        Element diseaseRoot = diseaseFormatter.createRootElement(doc);
        for (Disease a : record.getDiseases()) {
            diseaseRoot.appendChild(diseaseFormatter.createElementFromRecord(a, doc));
        }
        return diseaseRoot;
    }
}
