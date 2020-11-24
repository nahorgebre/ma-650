package genes.DataFusion.SAXParser.Patent;

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

public class ReadPatentXML {

    public static List<Patent> getPatentList(String xml) {

        try {

            Document doc = loadXMLFromString(xml);

            doc.getDocumentElement().normalize();
    
            NodeList nodeList = doc.getElementsByTagName("patentMention");
    
            List<Patent> patentList = new ArrayList<Patent>();
    
            for (int i = 0; i < nodeList.getLength(); i++) {
    
                patentList.add(getPatent(nodeList.item(i)));
    
            }
    
            return patentList;
         
        } catch (Exception e) {

            List<Patent> patentList = new ArrayList<Patent>();
            
            return patentList;

        }

    }

    private static Patent getPatent(Node node) {

        Patent patent = new Patent();

        if (node.getNodeType() == Node.ELEMENT_NODE) {

            Element element = (Element) node;

            patent.setPatentId(getTagValue("patentId", element));

            patent.setPatentDate(getTagValue("patentDate", element));

            patent.setPatentClaimsCount(getTagValue("patentClaimsCount", element));

        }

        return patent;

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