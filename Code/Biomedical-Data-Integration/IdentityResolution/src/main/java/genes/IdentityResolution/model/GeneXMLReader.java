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
        String recordId = getValueFromChildElement(node, "recordId");

        Gene gene = new Gene(recordId, provenanceInfo);

        gene.setEnsemblId(getValueFromChildElement(node, "ensemblId"));
        gene.setGeneName(getValueFromChildElement(node, "geneName"));
        gene.setGeneDescription(getValueFromChildElement(node, "geneDescription"));
        gene.setDisagreement(getValueFromChildElement(node, "disagreement"));
        gene.setProbEqualOrthoAdj(getValueFromChildElement(node, "probEqualOrthoAdj"));
        gene.setCall(getValueFromChildElement(node, "call"));
        gene.setNcbiId(getValueFromChildElement(node, "ncbiId"));

        List<Disease> diseases = getObjectListFromChildElement(node, "diseaseAssociations", "diseaseAssociation", new DiseaseXMLReader(), provenanceInfo);
        gene.setDiseases(diseases);

        List<Publication> publications = getObjectListFromChildElement(node, "publicationMentions", "publicationMention", new PublicationXMLReader(), provenanceInfo);
        gene.setPublications(publications);

        List<Patent> patents = getObjectListFromChildElement(node, "patentMentions", "patentMention", new PatentXMLReader(), provenanceInfo);
        gene.setPatents(patents);

        return gene;
    }
}
