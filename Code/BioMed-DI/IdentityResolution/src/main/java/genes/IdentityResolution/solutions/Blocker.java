package genes.IdentityResolution.solutions;

// java
import java.io.File;
import java.io.FileNotFoundException;
import java.io.PrintWriter;

// winter
import de.uni_mannheim.informatik.dws.winter.matching.blockers.StandardRecordBlocker;
import de.uni_mannheim.informatik.dws.winter.matching.blockers.SortedNeighbourhoodBlocker;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;
import genes.IdentityResolution.model.Gene.Gene;

// ----

import java.time.Duration;
import java.time.LocalDateTime;

import org.apache.commons.lang3.time.DurationFormatUtils;
import org.slf4j.Logger;

import de.uni_mannheim.informatik.dws.winter.matching.blockers.Blocker;
import de.uni_mannheim.informatik.dws.winter.matching.rules.MatchingRule;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.DataSet;
import de.uni_mannheim.informatik.dws.winter.model.HashedDataSet;
import de.uni_mannheim.informatik.dws.winter.model.Matchable;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;
import de.uni_mannheim.informatik.dws.winter.utils.WinterLogManager;

public class Blocker {

    public static void writeStandardRecordBlockerResults(StandardRecordBlocker<Gene, Attribute> blocker, String outputDirectory)
            throws FileNotFoundException {

        File file = new File(outputDirectory + "/blockerResultTable.txt");

        PrintWriter writer = new PrintWriter(file);

        writer.println("ReductionRatio:" + blocker.getReductionRatio());

        //writer.println("BlockedPairs:" + blocker.getBlockedPairs().size());

        writer.close();

    }

    public static void writeSortedNeighbourhoodBlockerResults(SortedNeighbourhoodBlocker<Gene, Attribute, Attribute> blocker, String outputDirectory,
        //Processable<Correspondence<Gene, Attribute>> correspondences
        )
            throws FileNotFoundException {

        File file = new File(outputDirectory + "/blockerResultTable.txt");

        PrintWriter writer = new PrintWriter(file);

        writer.println("ReductionRatio:" + blocker.getReductionRatio());

        //writer.println("BlockedPairs:" + correspondences.size());

        //writer.println("BlockedPairs:" + blocker.getBlockedPairs().size());

        writer.close();

    }
    
}