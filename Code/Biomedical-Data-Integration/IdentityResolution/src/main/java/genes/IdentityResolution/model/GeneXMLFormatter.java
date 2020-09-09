package genes.IdentityResolution.model;

import org.w3c.dom.Document;
import org.w3c.dom.Element;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLFormatter;

public class GeneXMLFormatter extends XMLFormatter<Gene> {

    GeneNameXMLFormatter geneNameFormatter = new GeneNameXMLFormatter();
    DiseaseXMLFormatter diseaseFormatter = new DiseaseXMLFormatter();
    PatentXMLFormatter patentFormatter = new PatentXMLFormatter();
    PublicationXMLFormatter publicationFormatter = new PublicationXMLFormatter();

    @Override
    public Element createRootElement(Document doc) {
        return doc.createElement("genes");
    }

    @Override
    public Element createElementFromRecord(Gene record, Document doc) {
        Element gene = doc.createElement("gene");

        gene.appendChild(createTextElement("recordId", record.getIdentifier(), doc));
        gene.appendChild(createTextElement("ensemblId", record.getEnsemblId(), doc));

        gene.appendChild(createGeneNamesElement(record, doc));

        gene.appendChild(createTextElement("geneDescription", record.getGeneDescription(), doc));
        gene.appendChild(createTextElement("disagreement", record.getDisagreement(), doc));
        gene.appendChild(createTextElement("probEqualOrthoAdj", record.getProbEqualOrthoAdj(), doc));
        gene.appendChild(createTextElement("call", record.getCall(), doc));
        gene.appendChild(createTextElement("ncbiId", record.getNcbiId(), doc));

        gene.appendChild(createDiseasesElement(record, doc));
        gene.appendChild(createPublicationsElement(record, doc));
        gene.appendChild(createPatentsElement(record, doc));

        return gene;
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

    protected Element createPublicationsElement(Gene record, Document doc) {
        Element publicationRoot = publicationFormatter.createRootElement(doc);
        for (Publication a : record.getPublications()) {
            publicationRoot.appendChild(publicationFormatter.createElementFromRecord(a, doc));
        }
        return publicationRoot;
    }

    protected Element createPatentsElement(Gene record, Document doc) {
        Element patentRoot = patentFormatter.createRootElement(doc);
        for (Patent a : record.getPatents()) {
            patentRoot.appendChild(patentFormatter.createElementFromRecord(a, doc));
        }
        return patentRoot;
    }

    protected Element createGeneNamesElement(Gene record, Document doc) {
        Element geneNameRoot = geneNameFormatter.createRootElement(doc);
        for (GeneName a : record.getGeneNames()) {
            geneNameRoot.appendChild(geneNameFormatter.createElementFromRecord(a, doc));
        }
        return geneNameRoot;
    }
}
