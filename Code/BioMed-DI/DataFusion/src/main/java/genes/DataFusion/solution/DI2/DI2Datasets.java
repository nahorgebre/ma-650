package genes.DataFusion.solution.DI2;


import java.io.File;

import de.uni_mannheim.informatik.dws.winter.model.FusibleDataSet;
import de.uni_mannheim.informatik.dws.winter.model.FusibleHashedDataSet;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import genes.DataFusion.model.Gene.Gene;
import genes.DataFusion.model.Gene.GeneXMLReader;


public class DI2Datasets {


    public static FusibleDataSet<Gene, Attribute> kaessmann() throws Exception {

        FusibleDataSet<Gene, Attribute> ds = new FusibleHashedDataSet<>();

        new GeneXMLReader().loadFromXML(new File("data/input/DI2/Kaessmann_dt.xml"), "/genes/gene", ds);

        return ds;

    }


    public static FusibleDataSet<Gene, Attribute> all_gene_disease_pmid_associations(int i) throws Exception {

        FusibleDataSet<Gene, Attribute> ds = new FusibleHashedDataSet<>();

        new GeneXMLReader().loadFromXML(new File("data/input/DI2/all_gene_disease_pmid_associations_" + i + "_dt.xml"), "/genes/gene", ds);

        return ds;

    }
    

}