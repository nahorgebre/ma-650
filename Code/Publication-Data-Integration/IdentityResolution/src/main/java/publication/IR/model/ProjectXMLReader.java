package publication.IR.model;

import de.uni_mannheim.informatik.dws.winter.model.io.XMLMatchableReader;

import org.w3c.dom.Node;

import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

public class ProjectXMLReader extends XMLMatchableReader<Project, Attribute> 
{
    @Override
    public Project createModelFromElement(Node node, String provenanceInfo) 
    {
        String id = getValueFromChildElement(node, "id");

        Project project = new Project(id, provenanceInfo);

        project.setProjectId(getValueFromChildElement(node, "projectId"));

        return project;
    }
}