mvn compile

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmannDiseaseAssociations_2_gene2pubtatorcentral.Run"

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmannDiseaseAssociations_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="29"

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.AWS.UploadToS3"