package genes.IdentityResolution.model;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLMatchableReader;

import org.w3c.dom.Node;

import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

public class DiseaseXMLReader extends XMLMatchableReader<Disease, Attribute> {

    @Override
    public Disease createModelFromElement(Node node, String provenanceInfo) {
        String id = getValueFromChildElement(node, "id");

        Disease disease = new Disease(id, provenanceInfo);

        disease.setDiseaseId(getValueFromChildElement(node, "diseaseId"));
        disease.setDiseaseName(getValueFromChildElement(node, "diseaseName"));
        disease.setDiseaseType(getValueFromChildElement(node, "diseaseType"));
        disease.setDiseaseClass(getValueFromChildElement(node, "diseaseClass"));
        disease.setDiseaseSemanticType(getValueFromChildElement(node, "diseaseSemanticType"));
        disease.setScore(getValueFromChildElement(node, "score"));
        disease.setEi(getValueFromChildElement(node, "ei"));
        disease.setYearInitial(getValueFromChildElement(node, "yearInitial"));
        disease.setYearFinal(getValueFromChildElement(node, "yearFinal"));
        disease.setPmid(getValueFromChildElement(node, "pmid"));
        disease.setSource(getValueFromChildElement(node, "source"));

        return disease;
    }
}
