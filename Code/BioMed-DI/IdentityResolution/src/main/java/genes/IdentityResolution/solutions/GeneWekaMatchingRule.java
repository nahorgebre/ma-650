package genes.IdentityResolution.solutions;

// java
import java.util.ArrayList;
import java.util.List;

public class GeneWekaMatchingRule {

    public String className;
    public String options[];
    public String modelType;
    public Boolean backwardSelection; 

    public static List<GeneWekaMatchingRule> createGeneMatchingRuleList() 
    {

        List<GeneWekaMatchingRule> matchingRuleList = new ArrayList<GeneWekaMatchingRule>();

        
        /*
        GeneWekaMatchingRule matchingRule1 = new GeneWekaMatchingRule();

        matchingRule1.className = "ML_AdaBoost";

        matchingRule1.options = new String[] { "" };

        matchingRule1.modelType = "AdaBoostM1";

        matchingRule1.backwardSelection = true;

        matchingRuleList.add(matchingRule1);



        GeneWekaMatchingRule matchingRule2 = new GeneWekaMatchingRule();

        matchingRule2.className = "ML_DecisionTree";

        matchingRule2.options = new String[] { "" };

        matchingRule2.modelType = "J48";

        matchingRule2.backwardSelection = true;

        matchingRuleList.add(matchingRule2);



        GeneWekaMatchingRule matchingRule3 = new GeneWekaMatchingRule();

        matchingRule3.className = "ML_KNN";

        matchingRule3.options = new String[] { "" };

        matchingRule3.modelType = "IBk";

        matchingRule3.backwardSelection = true;

        matchingRuleList.add(matchingRule3);
        */
        

        GeneWekaMatchingRule matchingRule5 = new GeneWekaMatchingRule();

        matchingRule5.className = "ML_SimpleLogistic";

        matchingRule5.options = new String[] { "-S" };

        matchingRule5.modelType = "SimpleLogistic";

        matchingRule5.backwardSelection = false;

        matchingRuleList.add(matchingRule5);
        

        return matchingRuleList;

    }
    
}
