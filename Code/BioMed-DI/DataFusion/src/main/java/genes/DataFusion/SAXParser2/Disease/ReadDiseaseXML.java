package genes.DataFusion.SAXParser2.Disease;

import java.io.StringReader;
import java.util.ArrayList;
import java.util.List;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.xml.sax.InputSource;

public class ReadDiseaseXML {

    public static List<Disease> getDiseaseList(String xml) {

        try {

            Document doc = loadXMLFromString(xml);

            doc.getDocumentElement().normalize();
    
            NodeList nodeList = doc.getElementsByTagName("diseaseAssociation");
    
            List<Disease> diseaseList = new ArrayList<Disease>();
    
            for (int i = 0; i < nodeList.getLength(); i++) {
    
                diseaseList.add(getDisease(nodeList.item(i)));
    
            }
    
            return diseaseList;
         
        } catch (Exception e) {

            List<Disease> diseaseList = new ArrayList<Disease>();
            
            return diseaseList;

        }

    }

    private static Disease getDisease(Node node) {

        Disease disease = new Disease();

        if (node.getNodeType() == Node.ELEMENT_NODE) {

            Element element = (Element) node;

            disease.setDiseaseName(getTagValue("diseaseName", element));

            disease.setDiseaseSpecificityIndex(getTagValue("diseaseSpecificityIndex", element));

            disease.setDiseasePleiotropyIndex(getTagValue("diseasePleiotropyIndex", element));

            disease.setDiseaseTypeDisGeNET(getTagValue("diseaseTypeDisGeNET", element));

            disease.setDiseaseClassMeSH(getTagValue("diseaseClassMeSH", element));

            disease.setDiseaseSemanticTypeUMLS(getTagValue("diseaseSemanticTypeUMLS", element));

            disease.setAssociationScore(getTagValue("associationScore", element));

            disease.setEvidenceIndex(getTagValue("evidenceIndex", element));

            disease.setYearInitialReport(getTagValue("yearInitialReport", element));

            disease.setYearFinalReport(getTagValue("yearFinalReport", element));

            disease.setPmId(getTagValue("pmId", element));

            disease.setSource(getTagValue("source", element));

        }

        return disease;

    }

    private static String getTagValue(String tag, Element element) {

        NodeList nodeList = element.getElementsByTagName(tag).item(0).getChildNodes();

        Node node = (Node) nodeList.item(0);

        return node.getNodeValue();

    }

    public static Document loadXMLFromString(String xml) throws Exception {

        DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();

        DocumentBuilder builder = factory.newDocumentBuilder();

        InputSource is = new InputSource(new StringReader(xml));

        return builder.parse(is);

    }

}