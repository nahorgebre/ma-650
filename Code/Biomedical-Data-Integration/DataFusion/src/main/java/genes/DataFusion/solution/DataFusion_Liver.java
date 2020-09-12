package genes.DataFusion.solution;

import de.uni_mannheim.informatik.dws.winter.datafusion.CorrespondenceSet;
import de.uni_mannheim.informatik.dws.winter.datafusion.DataFusionEngine;
import de.uni_mannheim.informatik.dws.winter.datafusion.DataFusionEvaluator;
import de.uni_mannheim.informatik.dws.winter.datafusion.DataFusionStrategy;
import de.uni_mannheim.informatik.dws.winter.model.DataSet;
import de.uni_mannheim.informatik.dws.winter.model.FusibleDataSet;
import de.uni_mannheim.informatik.dws.winter.model.FusibleHashedDataSet;
import de.uni_mannheim.informatik.dws.winter.model.RecordGroupFactory;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.utils.WinterLogManager;
import genes.DataFusion.evaluation.*;
import genes.DataFusion.fusers.*;
import genes.DataFusion.model.Gene;
import genes.DataFusion.model.GeneXMLFormatter;
import genes.DataFusion.model.GeneXMLReader;
import org.apache.logging.log4j.Logger;

import java.io.File;

public class DataFusion_Liver {

    private static final Logger logger = WinterLogManager.activateLogger("trace");

