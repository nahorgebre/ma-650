package genes.IdentityResolution.model;

import org.w3c.dom.Document;
import org.w3c.dom.Element;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLFormatter;

public class DiseaseXMLFormatter extends XMLFormatter<Disease> {

    @Override
    public Element createRootElement(Document doc) {
        return doc.createElement("diseases");
    }

    @Override
    public Element createElementFromRecord(Disease record, Document doc) {
        Element disease = doc.createElement("disease");

        disease.appendChild(createTextElement("diseaseId", record.getDiseaseId(), doc));
        disease.appendChild(createTextElement("diseaseName", record.getDiseaseName(), doc));
        disease.appendChild(createTextElement("diseaseType", record.getDiseaseType(), doc));
        disease.appendChild(createTextElement("diseaseClass", record.getDiseaseClass(), doc));
        disease.appendChild(createTextElement("diseaseSemanticType", record.getDiseaseSemanticType(), doc));
        disease.appendChild(createTextElement("score", record.getScore(), doc));
        disease.appendChild(createTextElement("ei", record.getEi(), doc));
        disease.appendChild(createTextElement("yearInitial", record.getYearInitial(), doc));
        disease.appendChild(createTextElement("yearFinal", record.getYearFinal(), doc));
        disease.appendChild(createTextElement("pmid", record.getPmid(), doc));
        disease.appendChild(createTextElement("source", record.getSource(), doc));

        return disease;
    }
}
