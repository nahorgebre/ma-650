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
import genes.DataFusion.fusers.Diseases.DiseasesFuserUnion;
import genes.DataFusion.model.Gene;
import genes.DataFusion.model.GeneXMLFormatter;
import genes.DataFusion.model.GeneXMLReader;
import org.apache.logging.log4j.Logger;

import java.io.File;

public class DataFusion_Cerebellum {

    private static final Logger logger = WinterLogManager.activateLogger("trace");

    public static void main( String[] args ) throws Exception {
        fusedKaessmannCerebellum();
    }

    public static void fusedKaessmannCerebellum() throws Exception {
        
        // load the data into FusibleDataSet
        System.out.println("*\n*\tLoading datasets\n*");
        FusibleDataSet<Gene, Attribute> Cerebellum = Datasets.Cerebellum();
        FusibleDataSet<Gene, Attribute> mart_export_cerebellum = Datasets.mart_export_cerebellum();
        
        // load correspondences
        System.out.println("*\n*\tLoading correspondences\n*");
        CorrespondenceSet<Gene, Attribute> correspondences = new CorrespondenceSet<>();
        correspondences.loadCorrespondences(new File(Correspondences.Cerebellum_2_mart_export_cerebellum), Cerebellum, mart_export_cerebellum);
        
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
        strategy.addAttributeFuser(Gene.ENSEMBLID, new EnsemblIdFuserLongestString(), new EnsemblIdEvaluationRule());
        strategy.addAttributeFuser(Gene.GENEDESCRIPTION, new GeneDescriptionFuserLongestString(), new GeneDescriptionEvaluationRule());
        strategy.addAttributeFuser(Gene.DISAGREEMENT, new DisagreementFuserLongestString(), new DisagreementEvaluationRule());
        strategy.addAttributeFuser(Gene.CALL, new CallFuserLongestString(), new CallEvaluationRule());
        strategy.addAttributeFuser(Gene.NCBIID, new NcbiIdFuserLongestString(), new NcbiIdEvaluationRule());
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
        new File("data/output/").mkdirs();
        new GeneXMLFormatter().writeXML(new File("data/output/fused-kaessmann-cerebellum.xml"), fusedDataSet);
        
        // evaluate
        System.out.println("*\n*\tEvaluating results\n*");
        DataFusionEvaluator<Gene, Attribute> evaluator = new DataFusionEvaluator<>(
                strategy, new RecordGroupFactory<Gene, Attribute>());
        double accuracy = evaluator.evaluate(fusedDataSet, gs, null);
        
        logger.info(String.format("Accuracy: %.2f", accuracy));

    }
}
