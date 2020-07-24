package publication.IR.model;

import de.uni_mannheim.informatik.dws.winter.model.AbstractRecord;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import java.io.Serializable;

public class Project extends AbstractRecord<Attribute> implements Serializable {
    
    private static final long serialVersionUID = 1L;
    private String projectId;

    public Project(String identifier, String provenance) 
    {
        super(identifier, provenance);
    }

    // Getter
    public String getProjectId() 
    { 
        return projectId; 
    }

    // Setter
    public void setProjectId(String projectId) 
    { 
        this.projectId = projectId; 
    }

    @Override
    public int hashCode() 
    {
        int result = 31 + ((projectId == null) ? 0 : projectId.hashCode());
        return result;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj)
            return true;
        if (obj == null)
            return false;
        if (getClass() != obj.getClass())
            return false;
        Project other = (Project) obj;
        if (projectId == null) {
            if (other.projectId != null)
                return false;
        } else if (!projectId.equals(other.projectId))
            return false;
        return true;
    }

    public static final Attribute PROJECTID = new Attribute("projectId");

    @Override
    public boolean hasValue(Attribute attribute) {
        if(attribute==PROJECTID)
            return projectId!=null;
        return false;
    }
}