package genes.IdentityResolution.solutions;

// java
import java.io.File;
import java.io.FileNotFoundException;
import java.io.PrintWriter;

// winter
import de.uni_mannheim.informatik.dws.winter.matching.blockers.StandardRecordBlocker;
import de.uni_mannheim.informatik.dws.winter.matching.blockers.SortedNeighbourhoodBlocker;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import genes.IdentityResolution.model.Gene.Gene;

public class Blocker {

    public static void writeStandardRecordBlockerResults(StandardRecordBlocker<Gene, Attribute> blocker, String outputDirectory)
            throws FileNotFoundException {

        File file = new File(outputDirectory + "/blockerResultTable.txt");

        PrintWriter writer = new PrintWriter(file);

        writer.println("ReductionRatio:" + blocker.getReductionRatio());

        //writer.println("BlockedPairs:" + blocker.getBlockedPairs().size());

        writer.close();

    }

    public static void writeSortedNeighbourhoodBlockerResults(SortedNeighbourhoodBlocker<Gene, Attribute, Attribute> blocker, String outputDirectory)
            throws FileNotFoundException {

        File file = new File(outputDirectory + "/blockerResultTable.txt");

        PrintWriter writer = new PrintWriter(file);

        writer.println("ReductionRatio:" + blocker.getReductionRatio());

        writer.println("BlockedPairs:" + blocker.getBlockedPairs().size());

        writer.close();

    }
    
}