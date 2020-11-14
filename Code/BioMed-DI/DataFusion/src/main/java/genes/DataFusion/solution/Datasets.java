package genes.DataFusion.solution;

import java.io.File;

import de.uni_mannheim.informatik.dws.winter.model.FusibleDataSet;
import de.uni_mannheim.informatik.dws.winter.model.FusibleHashedDataSet;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import genes.DataFusion.model.Gene.Gene;
import genes.DataFusion.model.Gene.GeneXMLReader;

public class Datasets {

    // Disease
    public static FusibleDataSet<Gene, Attribute> all_gene_disease_pmid_associations() throws Exception {
        FusibleDataSet<Gene, Attribute> all_gene_disease_pmid_associations = new FusibleHashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/all_gene_disease_pmid_associations_dt.xml"), "/genes/gene", all_gene_disease_pmid_associations);
        all_gene_disease_pmid_associations.printDataSetDensityReport();
        return all_gene_disease_pmid_associations;
    }

    // Publication
    public static FusibleDataSet<Gene, Attribute> gene2pubtatorcentral() throws Exception {
        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral = new FusibleHashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/gene2pubtatorcentral_dt.xml"), "/genes/gene", gene2pubtatorcentral);
        gene2pubtatorcentral.printDataSetDensityReport();
        return gene2pubtatorcentral;
    }

    public static FusibleDataSet<Gene, Attribute> PubMedDate() throws Exception {
        FusibleDataSet<Gene, Attribute> PubMedDate = new FusibleHashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/PubMedDate_dt.xml"), "/genes/gene", PubMedDate);
        PubMedDate.printDataSetDensityReport();
        return PubMedDate;
    }
   
}