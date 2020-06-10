package genes.IdentityResolution.model;

import org.w3c.dom.Document;
import org.w3c.dom.Element;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLFormatter;

public class ProjectXMLFormatter extends XMLFormatter<Project>
{
    @Override
    public Element createRootElement(Document doc) 
    {
        return doc.createElement("projects");
    }

    @Override
    public Element createElementFromRecord(Project record, Document doc) 
    {
        Element project = doc.createElement("project");

        project.appendChild(createTextElement("projectId", record.getProjectId(), doc));

        return project;
    }
}