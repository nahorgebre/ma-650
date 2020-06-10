package genes.DataFusion.model;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLMatchableReader;

import org.w3c.dom.Node;

import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

public class GeneXMLReader extends XMLMatchableReader<Gene, Attribute>
{
    @Override
    public Gene createModelFromElement(Node node, String provenanceInfo) 
    {
        String id = getValueFromChildElement(node, "id");

        Gene gene = new Gene(id, provenanceInfo);

        gene.setNcbiId(getValueFromChildElement(node, "ncbiId"));

        return gene;
    }
}