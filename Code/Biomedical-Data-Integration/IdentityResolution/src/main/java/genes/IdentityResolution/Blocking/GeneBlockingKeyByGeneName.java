package genes.IdentityResolution.Blocking;

import java.util.List;

import de.uni_mannheim.informatik.dws.winter.matching.blockers.generators.RecordBlockingKeyGenerator;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.Pair;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.processing.DataIterator;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;

import genes.IdentityResolution.model.Gene;
import genes.IdentityResolution.model.GeneName;

public class GeneBlockingKeyByGeneName extends
        RecordBlockingKeyGenerator<Gene, Attribute> {

    private static final long serialVersionUID = 1L;

    @Override
    public void generateBlockingKeys(Gene record, Processable<Correspondence<Attribute, Matchable>> correspondences,
                                     DataIterator<Pair<String, Gene>> resultCollector) {
        
        List<GeneName> geneNameList = record.getGeneNames();
        String shortestGeneName = geneNameList.get(0).getName().toLowerCase();
        for (GeneName geneNameItem : geneNameList) {
            String name = geneNameItem.getName().toLowerCase();
            if (shortestGeneName.length() > name.length()) {
                shortestGeneName = name;
            }
        }

        String key;
        if (shortestGeneName.length() <= 3) {
            key = "XYZ";
        } else {
            key = shortestGeneName.substring(0,2);
        }

        resultCollector.next(new Pair<>(key, record));
    }
}
