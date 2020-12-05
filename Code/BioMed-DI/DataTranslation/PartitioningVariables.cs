namespace DataTranslation
{

    public class gene2pubtatorcentralPartitioningVariables
    {

        // 15 output files - (54.367.006 - 1) / 15 = 54.367.005 / 15 = 3.624.467
        // 35 output files - (54.367.006 - 1) / 35 = 54.367.005 / 35 = 1.553.343
        // 50 output files - (54.367.006 - 1) / 50 = 54.367.005 / 50 = 1.087.340,1
        // 55 output files - (54.367.006 - 1) / 55 = 54.367.005 / 55 = 988.491
        // 100 output files - (54.367.006 - 1) / 100 = 54.367.005 / 100 = 543.670
        // 150 output files - (54.367.006 - 1) / 150 = 54.367.005 / 150 = 362.446,7
        // 200 output files - (54.367.006 - 1) / 200 = 54.367.005 / 200 = 271.835,025
        // 400 output files - (54.367.006 - 1) / 400 = 54.367.005 / 400 = 135.917,5125
        // 800 output files - (54.367.006 - 1) / 800 = 54.367.005 / 800 = 67.958,8

        public static int partitionSize = 1087340;
        
        public static int partitionNumbers = 50;

    }

    public class all_gene_disease_pmid_associationsPartitioningVariables
    {
        
        // 7 output files - (1.548.061) / 7 = 221.151,6

        public static int partitionSize = 221151;

        public static int partitionNumbers = 7;

    }

}