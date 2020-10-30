mvn compile

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

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.Brain_2_Kidney.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.Brain_2_Liver.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.Brain_2_Testis.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.Brain_2_mart_export_brain.Run"

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.Kidney_2_Liver.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.Kidney_2_Testis.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.Kidney_2_mart_export_kidney.Run"

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.Testis_2_Liver.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.Liver_2_mart_export_liver.Run"

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.Testis_2_mart_export_testis.Run"

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.AWS.UploadToS3"