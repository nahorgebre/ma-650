package publication.IR.model;

import org.w3c.dom.Document;
import org.w3c.dom.Element;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLFormatter;

public class PublicationXMLFormatter extends XMLFormatter<Publication> 
{
    GeneXMLFormatter geneFormatter = new GeneXMLFormatter();
    ProjectXMLFormatter projectFormatter = new ProjectXMLFormatter();

    @Override
    public Element createRootElement(Document doc) 
    {
        return doc.createElement("publication");
    }

    @Override
    public Element createElementFromRecord(Publication record, Document doc) 
    {
        Element publication = doc.createElement("publication");

        publication.appendChild(createTextElement("id", record.getIdentifier(), doc));
        publication.appendChild(createTextElement("pmid", record.getPmid(), doc));

        publication.appendChild(createGenesElement(record, doc));
        publication.appendChild(createProjectsElement(record, doc));

        return publication;
    }

    protected Element createTextElementWithProvenance(String name, String value, String provenance, Document doc) 
    {
        Element elem = createTextElement(name, value, doc);
        elem.setAttribute("provenance", provenance);
        return elem;
    }

    protected Element createGenesElement(Publication record, Document doc) 
    {
        Element geneRoot = geneFormatter.createRootElement(doc);
        for (Gene a : record.getGenes()) {
            geneRoot.appendChild(geneFormatter.createElementFromRecord(a, doc));
        }
        return geneRoot;
    }

    protected Element createProjectsElement(Publication record, Document doc) 
    {
        Element projectRoot = projectFormatter.createRootElement(doc);
        for (Project a : record.getProjects()) {
            projectRoot.appendChild(projectFormatter.createElementFromRecord(a, doc));
        }
        return projectRoot;
    }
}