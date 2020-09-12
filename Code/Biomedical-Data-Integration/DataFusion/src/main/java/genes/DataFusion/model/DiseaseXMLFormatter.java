package genes.DataFusion.model;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLFormatter;
import org.w3c.dom.Document;
import org.w3c.dom.Element;

public class DiseaseXMLFormatter extends XMLFormatter<Disease> {

    @Override
    public Element createRootElement(Document doc) {
        return doc.createElement("diseaseAssociations");
    }

    @Override
    public Element createElementFromRecord(Disease record, Document doc) {
        Element disease = doc.createElement("diseaseAssociation");

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
        
        if(record.getDiseaseName()!=null) {
            disease.appendChild(createTextElement("diseaseName", record.getDiseaseName(), doc));
        }

        if(record.getDiseaseType()!=null) {
            disease.appendChild(createTextElement("diseaseType", record.getDiseaseType(), doc));
        }

        if(record.getDiseaseClass()!=null) {
            disease.appendChild(createTextElement("diseaseClass", record.getDiseaseClass(), doc));
        }

        if(record.getDiseaseSemanticType()!=null) {
            disease.appendChild(createTextElement("diseaseSemanticType", record.getDiseaseSemanticType(), doc));
        }

        if(record.getScore()!=null) {
            disease.appendChild(createTextElement("score", record.getScore(), doc));
        }

        if(record.getEi()!=null) {
            disease.appendChild(createTextElement("ei", record.getEi(), doc));
        }

        if(record.getYearInitial()!=null) {
            disease.appendChild(createTextElement("yearInitial", record.getYearInitial(), doc));
        }

        if(record.getYearFinal()!=null) {
            disease.appendChild(createTextElement("yearFinal", record.getYearFinal(), doc));
        }

        if(record.getPmid()!=null) {
            disease.appendChild(createTextElement("pmid", record.getPmid(), doc));
        }

        if(record.getSource()!=null) {
            disease.appendChild(createTextElement("source", record.getSource(), doc));
        }

        return disease;
    }
}
