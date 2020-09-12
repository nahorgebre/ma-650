package genes.DataFusion.model;

import org.w3c.dom.Node;

import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.model.io.XMLMatchableReader;

public class GeneNameXMLReader extends XMLMatchableReader<GeneName, Attribute> {

    @Override
    public Disease createModelFromElement(Node node, String provenanceInfo) {
        String recordId = getValueFromChildElement(node, "recordId");

        GeneName geneName = new Disease(recordId, provenanceInfo);

        geneName.setName(getValueFromChildElement(node, "name"));

        return disease;
    }

}