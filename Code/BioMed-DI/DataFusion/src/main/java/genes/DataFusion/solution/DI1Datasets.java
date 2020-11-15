package genes.DataFusion.solution;

// Java
import java.io.File;

// Winter Framework
import de.uni_mannheim.informatik.dws.winter.model.FusibleDataSet;
import de.uni_mannheim.informatik.dws.winter.model.FusibleHashedDataSet;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import genes.DataFusion.model.Gene.Gene;
import genes.DataFusion.model.Gene.GeneXMLReader;


public class DI1Datasets {


    public static FusibleDataSet<Gene, Attribute> Brain() throws Exception {

        FusibleDataSet<Gene, Attribute> Brain = new FusibleHashedDataSet<>();

        new GeneXMLReader().loadFromXML(new File("data/input/DI1/Brain_dt.xml"), "/genes/gene", Brain);

        Brain.printDataSetDensityReport();

        return Brain;

    }

    public static FusibleDataSet<Gene, Attribute> mart_export_brain() throws Exception {

        FusibleDataSet<Gene, Attribute> mart_export_brain = new FusibleHashedDataSet<>();

        new GeneXMLReader().loadFromXML(new File("data/input/DI1/mart_export_brain_dt.xml"), "/genes/gene", mart_export_brain);

        mart_export_brain.printDataSetDensityReport();

        return mart_export_brain;

    }


    public static FusibleDataSet<Gene, Attribute> Cerebellum() throws Exception {

        FusibleDataSet<Gene, Attribute> Cerebellum = new FusibleHashedDataSet<>();

        new GeneXMLReader().loadFromXML(new File("data/input/DI1/Cerebellum_dt.xml"), "/genes/gene", Cerebellum);

        Cerebellum.printDataSetDensityReport();

        return Cerebellum;

    }


    public static FusibleDataSet<Gene, Attribute> mart_export_cerebellum() throws Exception {

        FusibleDataSet<Gene, Attribute> mart_export_cerebellum = new FusibleHashedDataSet<>();

        new GeneXMLReader().loadFromXML(new File("data/input/DI1/mart_export_cerebellum_dt.xml"), "/genes/gene", mart_export_cerebellum);

        mart_export_cerebellum.printDataSetDensityReport();
        
        return mart_export_cerebellum;

    }


    public static FusibleDataSet<Gene, Attribute> Heart() throws Exception {

        FusibleDataSet<Gene, Attribute> Heart = new FusibleHashedDataSet<>();

        new GeneXMLReader().loadFromXML(new File("data/input/DI1/Heart_dt.xml"), "/genes/gene", Heart);

        Heart.printDataSetDensityReport();

        return Heart;

    }


    public static FusibleDataSet<Gene, Attribute> mart_export_heart() throws Exception {

        FusibleDataSet<Gene, Attribute> mart_export_heart = new FusibleHashedDataSet<>();

        new GeneXMLReader().loadFromXML(new File("data/input/DI1/mart_export_heart_dt.xml"), "/genes/gene", mart_export_heart);

        mart_export_heart.printDataSetDensityReport();

        return mart_export_heart;

    }


    public static FusibleDataSet<Gene, Attribute> Heart_Ensembl_NCBI_Crosswalk() throws Exception {

        FusibleDataSet<Gene, Attribute> Heart_Ensembl_NCBI_Crosswalk = new FusibleHashedDataSet<>();

        new GeneXMLReader().loadFromXML(new File("data/input/DI1/Heart_Ensembl_NCBI_Crosswalk_dt.xml"), "/genes/gene", Heart_Ensembl_NCBI_Crosswalk);

        Heart_Ensembl_NCBI_Crosswalk.printDataSetDensityReport();

        return Heart_Ensembl_NCBI_Crosswalk;

    }


    public static FusibleDataSet<Gene, Attribute> Kidney() throws Exception {  

        FusibleDataSet<Gene, Attribute> Kidney = new FusibleHashedDataSet<>();

        new GeneXMLReader().loadFromXML(new File("data/input/DI1/Kidney_dt.xml"), "/genes/gene", Kidney);

        Kidney.printDataSetDensityReport();

        return Kidney;

    }


    public static FusibleDataSet<Gene, Attribute> mart_export_kidney() throws Exception {

        FusibleDataSet<Gene, Attribute> mart_export_kidney = new FusibleHashedDataSet<>();

        new GeneXMLReader().loadFromXML(new File("data/input/DI1/mart_export_kidney_dt.xml"), "/genes/gene", mart_export_kidney);

        mart_export_kidney.printDataSetDensityReport();

        return mart_export_kidney;

    }


    public static FusibleDataSet<Gene, Attribute> Liver() throws Exception {

        FusibleDataSet<Gene, Attribute> Liver = new FusibleHashedDataSet<>();

        new GeneXMLReader().loadFromXML(new File("data/input/DI1/Liver_dt.xml"), "/genes/gene", Liver);

        Liver.printDataSetDensityReport();

        return Liver;

    }


    public static FusibleDataSet<Gene, Attribute> mart_export_liver() throws Exception {

        FusibleDataSet<Gene, Attribute> mart_export_liver = new FusibleHashedDataSet<>();

        new GeneXMLReader().loadFromXML(new File("data/input/DI1/mart_export_liver_dt.xml"), "/genes/gene", mart_export_liver);

        mart_export_liver.printDataSetDensityReport();

        return mart_export_liver;

    }


    public static FusibleDataSet<Gene, Attribute> Testis() throws Exception {

        FusibleDataSet<Gene, Attribute> Testis = new FusibleHashedDataSet<>();

        new GeneXMLReader().loadFromXML(new File("data/input/DI1/Testis_dt.xml"), "/genes/gene", Testis);

        Testis.printDataSetDensityReport();

        return Testis;

    }


    public static FusibleDataSet<Gene, Attribute> mart_export_testis() throws Exception {

        FusibleDataSet<Gene, Attribute> mart_export_testis = new FusibleHashedDataSet<>();

        new GeneXMLReader().loadFromXML(new File("data/input/DI1/mart_export_testis_dt.xml"), "/genes/gene", mart_export_testis);

        mart_export_testis.printDataSetDensityReport();

        return mart_export_testis;

    }
  
    
}