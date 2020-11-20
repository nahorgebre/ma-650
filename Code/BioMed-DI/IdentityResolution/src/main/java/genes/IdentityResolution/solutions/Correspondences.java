package genes.IdentityResolution.solutions;

// java
import java.io.File;
import java.io.PrintWriter;

// winter
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.io.CSVCorrespondenceFormatter;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

// model
import genes.IdentityResolution.model.Gene.Gene;

public class Correspondences {

    public static void output(String outputDirectory, Processable<Correspondence<Gene, Attribute>> correspondences) throws Exception {
        
        new CSVCorrespondenceFormatter().writeCSV(new File(outputDirectory + "/correspondences.csv"), correspondences);

        File file = new File(outputDirectory + "/correspondencesResultTable.txt");

        PrintWriter writer = new PrintWriter(file);

        writer.println("CorrespondencesSize:" + correspondences.size());

        writer.close();

    }
}
