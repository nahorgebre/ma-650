package genes.IdentityResolution.model.Gene;

import org.w3c.dom.Document;
import org.w3c.dom.Element;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLFormatter;
import genes.IdentityResolution.model.Disease.Disease;
import genes.IdentityResolution.model.Disease.DiseaseXMLFormatter;
import genes.IdentityResolution.model.GeneDescription.GeneDescription;
import genes.IdentityResolution.model.GeneDescription.GeneDescriptionXMLFormatter;
import genes.IdentityResolution.model.GeneName.GeneName;
import genes.IdentityResolution.model.GeneName.GeneNameXMLFormatter;
import genes.IdentityResolution.model.Organ.Organ;
import genes.IdentityResolution.model.Organ.OrganXMLFormatter;
import genes.IdentityResolution.model.Patent.Patent;
import genes.IdentityResolution.model.Patent.PatentXMLFormatter;
import genes.IdentityResolution.model.Publication.Publication;
import genes.IdentityResolution.model.Publication.PublicationXMLFormatter;

public class GeneXMLFormatter extends XMLFormatter<Gene> {

    GeneNameXMLFormatter geneNameFormatter = new GeneNameXMLFormatter();
    GeneDescriptionXMLFormatter geneDescriptionFormatter = new GeneDescriptionXMLFormatter();

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
        gene.appendChild(createGeneNamesElement(record, doc));
        gene.appendChild(createGeneDescriptionsElement(record, doc));
        
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

    protected Element createGeneNamesElement(Gene record, Document doc) {
        Element geneNameRoot = geneNameFormatter.createRootElement(doc);
        for (GeneName a : record.getGeneNames()) {
            geneNameRoot.appendChild(geneNameFormatter.createElementFromRecord(a, doc));
        }
        return geneNameRoot;
    }

    protected Element createGeneDescriptionsElement(Gene record, Document doc) {
        Element geneDescriptionRoot = geneDescriptionFormatter.createRootElement(doc);
        for (GeneDescription a : record.getGeneDescriptions()) {
            geneDescriptionRoot.appendChild(geneDescriptionFormatter.createElementFromRecord(a, doc));
        }
        return geneDescriptionRoot;
    }

    protected Element createOrganElement(Gene record, Document doc) {
        Element organRoot = organFormatter.createRootElement(doc);
        for (Organ a : record.getOrgans()) {
            organRoot.appendChild(organFormatter.createElementFromRecord(a, doc));
        }
        return organRoot;
    }

}