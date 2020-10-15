package genes.IdentityResolution.gene2pubtatorcentralXMLReader;

import java.util.ArrayList;
import java.util.List;

import org.apache.jena.base.Sys;
import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

public class gene2pubtatorcentralHandler extends DefaultHandler {

    public boolean hasRecordId = false;
    public boolean hasNcbiId = false;
    public boolean hasName = false;
    public boolean hasPmid = false;
    public boolean hasRessource = false;

    public List<gene2pubtatorcentral> gene2pubtatorcentralsList = null;
    public gene2pubtatorcentral gene2pubtatorcentralItem = null;

    public List<gene2pubtatorcentral> getGene2pubtatorcentralsList() {
        return gene2pubtatorcentralsList;
    }

    @Override
    public void startElement(String uri, String localName, String qName, Attributes attributes) throws SAXException {

        if (qName.equalsIgnoreCase("gene")) {

            // initialize User object and set id attribute
            gene2pubtatorcentralItem = new gene2pubtatorcentral();
            
            // initialize list
            if (gene2pubtatorcentralsList == null) {
                gene2pubtatorcentralsList = new ArrayList < > ();
            }
            
        } else if (qName.equalsIgnoreCase("recordId")) {

            hasRecordId = true;
        
        } else if (qName.equalsIgnoreCase("ncbiId")) {

            hasNcbiId = true;
        
        } else if (qName.equalsIgnoreCase("name")) {

            hasName = true;
        
        } else if (qName.equalsIgnoreCase("pmid")) {

            hasPmid = true;
        
        } else if (qName.equalsIgnoreCase("ressource")) {

            hasRessource = true;
        
        }
    }

    @Override
    public void endElement(String uri, String localName, String qName) throws SAXException {
        if (qName.equalsIgnoreCase("gene")) {

            gene2pubtatorcentralsList.add(gene2pubtatorcentralItem);

        }
    }

    @Override
    public void characters(char ch[], int start, int length) throws SAXException {

        if (hasRecordId) {

            String recordId = new String(ch, start, length);

            if (recordId != null) {
                gene2pubtatorcentralItem.setRecordId(recordId);
            }
            
            hasRecordId = false;

        } else if (hasNcbiId) {

            String ncbiId = new String(ch, start, length);

            if (ncbiId != null) {
                gene2pubtatorcentralItem.setNcbiId(ncbiId);
            }
            
            hasNcbiId = false;

        } else if (hasName) {

            String name = new String(ch, start, length);

            if (name != null) {
                gene2pubtatorcentralItem.setName(name);
            }
            
            hasName = false;

        } else if (hasPmid) {

            String pmid = new String(ch, start, length);

            if (pmid != null) {
                gene2pubtatorcentralItem.setPmid(pmid);
            }
            
            hasPmid = false;

        } else if (hasRessource) {

            String ressource = new String(ch, start, length);

            if (ressource != null) {
                gene2pubtatorcentralItem.setRessource(ressource);
            }
            
            hasRessource = false;

        }

    }
    
}