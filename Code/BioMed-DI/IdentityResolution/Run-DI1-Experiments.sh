mvn compile

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.experiments.Cosine_StandardRecordBlocker"

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.experiments.Jaccard_StandardRecordBlocker"

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.experiments.Levenshtein_StandardRecordBlocker"

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI1.experiments.SorensenDice_StandardRecordBlocker"

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.AWS.UploadToS3"