package genes.DataFusion.model;

import java.util.List;

import org.w3c.dom.Node;

import de.uni_mannheim.informatik.dws.winter.model.DataSet;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.model.io.XMLMatchableReader;

public class PublicationXMLReader extends XMLMatchableReader<Publication, Attribute> 
{
    @Override
    protected void initialiseDataset(DataSet<Publication, Attribute> dataset) 
    {
        super.initialiseDataset(dataset);
    }

    @Override
    public Publication createModelFromElement(Node node, String provenanceInfo) 
    {
        String id = getValueFromChildElement(node, "id");

        Publication publication = new Publication(id, provenanceInfo);
        publication.setPmid(getValueFromChildElement(node, "pmid"));

        List<Gene> genes = getObjectListFromChildElement(node, "genes", "gene", new GeneXMLReader(), provenanceInfo);
        publication.setGenes(genes);

        List<Project> projects = getObjectListFromChildElement(node, "projects", "project", new ProjectXMLReader(), provenanceInfo);
        publication.setProjects(projects);

        return publication;
    }
}