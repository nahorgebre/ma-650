package genes.DataFusion.evaluation;

import genes.DataFusion.model.Gene.Gene;

import de.uni_mannheim.informatik.dws.winter.datafusion.EvaluationRule;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.similarity.SimilarityMeasure;
import de.uni_mannheim.informatik.dws.winter.similarity.string.TokenizingJaccardSimilarity;

public class GeneNamesEvaluationRule extends EvaluationRule<Gene, Attribute> {

    SimilarityMeasure<String> sim = new TokenizingJaccardSimilarity();

    @Override
    public boolean isEqual(Gene record1, Gene record2, Attribute schemaElement) {

        System.out.println("Evaluation - Record 1 - Gene Names: " + record1.getGeneNames());
        System.out.println("Evaluation - Record 2 - Gene Names: " + record2.getGeneNames());

        return sim.calculate(record1.getGeneNames(), record2.getGeneNames()) == 1.0;
    }

    @Override
    public boolean isEqual(Gene record1, Gene record2,
                           Correspondence<Attribute, Matchable> schemaCorrespondence) {
        return isEqual(record1, record2, (Attribute)null);
    }
    
}
