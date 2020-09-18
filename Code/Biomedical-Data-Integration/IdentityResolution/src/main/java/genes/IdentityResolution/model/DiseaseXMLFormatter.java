package genes.IdentityResolution.model;

import org.w3c.dom.Document;
import org.w3c.dom.Element;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLFormatter;

public class DiseaseXMLFormatter extends XMLFormatter<Disease> {

    @Override
    public Element createRootElement(Document doc) {
        return doc.createElement("diseaseAssociations");
    }

    @Override
    public Element createElementFromRecord(Disease record, Document doc) {
        Element disease = doc.createElement("diseaseAssociations");

        disease.appendChild(createTextElement("diseaseIdUMLS", record.getDiseaseIdUMLS(), doc));
        disease.appendChild(createTextElement("diseaseName", record.getDiseaseName(), doc));
        disease.appendChild(createTextElement("diseaseSpecificityIndex", record.getDiseaseSpecificityIndex(), doc));
        disease.appendChild(createTextElement("diseasePleiotropyIndex", record.getDiseasePleiotropyIndex(), doc));
        disease.appendChild(createTextElement("diseaseTypeDisGeNET", record.getDiseaseTypeDisGeNET(), doc));
        disease.appendChild(createTextElement("diseaseClassMeSH", record.getDiseaseClassMeSH(), doc));
        disease.appendChild(createTextElement("diseaseSemanticTypeUMLS", record.getDiseaseSemanticTypeUMLS(), doc));
        disease.appendChild(createTextElement("associationScore", record.getAssociationScore(), doc));
        disease.appendChild(createTextElement("evidenceIndex", record.getEvidenceIndex(), doc));
        disease.appendChild(createTextElement("yearInitialReport", record.getYearInitialReport(), doc));
        disease.appendChild(createTextElement("yearFinalReport", record.getYearFinalReport(), doc));
        disease.appendChild(createTextElement("pmId", record.getPmId(), doc));
        disease.appendChild(createTextElement("source", record.getSource(), doc));

        return disease;
    }
}
