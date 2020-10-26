package genes.IdentityResolution.AWS;

import java.io.IOException;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;

import com.amazonaws.auth.AWSCredentials;
import com.amazonaws.auth.BasicAWSCredentials;

import org.w3c.dom.Document;
import org.w3c.dom.Node;
import org.xml.sax.SAXException;

import javax.xml.xpath.XPath;
import javax.xml.xpath.XPathConstants;
import javax.xml.xpath.XPathExpression;
import javax.xml.xpath.XPathExpressionException;
import javax.xml.xpath.XPathFactory;

public class Credentials {

    public static AWSCredentials getCredentials() throws ParserConfigurationException, SAXException, IOException, XPathExpressionException {

        DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
        DocumentBuilder builder = factory.newDocumentBuilder();
        String xmlFileName = System.getProperty("user.dir") + "/credentials.config";
        Document doc = builder.parse(xmlFileName);

        XPathFactory xPathFactory = XPathFactory.newInstance();
        XPath xPath = xPathFactory.newXPath();

        XPathExpression exprAccessKey = xPath.compile("/credentials/accessKey");
        XPathExpression exprSecretKey = xPath.compile("/credentials/secretKey");

        Node nodeAccessKey = (Node) exprAccessKey.evaluate(doc, XPathConstants.NODE);
        Node nodeSecretKey = (Node) exprSecretKey.evaluate(doc, XPathConstants.NODE);

        String accesskey = nodeAccessKey.getTextContent();
        String secretkey = nodeSecretKey.getTextContent();
        
        AWSCredentials credentials = new BasicAWSCredentials(
            accesskey, 
            secretkey
        );

        return credentials;
    }
    
}
