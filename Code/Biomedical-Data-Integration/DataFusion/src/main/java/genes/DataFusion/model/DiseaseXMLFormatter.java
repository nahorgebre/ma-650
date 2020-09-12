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

        if(record.getDiseaseSpecificityIndex()!=null) {
            disease.appendChild(createTextElement("diseaseSpecificityIndex", record.getDiseaseSpecificityIndex(), doc));
        }

        if(record.getDiseasePleiotropyIndex()!=null) {
            disease.appendChild(createTextElement("diseasePleiotropyIndex", record.getDiseasePleiotropyIndex(), doc));
        }

        if(record.getDiseaseTypeDisGeNET()!=null) {
            disease.appendChild(createTextElement("diseaseTypeDisGeNET", record.getDiseaseTypeDisGeNET(), doc));
        }

        if(record.getDiseaseClassMeSH()!=null) {
            disease.appendChild(createTextElement("diseaseClassMeSH", record.getDiseaseClassMeSH(), doc));
        }

        if(record.getDiseaseSemanticTypeUMLS()!=null) {
            disease.appendChild(createTextElement("diseaseSemanticTypeUMLS", record.getDiseaseSemanticTypeUMLS(), doc));
        }

        if(record.getAssociationScore()!=null) {
            disease.appendChild(createTextElement("associationScore", record.getAssociationScore(), doc));
        }

        if(record.getEvidenceIndex()!=null) {
            disease.appendChild(createTextElement("evidenceIndex", record.getEvidenceIndex(), doc));
        }

        if(record.getYearInitialReport()!=null) {
            disease.appendChild(createTextElement("yearInitialReport", record.getYearInitialReport(), doc));
        }

        if(record.getYearFinalReport()!=null) {
            disease.appendChild(createTextElement("yearFinalReport", record.getYearFinalReport(), doc));
        }

        if(record.getPmId()!=null) {
            disease.appendChild(createTextElement("pmId", record.getPmId(), doc));
        }

        if(record.getSource()!=null) {
            disease.appendChild(createTextElement("source", record.getSource(), doc));
        }

        return disease;
    }
}
