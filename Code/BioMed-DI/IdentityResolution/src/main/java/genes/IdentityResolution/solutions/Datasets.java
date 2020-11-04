package genes.IdentityResolution.solutions;

import java.io.File;

import de.uni_mannheim.informatik.dws.winter.model.HashedDataSet;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import genes.IdentityResolution.model.Gene.Gene;
import genes.IdentityResolution.model.Gene.GeneXMLReader;

public class Datasets {

    // DI1
    public static HashedDataSet<Gene, Attribute> Brain() throws Exception {
        HashedDataSet<Gene, Attribute> Brain = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/DI1/Brain_dt.xml"), "/genes/gene", Brain);
        return Brain;
    }

    public static HashedDataSet<Gene, Attribute> mart_export_brain() throws Exception {
        HashedDataSet<Gene, Attribute> mart_export_brain = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/DI1/mart_export_brain_dt.xml"), "/genes/gene", mart_export_brain);
        return mart_export_brain;
    }

    public static HashedDataSet<Gene, Attribute> Cerebellum() throws Exception {
        HashedDataSet<Gene, Attribute> Cerebellum = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/DI1/Cerebellum_dt.xml"), "/genes/gene", Cerebellum);
        return Cerebellum;
    }

    public static HashedDataSet<Gene, Attribute> mart_export_cerebellum() throws Exception {
        HashedDataSet<Gene, Attribute> mart_export_cerebellum = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/DI1/mart_export_cerebellum_dt.xml"), "/genes/gene", mart_export_cerebellum);
        return mart_export_cerebellum;
    }

    public static HashedDataSet<Gene, Attribute> Heart() throws Exception {
        HashedDataSet<Gene, Attribute> Heart = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/DI1/Heart_dt.xml"), "/genes/gene", Heart);
        return Heart;
    }

    public static HashedDataSet<Gene, Attribute> mart_export_heart() throws Exception {
        HashedDataSet<Gene, Attribute> mart_export_heart = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/DI1/mart_export_heart_dt.xml"), "/genes/gene", mart_export_heart);
        return mart_export_heart;
    }

    public static HashedDataSet<Gene, Attribute> Heart_Ensembl_NCBI_Crosswalk() throws Exception {
        HashedDataSet<Gene, Attribute> Heart_Ensembl_NCBI_Crosswalk = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/DI1/Heart_Ensembl_NCBI_Crosswalk_dt.xml"), "/genes/gene", Heart_Ensembl_NCBI_Crosswalk);
        return Heart_Ensembl_NCBI_Crosswalk;
    }

    public static HashedDataSet<Gene, Attribute> Kidney() throws Exception {    
        HashedDataSet<Gene, Attribute> Kidney = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/DI1/Kidney_dt.xml"), "/genes/gene", Kidney);
        return Kidney;
    }

    public static HashedDataSet<Gene, Attribute> mart_export_kidney() throws Exception {
        HashedDataSet<Gene, Attribute> mart_export_kidney = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/DI1/mart_export_kidney_dt.xml"), "/genes/gene", mart_export_kidney);
        return mart_export_kidney;
    }

    public static HashedDataSet<Gene, Attribute> Liver() throws Exception {
        HashedDataSet<Gene, Attribute> Liver = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/DI1/Liver_dt.xml"), "/genes/gene", Liver);
        return Liver;
    }

    public static HashedDataSet<Gene, Attribute> mart_export_liver() throws Exception {
        HashedDataSet<Gene, Attribute> mart_export_liver = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/DI1/mart_export_liver_dt.xml"), "/genes/gene", mart_export_liver);
        return mart_export_liver;
    }

    public static HashedDataSet<Gene, Attribute> Testis() throws Exception {
        HashedDataSet<Gene, Attribute> Testis = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/DI1/Testis_dt.xml"), "/genes/gene", Testis);
        return Testis;
    }

    public static HashedDataSet<Gene, Attribute> mart_export_testis() throws Exception {
        HashedDataSet<Gene, Attribute> mart_export_testis = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/DI1/mart_export_testis_dt.xml"), "/genes/gene", mart_export_testis);
        return mart_export_testis;
    }


    // DI2
    public static HashedDataSet<Gene, Attribute> kaessmann() throws Exception {
        HashedDataSet<Gene, Attribute> Brain = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/DI2/Kaessmann_dt.xml"), "/genes/gene", Brain);
        return Brain;
    }

    public static HashedDataSet<Gene, Attribute> gene2pubtatorcentral(int fileNumber) throws Exception {
        HashedDataSet<Gene, Attribute> gene2pubtatorcentral = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/DI2/" + Variables.partitionNumbers +"/gene2pubtatorcentral_" + fileNumber + "_dt.xml"), "/genes/gene", gene2pubtatorcentral);
        return gene2pubtatorcentral;
    }



    public static HashedDataSet<Gene, Attribute> all_gene_disease_pmid_associations() throws Exception {
        HashedDataSet<Gene, Attribute> all_gene_disease_pmid_associations = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/all_gene_disease_pmid_associations_dt.xml"), "/genes/gene", all_gene_disease_pmid_associations);
        return all_gene_disease_pmid_associations;
    }

    
    public static HashedDataSet<Gene, Attribute> PubMedDate() throws Exception {
        HashedDataSet<Gene, Attribute> PubMedDate = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/PubMedDate_dt.xml"), "/genes/gene", PubMedDate);
        return PubMedDate;
    }
   
}