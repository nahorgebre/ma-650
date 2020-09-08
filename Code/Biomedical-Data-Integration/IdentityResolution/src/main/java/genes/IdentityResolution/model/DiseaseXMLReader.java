package genes.IdentityResolution.model;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLMatchableReader;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import org.w3c.dom.Node;

public class DiseaseXMLReader extends XMLMatchableReader<Disease, Attribute> {

    @Override
    public Disease createModelFromElement(Node node, String provenanceInfo) {
        String id = getValueFromChildElement(node, "id");

        Disease disease = new Disease(id, provenanceInfo);

        disease.setDiseaseIdUMLS(getValueFromChildElement(node, "diseaseIdUMLS"));
        disease.setDiseaseName(getValueFromChildElement(node, "diseaseName"));
        disease.setDiseaseSpecificityIndex(getValueFromChildElement(node, "diseaseSpecificityIndex"));
        disease.setDiseasePleiotropyIndex(getValueFromChildElement(node, "diseasePleiotropyIndex"));
        disease.setDiseaseTypeDisGeNET(getValueFromChildElement(node, "diseaseTypeDisGeNET"));
        disease.setDiseaseClassMeSH(getValueFromChildElement(node, "diseaseClassMeSH"));
        disease.setDiseaseSemanticTypeUMLS(getValueFromChildElement(node, "diseaseSemanticTypeUMLS"));
        disease.setAssociationScore(getValueFromChildElement(node, "associationScore"));
        disease.setEvidenceIndex(getValueFromChildElement(node, "evidenceIndex"));
        disease.setYearInitialReport(getValueFromChildElement(node, "yearInitialReport"));
        disease.setYearFinalReport(getValueFromChildElement(node, "yearFinalReport"));
        disease.setPmId(getValueFromChildElement(node, "pmId"));
        disease.setSource(getValueFromChildElement(node, "source"));

        return disease;
    }
}
