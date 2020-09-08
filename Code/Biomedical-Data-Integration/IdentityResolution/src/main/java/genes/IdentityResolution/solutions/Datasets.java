package genes.IdentityResolution.solutions;

import java.io.File;

import de.uni_mannheim.informatik.dws.winter.model.HashedDataSet;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import genes.IdentityResolution.model.Gene;
import genes.IdentityResolution.model.GeneXMLReader;

public class Datasets {

    // Brain
    public static HashedDataSet<Gene, Attribute> getBrain() throws Exception{
        HashedDataSet<Gene, Attribute> Brain = new HashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Brain/Brain_dt.xml"), "/genes/gene", Brain);
        return Brain;
    }

    HashedDataSet<Gene, Attribute> mart_export_brain = new HashedDataSet<>();
    new GeneXMLReader().loadFromXML(new File("data/input/Brain/mart_export_brain_dt.xml"), "/genes/gene", mart_export_brain);

    // Cerebellum

    HashedDataSet<Gene, Attribute> Cerebellum = new HashedDataSet<>();
    new GeneXMLReader().loadFromXML(new File("data/input/Cerebellum/Cerebellum_dt.xml"), "/genes/gene", Cerebellum);

    HashedDataSet<Gene, Attribute> mart_export_cerebellum = new HashedDataSet<>();
    new GeneXMLReader().loadFromXML(new File("data/input/Cerebellum/mart_export_cerebellum_dt.xml"), "/genes/gene", mart_export_cerebellum);

    // Heart

    HashedDataSet<Gene, Attribute> Heart = new HashedDataSet<>();
    new GeneXMLReader().loadFromXML(new File("data/input/Heart/Heart_dt.xml"), "/genes/gene", Heart);

    HashedDataSet<Gene, Attribute> mart_export_heart = new HashedDataSet<>();
    new GeneXMLReader().loadFromXML(new File("data/input/Heart/mart_export_heart_dt.xml"), "/genes/gene", mart_export_heart);

    HashedDataSet<Gene, Attribute> Ensembl_NCBI_Crosswalk = new HashedDataSet<>();
    new GeneXMLReader().loadFromXML(new File("data/input/Heart/Heart_Ensembl_NCBI_Crosswalk_dt.xml"), "/genes/gene", Ensembl_NCBI_Crosswalk);

    // Kidney

    HashedDataSet<Gene, Attribute> Kidney = new HashedDataSet<>();
    new GeneXMLReader().loadFromXML(new File("data/input/Kidney/Kidney_dt.xml"), "/genes/gene", Kidney);

    HashedDataSet<Gene, Attribute> mart_export_kidney = new HashedDataSet<>();
    new GeneXMLReader().loadFromXML(new File("data/input/Kidney/mart_export_kidney_dt.xml"), "/genes/gene", mart_export_kidney);

    // Liver

    HashedDataSet<Gene, Attribute> Liver = new HashedDataSet<>();
    new GeneXMLReader().loadFromXML(new File("data/input/Liver/Liver_dt.xml"), "/genes/gene", Liver);

    HashedDataSet<Gene, Attribute> mart_export_liver = new HashedDataSet<>();
    new GeneXMLReader().loadFromXML(new File("data/input/Liver/mart_export_liver_dt.xml"), "/genes/gene", mart_export_liver);

    // Testis

    HashedDataSet<Gene, Attribute> Testis = new HashedDataSet<>();
    new GeneXMLReader().loadFromXML(new File("data/input/Testis/Testis_dt.xml"), "/genes/gene", Testis);

    HashedDataSet<Gene, Attribute> mart_export_testis = new HashedDataSet<>();
    new GeneXMLReader().loadFromXML(new File("data/input/Testis/mart_export_testis_dt.xml"), "/genes/gene", mart_export_testis);

    
}