namespace DataFusion2
{

    public class DI1MatchingEngine
    {

        public static string checkMatchingEngine(string comparisonName)
        {

            if (comparisonName.Equals("kaessmann_2_all_gene_disease_pmid_associations_1"))
            {

                return MatchingEngines.ML_SimpleLogistic_StandardRecordBlocker;

            }
            else if (comparisonName.Equals("kaessmann_2_all_gene_disease_pmid_associations_2"))
            {

                return MatchingEngines.ML_SimpleLogistic_StandardRecordBlocker;

            }

/*
            mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.Heart_2_Brain.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.Heart_2_Cerebellum.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.Heart_2_Kidney.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.Heart_2_Liver.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.Heart_2_Testis.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.Heart_2_Heart_Ensembl_NCBI_Crosswalk.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk.Run"

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.Cerebellum_2_Brain.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.Cerebellum_2_Kidney.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.Cerebellum_2_Liver.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.Cerebellum_2_Testis.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.Cerebellum_2_mart_export_cerebellum.Run"

Brain_2_Kidney.Run"
Brain_2_Liver.Run"
Brain_2_Testis.Run"
Brain_2_mart_export_brain.Run"

Kidney_2_Liver.Run"
Kidney_2_Testis.Run"
Kidney_2_mart_export_kidney.Run"

Testis_2_Liver.Run"
Liver_2_mart_export_liver.Run"

Testis_2_mart_export_testis.Run"
*/

        }

    }

}