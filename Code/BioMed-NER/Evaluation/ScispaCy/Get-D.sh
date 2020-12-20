
mkdir -p data/input/test
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/named-entity-recognition/evaluation/test_abstract.txt -O data/input/test/test_abstract.txt
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/named-entity-recognition/evaluation/test_entity_abstract.tsv -O data/input/test/test_entity_abstract.tsv
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/named-entity-recognition/evaluation/test_title.txt -O data/input/test/test_title.txt
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/named-entity-recognition/evaluation/test_entity_title.tsv -O data/input/test/test_entity_title.tsv

mkdir -p data/input/train
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/named-entity-recognition/evaluation/train_abstract.txt -O data/input/train/train_abstract.txt
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/named-entity-recognition/evaluation/train_entity_abstract.tsv -O data/input/train/train_entity_abstract.tsv
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/named-entity-recognition/evaluation/train_title.txt -O data/input/train/train_title.txt
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/named-entity-recognition/evaluation/train_entity_title.tsv -O data/input/train/train_entity_title.tsv

mkdir -p data/output