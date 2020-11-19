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

public class DI2DataFusion {

    private static final Logger logger = WinterLogManager.activateLogger("trace");

    public static void main( String[] args ) throws Exception {

        // load the data into FusibleDataSet
        System.out.println("*\n*\tLoading datasets\n*");

        FusibleDataSet<Gene, Attribute> kaessmann = DI2Datasets.kaessmann();

        FusibleDataSet<Gene, Attribute> all_gene_disease_pmid_associations_1 = DI2Datasets.all_gene_disease_pmid_associations(1);

        FusibleDataSet<Gene, Attribute> all_gene_disease_pmid_associations_2 = DI2Datasets.all_gene_disease_pmid_associations(2);

        FusibleDataSet<Gene, Attribute> all_gene_disease_pmid_associations_3 = DI2Datasets.all_gene_disease_pmid_associations(3);

        FusibleDataSet<Gene, Attribute> all_gene_disease_pmid_associations_4 = DI2Datasets.all_gene_disease_pmid_associations(4);

        FusibleDataSet<Gene, Attribute> all_gene_disease_pmid_associations_5 = DI2Datasets.all_gene_disease_pmid_associations(5);

        FusibleDataSet<Gene, Attribute> all_gene_disease_pmid_associations_6 = DI2Datasets.all_gene_disease_pmid_associations(6);

        FusibleDataSet<Gene, Attribute> all_gene_disease_pmid_associations_7 = DI2Datasets.all_gene_disease_pmid_associations(7);


        // load correspondences
        System.out.println("*\n*\tLoading correspondences\n*");

        CorrespondenceSet<Gene, Attribute> correspondences = new CorrespondenceSet<>();

        correspondences.loadCorrespondences(new File(DI2Correspondences.kaessmann_2_all_gene_disease_pmid_associations_1), kaessmann, all_gene_disease_pmid_associations_1);

        correspondences.loadCorrespondences(new File(DI2Correspondences.kaessmann_2_all_gene_disease_pmid_associations_2), kaessmann, all_gene_disease_pmid_associations_2);

        correspondences.loadCorrespondences(new File(DI2Correspondences.kaessmann_2_all_gene_disease_pmid_associations_3), kaessmann, all_gene_disease_pmid_associations_3);

        correspondences.loadCorrespondences(new File(DI2Correspondences.kaessmann_2_all_gene_disease_pmid_associations_4), kaessmann, all_gene_disease_pmid_associations_4);

        correspondences.loadCorrespondences(new File(DI2Correspondences.kaessmann_2_all_gene_disease_pmid_associations_5), kaessmann, all_gene_disease_pmid_associations_5);

        correspondences.loadCorrespondences(new File(DI2Correspondences.kaessmann_2_all_gene_disease_pmid_associations_6), kaessmann, all_gene_disease_pmid_associations_6);

        correspondences.loadCorrespondences(new File(DI2Correspondences.kaessmann_2_all_gene_disease_pmid_associations_7), kaessmann, all_gene_disease_pmid_associations_7);


        // write group size distribution
        correspondences.printGroupSizeDistribution();


        // load the gold standard
        DataSet<Gene, Attribute> gs = new FusibleHashedDataSet<>();

        new GeneXMLReader().loadFromXML(new File("data/goldstandard/kaessmann-gs.xml"), "/genes/gene", gs);


        // define the fusion strategy
        DataFusionStrategy<Gene, Attribute> strategy = new DataFusionStrategy<>(new GeneXMLReader());


        // write debug results to file
        strategy.activateDebugReport("data/output/DI2/debugResultsDatafusion.csv", 1000, gs);


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

        new GeneXMLFormatter().writeXML(new File("data/output/DI2/kaessmann_diseaseAssociations-fused.xml"), fusedDataSet);
        

        // evaluate
        System.out.println("*\n*\tEvaluating results\n*");

        DataFusionEvaluator<Gene, Attribute> evaluator = new DataFusionEvaluator<>(
            strategy, new RecordGroupFactory<Gene, Attribute>());
            
        double accuracy = evaluator.evaluate(fusedDataSet, gs, null);
        
        logger.info(String.format("Accuracy: %.2f", accuracy));
        
        
    }
    

}