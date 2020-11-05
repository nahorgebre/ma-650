package genes.IdentityResolution.Blocking;

import de.uni_mannheim.informatik.dws.winter.matching.blockers.generators.RecordBlockingKeyGenerator;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.model.Pair;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.processing.DataIterator;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;

import genes.IdentityResolution.model.Gene.Gene;

public class GeneBlockingKeyByGeneName extends
        RecordBlockingKeyGenerator<Gene, Attribute> {

    private static final long serialVersionUID = 1L;

    @Override
    public void generateBlockingKeys(Gene record, Processable<Correspondence<Attribute, Matchable>> correspondences,
                                     DataIterator<Pair<String, Gene>> resultCollector) {

        String key = "XYZ";

        String geneNames = record.getGeneNames().toLowerCase();

        String[] geneNameArray = geneNames.split("|");

        String geneName = "";

        for (String geneNameItem : geneNameArray) {
            
            if (geneNameItem.length() > geneName.length()) {
                
                geneName = geneNameItem;

            }

        }

        geneName = geneName.replaceAll("\\s+","");

        int nameLength = geneName.length();

        if (nameLength >= 4) {

            int keyIndex = geneName.length() / 2;
            key = geneName.substring(0, keyIndex);

        } else if (nameLength == 1) {

            key = geneName;

        } else if (nameLength == 2) {

            key = geneName;

        } else if (nameLength == 3) {
            
            key = geneName;

        }

        resultCollector.next(new Pair<>(key, record));

    }

}