    public static void main( String[] args ) throws Exception {

        // Load the Data into FusibleDataSet
        System.out.println("*\n*\tLoading datasets\n*");

        FusibleDataSet<Gene, Attribute> ds1 = new FusibleHashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Liver/Liver_dt.xml"), "/genes/gene", ds1);
        ds1.printDataSetDensityReport();

        FusibleDataSet<Gene, Attribute> ds2 = new FusibleHashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Liver/mart_export_liver_dt.xml"), "/genes/gene", ds2);
        ds2.printDataSetDensityReport();

        // gene disease associations
        // 1, 2, 3, 6, 7, 8, 13, 15, 19, 20, 21, 22, 23, 24, 25
        FusibleDataSet<Gene, Attribute> gda1 = new FusibleHashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Gene-Disease-Associations/all_gene_disease_pmid_associations_dt_1.xml"), "/genes/gene", gda1);
        gda1.printDataSetDensityReport();

        FusibleDataSet<Gene, Attribute> gda2 = new FusibleHashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Gene-Disease-Associations/all_gene_disease_pmid_associations_dt_2.xml"), "/genes/gene", gda2);
        gda2.printDataSetDensityReport();

        FusibleDataSet<Gene, Attribute> gda3 = new FusibleHashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Gene-Disease-Associations/all_gene_disease_pmid_associations_dt_3.xml"), "/genes/gene", gda3);
        gda3.printDataSetDensityReport();

        FusibleDataSet<Gene, Attribute> gda6 = new FusibleHashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Gene-Disease-Associations/all_gene_disease_pmid_associations_dt_6.xml"), "/genes/gene", gda6);
        gda6.printDataSetDensityReport();

        FusibleDataSet<Gene, Attribute> gda7 = new FusibleHashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Gene-Disease-Associations/all_gene_disease_pmid_associations_dt_7.xml"), "/genes/gene", gda7);
        gda7.printDataSetDensityReport();

        FusibleDataSet<Gene, Attribute> gda8 = new FusibleHashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Gene-Disease-Associations/all_gene_disease_pmid_associations_dt_8.xml"), "/genes/gene", gda8);
        gda8.printDataSetDensityReport();

        FusibleDataSet<Gene, Attribute> gda13 = new FusibleHashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Gene-Disease-Associations/all_gene_disease_pmid_associations_dt_13.xml"), "/genes/gene", gda13);
        gda13.printDataSetDensityReport();

        FusibleDataSet<Gene, Attribute> gda15 = new FusibleHashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Gene-Disease-Associations/all_gene_disease_pmid_associations_dt_15.xml"), "/genes/gene", gda15);
        gda15.printDataSetDensityReport();

        FusibleDataSet<Gene, Attribute> gda19 = new FusibleHashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Gene-Disease-Associations/all_gene_disease_pmid_associations_dt_19.xml"), "/genes/gene", gda19);
        gda19.printDataSetDensityReport();

        FusibleDataSet<Gene, Attribute> gda20 = new FusibleHashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Gene-Disease-Associations/all_gene_disease_pmid_associations_dt_20.xml"), "/genes/gene", gda20);
        gda20.printDataSetDensityReport();

        FusibleDataSet<Gene, Attribute> gda21 = new FusibleHashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Gene-Disease-Associations/all_gene_disease_pmid_associations_dt_21.xml"), "/genes/gene", gda21);
        gda21.printDataSetDensityReport();

        FusibleDataSet<Gene, Attribute> gda22 = new FusibleHashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Gene-Disease-Associations/all_gene_disease_pmid_associations_dt_22.xml"), "/genes/gene", gda22);
        gda22.printDataSetDensityReport();

        FusibleDataSet<Gene, Attribute> gda23 = new FusibleHashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Gene-Disease-Associations/all_gene_disease_pmid_associations_dt_23.xml"), "/genes/gene", gda23);
        gda23.printDataSetDensityReport();

        FusibleDataSet<Gene, Attribute> gda24 = new FusibleHashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Gene-Disease-Associations/all_gene_disease_pmid_associations_dt_24.xml"), "/genes/gene", gda24);
        gda24.printDataSetDensityReport();

        FusibleDataSet<Gene, Attribute> gda25 = new FusibleHashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Gene-Disease-Associations/all_gene_disease_pmid_associations_dt_25.xml"), "/genes/gene", gda25);
        gda25.printDataSetDensityReport();

        // load correspondences
        System.out.println("*\n*\tLoading correspondences\n*");
        CorrespondenceSet<Gene, Attribute> correspondences = new CorrespondenceSet<>();
        correspondences.loadCorrespondences(new File("data/correspondences/Liver/Liver_2_mart_export_liver/Liver_2_mart_export_liver_correspondences.csv"),ds1, ds2);

        // 1, 2, 3, 6, 7, 8, 13, 15, 19, 20, 21, 22, 23, 24, 25
        String correspondencesPath = "data/correspondences/Liver/mart_export_liver_2_all_gene_disease_pmid_associations/mart_export_liver_2_all_gene_disease_pmid_associations_correspondences_";
        correspondences.loadCorrespondences(new File(correspondencesPath + "1.csv"),gda1, ds2);
        correspondences.loadCorrespondences(new File(correspondencesPath + "2.csv"),gda2, ds2);
        correspondences.loadCorrespondences(new File(correspondencesPath + "3.csv"),gda3, ds2);
        correspondences.loadCorrespondences(new File(correspondencesPath + "6.csv"),gda6, ds2);
        correspondences.loadCorrespondences(new File(correspondencesPath + "7.csv"),gda7, ds2);
        correspondences.loadCorrespondences(new File(correspondencesPath + "8.csv"),gda8, ds2);
        correspondences.loadCorrespondences(new File(correspondencesPath + "13.csv"),gda13, ds2);
        correspondences.loadCorrespondences(new File(correspondencesPath + "15.csv"),gda15, ds2);
        correspondences.loadCorrespondences(new File(correspondencesPath + "19.csv"),gda19, ds2);
        correspondences.loadCorrespondences(new File(correspondencesPath + "20.csv"),gda20, ds2);
        correspondences.loadCorrespondences(new File(correspondencesPath + "21.csv"),gda21, ds2);
        correspondences.loadCorrespondences(new File(correspondencesPath + "22.csv"),gda22, ds2);
        correspondences.loadCorrespondences(new File(correspondencesPath + "23.csv"),gda23, ds2);
        correspondences.loadCorrespondences(new File(correspondencesPath + "24.csv"),gda24, ds2);
        correspondences.loadCorrespondences(new File(correspondencesPath + "25.csv"),gda25, ds2);

        // write group size distribution
        correspondences.printGroupSizeDistribution();

        // load the gold standard
        DataSet<Gene, Attribute> gs = new FusibleHashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/goldstandard/liver-goldstandard.xml"), "/genes/gene", gs);

        // define the fusion strategy
        DataFusionStrategy<Gene, Attribute> strategy = new DataFusionStrategy<>(new GeneXMLReader());

        // write debug results to file
        strategy.activateDebugReport("data/output/debugResultsDatafusion-liver.csv", 1000, gs);

        // add attribute fusers
        strategy.addAttributeFuser(Gene.ENSEMBLID, new GeneIdFuserLongestString(), new GeneIdEvaluationRule());
        strategy.addAttributeFuser(Gene.GENENAME, new GeneNameFuserLongestString(), new GeneNameEvaluationRule());
        strategy.addAttributeFuser(Gene.GENEDESCRIPTION, new GeneDescriptionFuserLongestString(), new GeneDescriptionEvaluationRule());
        strategy.addAttributeFuser(Gene.DISAGREEMENT, new DisagreementFuserLongestString(), new DisagreementEvaluationRule());
        strategy.addAttributeFuser(Gene.CALL, new CallFuserLongestString(), new CallEvaluationRule());
        strategy.addAttributeFuser(Gene.NCBIID, new NcbiIdFuserLongestString(), new NcbiIdEvaluationRule());
        strategy.addAttributeFuser(Gene.DSI, new DsiFuserLongestString(), new DsiEvaluationRule());
        strategy.addAttributeFuser(Gene.DPI, new DpiFuserLongestString(), new DpiEvaluationRule());
        strategy.addAttributeFuser(Gene.DISEASEASSOCIATIONS, new DiseasesFuserUnion(), new DisaesesEvaluationRule());

        // create the fusion engine
        DataFusionEngine<Gene, Attribute> engine = new DataFusionEngine<Gene, Attribute>(strategy);

        // print consistency report
        engine.printClusterConsistencyReport(correspondences, null);

        // run the fusion
        System.out.println("*\n*\tRunning data fusion\n*");
        FusibleDataSet<Gene, Attribute> fusedDataSet = engine.run(correspondences, null);
        fusedDataSet.printDataSetDensityReport();

        // write the result
        //new GeneCSVFormatter().writeCSV(new File("data/output/fused-heart.xml"),);
        new GeneXMLFormatter().writeXML(new File("data/output/fused-liver.xml"), fusedDataSet);

        // evaluate
        System.out.println("*\n*\tEvaluating results\n*");
        DataFusionEvaluator<Gene, Attribute> evaluator = new DataFusionEvaluator<>(
                strategy, new RecordGroupFactory<Gene, Attribute>());
        double accuracy = evaluator.evaluate(fusedDataSet, gs, null);

        logger.info(String.format("Accuracy: %.2f", accuracy));
    }
}
