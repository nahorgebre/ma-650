package genes.DataFusion.model;

import org.w3c.dom.Document;
import org.w3c.dom.Element;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLFormatter;

public class GeneXMLFormatter extends XMLFormatter<Gene> {
  
    GeneNameXMLFormatter geneNameFormatter = new GeneNameXMLFormatter();
    GeneDescriptionXMLFormatter geneDescriptionFormatter = new GeneDescriptionXMLFormatter();

    OrganXMLFormatter organFormatter = new OrganXMLFormatter();
    PublicationXMLFormatter publicationFormatter = new PublicationXMLFormatter();
    PatentXMLFormatter patentFormater = new PatentXMLFormatter();
    DiseaseXMLFormatter diseaseFormatter = new DiseaseXMLFormatter();

    @Override
    public Element createRootElement(Document doc) {
        return doc.createElement("genes");
    }

    @Override
    public Element createElementFromRecord(Gene record, Document doc) {
        Element gene = doc.createElement("gene");

        gene.appendChild(createTextElement("recordId",
                record.getIdentifier(),
                doc));
        gene.appendChild(createTextElementWithProvenance("ensemblId",
                record.getEnsemblId(),
                record.getMergedAttributeProvenance(Gene.ENSEMBLID), doc));
        gene.appendChild(createTextElementWithProvenance("ncbiId",
                record.getNcbiId(),
                record.getMergedAttributeProvenance(Gene.NCBIID), doc));
        gene.appendChild(createGeneDescriptionElement(record, doc));
        gene.appendChild(createGeneNameElement(record, doc));

        gene.appendChild(createOrganElement(record, doc));
        gene.appendChild(createPublicationMentionElement(record, doc));
        gene.appendChild(createPatentMentionElement(record, doc));
        gene.appendChild(createDiseasesElement(record, doc));

        return gene;
    }

    protected Element createTextElementWithProvenance(String name, String value, String provenance, Document doc) {
        Element elem = createTextElement(name, value, doc);
        elem.setAttribute("provenance", provenance);
        return elem;
    }

    protected Element createGeneNameElement(Gene record, Document doc) {
        Element geneNamesRoot = geneNameFormatter.createRootElement(doc);
        geneNamesRoot.setAttribute("provenance",
                record.getMergedAttributeProvenance(Gene.GENENAMES));

        for (GeneName a : record.getGeneNames()) {
                geneNamesRoot.appendChild(geneNameFormatter.createElementFromRecord(a, doc));
        }

        return geneNamesRoot;
    }

    protected Element createGeneDescriptionElement(Gene record, Document doc) {
        Element geneDescriptionsRoot = geneDescriptionFormatter.createRootElement(doc);
        geneDescriptionsRoot.setAttribute("provenance",
                record.getMergedAttributeProvenance(Gene.GENEDESCRIPTIONS));

        for (GeneDescription a : record.getGeneDescriptions()) {
                geneDescriptionsRoot.appendChild(geneDescriptionFormatter.createElementFromRecord(a, doc));
        }

        return geneDescriptionsRoot;
    }

    protected Element createOrganElement(Gene record, Document doc) {
        Element organsRoot = organFormatter.createRootElement(doc);
        organsRoot.setAttribute("provenance",
                record.getMergedAttributeProvenance(Gene.ORGANS));

        for (Organ a : record.getOrgans()) {
                organsRoot.appendChild(organFormatter.createElementFromRecord(a, doc));
        }

        return organsRoot;
    }

    protected Element createPublicationMentionElement(Gene record, Document doc) {
        Element publicationMentionsRoot = publicationFormatter.createRootElement(doc);
        publicationMentionsRoot.setAttribute("provenance",
                record.getMergedAttributeProvenance(Gene.PUBLICATIONMENTIONS));

        for (Publication a : record.getPublicationMentions()) {
                publicationMentionsRoot.appendChild(publicationFormatter.createElementFromRecord(a, doc));
        }

        return publicationMentionsRoot;
    }
   
    protected Element createPatentMentionElement(Gene record, Document doc) {
        Element patentMentionsRoot = patentFormater.createRootElement(doc);
        patentMentionsRoot.setAttribute("provenance",
                record.getMergedAttributeProvenance(Gene.PATENTMENTIONS));

        for (Patent a : record.getPatentMentions()) {
                patentMentionsRoot.appendChild(patentFormater.createElementFromRecord(a, doc));
        }

        return patentMentionsRoot;
    }

    protected Element createDiseasesElement(Gene record, Document doc) {
        Element diseaseRoot = diseaseFormatter.createRootElement(doc);
        diseaseRoot.setAttribute("provenance",
                record.getMergedAttributeProvenance(Gene.DISEASEASSOCIATIONS));

        for (Disease a : record.getDiseaseAssociations()) {
            diseaseRoot.appendChild(diseaseFormatter.createElementFromRecord(a, doc));
        }

        return diseaseRoot;
    }

}