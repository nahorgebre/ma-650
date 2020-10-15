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

        System.out.println("Provenance Info: " + provenanceInfo);

        Gene gene = new Gene(recordId, provenanceInfo);

        gene.setEnsemblId(getValueFromChildElement(node, "ensemblId"));
        gene.setNcbiId(getValueFromChildElement(node, "ncbiId"));
        List<GeneName> geneNames = getObjectListFromChildElement(node, "geneNames", "geneNames", new GeneNameXMLReader(), provenanceInfo);
        gene.setGeneNames(geneNames);
        List<GeneDescription> geneDescriptions = getObjectListFromChildElement(node, "geneDescriptions", "geneDescriptions", new GeneDescriptionXMLReader(), provenanceInfo);
        gene.setGeneDescriptions(geneDescriptions);
        
        List<Organ> organs = getObjectListFromChildElement(node, "organs", "organs", new OrganXMLReader(), provenanceInfo);
        gene.setOrgans(organs);
        List<Disease> diseases = getObjectListFromChildElement(node, "diseaseAssociations", "diseaseAssociations", new DiseaseXMLReader(), provenanceInfo);
        gene.setDiseases(diseases);
        List<Publication> publications = getObjectListFromChildElement(node, "publicationMentions", "publicationMentions", new PublicationXMLReader(), provenanceInfo);
        gene.setPublications(publications);
        List<Patent> patents = getObjectListFromChildElement(node, "patentMentions", "patentMentions", new PatentXMLReader(), provenanceInfo);
        gene.setPatents(patents);

        return gene;
    }
}
