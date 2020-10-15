package genes.IdentityResolution.modelSAX2;

import java.io.File;
import java.io.IOException;
import java.util.List;

import javax.xml.parsers.ParserConfigurationException;
import javax.xml.parsers.SAXParser;
import javax.xml.parsers.SAXParserFactory;

import org.apache.jena.base.Sys;
import org.xml.sax.SAXException;

public class ReadXMLSAXParser {

    public static void main(String[] args) {

        SAXParserFactory saxParserFactory = SAXParserFactory.newInstance();

        try {

            SAXParser saxParser = saxParserFactory.newSAXParser();
            GeneHandler handler = new GeneHandler();
            saxParser.parse(new File("src/main/java/genes/IdentityResolution/modelSAX2/sax_users.xml"), handler);
            
            // Get Users list
            List <Gene> geneList = handler.getGeneList();
            
            // print user information
            for (Gene gene: geneList) {
                System.out.println(gene);
            }
                     
        } catch (ParserConfigurationException | SAXException | IOException e) {
            e.printStackTrace();
        }
    }
}
