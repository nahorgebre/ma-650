package genes.DataFusion.solution.DI1;

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

public class DI1DataFusionEvaluation {

    private static final Logger logger = WinterLogManager.activateLogger("trace");

    public static void main( String[] args ) throws Exception {

        /*

        // kaessmann-fused

        FusibleDataSet<Gene, Attribute> fusedDataSet = new FusibleHashedDataSet<>();

        new GeneXMLReader().loadFromXML(new File("data/outpu/kaessmann-fused.xml"), "/genes/gene", fusedDataSet);

        fusedDataSet.printDataSetDensityReport();


        // load the gold standard
        DataSet<Gene, Attribute> gs = new FusibleHashedDataSet<>();

        new GeneXMLReader().loadFromXML(new File("data/goldstandard/kaessmann-gs.xml"), "/genes/gene", gs);


        // evaluate
        System.out.println("*\n*\tEvaluating results\n*");

        DataFusionEvaluator<Gene, Attribute> evaluator = new DataFusionEvaluator<>(
            strategy, new RecordGroupFactory<Gene, Attribute>());
                    
        double accuracy = evaluator.evaluate(fusedDataSet, gs, null);
                
        logger.info(String.format("Accuracy: %.2f", accuracy));

        */

    }
    
}
