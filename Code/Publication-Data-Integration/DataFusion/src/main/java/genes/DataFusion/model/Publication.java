package genes.DataFusion.model;

import de.uni_mannheim.informatik.dws.winter.model.Matchable;

import java.util.LinkedList;
import java.util.List;

public class Publication implements Matchable 
{
    
    protected String id;
    protected String provenance;
    private String pmid;
    private List<Gene> genes;
    private List<Project> projects;

    public Publication(String identifier, String provenance) 
    {
        id = identifier;
        this.provenance = provenance;
        genes = new LinkedList<>();
        projects = new LinkedList<>();
    }

    @Override
    public String getIdentifier() 
    {
        return id;
    }

    @Override
    public String getProvenance() 
    {
        return provenance;
    }

    // Getter
    public String getPmid() 
    { 
        return pmid; 
    }
    public List<Gene> getGenes() 
    {
        return genes;
    }
    public List<Project> getProjects() 
    {
        return projects;
    }

    // Setter
    public void setPmid(String pmid) 
    { 
        this.pmid = pmid; 
    }
    public void setGenes(List<Gene> genes) 
    {
        this.genes = genes;
    }
    public void setProjects(List<Project> projects) 
    {
        this.projects = projects;
    }

    @Override
    public String toString() 
    {
        return String.format("[Publication %s: %s / %s / %s]", getIdentifier(), getPmid(), getGenes(), getProjects());
    }

    @Override
    public int hashCode() 
    {
        return getIdentifier().hashCode();
    }

    @Override
    public boolean equals(Object obj) 
    {
        if(obj instanceof Publication)
        {
            return this.getIdentifier().equals(((Publication) obj).getIdentifier());
        } 
        else 
        {
            return false;
        }
    }
}