mkdir -p data/input
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/parser/output/PubMedDate.csv -O data/input/PubMedDate.csv

wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-fusion/output/DI1/DI1-fused.xml -O data/input/DI1-fused.xml
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-fusion/output/DI3/DI3-fused.xml -O data/input/DI3-fused.xml

wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-translation/input/Gene-Disease-Associations/all_gene_disease_pmid_associations.tsv -O data/input/all_gene_disease_pmid_associations.tsv
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-translation/input/Gene2Pubtatorcentral/gene2pubtatorcentral.tsv -O data/input/gene2pubtatorcentral.tsv

mkdir -p data/input/patent
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/parser/output/abstract.tsv -O data/input/patent/abstract.tsv
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/parser/output/title.tsv -O data/input/patent/title.tsv
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-translation/input/Patent/scispaCyAbstractGene.csv -O data/input/patent/scispaCyAbstractGene.csv
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-translation/input/Patent/scispaCyTitleGene.csv -O data/input/patent/scispaCyTitleGene.csv
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/parser/input/PatNum/US_Patents_1985_2016_313392.csv -O data/input/patent/US_Patents_1985_2016_313392.csv
