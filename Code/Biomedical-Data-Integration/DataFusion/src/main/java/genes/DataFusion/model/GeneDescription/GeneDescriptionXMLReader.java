package genes.DataFusion.model.GeneDescription;

import org.w3c.dom.Node;

import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.model.io.XMLMatchableReader;

public class GeneDescriptionXMLReader extends XMLMatchableReader<GeneDescription, Attribute> {

    @Override
    public GeneDescription createModelFromElement(Node node, String provenanceInfo) {
        String recordId = getValueFromChildElement(node, "recordId");

        GeneDescription geneDescription = new GeneDescription(recordId, provenanceInfo);

        geneDescription.setGeneDescription(getValueFromChildElement(node, "description"));

        return geneDescription;
    }

}