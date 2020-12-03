
mkdir -p data/input
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/parser/output/title.tsv -O data/input/title.tsv
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/parser/output/abstract.tsv -O data/input/abstract.tsv
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/parser/output/claims.tsv -O data/input/claims.tsv
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/parser/output/description.tsv -O data/input/description.tsv
mkdir -p data/output