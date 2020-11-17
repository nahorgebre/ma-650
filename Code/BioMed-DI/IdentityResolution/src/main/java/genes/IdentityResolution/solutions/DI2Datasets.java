package genes.IdentityResolution.solutions;

import java.io.File;

import de.uni_mannheim.informatik.dws.winter.model.HashedDataSet;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import genes.IdentityResolution.model.Gene.Gene;
import genes.IdentityResolution.model.Gene.GeneXMLReader;

public class DI2Datasets {


    public static HashedDataSet<Gene, Attribute> kaessmann() throws Exception {

        HashedDataSet<Gene, Attribute> ds = new HashedDataSet<>();

        new GeneXMLReader().loadFromXML(new File("data/input/DI2/Kaessmann_dt.xml"), "/genes/gene", ds);

        return ds;

    }


    public static HashedDataSet<Gene, Attribute> all_gene_disease_pmid_associations(int i) throws Exception {

        HashedDataSet<Gene, Attribute> ds = new HashedDataSet<>();

        new GeneXMLReader().loadFromXML(new File("data/input/DI2/all_gene_disease_pmid_associations_" + i + "_dt.xml"), "/genes/gene", ds);

        return ds;

    }
 
    
}