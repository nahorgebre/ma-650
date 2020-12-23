package genes.IdentityResolution.solutions.DI3;

// java
import java.io.File;

// winter
import de.uni_mannheim.informatik.dws.winter.model.HashedDataSet;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

// model
import genes.IdentityResolution.model.Gene.Gene;
import genes.IdentityResolution.model.Gene.GeneXMLReader;


public class DI3Datasets {


    public static HashedDataSet<Gene, Attribute> gene2pubtatorcentral(int fileNumber) throws Exception {
        
        HashedDataSet<Gene, Attribute> gene2pubtatorcentral = new HashedDataSet<>();
        
        new GeneXMLReader().loadFromXML(new File("data/input/DI3/gene2pubtatorcentral_" + fileNumber + "_dt.xml"), "/genes/gene", gene2pubtatorcentral);
        
        return gene2pubtatorcentral;

    }


    public static HashedDataSet<Gene, Attribute> kaessmann() throws Exception {

        HashedDataSet<Gene, Attribute> ds = new HashedDataSet<>();

        new GeneXMLReader().loadFromXML(new File("data/input/DI3/DI1_dt.xml"), "/genes/gene", ds);

        return ds;

    }

    
}
