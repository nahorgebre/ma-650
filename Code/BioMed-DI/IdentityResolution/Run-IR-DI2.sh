mvn compile

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="1 0"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_1/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="1 1"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_1/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="1 2"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_1/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="1 3"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_1/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="1 0"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_1/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="1 1"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_1/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="1 2"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_1/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="1 3"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_1/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="2 0"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_2/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="2 1"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_2/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="2 2"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_2/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="2 3"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_2/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="2 0"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_2/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="2 1"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_2/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="2 2"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_2/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="2 3"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_2/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="3 0"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_3/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="3 1"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_3/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="3 2"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_3/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="3 3"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_3/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="3 0"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_3/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="3 1"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_3/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="3 2"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_3/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="3 3"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_3/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="4 0"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_4/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="4 1"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_4/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="4 2"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_4/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="4 3"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_4/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="4 0"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_4/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="4 1"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_4/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="4 2"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_4/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="4 3"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_4/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="5 0"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_5/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="5 1"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_5/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="5 2"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_5/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="5 3"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_5/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="5 0"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_5/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="5 1"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_5/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="5 2"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_5/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="5 3"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_5/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="6 0"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_6/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="6 1"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_6/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="6 2"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_6/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="6 3"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_6/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="6 0"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_6/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="6 1"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_6/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="6 2"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_6/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="6 3"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_6/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="7 0"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_7/ML_AdaBoost_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="7 1"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_7/ML_DecisionTree_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="7 2"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_7/ML_KNN_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_StandardRecordBlocker" -Dexec.args="7 3"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_7/ML_SimpleLogistic_StandardRecordBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="7 0"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_7/ML_AdaBoost_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="7 1"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_7/ML_DecisionTree_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="7 2"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_7/ML_KNN_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.solutions.DI2.kaessmann_2_all_gene_disease_pmid_associations.ML_SortedNeighbourhoodBlocker" -Dexec.args="7 3"
cp logs/winter.log data/output/DI2/kaessmann_2_all_gene_disease_pmid_associations_7/ML_SimpleLogistic_SortedNeighbourhoodBlocker
rm logs/winter.log

mvn exec:java -Dexec.mainClass="genes.IdentityResolution.AWS.UploadToS3"