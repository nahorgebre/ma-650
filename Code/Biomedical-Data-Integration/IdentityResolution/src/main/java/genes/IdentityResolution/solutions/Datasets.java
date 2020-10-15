package genes.IdentityResolution.solutions;

import java.io.File;

import de.uni_mannheim.informatik.dws.winter.model.HashedDataSet;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import genes.IdentityResolution.model.Gene;
import genes.IdentityResolution.model.GeneXMLReader;
import genes.IdentityResolution.gene2pubtatorcentralXMLReader.ReadXML;

public class Datasets {

    public static HashedDataSet<Gene, Attribute> all_gene_disease_pmid_associations() throws Exception {
        HashedDataSet<Gene, Attribute> all_gene_disease_pmid_associations = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/all_gene_disease_pmid_associations_dt.xml"), "/genes/gene", all_gene_disease_pmid_associations);
        return all_gene_disease_pmid_associations;
    }
    public static HashedDataSet<Gene, Attribute> gene2pubtatorcentral() throws Exception {
        HashedDataSet<Gene, Attribute> gene2pubtatorcentral = ReadXML.getGene2pubtatorcentralHashDataSet();
        return gene2pubtatorcentral;
    }
    public static HashedDataSet<Gene, Attribute> gene2pubtatorcentral2() throws Exception {
        HashedDataSet<Gene, Attribute> gene2pubtatorcentral = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/gene2pubtatorcentral_dt.xml"), "/genes/gene", gene2pubtatorcentral);
        return gene2pubtatorcentral;
    }
    public static HashedDataSet<Gene, Attribute> PubMedDate() throws Exception {
        HashedDataSet<Gene, Attribute> PubMedDate = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/PubMedDate_dt.xml"), "/genes/gene", PubMedDate);
        return PubMedDate;
    }

    // Brain
    public static HashedDataSet<Gene, Attribute> Brain() throws Exception {
        HashedDataSet<Gene, Attribute> Brain = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Brain/Brain_dt.xml"), "/genes/gene", Brain);
        return Brain;
    }

    public static HashedDataSet<Gene, Attribute> mart_export_brain() throws Exception {
        HashedDataSet<Gene, Attribute> mart_export_brain = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Brain/mart_export_brain_dt.xml"), "/genes/gene", mart_export_brain);
        return mart_export_brain;
    }

    // Cerebellum
    public static HashedDataSet<Gene, Attribute> Cerebellum() throws Exception {
        HashedDataSet<Gene, Attribute> Cerebellum = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Cerebellum/Cerebellum_dt.xml"), "/genes/gene", Cerebellum);
        return Cerebellum;
    }

    public static HashedDataSet<Gene, Attribute> mart_export_cerebellum() throws Exception {
        HashedDataSet<Gene, Attribute> mart_export_cerebellum = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Cerebellum/mart_export_cerebellum_dt.xml"), "/genes/gene", mart_export_cerebellum);
        return mart_export_cerebellum;
    }

    // Heart
    public static HashedDataSet<Gene, Attribute> Heart() throws Exception {
        HashedDataSet<Gene, Attribute> Heart = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Heart/Heart_dt.xml"), "/genes/gene", Heart);
        return Heart;
    }

    public static HashedDataSet<Gene, Attribute> mart_export_heart() throws Exception {
        HashedDataSet<Gene, Attribute> mart_export_heart = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Heart/mart_export_heart_dt.xml"), "/genes/gene", mart_export_heart);
        return mart_export_heart;
    }

    public static HashedDataSet<Gene, Attribute> Heart_Ensembl_NCBI_Crosswalk() throws Exception {
        HashedDataSet<Gene, Attribute> Heart_Ensembl_NCBI_Crosswalk = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Heart/Heart_Ensembl_NCBI_Crosswalk_dt.xml"), "/genes/gene", Heart_Ensembl_NCBI_Crosswalk);
        return Heart_Ensembl_NCBI_Crosswalk;
    }

    // Kidney
    public static HashedDataSet<Gene, Attribute> Kidney() throws Exception {    
        HashedDataSet<Gene, Attribute> Kidney = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Kidney/Kidney_dt.xml"), "/genes/gene", Kidney);
        return Kidney;
    }

    public static HashedDataSet<Gene, Attribute> mart_export_kidney() throws Exception {
        HashedDataSet<Gene, Attribute> mart_export_kidney = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Kidney/mart_export_kidney_dt.xml"), "/genes/gene", mart_export_kidney);
        return mart_export_kidney;
    }

    // Liver
    public static HashedDataSet<Gene, Attribute> Liver() throws Exception {
        HashedDataSet<Gene, Attribute> Liver = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Liver/Liver_dt.xml"), "/genes/gene", Liver);
        return Liver;
    }

    public static HashedDataSet<Gene, Attribute> mart_export_liver() throws Exception {
        HashedDataSet<Gene, Attribute> mart_export_liver = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Liver/mart_export_liver_dt.xml"), "/genes/gene", mart_export_liver);
        return mart_export_liver;
    }

    // Testis
    public static HashedDataSet<Gene, Attribute> Testis() throws Exception {
        HashedDataSet<Gene, Attribute> Testis = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Testis/Testis_dt.xml"), "/genes/gene", Testis);
        return Testis;
    }

    public static HashedDataSet<Gene, Attribute> mart_export_testis() throws Exception {
        HashedDataSet<Gene, Attribute> mart_export_testis = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Testis/mart_export_testis_dt.xml"), "/genes/gene", mart_export_testis);
        return mart_export_testis;
    }
   
}