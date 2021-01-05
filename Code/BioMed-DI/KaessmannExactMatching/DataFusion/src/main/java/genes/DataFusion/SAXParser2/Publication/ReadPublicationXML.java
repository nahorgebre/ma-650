package genes.DataFusion.SAXParser2.Publication;

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

public class ReadPublicationXML {

    public static List<Publication> getPublicationList(String xml) {

        try {

            Document doc = loadXMLFromString(xml);

            doc.getDocumentElement().normalize();
    
            NodeList nodeList = doc.getElementsByTagName("publicationMention");
    
            List<Publication> publicationList = new ArrayList<Publication>();
    
            for (int i = 0; i < nodeList.getLength(); i++) {
    
                publicationList.add(getPublication(nodeList.item(i)));
    
            }
    
            return publicationList;
         
        } catch (Exception e) {

            List<Publication> publicationList = new ArrayList<Publication>();
            
            return publicationList;

        }

    }

    private static Publication getPublication(Node node) {

        Publication publication = new Publication();

        if (node.getNodeType() == Node.ELEMENT_NODE) {

            Element element = (Element) node;

            publication.setPmId(getTagValue("pmId", element));

            publication.setYear(getTagValue("year", element));
            
            publication.setRessource(getTagValue("ressource", element));

        }

        return publication;

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