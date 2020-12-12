package genes.DataFusion.model.Gene;

import org.w3c.dom.Document;
import org.w3c.dom.Element;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLFormatter;

import genes.DataFusion.model.Disease.Disease;
import genes.DataFusion.model.Disease.DiseaseXMLFormatter;
import genes.DataFusion.model.Organ.Organ;
import genes.DataFusion.model.Organ.OrganXMLFormatter;
import genes.DataFusion.model.Patent.Patent;
import genes.DataFusion.model.Patent.PatentXMLFormatter;
import genes.DataFusion.model.Publication.Publication;
import genes.DataFusion.model.Publication.PublicationXMLFormatter;

public class GeneXMLFormatter extends XMLFormatter<Gene> {

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

        gene.appendChild(createTextElementWithProvenance("geneDescriptions",
                record.getGeneDescriptions(),
                record.getMergedAttributeProvenance(Gene.GENEDESCRIPTIONS), doc));

        gene.appendChild(createTextElementWithProvenance("geneNames",
                record.getGeneNames(),
                record.getMergedAttributeProvenance(Gene.GENENAMES), doc));

        gene.appendChild(createTextElementWithProvenance("overallCall",
                record.getOverallCall(),
                record.getMergedAttributeProvenance(Gene.OVERALLCALL), doc));

        gene.appendChild(createTextElementWithProvenance("overallDiseaseAssociation",
                record.getOverallDiseaseAssociation(),
                record.getMergedAttributeProvenance(Gene.OVERALLDISEASEASSOCIATION), doc));

        gene.appendChild(createTextElementWithProvenance("firstPublicationYear",
                record.getFirstPublicationYear(),
                record.getMergedAttributeProvenance(Gene.FIRSTPUBLICATIONYEAR), doc));

        gene.appendChild(createTextElementWithProvenance("frequencyPatent",
                record.getFrequencyPatent(),
                record.getMergedAttributeProvenance(Gene.FREQUENCYPATENT), doc));

        gene.appendChild(createTextElementWithProvenance("frequencyPatentTitle",
                record.getFrequencyPatentTitle(),
                record.getMergedAttributeProvenance(Gene.FREQUENCYPATENTTITLE), doc));

        gene.appendChild(createTextElementWithProvenance("frequencyPatentAbstract",
                record.getFrequencyPatentAbstract(),
                record.getMergedAttributeProvenance(Gene.FREQUENCYPATENTABSTRACT), doc));

        gene.appendChild(createTextElementWithProvenance("frequencyPatentDescription",
                record.getFrequencyPatentDescription(),
                record.getMergedAttributeProvenance(Gene.FREQUENCYPATENTDESCRIPTION), doc));

        gene.appendChild(createTextElementWithProvenance("frequencyPatentClaims",
                record.getFrequencyPatentClaims(),
                record.getMergedAttributeProvenance(Gene.FREQUENCYPATENTCLAIMS), doc));
        
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