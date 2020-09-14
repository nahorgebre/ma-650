package genes.IdentityResolution.solutions;

import java.io.File;
import java.io.PrintWriter;

import de.uni_mannheim.informatik.dws.winter.matching.MatchingEvaluator;
import de.uni_mannheim.informatik.dws.winter.model.Correspondence;
import de.uni_mannheim.informatik.dws.winter.model.MatchingGoldStandard;
import de.uni_mannheim.informatik.dws.winter.model.Performance;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.processing.Processable;
import genes.IdentityResolution.model.Gene;

public class Evaluation {
        
    public static void run(Processable<Correspondence<Gene, Attribute>> correspondences, MatchingGoldStandard goldStandard, String outputDirectory, String className, String comparisonDescription) throws Exception {
        
        System.out.println("*\n*\tEvaluating result\n*");
        MatchingEvaluator<Gene, Attribute> evaluator = new MatchingEvaluator<Gene, Attribute>();
        Performance perfTest = evaluator.evaluateMatching(correspondences,
                goldStandard);
        
        printEvaluationResult(perfTest, comparisonDescription);
        writeEvaluationResult(perfTest, outputDirectory, className, comparisonDescription);
    }

    public static void printEvaluationResult(Performance perfTest, String comparisonDescription) {
        System.out.println(comparisonDescription);
        System.out.println(String.format(
                "Precision: %.4f",perfTest.getPrecision()));
        System.out.println(String.format(
                "Recall: %.4f",	perfTest.getRecall()));
        System.out.println(String.format(
                "F1: %.4f",perfTest.getF1()));
    }

    public static void writeEvaluationResult(Performance perfTest, String outputDirectory, String className, String comparisonDescription) throws Exception {
        File file = new File(outputDirectory + "/evaluation.txt");
        PrintWriter writer = new PrintWriter(file);
        writer.println(comparisonDescription);
        writer.println(String.format(
                "Precision: %.4f",perfTest.getPrecision()));
        writer.println(String.format(
                "Recall: %.4f",	perfTest.getRecall()));
        writer.println(String.format(
                "F1: %.4f",perfTest.getF1()));
        writer.close();
    }
}