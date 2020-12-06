package genes.IdentityResolution.model.Gene;

import org.w3c.dom.Document;
import org.w3c.dom.Element;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLFormatter;
import genes.IdentityResolution.model.Disease.Disease;
import genes.IdentityResolution.model.Disease.DiseaseXMLFormatter;
import genes.IdentityResolution.model.Organ.Organ;
import genes.IdentityResolution.model.Organ.OrganXMLFormatter;
import genes.IdentityResolution.model.Patent.Patent;
import genes.IdentityResolution.model.Patent.PatentXMLFormatter;
import genes.IdentityResolution.model.Publication.Publication;
import genes.IdentityResolution.model.Publication.PublicationXMLFormatter;

public class GeneXMLFormatter extends XMLFormatter<Gene> {

    OrganXMLFormatter organFormatter = new OrganXMLFormatter();

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

        gene.appendChild(createTextElement("ncbiId", record.getNcbiId(), doc));

        gene.appendChild(createTextElement("geneNames", record.getGeneNames(), doc));

        gene.appendChild(createTextElement("geneDescriptions", record.getGeneDescriptions(), doc));

        gene.appendChild(createTextElement("overallCall", record.getOverallCall(), doc));

        gene.appendChild(createTextElement("firstPublicationYear", record.getFirstPublicationYear(), doc));

        gene.appendChild(createTextElement("frequencyPatent", record.getFrequencyPatent(), doc));

        gene.appendChild(createTextElement("frequencyPatentTitle", record.getFrequencyPatentTitle(), doc));

        gene.appendChild(createTextElement("frequencyPatentAbstract", record.getFrequencyPatentAbstract(), doc));

        gene.appendChild(createTextElement("frequencyPatentDescription", record.getFrequencyPatentDescription(), doc));

        gene.appendChild(createTextElement("frequencyPatentClaims", record.getFrequencyPatentClaims(), doc));
        
        gene.appendChild(createOrganElement(record, doc));

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

    protected Element createOrganElement(Gene record, Document doc) {

        Element organRoot = organFormatter.createRootElement(doc);

        for (Organ a : record.getOrgans()) {

            organRoot.appendChild(organFormatter.createElementFromRecord(a, doc));

        }

        return organRoot;
        
    }

}