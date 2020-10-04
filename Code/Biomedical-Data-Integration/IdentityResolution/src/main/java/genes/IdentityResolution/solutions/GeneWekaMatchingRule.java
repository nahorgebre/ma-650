package genes.IdentityResolution.solutions;

// java
import java.util.ArrayList;
import java.util.List;

// winter
import de.uni_mannheim.informatik.dws.winter.matching.rules.WekaMatchingRule;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import genes.IdentityResolution.model.Gene;

public class GeneWekaMatchingRule {

    public String modelType;
    public WekaMatchingRule<Gene, Attribute> matchingRule;

    public static WekaMatchingRule<Gene, Attribute> AdaBoostM1_Gene() throws Exception {
        String options[] = new String[] { "" };
        String modelType = "AdaBoostM1"; // AdaBoost
        WekaMatchingRule<Gene, Attribute> matchingRule = new WekaMatchingRule<>(0.7, modelType, options);
        matchingRule.setBackwardSelection(true);

        return matchingRule;
    }

    public static WekaMatchingRule<Gene, Attribute> DecisionTreeJ48_Gene() throws Exception {
        String options[] = new String[] { "" };
        String modelType = "J48"; // Decision Tree
        WekaMatchingRule<Gene, Attribute> matchingRule = new WekaMatchingRule<>(0.7, modelType, options);
        matchingRule.setBackwardSelection(true);

        return matchingRule;
    }

    public static WekaMatchingRule<Gene, Attribute> KnnIbk_Gene() throws Exception {
        String options[] = new String[] { "" };
        String modelType = "IBk"; // K-NN
        WekaMatchingRule<Gene, Attribute> matchingRule = new WekaMatchingRule<>(0.7, modelType, options);
        matchingRule.setBackwardSelection(true);

        return matchingRule;
    }

    public static WekaMatchingRule<Gene, Attribute> LinearRegression_Gene() throws Exception {
        String options[] = new String[] { "-S 2" };
        String modelType = "LinearRegression"; // use a linear regression
        WekaMatchingRule<Gene, Attribute> matchingRule = new WekaMatchingRule<>(0.7, modelType, options);

        return matchingRule;
    }

    public static WekaMatchingRule<Gene, Attribute> SimpleLogistic_Gene() throws Exception {
        String options[] = new String[] { "-S" };
        String modelType = "SimpleLogistic"; // use a logistic regression
        WekaMatchingRule<Gene, Attribute> matchingRule = new WekaMatchingRule<>(0.7, modelType, options);

        return matchingRule;
    }

    public static List<GeneWekaMatchingRule> createGeneMatchingRuleList() throws Exception {

        // crate matching rule list
        List<GeneWekaMatchingRule> matchingRuleList = new ArrayList<GeneWekaMatchingRule>();

        // AdaBoost
        GeneWekaMatchingRule adaBoost = new GeneWekaMatchingRule();
        adaBoost.modelType = "ML_AdaBoost";
        adaBoost.matchingRule = GeneWekaMatchingRule.AdaBoostM1_Gene();
        matchingRuleList.add(adaBoost);
                
        // DecisionTree
        GeneWekaMatchingRule decisionTree = new GeneWekaMatchingRule();
        decisionTree.modelType = "ML_DecisionTree";
        decisionTree.matchingRule = GeneWekaMatchingRule.DecisionTreeJ48_Gene();
        matchingRuleList.add(decisionTree);
                
        // KNN
        GeneWekaMatchingRule knn = new GeneWekaMatchingRule();
        knn.modelType = "ML_KNN";
        knn.matchingRule = GeneWekaMatchingRule.KnnIbk_Gene();
        matchingRuleList.add(knn);
                
        // LinearRegression
        GeneWekaMatchingRule linearRegression = new GeneWekaMatchingRule();
        linearRegression.modelType = "ML_LinearRegression";
        linearRegression.matchingRule = GeneWekaMatchingRule.LinearRegression_Gene();
        matchingRuleList.add(linearRegression);
                
        // SimpleLogistic
        GeneWekaMatchingRule simpleLogistic = new GeneWekaMatchingRule();
        simpleLogistic.modelType = "ML_SimpleLogistic";
        simpleLogistic.matchingRule = GeneWekaMatchingRule.SimpleLogistic_Gene();
        matchingRuleList.add(simpleLogistic);

        return matchingRuleList;
    }
    
}
