
mkdir -p data/input/goldstandard
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/named-entity-recognition/evaluation/test_entity_title.tsv -O data/input/goldstandard/test_entity_title.tsv
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/named-entity-recognition/evaluation/test_entity_abstract.tsv -O data/input/goldstandard/test_entity_abstract.tsv

mkdir -p data/input/prediction
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/named-entity-recognition/evaluation/output/scispaCyEvaluationTitle.csv -O data/input/prediction/scispaCyEvaluationTitle.csv
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/named-entity-recognition/evaluation/output/scispaCyEvaluationAbstract.csv -O data/input/prediction/scispaCyEvaluationAbstract.csv