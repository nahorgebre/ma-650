package genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations;

public class Run {

    public static void main( String[] args ) throws Exception
    {

        ML_StandardRecordBlocker.main(args);

        ML_SortedNeighbourhoodBlocker.main(args);
        
    }
    
}