# Integrate Disease-Associations Dataset

mkdir -p data/input/DI4
# kaessmann-publication-fused
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-fusion/output/kaessmann-fused.xml -O data/input/DI2/kaessmann-fused.xml
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-translation/input/Gene-Disease-Associations/all_gene_disease_pmid_associations.tsv -O data/input/Gene-Disease-Associations/all_gene_disease_pmid_associations.tsv
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-translation/input/Gene-Disease-Associations/readme.txt -O data/input/Gene-Disease-Associations/readme.txt