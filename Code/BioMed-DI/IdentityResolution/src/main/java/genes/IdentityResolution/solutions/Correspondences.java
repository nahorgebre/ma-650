package genes.IdentityResolution.solutions;

import java.io.File;

import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.io.CSVCorrespondenceFormatter;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import genes.IdentityResolution.model.Gene.Gene;

public class Correspondences {

    public static void output(String outputDirectory, Processable<Correspondence<Gene, Attribute>> correspondences) throws Exception {
        
        System.out.println("Correspondences size: " + correspondences.size());
        new CSVCorrespondenceFormatter().writeCSV(new File(outputDirectory + "/correspondences.csv"), correspondences);

    }
}