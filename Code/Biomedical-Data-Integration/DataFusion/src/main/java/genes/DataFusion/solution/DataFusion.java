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
import de.uni_mannheim.informatik.dws.winter.model.FusibleDataSet;

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
import genes.DataFusion.fusers.Diseases.*;
import genes.DataFusion.fusers.GeneNames.*;
import genes.DataFusion.fusers.GeneDescriptions.*;
import genes.DataFusion.fusers.Organs.*;
import genes.DataFusion.fusers.Patents.*;
import genes.DataFusion.fusers.Publications.*;

// Model
import genes.DataFusion.model.Gene.Gene;
import genes.DataFusion.model.Gene.GeneXMLFormatter;
import genes.DataFusion.model.Gene.GeneXMLReader;

public class DataFusion {

    private static final Logger logger = WinterLogManager.activateLogger("trace");

    public static void main( String[] args ) throws Exception {

        // load the data into FusibleDataSet
        System.out.println("*\n*\tLoading gene-disease-associations dataset\n*");
        FusibleDataSet<Gene, Attribute> all_gene_disease_pmid_associations = Datasets.all_gene_disease_pmid_associations();

        System.out.println("*\n*\tLoading gene2pubtatorcentral dataset\n*");
        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral = Datasets.gene2pubtatorcentral();

        System.out.println("*\n*\tLoading brain datasets\n*");
        FusibleDataSet<Gene, Attribute> Brain = Datasets.Brain();
        FusibleDataSet<Gene, Attribute> mart_export_brain = Datasets.mart_export_brain();

        System.out.println("*\n*\tLoading cerebellum datasets\n*");
        FusibleDataSet<Gene, Attribute> Cerebellum = Datasets.Cerebellum();
        FusibleDataSet<Gene, Attribute> mart_export_cerebellum = Datasets.mart_export_cerebellum();

        System.out.println("*\n*\tLoading heart datasets\n*");
        FusibleDataSet<Gene, Attribute> Heart = Datasets.Heart();
        FusibleDataSet<Gene, Attribute> Heart_Ensembl_NCBI_Crosswalk = Datasets.Heart_Ensembl_NCBI_Crosswalk();

        System.out.println("*\n*\tLoading kidney datasets\n*");
        FusibleDataSet<Gene, Attribute> Kidney = Datasets.Kidney();
        FusibleDataSet<Gene, Attribute> mart_export_kidney = Datasets.mart_export_kidney();

        System.out.println("*\n*\tLoading liver datasets\n*");
        FusibleDataSet<Gene, Attribute> Liver = Datasets.Liver();
        FusibleDataSet<Gene, Attribute> mart_export_liver = Datasets.mart_export_liver();

        System.out.println("*\n*\tLoading testis datasets\n*");
        FusibleDataSet<Gene, Attribute> Testis = Datasets.Testis();
        FusibleDataSet<Gene, Attribute> mart_export_testis = Datasets.mart_export_testis();

        // load correspondences
        System.out.println("*\n*\tLoading correspondences\n*");
        CorrespondenceSet<Gene, Attribute> correspondences = new CorrespondenceSet<>();
        // Brain
        correspondences.loadCorrespondences(new File(Correspondences.Brain_2_mart_export_brain),Brain, mart_export_brain);
        // Cerebellum
        correspondences.loadCorrespondences(new File(Correspondences.Cerebellum_2_mart_export_cerebellum), Cerebellum, mart_export_cerebellum);
        // Heart
        correspondences.loadCorrespondences(new File(Correspondences.Heart_2_Heart_Ensembl_NCBI_Crosswalk), Heart, Heart_Ensembl_NCBI_Crosswalk);
        // Kidney
        correspondences.loadCorrespondences(new File(Correspondences.Kidney_2_mart_export_kidney), Kidney, mart_export_kidney);
        // Liver
        correspondences.loadCorrespondences(new File(Correspondences.Liver_2_mart_export_liver), mart_export_liver, Liver);
        // Testis
        correspondences.loadCorrespondences(new File(Correspondences.Testis_2_mart_export_testis), Testis, mart_export_testis);
        
        // write group size distribution
        correspondences.printGroupSizeDistribution();

        // load the gold standard
        DataSet<Gene, Attribute> gs = new FusibleHashedDataSet<>();
        new GeneXMLReader().loadFromXML(new File("data/goldstandard/goldstandard.xml"), "/genes/gene", gs);

        // define the fusion strategy
        DataFusionStrategy<Gene, Attribute> strategy = new DataFusionStrategy<>(new GeneXMLReader());

        // write debug results to file
        strategy.activateDebugReport("data/output/debugResultsDatafusion.csv", 1000, gs);

        // add attribute fusers
        strategy.addAttributeFuser(Gene.ENSEMBLID, new EnsemblIdFuserLongestString(), new EnsemblIdEvaluationRule());
        strategy.addAttributeFuser(Gene.NCBIID, new NcbiIdFuserLongestString(), new NcbiIdEvaluationRule());
        strategy.addAttributeFuser(Gene.GENENAMES, new GeneNamesFuserUnion(), new GeneNamesEvaluationRule());
        strategy.addAttributeFuser(Gene.GENEDESCRIPTIONS, new GeneDescriptionsFuserUnion(), new GeneDescriptionsEvaluationRule());

        strategy.addAttributeFuser(Gene.DISEASEASSOCIATIONS, new DiseasesFuserUnion(), new DisaesesEvaluationRule());
        strategy.addAttributeFuser(Gene.ORGANS, new OrgansFuserUnion(), new OrgansEvaluationRule());
        strategy.addAttributeFuser(Gene.PATENTMENTIONS, new PatentsFuserUnion(), new PatentsEvaluationRule());
        strategy.addAttributeFuser(Gene.PUBLICATIONMENTIONS, new PublicationsFuserUnion(), new PublicationsEvaluationRule());

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
        new GeneXMLFormatter().writeXML(new File("data/output/fused.xml"), fusedDataSet);
        
        // evaluate
        System.out.println("*\n*\tEvaluating results\n*");
        DataFusionEvaluator<Gene, Attribute> evaluator = new DataFusionEvaluator<>(
            strategy, new RecordGroupFactory<Gene, Attribute>());
        double accuracy = evaluator.evaluate(fusedDataSet, gs, null);
        
        logger.info(String.format("Accuracy: %.2f", accuracy));   
    }
    
}