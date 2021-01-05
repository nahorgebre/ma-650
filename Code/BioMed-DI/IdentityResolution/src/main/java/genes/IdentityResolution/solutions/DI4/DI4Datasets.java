package genes.IdentityResolution.solutions.DI4;

// java
import java.io.File;

// winter
import de.uni_mannheim.informatik.dws.winter.model.HashedDataSet;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

// model
import genes.IdentityResolution.model.Gene.Gene;
import genes.IdentityResolution.model.Gene.GeneXMLReader;

public class DI4Datasets {

    public static HashedDataSet<Gene, Attribute> kaessmann() throws Exception {

        HashedDataSet<Gene, Attribute> ds = new HashedDataSet<>();

        new GeneXMLReader().loadFromXML(new File("data/input/DI4/DI1_dt.xml"), "/genes/gene", ds);

        return ds;

    }

    public static HashedDataSet<Gene, Attribute> patentAbstract() throws Exception {

        HashedDataSet<Gene, Attribute> ds = new HashedDataSet<>();

        new GeneXMLReader().loadFromXML(new File("data/input/DI4/patent_abstract_dt.xml"), "/genes/gene", ds);

        return ds;

    }
    
}
