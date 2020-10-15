package genes.IdentityResolution.solutions.SAXtest;

import java.util.ArrayList;
import java.util.List;

import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

public class UserHandler extends DefaultHandler {

    private boolean hasFirstName = false;
    private boolean hasLastName = false;
    private boolean hasAge = false;
    private boolean hasGender = false;

    // List to hold Users object
    private List < User > userList = null;
    private User user = null;

    // getter method for userloyee list
    public List < User > getEmpList() {
        return userList;
    }

    @Override
    public void startElement(String uri, String localName, String qName, Attributes attributes) throws SAXException {

        if (qName.equalsIgnoreCase("User")) {
            // create a new User and put it in Map
            String id = attributes.getValue("id");
            // initialize User object and set id attribute
            user = new User();
            user.setId(Integer.parseInt(id));
            // initialize list
            if (userList == null)
                userList = new ArrayList < > ();
        } else if (qName.equalsIgnoreCase("firstName")) {
            // set boolean values for fields, will be used in setting User variables
            hasFirstName = true;
        } else if (qName.equalsIgnoreCase("age")) {
            hasAge = true;
        } else if (qName.equalsIgnoreCase("gender")) {
            hasGender = true;
        } else if (qName.equalsIgnoreCase("lastName")) {
            hasLastName = true;
        }
    }

    @Override
    public void endElement(String uri, String localName, String qName) throws SAXException {
        if (qName.equalsIgnoreCase("User")) {
            // add User object to list
            userList.add(user);
        }
    }

    @Override
    public void characters(char ch[], int start, int length) throws SAXException {

        if (hasAge) {
            // age element, set User age
            user.setAge(Integer.parseInt(new String(ch, start, length)));
            hasAge = false;
        } else if (hasFirstName) {
            user.setFirstName(new String(ch, start, length));
            hasFirstName = false;
        } else if (hasLastName) {
            user.setLastName(new String(ch, start, length));
            hasLastName = false;
        } else if (hasGender) {
            user.setGender(new String(ch, start, length));
            hasGender = false;
        }
    }
    
}
