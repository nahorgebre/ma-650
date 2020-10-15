package genes.IdentityResolution.modelSAX;

import java.util.ArrayList;
import java.util.List;

import org.apache.jena.base.Sys;
import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

public class GeneHandler extends DefaultHandler {

    private boolean hasFirstName = false;
    private boolean hasLastName = false;
    private boolean hasAge = false;
    private boolean hasGender = false;

    private boolean hasyvalue = false;

    private List <Gene> geneList = null;
    private Gene gene = null;

    public List <Gene> getGeneList() {
        return geneList;
    }

    @Override
    public void startElement(String uri, String localName, String qName, Attributes attributes) throws SAXException {

        if (qName.equalsIgnoreCase("User")) {

            // create a new User and put it in Map
            String id = attributes.getValue("id");

            // initialize User object and set id attribute
            gene = new Gene();
            gene.setId(Integer.parseInt(id));

            // initialize list
            if (geneList == null)
                geneList = new ArrayList < > ();

        } else if (qName.equalsIgnoreCase("firstName")) {

            // set boolean values for fields, will be used in setting User variables
            hasFirstName = true;

        } else if (qName.equalsIgnoreCase("age")) {

            hasAge = true;

        } else if (qName.equalsIgnoreCase("gender")) {

            hasGender = true;

        } else if (qName.equalsIgnoreCase("lastName")) {

            hasLastName = true;

        } else if (qName.equalsIgnoreCase("yvalue")) {

            hasyvalue = true;
        }
    }

    @Override
    public void endElement(String uri, String localName, String qName) throws SAXException {
        if (qName.equalsIgnoreCase("User")) {

            // add User object to list
            geneList.add(gene);

        }
    }

    @Override
    public void characters(char ch[], int start, int length) throws SAXException {

        if (hasAge) {

            // age element, set User age
            gene.setAge(Integer.parseInt(new String(ch, start, length)));
            hasAge = false;

        } else if (hasFirstName) {

            gene.setFirstName(new String(ch, start, length));
            hasFirstName = false;

        } else if (hasLastName) {

            gene.setLastName(new String(ch, start, length));
            hasLastName = false;

        } else if (hasGender) {

            gene.setGender(new String(ch, start, length));
            hasGender = false;

        } else if (hasyvalue) {

            String yvalue = new String(ch, start, length);
            System.out.println(yvalue);
            gene.setYvalueList(yvalue);
            hasyvalue = false;

        }
    }
    
}
