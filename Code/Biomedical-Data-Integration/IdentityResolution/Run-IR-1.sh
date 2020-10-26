mvn compile

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kaessmann.Heart_2_Brain.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kaessmann.Heart_2_Cerebellum.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kaessmann.Heart_2_Kidney.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kaessmann.Heart_2_Liver.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kaessmann.Heart_2_Testis.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kaessmann.Heart_2_Heart_Ensembl_NCBI_Crosswalk.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kaessmann.mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk.Run"

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kaessmann.Cerebellum_2_Brain.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kaessmann.Cerebellum_2_Kidney.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kaessmann.Cerebellum_2_Liver.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kaessmann.Cerebellum_2_Testis.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kaessmann.Cerebellum_2_mart_export_cerebellum.Run"

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kaessmann.Brain_2_Kidney.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kaessmann.Brain_2_Liver.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kaessmann.Brain_2_Testis.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kaessmann.Brain_2_mart_export_brain.Run"

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kaessmann.Kidney_2_Liver.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kaessmann.Kidney_2_Testis.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kaessmann.Kidney_2_mart_export_kidney.Run"

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kaessmann.Testis_2_Liver.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kaessmann.Liver_2_mart_export_liver.Run"

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kaessmann.Testis_2_mart_export_testis.Run"

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.AWS.UploadToS3"