package genes.DataFusion.model;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLMatchableReader;

import org.w3c.dom.Node;

import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

public class GeneNameXMLReader extends XMLMatchableReader<GeneName, Attribute>
{
    @Override
    public GeneName createModelFromElement(Node node, String provenanceInfo) 
    {
        String id = getValueFromChildElement(node, "id");

        GeneName geneName = new GeneName(id, provenanceInfo);

        geneName.setGeneName(getValueFromChildElement(node, "geneName"));

        return geneName;
    }
}