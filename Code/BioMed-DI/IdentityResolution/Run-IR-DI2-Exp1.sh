mvn compile

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.experiments.Levenshtein_StandardRecordBlocker" -Dexec.args="0.9" 

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.experiments.Jaccard_StandardRecordBlocker" -Dexec.args="0.9"  

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.experiments.Cosine_StandardRecordBlocker" -Dexec.args="0.9"  

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.experiments.SorensenDice_StandardRecordBlocker" -Dexec.args="0.9"  

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.AWS.UploadToS3"