mvn compile

# Brain
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Brain.Brain_2_mart_export_brain.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Brain.mart_export_brain_2_all_gene_disease_pmid_associations.Run"

# Cerebellum
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Cerebellum.Cerebellum_2_mart_export_cerebellum.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Cerebellum.mart_export_cerebellum_2_all_gene_disease_pmid_associations.Run"

# Heart
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Heart.Heart_Ensembl_NCBI_Crosswalk_2_all_gene_disease_pmid_associations.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Heart.Heart_2_Heart_Ensembl_NCBI_Crosswalk.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Heart.mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk.Run"

# Kidney
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kidney.Kidney_2_mart_export_kidney.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kidney.mart_export_kidney_2_all_gene_disease_pmid_associations.Run"

# Liver
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Liver.Liver_2_mart_export_liver.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Liver.mart_export_liver_2_all_gene_disease_pmid_associations.Run"

# Testis
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Testis.mart_export_testis_2_all_gene_disease_pmid_associations.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Testis.Testis_2_mart_export_testis.Run"

# Organs
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Organs.mart_export_heart_2_mart_export_brain.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Organs.mart_export_heart_2_mart_export_cerebellum.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Organs.mart_export_heart_2_mart_export_kidney.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Organs.mart_export_heart_2_mart_export_liver.Run"
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Organs.mart_export_heart_2_mart_export_testis.Run"