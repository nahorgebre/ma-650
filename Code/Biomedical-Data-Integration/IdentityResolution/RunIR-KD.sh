# Run Identity Resolution - Kaessmann Datasets

mvn compile

# Brain
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Brain.Brain_2_mart_export_brain.Run"


# Cerebellum
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Cerebellum.Cerebellum_2_mart_export_cerebellum.Run"

# Heart
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Heart.Heart_2_Heart_Ensembl_NCBI_Crosswalk.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Heart.mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk.Run"

# Kidney
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kidney.Kidney_2_mart_export_kidney.Run"

# Liver
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Liver.Liver_2_mart_export_liver.Run"

# Testis
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Testis.Testis_2_mart_export_testis.Run"

# Organs
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Organs.mart_export_heart_2_mart_export_brain.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Organs.mart_export_heart_2_mart_export_cerebellum.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Organs.mart_export_heart_2_mart_export_kidney.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Organs.mart_export_heart_2_mart_export_liver.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Organs.mart_export_heart_2_mart_export_testis.Run"