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

public class DataFusion_Brain {

    private static final Logger logger = WinterLogManager.activateLogger("trace");

    public static void main( String[] args ) throws Exception {

        // Load the Data into FusibleDataSet
        System.out.println("*\n*\tLoading datasets\n*");

        FusibleDataSet<Gene, Attribute> ds1 = new FusibleHashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Brain/Brain_dt.xml"), "/genes/gene", ds1);
        ds1.printDataSetDensityReport();

        FusibleDataSet<Gene, Attribute> ds2 = new FusibleHashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Brain/mart_export_brain_dt.xml"), "/genes/gene", ds2);
        ds2.printDataSetDensityReport();

        // gene disease associations - 2, 3, 6, 7, 8, 11, 13, 15, 19, 20, 21, 22, 23, 24, 25
        FusibleDataSet<Gene, Attribute> gda2 = new FusibleHashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/input/Gene-Disease-Associations/all_gene_disease_pmid_associations_dt_2.xml"), "/genes/gene", gda2);
        gda2.printDataSetDensityReport();

        // load correspondences
        System.out.println("*\n*\tLoading correspondences\n*");
        CorrespondenceSet<Gene, Attribute> correspondences = new CorrespondenceSet<>();
        correspondences.loadCorrespondences(new File("data/correspondences/Brain/Brain_2_mart_export_brain/Brain_2_mart_export_brain_correspondences.csv"),ds1, ds2);

        //2, 3, 6, 7, 8, 11, 13, 15, 19, 20, 21, 22, 23, 24, 25
        correspondences.loadCorrespondences(new File("data/correspondences/Brain/mart_export_brain_2_all_gene_disease_pmid_associations/mart_export_brain_2_all_gene_disease_pmid_associations_correspondences_2.csv"),ds2, gda2);
        correspondences.loadCorrespondences(new File("data/correspondences/Brain/mart_export_brain_2_all_gene_disease_pmid_associations/mart_export_brain_2_all_gene_disease_pmid_associations_correspondences_3.csv"),ds2, gda3);
        correspondences.loadCorrespondences(new File("data/correspondences/Brain/mart_export_brain_2_all_gene_disease_pmid_associations/mart_export_brain_2_all_gene_disease_pmid_associations_correspondences_6.csv"),ds2, gda6);
        correspondences.loadCorrespondences(new File("data/correspondences/Brain/mart_export_brain_2_all_gene_disease_pmid_associations/mart_export_brain_2_all_gene_disease_pmid_associations_correspondences_7.csv"),ds2, gda7);
        correspondences.loadCorrespondences(new File("data/correspondences/Brain/mart_export_brain_2_all_gene_disease_pmid_associations/mart_export_brain_2_all_gene_disease_pmid_associations_correspondences_8.csv"),ds2, gda8);
        correspondences.loadCorrespondences(new File("data/correspondences/Brain/mart_export_brain_2_all_gene_disease_pmid_associations/mart_export_brain_2_all_gene_disease_pmid_associations_correspondences_11.csv"),ds2, gda11);
        correspondences.loadCorrespondences(new File("data/correspondences/Brain/mart_export_brain_2_all_gene_disease_pmid_associations/mart_export_brain_2_all_gene_disease_pmid_associations_correspondences_13.csv"),ds2, gda13);
        correspondences.loadCorrespondences(new File("data/correspondences/Brain/mart_export_brain_2_all_gene_disease_pmid_associations/mart_export_brain_2_all_gene_disease_pmid_associations_correspondences_15.csv"),ds2, gda15);
        correspondences.loadCorrespondences(new File("data/correspondences/Brain/mart_export_brain_2_all_gene_disease_pmid_associations/mart_export_brain_2_all_gene_disease_pmid_associations_correspondences_19.csv"),ds2, gda19);
        correspondences.loadCorrespondences(new File("data/correspondences/Brain/mart_export_brain_2_all_gene_disease_pmid_associations/mart_export_brain_2_all_gene_disease_pmid_associations_correspondences_20.csv"),ds2, gda20);
        correspondences.loadCorrespondences(new File("data/correspondences/Brain/mart_export_brain_2_all_gene_disease_pmid_associations/mart_export_brain_2_all_gene_disease_pmid_associations_correspondences_21.csv"),ds2, gda21);
        correspondences.loadCorrespondences(new File("data/correspondences/Brain/mart_export_brain_2_all_gene_disease_pmid_associations/mart_export_brain_2_all_gene_disease_pmid_associations_correspondences_22.csv"),ds2, gda22);
        correspondences.loadCorrespondences(new File("data/correspondences/Brain/mart_export_brain_2_all_gene_disease_pmid_associations/mart_export_brain_2_all_gene_disease_pmid_associations_correspondences_23.csv"),ds2, gda23);
        correspondences.loadCorrespondences(new File("data/correspondences/Brain/mart_export_brain_2_all_gene_disease_pmid_associations/mart_export_brain_2_all_gene_disease_pmid_associations_correspondences_24.csv"),ds2, gda24);
        correspondences.loadCorrespondences(new File("data/correspondences/Brain/mart_export_brain_2_all_gene_disease_pmid_associations/mart_export_brain_2_all_gene_disease_pmid_associations_correspondences_25.csv"),ds2, gda25);

        // write group size distribution
        correspondences.printGroupSizeDistribution();

        // load the gold standard
        DataSet<Gene, Attribute> gs = new FusibleHashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/goldstandard/brain-goldstandard.xml"), "/genes/gene", gs);

        // define the fusion strategy
        DataFusionStrategy<Gene, Attribute> strategy = new DataFusionStrategy<>(new GeneXMLReader());

        // write debug results to file
        strategy.activateDebugReport("data/output/debugResultsDatafusion-Brain.csv", 1000, gs);

        // add attribute fusers
        strategy.addAttributeFuser(Gene.ENSEMBLID, new GeneIdFuserLongestString(), new GeneIdEvaluationRule());
        strategy.addAttributeFuser(Gene.GENENAMES, new GeneNameFuserLongestString(), new GeneNameEvaluationRule());
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
        new GeneXMLFormatter().writeXML(new File("data/output/fused-brain.xml"), fusedDataSet);

        // evaluate
        System.out.println("*\n*\tEvaluating results\n*");
        DataFusionEvaluator<Gene, Attribute> evaluator = new DataFusionEvaluator<>(
                strategy, new RecordGroupFactory<Gene, Attribute>());
        double accuracy = evaluator.evaluate(fusedDataSet, gs, null);

        logger.info(String.format("Accuracy: %.2f", accuracy));
    }
}
