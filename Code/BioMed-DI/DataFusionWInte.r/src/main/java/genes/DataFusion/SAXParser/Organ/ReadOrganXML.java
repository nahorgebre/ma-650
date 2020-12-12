package genes.DataFusion.SAXParser.Organ;

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

public class ReadOrganXML {

    public static List<Organ> getOrganList(String xml) {

        try {

            Document doc = loadXMLFromString(xml);

            doc.getDocumentElement().normalize();
    
            NodeList nodeList = doc.getElementsByTagName("organ");
    
            List<Organ> organList = new ArrayList<Organ>();
    
            for (int i = 0; i < nodeList.getLength(); i++) {
    
                organList.add(getOrgan(nodeList.item(i)));
    
            }
    
            return organList;
         
        } catch (Exception e) {

            List<Organ> organList = new ArrayList<Organ>();
            
            return organList;

        }

    }

    private static Organ getOrgan(Node node) {

        Organ organ = new Organ();

        if (node.getNodeType() == Node.ELEMENT_NODE) {

            Element element = (Element) node;

            organ.setOrganName(getTagValue("organName", element));

            organ.setDisagreement(getTagValue("disagreement", element));

            organ.setProbEqualOrthoAdj(getTagValue("probEqualOrthoAdj", element));

            organ.setCall(getTagValue("call", element));

        }

        return organ;

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