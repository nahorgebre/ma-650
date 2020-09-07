package genes.IdentityResolution.solutions;

import java.io.File;
import java.io.PrintWriter;

import de.uni_mannheim.informatik.dws.winter.model.Performance;

public class Evaluation {
    public static void runEvaluation(Performance perfTest, String outputDirectory, String className, String comparisonDescription) throws Exception {
        String evaluationDirectory = outputDirectory + "/evalutaion";
        new File(evaluationDirectory).mkdirs();
        printEvaluationResult(perfTest, comparisonDescription);
        writeEvaluationResult(perfTest, evaluationDirectory, className, comparisonDescription);
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

    public static void writeEvaluationResult(Performance perfTest, String evaluationDirectory, String className, String comparisonDescription) throws Exception {
        File file = new File(evaluationDirectory + "/" + className + ".txt");
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