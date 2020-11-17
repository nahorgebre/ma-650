package genes.DataFusion.solution;

import org.apache.logging.log4j.Logger;
import java.io.File;

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

// Evaluation
import genes.DataFusion.evaluation.EnsemblIdEvaluationRule;
import genes.DataFusion.evaluation.NcbiIdEvaluationRule;
import genes.DataFusion.evaluation.GeneNamesEvaluationRule;
import genes.DataFusion.evaluation.GeneDescriptionsEvaluationRule;
import genes.DataFusion.evaluation.OrgansEvaluationRule;
import genes.DataFusion.evaluation.PatentsEvaluationRule;
import genes.DataFusion.evaluation.PublicationsEvaluationRule;
import genes.DataFusion.evaluation.DisaesesEvaluationRule;

// Fuser
import genes.DataFusion.fusers.EnsemblIdFuserLongestString;
import genes.DataFusion.fusers.NcbiIdFuserLongestString;
import genes.DataFusion.fusers.GeneNamesFuserLongestString;
import genes.DataFusion.fusers.GeneDescriptionsFuserLongestString;
import genes.DataFusion.fusers.Diseases.*;
import genes.DataFusion.fusers.Organs.*;
import genes.DataFusion.fusers.Patents.*;
import genes.DataFusion.fusers.Publications.*;

// Model
import genes.DataFusion.model.Gene.Gene;
import genes.DataFusion.model.Gene.GeneXMLFormatter;
import genes.DataFusion.model.Gene.GeneXMLReader;

public class DI1DataFusion {

    private static final Logger logger = WinterLogManager.activateLogger("trace");

