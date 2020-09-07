mvn compile

# Brain

# genes.IdentityResolution.solutions.Brain.Brain_2_mart_export_brain
# mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Brain.Brain_2_mart_export_brain."
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Brain.Brain_2_mart_export_brain.LR_Jaccard_StandardRecordBlocker"

# genes.IdentityResolution.solutions.Brain.mart_export_brain_2_all_gene_disease_pmid_associations
# mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Brain.mart_export_brain_2_all_gene_disease_pmid_associations."
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Brain.mart_export_brain_2_all_gene_disease_pmid_associations.LR_Jaccard_StandardRecordBlocker"


# Cerebellum

# genes.IdentityResolution.solutions.Cerebellum.Cerebellum_2_mart_export_cerebellum
# mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Cerebellum.Cerebellum_2_mart_export_cerebellum."
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Cerebellum.Cerebellum_2_mart_export_cerebellum.LR_Jaccard_StandardRecordBlocker"

# genes.IdentityResolution.solutions.Cerebellum.mart_export_cerebellum_2_all_gene_disease_pmid_associations
# mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Cerebellum.mart_export_cerebellum_2_all_gene_disease_pmid_associations."
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Cerebellum.mart_export_cerebellum_2_all_gene_disease_pmid_associations.LR_Jaccard_StandardRecordBlocker"


# Heart

# genes.IdentityResolution.solutions.Heart.gene_disease_pmid_associations_2_Heart_Ensembl_NCBI_Crosswalk
# mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Heart.gene_disease_pmid_associations_2_Heart_Ensembl_NCBI_Crosswalk."
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Heart.gene_disease_pmid_associations_2_Heart_Ensembl_NCBI_Crosswalk.LR_Jaccard_StandardRecordBlocker"

# genes.IdentityResolution.solutions.Heart.Heart_2_Heart_Ensembl_NCBI_Crosswalk
# mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Heart.Heart_2_Heart_Ensembl_NCBI_Crosswalk."
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Heart.Heart_2_Heart_Ensembl_NCBI_Crosswalk.LR_Jaccard_StandardRecordBlocker"

# genes.IdentityResolution.solutions.Heart.mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk
# mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Heart.mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk."
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Heart.mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk.LR_Jaccard_StandardRecordBlocker"


# Kidney

# genes.IdentityResolution.solutions.Kidney.Kidney_2_mart_export_kidney
# mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kidney.Kidney_2_mart_export_kidney."
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kidney.Kidney_2_mart_export_kidney.LR_Jaccard_StandardRecordBlocker"

# genes.IdentityResolution.solutions.Kidney.mart_export_kidney_2_all_gene_disease_pmid_associations
# mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kidney.mart_export_kidney_2_all_gene_disease_pmid_associations."
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Kidney.mart_export_kidney_2_all_gene_disease_pmid_associations.LR_Jaccard_StandardRecordBlocker"


# Liver

# genes.IdentityResolution.solutions.Liver.Liver_2_mart_export_liver
# mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Liver.Liver_2_mart_export_liver."
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Liver.Liver_2_mart_export_liver.LR_Jaccard_StandardRecordBlocker"

# genes.IdentityResolution.solutions.Liver.mart_export_liver_2_all_gene_disease_pmid_associations
# mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Liver.mart_export_liver_2_all_gene_disease_pmid_associations."
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Liver.mart_export_liver_2_all_gene_disease_pmid_associations.LR_Jaccard_StandardRecordBlocker"


# Testis

# genes.IdentityResolution.solutions.Testis.mart_export_testis_2_all_gene_disease_pmid_associations
# mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Testis.mart_export_testis_2_all_gene_disease_pmid_associations."
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Testis.mart_export_testis_2_all_gene_disease_pmid_associations.LR_Jaccard_StandardRecordBlocker"

# genes.IdentityResolution.solutions.Testis.Testis_2_mart_export_testis
# mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Testis.Testis_2_mart_export_testis."
mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.Testis.Testis_2_mart_export_testis.LR_Jaccard_StandardRecordBlocker"


cd UploadToAWS
dotnet run