package genes.DataFusion.model;

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
        Element gene = doc.createElement("gene");

        gene.appendChild(createTextElement("recordId",
                record.getIdentifier(),
                doc));

        gene.appendChild(createTextElementWithProvenance("ensemblId",
                record.getEnsemblId(),
                record.getMergedAttributeProvenance(Gene.ENSEMBLID), doc));

        gene.appendChild(createTextElementWithProvenance("geneName",
                record.getGeneName(),
                record.getMergedAttributeProvenance(Gene.GENENAME), doc));

        gene.appendChild(createTextElementWithProvenance("geneDescription",
                record.getGeneDescription(),
                record.getMergedAttributeProvenance(Gene.GENEDESCRIPTION), doc));

        gene.appendChild(createTextElementWithProvenance("disagreement",
                record.getDisagreement(),
                record.getMergedAttributeProvenance(Gene.DISAGREEMENT), doc));

        gene.appendChild(createTextElementWithProvenance("probEqualOrthoAdj",
                record.getProbEqualOrthoAdj(),
                record.getMergedAttributeProvenance(Gene.PROBEQUALORTHOADJ), doc));

        gene.appendChild(createTextElementWithProvenance("call",
                record.getCall(),
                record.getMergedAttributeProvenance(Gene.CALL), doc));

        gene.appendChild(createTextElementWithProvenance("ncbiId",
                record.getNcbiId(),
                record.getMergedAttributeProvenance(Gene.NCBIID), doc));

        gene.appendChild(createDiseasesElement(record, doc));

        return gene;
    }

    protected Element createTextElementWithProvenance(String name, String value, String provenance, Document doc) {
        Element elem = createTextElement(name, value, doc);
        elem.setAttribute("provenance", provenance);
        return elem;
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
