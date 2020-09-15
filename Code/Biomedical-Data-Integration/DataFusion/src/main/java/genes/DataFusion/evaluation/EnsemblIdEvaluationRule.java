package genes.DataFusion.evaluation;

import genes.DataFusion.model.Gene;
import de.uni_mannheim.informatik.dws.winter.datafusion.EvaluationRule;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.similarity.SimilarityMeasure;
import de.uni_mannheim.informatik.dws.winter.similarity.string.TokenizingJaccardSimilarity;

public class EnsemblIdEvaluationRule extends EvaluationRule<Gene, Attribute> {

    SimilarityMeasure<String> sim = new TokenizingJaccardSimilarity();

    @Override
    public boolean isEqual(Gene record1, Gene record2, Attribute schemaElement) {
        return sim.calculate(record1.getEnsemblId(), record2.getEnsemblId()) == 1.0;
    }

    @Override
    public boolean isEqual(Gene record1, Gene record2, Correspondence<Attribute, Matchable> schemaCorrespondence) {
        return isEqual(record1, record2, (Attribute)null);
    }

}