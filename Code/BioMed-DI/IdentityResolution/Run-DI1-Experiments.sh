mvn compile

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.Heart_2_Heart_Ensembl_NCBI_Crosswalk.Cosine_StandardRecordBlocker"

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.Heart_2_Heart_Ensembl_NCBI_Crosswalk.Jaccard_StandardRecordBlocker"

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.Heart_2_Heart_Ensembl_NCBI_Crosswalk.Levenshtein_StandardRecordBlocker"

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.Heart_2_Heart_Ensembl_NCBI_Crosswalk.SorensenDice_StandardRecordBlocker"

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.AWS.UploadToS3"