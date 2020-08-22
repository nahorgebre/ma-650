package genes.DataFusion.model;

import java.util.Collections;
import java.util.LinkedList;
import java.util.List;

import org.apache.commons.lang3.StringUtils;
import org.w3c.dom.Node;

import de.uni_mannheim.informatik.dws.winter.model.DataSet;
import de.uni_mannheim.informatik.dws.winter.model.FusibleFactory;
import de.uni_mannheim.informatik.dws.winter.model.RecordGroup;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.model.io.XMLMatchableReader;

public class GeneXMLReader extends XMLMatchableReader<Gene, Attribute> implements FusibleFactory<Gene, Attribute> {

    @Override
    protected void initialiseDataset(DataSet<Gene, Attribute> dataset) {
        super.initialiseDataset(dataset);

        dataset.addAttribute(Gene.GENEID);
        dataset.addAttribute(Gene.GENENAME);
        dataset.addAttribute(Gene.GENEDESCRIPTION);
        dataset.addAttribute(Gene.DISAGREEMENT);
        dataset.addAttribute(Gene.CALL);
        dataset.addAttribute(Gene.NCBIID);
        dataset.addAttribute(Gene.DSI);
        dataset.addAttribute(Gene.DPI);
        dataset.addAttribute(Gene.DISEASES);
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

    @Override
    public Gene createInstanceForFusion(RecordGroup<Gene, Attribute> cluster) {

        List<String> ids = new LinkedList<>();

        for (Gene m : cluster.getRecords()) {
            ids.add(m.getIdentifier());
        }

        Collections.sort(ids);

        String mergedId = StringUtils.join(ids, '+');

        return new Gene(mergedId, "fused");
    }
}