    public static void main( String[] args ) throws Exception {

        // load the data into FusibleDataSet
        System.out.println("*\n*\tLoading datasets\n*");

        FusibleDataSet<Gene, Attribute> Brain = DI1Datasets.Brain();

        FusibleDataSet<Gene, Attribute> mart_export_brain = DI1Datasets.mart_export_brain();

        FusibleDataSet<Gene, Attribute> Cerebellum = DI1Datasets.Cerebellum();

        FusibleDataSet<Gene, Attribute> mart_export_cerebellum = DI1Datasets.mart_export_cerebellum();

        FusibleDataSet<Gene, Attribute> Heart = DI1Datasets.Heart();

        FusibleDataSet<Gene, Attribute> Heart_Ensembl_NCBI_Crosswalk = DI1Datasets.Heart_Ensembl_NCBI_Crosswalk();

        FusibleDataSet<Gene, Attribute> mart_export_heart = DI1Datasets.mart_export_heart();

        FusibleDataSet<Gene, Attribute> Kidney = DI1Datasets.Kidney();

        FusibleDataSet<Gene, Attribute> mart_export_kidney = DI1Datasets.mart_export_kidney();

        FusibleDataSet<Gene, Attribute> Liver = DI1Datasets.Liver();

        FusibleDataSet<Gene, Attribute> mart_export_liver = DI1Datasets.mart_export_liver();

        FusibleDataSet<Gene, Attribute> Testis = DI1Datasets.Testis();

        FusibleDataSet<Gene, Attribute> mart_export_testis = DI1Datasets.mart_export_testis();


        // load correspondences
        System.out.println("*\n*\tLoading correspondences\n*");

        CorrespondenceSet<Gene, Attribute> correspondences = new CorrespondenceSet<>();

        correspondences.loadCorrespondences(new File(DI1Correspondences.Heart_2_Brain), Brain, Heart);

        correspondences.loadCorrespondences(new File(DI1Correspondences.Heart_2_Cerebellum), Cerebellum, Heart);

        correspondences.loadCorrespondences(new File(DI1Correspondences.Heart_2_Kidney), Kidney, Heart);

        correspondences.loadCorrespondences(new File(DI1Correspondences.Heart_2_Liver), Liver, Heart);

        correspondences.loadCorrespondences(new File(DI1Correspondences.Heart_2_Testis), Testis, Heart);

        correspondences.loadCorrespondences(new File(DI1Correspondences.Heart_2_Heart_Ensembl_NCBI_Crosswalk), Heart, Heart_Ensembl_NCBI_Crosswalk);

        correspondences.loadCorrespondences(new File(DI1Correspondences.mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk), mart_export_heart);

        correspondences.loadCorrespondences(new File(DI1Correspondences.Cerebellum_2_Brain), Brain, Cerebellum);

        correspondences.loadCorrespondences(new File(DI1Correspondences.Cerebellum_2_Kidney), Kidney, Cerebellum);

        correspondences.loadCorrespondences(new File(DI1Correspondences.Cerebellum_2_Liver), Liver, Cerebellum);

        correspondences.loadCorrespondences(new File(DI1Correspondences.Cerebellum_2_Testis), Testis, Cerebellum);

        correspondences.loadCorrespondences(new File(DI1Correspondences.Cerebellum_2_mart_export_cerebellum), Cerebellum, mart_export_cerebellum);

        correspondences.loadCorrespondences(new File(DI1Correspondences.Brain_2_Kidney), Kidney, Brain);

        correspondences.loadCorrespondences(new File(DI1Correspondences.Brain_2_Liver), Brain, Liver);

        correspondences.loadCorrespondences(new File(DI1Correspondences.Brain_2_Testis), Testis, Brain);

        correspondences.loadCorrespondences(new File(DI1Correspondences.Brain_2_mart_export_brain),Brain, mart_export_brain);

        correspondences.loadCorrespondences(new File(DI1Correspondences.Kidney_2_Liver), Liver, Kidney);

        correspondences.loadCorrespondences(new File(DI1Correspondences.Kidney_2_Testis), Testis, Kidney);

        correspondences.loadCorrespondences(new File(DI1Correspondences.Kidney_2_mart_export_kidney), Kidney, mart_export_kidney);
        
        correspondences.loadCorrespondences(new File(DI1Correspondences.Liver_2_mart_export_liver), Liver, mart_export_liver);
        
        correspondences.loadCorrespondences(new File(DI1Correspondences.Testis_2_mart_export_testis), Testis, mart_export_testis);
        

        // write group size distribution
        correspondences.printGroupSizeDistribution();


        // load the gold standard
        DataSet<Gene, Attribute> gs = new FusibleHashedDataSet<>();

        new GeneXMLReader().loadFromXML(new File("data/goldstandard/kaessmann-gs.xml"), "/genes/gene", gs);


        // define the fusion strategy
        DataFusionStrategy<Gene, Attribute> strategy = new DataFusionStrategy<>(new GeneXMLReader());

        // write debug results to file
        strategy.activateDebugReport("data/output/DI1/debugResultsDatafusion.csv", 1000, gs);

        // add attribute fusers
        strategy.addAttributeFuser(Gene.ENSEMBLID, new EnsemblIdFuserLongestString(), new EnsemblIdEvaluationRule());

        strategy.addAttributeFuser(Gene.NCBIID, new NcbiIdFuserLongestString(), new NcbiIdEvaluationRule());

        strategy.addAttributeFuser(Gene.GENENAMES, new GeneNamesFuserLongestString(), new GeneNamesEvaluationRule());

        strategy.addAttributeFuser(Gene.GENEDESCRIPTIONS, new GeneDescriptionsFuserLongestString(), new GeneDescriptionsEvaluationRule());

        strategy.addAttributeFuser(Gene.ORGANS, new OrgansFuserUnion(), new OrgansEvaluationRule());

        strategy.addAttributeFuser(Gene.PUBLICATIONMENTIONS, new PublicationsFuserUnion(), new PublicationsEvaluationRule());

        strategy.addAttributeFuser(Gene.PATENTMENTIONS, new PatentsFuserUnion(), new PatentsEvaluationRule());

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
        new File("data/output/DI1/").mkdirs();

        new GeneXMLFormatter().writeXML(new File("data/output/DI1/kaessmann-fused.xml"), fusedDataSet);
        

        // evaluate
        System.out.println("*\n*\tEvaluating results\n*");

        DataFusionEvaluator<Gene, Attribute> evaluator = new DataFusionEvaluator<>(
            strategy, new RecordGroupFactory<Gene, Attribute>());
            
        double accuracy = evaluator.evaluate(fusedDataSet, gs, null);
        
        logger.info(String.format("Accuracy: %.2f", accuracy));
          
    }
    
}