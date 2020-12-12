package genes.DataFusion.solution.DI3;

// java
import java.io.File;

// winter
import de.uni_mannheim.informatik.dws.winter.model.FusibleDataSet;
import de.uni_mannheim.informatik.dws.winter.model.FusibleHashedDataSet;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

// model
import genes.DataFusion.model.Gene.Gene;
import genes.DataFusion.model.Gene.GeneXMLReader;

public class DI3Datasets {


    public static FusibleDataSet<Gene, Attribute> gene2pubtatorcentral(int i) throws Exception {

        FusibleDataSet<Gene, Attribute> ds = new FusibleHashedDataSet<>();

        new GeneXMLReader().loadFromXML(new File("data/input/DI3/gene2pubtatorcentral_" + i + "_dt.xml"), "/genes/gene", ds);

        return ds;

    }
    
}
