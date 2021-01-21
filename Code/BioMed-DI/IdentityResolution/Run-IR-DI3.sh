mvn compile

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="1 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_1/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="1 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_1/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="1 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_1/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="1 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_1/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_NoBlocker" -Dexec.args="1 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_1/ML_AdaBoost_NoBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_NoBlocker" -Dexec.args="1 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_1/ML_DecisionTree_NoBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_NoBlocker" -Dexec.args="1 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_1/ML_KNN_NoBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_NoBlocker" -Dexec.args="1 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_1/ML_SimpleLogistic_NoBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="1 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_1/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="1 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_1/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="1 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_1/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="1 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_1/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="2 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_2/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="2 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_2/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="2 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_2/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="2 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_2/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="2 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_2/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="2 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_2/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="2 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_2/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="2 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_2/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="3 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_3/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="3 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_3/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="3 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_3/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="3 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_3/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="3 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_3/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="3 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_3/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="3 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_3/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="3 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_3/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="4 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_4/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="4 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_4/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="4 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_4/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="4 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_4/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="4 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_4/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="4 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_4/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="4 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_4/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="4 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_4/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="5 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_5/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="5 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_5/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="5 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_5/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="5 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_5/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="5 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_5/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="5 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_5/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="5 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_5/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="5 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_5/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="6 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_6/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="6 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_6/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="6 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_6/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="6 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_6/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="6 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_6/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="6 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_6/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="6 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_6/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="6 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_6/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="7 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_7/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="7 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_7/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="7 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_7/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="7 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_7/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="7 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_7/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="7 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_7/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="7 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_7/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="7 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_7/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="8 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_8/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="8 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_8/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="8 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_8/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="8 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_8/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="8 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_8/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="8 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_8/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="8 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_8/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="8 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_8/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="9 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_9/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="9 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_9/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="9 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_9/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="9 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_9/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="9 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_9/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="9 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_9/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="9 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_9/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="9 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_9/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="10 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_10/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="10 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_10/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="10 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_10/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="10 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_10/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="10 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_10/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="10 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_10/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="10 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_10/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="10 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_10/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="11 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_11/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="11 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_11/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="11 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_11/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="11 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_11/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="11 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_11/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="11 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_11/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="11 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_11/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="11 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_11/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="12 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_12/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="12 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_12/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="12 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_12/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="12 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_12/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="12 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_12/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="12 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_12/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="12 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_12/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="12 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_12/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="13 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_13/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="13 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_13/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="13 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_13/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="13 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_13/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="13 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_13/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="13 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_13/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="13 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_13/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="13 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_13/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="14 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_14/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="14 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_14/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="14 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_14/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="14 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_14/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="14 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_14/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="14 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_14/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="14 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_14/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="14 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_14/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="15 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_15/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="15 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_15/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="15 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_15/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="15 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_15/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="15 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_15/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="15 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_15/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="15 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_15/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="15 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_15/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="16 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_16/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="16 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_16/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="16 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_16/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="16 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_16/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="16 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_16/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="16 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_16/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="16 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_16/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="16 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_16/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="17 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_17/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="17 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_17/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="17 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_17/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="17 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_17/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="17 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_17/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="17 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_17/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="17 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_17/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="17 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_17/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="18 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_18/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="18 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_18/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="18 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_18/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="18 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_18/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="18 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_18/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="18 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_18/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="18 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_18/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="18 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_18/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="19 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_19/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="19 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_19/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="19 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_19/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="19 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_19/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="19 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_19/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="19 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_19/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="19 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_19/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="19 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_19/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="20 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_20/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="20 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_20/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="20 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_20/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="20 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_20/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="20 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_20/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="20 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_20/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="20 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_20/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="20 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_20/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="21 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_21/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="21 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_21/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="21 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_21/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="21 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_21/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="21 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_21/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="21 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_21/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="21 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_21/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="21 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_21/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="22 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_22/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="22 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_22/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="22 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_22/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="22 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_22/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="22 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_22/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="22 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_22/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="22 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_22/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="22 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_22/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="23 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_23/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="23 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_23/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="23 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_23/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="23 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_23/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="23 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_23/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="23 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_23/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="23 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_23/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="23 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_23/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="24 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_24/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="24 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_24/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="24 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_24/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="24 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_24/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="24 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_24/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="24 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_24/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="24 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_24/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="24 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_24/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="25 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_25/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="25 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_25/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="25 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_25/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="25 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_25/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="25 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_25/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="25 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_25/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="25 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_25/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="25 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_25/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="26 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_26/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="26 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_26/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="26 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_26/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="26 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_26/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="26 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_26/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="26 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_26/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="26 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_26/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="26 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_26/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="27 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_27/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="27 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_27/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="27 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_27/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="27 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_27/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="27 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_27/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="27 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_27/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="27 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_27/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="27 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_27/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="28 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_28/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="28 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_28/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="28 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_28/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="28 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_28/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="28 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_28/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="28 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_28/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="28 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_28/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="28 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_28/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="29 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_29/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="29 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_29/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="29 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_29/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="29 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_29/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="29 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_29/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="29 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_29/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="29 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_29/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="29 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_29/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="30 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_30/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="30 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_30/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="30 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_30/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="30 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_30/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="30 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_30/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="30 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_30/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="30 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_30/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="30 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_30/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="31 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_31/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="31 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_31/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="31 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_31/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="31 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_31/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="31 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_31/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="31 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_31/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="31 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_31/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="31 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_31/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="32 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_32/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="32 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_32/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="32 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_32/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="32 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_32/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="32 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_32/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="32 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_32/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="32 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_32/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="32 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_32/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="33 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_33/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="33 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_33/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="33 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_33/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="33 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_33/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="33 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_33/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="33 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_33/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="33 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_33/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="33 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_33/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="34 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_34/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="34 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_34/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="34 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_34/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="34 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_34/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="34 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_34/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="34 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_34/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="34 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_34/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="34 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_34/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="35 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_35/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="35 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_35/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="35 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_35/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="35 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_35/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="35 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_35/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="35 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_35/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="35 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_35/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="35 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_35/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="36 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_36/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="36 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_36/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="36 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_36/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="36 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_36/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="36 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_36/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="36 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_36/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="36 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_36/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="36 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_36/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="37 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_37/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="37 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_37/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="37 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_37/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="37 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_37/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="37 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_37/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="37 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_37/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="37 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_37/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="37 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_37/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="38 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_38/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="38 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_38/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="38 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_38/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="38 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_38/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="38 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_38/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="38 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_38/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="38 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_38/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="38 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_38/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="39 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_39/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="39 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_39/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="39 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_39/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="39 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_39/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="39 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_39/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="39 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_39/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="39 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_39/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="39 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_39/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="40 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_40/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="40 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_40/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="40 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_40/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="40 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_40/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="40 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_40/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="40 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_40/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="40 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_40/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="40 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_40/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="41 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_41/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="41 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_41/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="41 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_41/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="41 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_41/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="41 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_41/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="41 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_41/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="41 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_41/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="41 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_41/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="42 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_42/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="42 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_42/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="42 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_42/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="42 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_42/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="42 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_42/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="42 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_42/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="42 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_42/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="42 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_42/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="43 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_43/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="43 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_43/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="43 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_43/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="43 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_43/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="43 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_43/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="43 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_43/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="43 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_43/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="43 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_43/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="44 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_44/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="44 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_44/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="44 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_44/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="44 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_44/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="44 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_44/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="44 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_44/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="44 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_44/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="44 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_44/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="45 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_45/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="45 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_45/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="45 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_45/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="45 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_45/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="45 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_45/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="45 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_45/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="45 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_45/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="45 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_45/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="46 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_46/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="46 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_46/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="46 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_46/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="46 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_46/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="46 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_46/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="46 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_46/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="46 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_46/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="46 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_46/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="47 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_47/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="47 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_47/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="47 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_47/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="47 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_47/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="47 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_47/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="47 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_47/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="47 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_47/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="47 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_47/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="48 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_48/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="48 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_48/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="48 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_48/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="48 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_48/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="48 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_48/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="48 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_48/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="48 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_48/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="48 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_48/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="49 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_49/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="49 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_49/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="49 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_49/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="49 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_49/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="49 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_49/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="49 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_49/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="49 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_49/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="49 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_49/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="50 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_50/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="50 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_50/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="50 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_50/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_StandardRecordBlocker" -Dexec.args="50 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_50/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="50 0"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_50/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="50 1"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_50/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="50 2"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_50/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI3.kaessmann_2_gene2pubtatorcentral.ML_SortedNeighbourhoodBlocker" -Dexec.args="50 3"
cp logs/winter.log data/output/DI3/kaessmann_2_gene2pubtatorcentral_50/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.AWS.UploadToS3"