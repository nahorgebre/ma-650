mvn compile

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI4.kaessmann_2_patentAbstract.ML_StandardRecordBlocker" -Dexec.args="0"
cp logs/winter.log data/output/DI4/kaessmann_2_patentAbstract/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI4.kaessmann_2_patentAbstract.ML_StandardRecordBlocker" -Dexec.args="1"
cp logs/winter.log data/output/DI4/kaessmann_2_patentAbstract/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI4.kaessmann_2_patentAbstract.ML_StandardRecordBlocker" -Dexec.args="2"
cp logs/winter.log data/output/DI4/kaessmann_2_patentAbstract/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI4.kaessmann_2_patentAbstract.ML_StandardRecordBlocker" -Dexec.args="3"
cp logs/winter.log data/output/DI4/kaessmann_2_patentAbstract/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI4.kaessmann_2_patentAbstract.ML_SortedNeighbourhoodBlocker" -Dexec.args="0"
cp logs/winter.log data/output/DI4/kaessmann_2_patentAbstract/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI4.kaessmann_2_patentAbstract.ML_SortedNeighbourhoodBlocker" -Dexec.args="1"
cp logs/winter.log data/output/DI4/kaessmann_2_patentAbstract/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI4.kaessmann_2_patentAbstract.ML_SortedNeighbourhoodBlocker" -Dexec.args="2"
cp logs/winter.log data/output/DI4/kaessmann_2_patentAbstract/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI4.kaessmann_2_patentAbstract.ML_SortedNeighbourhoodBlocker" -Dexec.args="3"
cp logs/winter.log data/output/DI4/kaessmann_2_gene2pubtatorcentral_1/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.AWS.UploadToS3"