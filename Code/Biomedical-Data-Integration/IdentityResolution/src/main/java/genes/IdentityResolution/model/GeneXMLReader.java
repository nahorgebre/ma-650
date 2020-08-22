package genes.IdentityResolution.model;

import java.util.List;

import org.w3c.dom.Node;

import de.uni_mannheim.informatik.dws.winter.model.DataSet;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.model.io.XMLMatchableReader;

public class GeneXMLReader extends XMLMatchableReader<Gene, Attribute> {

    @Override
    protected void initialiseDataset(DataSet<Gene, Attribute> dataset) {
        super.initialiseDataset(dataset);
    }

    @Override
    public Gene createModelFromElement(Node node, String provenanceInfo) {
        String id = getValueFromChildElement(node, "id");

        Gene gene = new Gene(id, provenanceInfo);

        gene.setGeneId(getValueFromChildElement(node, "geneId"));
        gene.setGeneName(getValueFromChildElement(node, "geneName"));
        gene.setGeneDescription(getValueFromChildElement(node, "geneDescription"));
        gene.setDisagreement(getValueFromChildElement(node, "disagreement"));
        gene.setCall(getValueFromChildElement(node, "call"));
        gene.setNcbiId(getValueFromChildElement(node, "ncbiId"));
        gene.setDsi(getValueFromChildElement(node, "dsi"));
        gene.setDpi(getValueFromChildElement(node, "dpi"));

        List<Disease> diseases = getObjectListFromChildElement(node, "diseases", "disease", new DiseaseXMLReader(), provenanceInfo);
        gene.setDiseases(diseases);

        return gene;
    }
}
