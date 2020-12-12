package genes.DataFusion.AWS;

// java
import java.util.ArrayList;
import java.util.List;

public class DI3Comparisons {


    public String Comparison;

    public String MatchingEngine;


    public static boolean checkMatchingEngine(String inputComparison, String inputMatchingEngine)
    {

        boolean returnValue = false;

        List<DI1Comparisons> di1ComparisonList = new ArrayList<DI1Comparisons>();


        DI1Comparisons kaessmann_2_all_gene_disease_pmid_associations_1 = new DI1Comparisons();

        kaessmann_2_all_gene_disease_pmid_associations_1.Comparison = "kaessmann_2_all_gene_disease_pmid_associations_1";

        kaessmann_2_all_gene_disease_pmid_associations_1.MatchingEngine = MatchingEngines.adaBoostStandardRecordBlocker;

        di1ComparisonList.add(kaessmann_2_all_gene_disease_pmid_associations_1);


        DI1Comparisons kaessmann_2_all_gene_disease_pmid_associations_2 = new DI1Comparisons();

        kaessmann_2_all_gene_disease_pmid_associations_2.Comparison = "kaessmann_2_all_gene_disease_pmid_associations_2";

        kaessmann_2_all_gene_disease_pmid_associations_2.MatchingEngine = MatchingEngines.adaBoostStandardRecordBlocker;

        di1ComparisonList.add(kaessmann_2_all_gene_disease_pmid_associations_2);


        DI1Comparisons kaessmann_2_all_gene_disease_pmid_associations_3 = new DI1Comparisons();

        kaessmann_2_all_gene_disease_pmid_associations_3.Comparison = "kaessmann_2_all_gene_disease_pmid_associations_3";

        kaessmann_2_all_gene_disease_pmid_associations_3.MatchingEngine = MatchingEngines.adaBoostStandardRecordBlocker;

        di1ComparisonList.add(kaessmann_2_all_gene_disease_pmid_associations_3);


        DI1Comparisons kaessmann_2_all_gene_disease_pmid_associations_4 = new DI1Comparisons();

        kaessmann_2_all_gene_disease_pmid_associations_4.Comparison = "kaessmann_2_all_gene_disease_pmid_associations_4";

        kaessmann_2_all_gene_disease_pmid_associations_4.MatchingEngine = MatchingEngines.adaBoostStandardRecordBlocker;

        di1ComparisonList.add(kaessmann_2_all_gene_disease_pmid_associations_4);


        DI1Comparisons kaessmann_2_all_gene_disease_pmid_associations_5 = new DI1Comparisons();

        kaessmann_2_all_gene_disease_pmid_associations_5.Comparison = "kaessmann_2_all_gene_disease_pmid_associations_5";

        kaessmann_2_all_gene_disease_pmid_associations_5.MatchingEngine = MatchingEngines.adaBoostStandardRecordBlocker;

        di1ComparisonList.add(kaessmann_2_all_gene_disease_pmid_associations_5);


        DI1Comparisons kaessmann_2_all_gene_disease_pmid_associations_6 = new DI1Comparisons();

        kaessmann_2_all_gene_disease_pmid_associations_6.Comparison = "kaessmann_2_all_gene_disease_pmid_associations_6";

        kaessmann_2_all_gene_disease_pmid_associations_6.MatchingEngine = MatchingEngines.adaBoostStandardRecordBlocker;

        di1ComparisonList.add(kaessmann_2_all_gene_disease_pmid_associations_6);


        DI1Comparisons kaessmann_2_all_gene_disease_pmid_associations_7 = new DI1Comparisons();

        kaessmann_2_all_gene_disease_pmid_associations_7.Comparison = "kaessmann_2_all_gene_disease_pmid_associations_7";

        kaessmann_2_all_gene_disease_pmid_associations_7.MatchingEngine = MatchingEngines.adaBoostStandardRecordBlocker;

        di1ComparisonList.add(kaessmann_2_all_gene_disease_pmid_associations_7);


        for (DI1Comparisons di1ComparisonItem : di1ComparisonList) {
            
            if (di1ComparisonItem.Comparison.equals(inputComparison)) {

                if (di1ComparisonItem.MatchingEngine.equals(inputMatchingEngine)) {

                    returnValue = true;
                    
                }
                
            }
            
        }

        return returnValue;

    }

    
}