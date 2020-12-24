mvn compile

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.experiments.Levenshtein_StandardRecordBlocker" -Dexec.args="0.9"

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.experiments.Jaccard_StandardRecordBlocker" -Dexec.args="0.9" 

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.experiments.Cosine_StandardRecordBlocker" -Dexec.args="0.9" 

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.experiments.SorensenDice_StandardRecordBlocker" -Dexec.args="0.9"

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.AWS.UploadToS3"